namespace DddInPractice.UI.Management
{
    using System.Collections.Generic;
    using System.Windows;

    using DddInPractice.Logic.Atms;
    using DddInPractice.Logic.Management;
    using DddInPractice.Logic.SnackMachines;
    using DddInPractice.UI.Atms;
    using DddInPractice.UI.Common;
    using DddInPractice.UI.SnackMachines;

    public class DashboardViewModel : ViewModel
    {
        private readonly AtmRepository _atmRepository;

        private readonly HeadOfficeRepository _headOfficeRepository;

        private readonly SnackMachineRepository _snackMachineRepository;

        public DashboardViewModel()
        {
            this.HeadOffice = HeadOfficeInstance.Instance;
            this._snackMachineRepository = new SnackMachineRepository();
            this._atmRepository = new AtmRepository();
            this._headOfficeRepository = new HeadOfficeRepository();

            this.RefreshAll();

            this.ShowSnackMachineCommand = new Command<SnackMachineDto>(x => x != null, this.ShowSnackMachine);
            this.UnloadCashCommand = new Command<SnackMachineDto>(this.CanUnloadCash, this.UnloadCash);
            this.ShowAtmCommand = new Command<AtmDto>(x => x != null, this.ShowAtm);
            this.LoadCashToAtmCommand = new Command<AtmDto>(this.CanLoadCashToAtm, this.LoadCashToAtm);
        }

        public IReadOnlyList<AtmDto> Atms { get; private set; }

        public HeadOffice HeadOffice { get; }

        public Command<AtmDto> LoadCashToAtmCommand { get; private set; }

        public Command<AtmDto> ShowAtmCommand { get; private set; }

        public Command<SnackMachineDto> ShowSnackMachineCommand { get; private set; }

        public IReadOnlyList<SnackMachineDto> SnackMachines { get; private set; }

        public Command<SnackMachineDto> UnloadCashCommand { get; private set; }

        private bool CanLoadCashToAtm(AtmDto atmDto)
        {
            return atmDto != null && this.HeadOffice.Cash.Amount > 0;
        }

        private bool CanUnloadCash(SnackMachineDto snackMachineDto)
        {
            return snackMachineDto != null && snackMachineDto.MoneyInside > 0;
        }

        private void LoadCashToAtm(AtmDto atmDto)
        {
            Atm atm = this._atmRepository.GetById(atmDto.Id);

            if (atm == null) return;

            this.HeadOffice.LoadCashToAtm(atm);
            this._atmRepository.Save(atm);
            this._headOfficeRepository.Save(this.HeadOffice);

            this.RefreshAll();
        }

        private void RefreshAll()
        {
            this.SnackMachines = this._snackMachineRepository.GetSnackMachineList();
            this.Atms = this._atmRepository.GetAtmList();

            this.Notify(nameof(this.Atms));
            this.Notify(nameof(this.SnackMachines));
            this.Notify(nameof(this.HeadOffice));
        }

        private void ShowAtm(AtmDto atmDto)
        {
            Atm atm = this._atmRepository.GetById(atmDto.Id);

            if (atm == null) return;

            _dialogService.ShowDialog(new AtmViewModel(atm));
            this.RefreshAll();
        }

        private void ShowSnackMachine(SnackMachineDto snackMachineDto)
        {
            SnackMachine snackMachine = this._snackMachineRepository.GetById(snackMachineDto.Id);

            if (snackMachine == null)
            {
                MessageBox.Show("Snack machine was not found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _dialogService.ShowDialog(new SnackMachineViewModel(snackMachine));
            this.RefreshAll();
        }

        private void UnloadCash(SnackMachineDto snackMachineDto)
        {
            SnackMachine snackMachine = this._snackMachineRepository.GetById(snackMachineDto.Id);

            if (snackMachine == null) return;

            this.HeadOffice.UnloadCashFromSnackMachine(snackMachine);
            this._snackMachineRepository.Save(snackMachine);
            this._headOfficeRepository.Save(this.HeadOffice);

            this.RefreshAll();
        }
    }
}