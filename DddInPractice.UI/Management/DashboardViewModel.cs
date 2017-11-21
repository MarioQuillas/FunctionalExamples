using System.Collections.Generic;
using System.Windows;
using DddInPractice.Logic.Atms;
using DddInPractice.Logic.Management;
using DddInPractice.Logic.SnackMachines;
using DddInPractice.UI.Atms;
using DddInPractice.UI.Common;
using DddInPractice.UI.SnackMachines;

namespace DddInPractice.UI.Management
{
    public class DashboardViewModel : ViewModel
    {
        private readonly AtmRepository _atmRepository;

        private readonly HeadOfficeRepository _headOfficeRepository;

        private readonly SnackMachineRepository _snackMachineRepository;

        public DashboardViewModel()
        {
            HeadOffice = HeadOfficeInstance.Instance;
            _snackMachineRepository = new SnackMachineRepository();
            _atmRepository = new AtmRepository();
            _headOfficeRepository = new HeadOfficeRepository();

            RefreshAll();

            ShowSnackMachineCommand = new Command<SnackMachineDto>(x => x != null, ShowSnackMachine);
            UnloadCashCommand = new Command<SnackMachineDto>(CanUnloadCash, UnloadCash);
            ShowAtmCommand = new Command<AtmDto>(x => x != null, ShowAtm);
            LoadCashToAtmCommand = new Command<AtmDto>(CanLoadCashToAtm, LoadCashToAtm);
        }

        public IReadOnlyList<AtmDto> Atms { get; private set; }

        public HeadOffice HeadOffice { get; }

        public Command<AtmDto> LoadCashToAtmCommand { get; }

        public Command<AtmDto> ShowAtmCommand { get; }

        public Command<SnackMachineDto> ShowSnackMachineCommand { get; }

        public IReadOnlyList<SnackMachineDto> SnackMachines { get; private set; }

        public Command<SnackMachineDto> UnloadCashCommand { get; }

        private bool CanLoadCashToAtm(AtmDto atmDto)
        {
            return atmDto != null && HeadOffice.Cash.Amount > 0;
        }

        private bool CanUnloadCash(SnackMachineDto snackMachineDto)
        {
            return snackMachineDto != null && snackMachineDto.MoneyInside > 0;
        }

        private void LoadCashToAtm(AtmDto atmDto)
        {
            var atm = _atmRepository.GetById(atmDto.Id);

            if (atm == null) return;

            HeadOffice.LoadCashToAtm(atm);
            _atmRepository.Save(atm);
            _headOfficeRepository.Save(HeadOffice);

            RefreshAll();
        }

        private void RefreshAll()
        {
            SnackMachines = _snackMachineRepository.GetSnackMachineList();
            Atms = _atmRepository.GetAtmList();

            Notify(nameof(Atms));
            Notify(nameof(SnackMachines));
            Notify(nameof(HeadOffice));
        }

        private void ShowAtm(AtmDto atmDto)
        {
            var atm = _atmRepository.GetById(atmDto.Id);

            if (atm == null) return;

            _dialogService.ShowDialog(new AtmViewModel(atm));
            RefreshAll();
        }

        private void ShowSnackMachine(SnackMachineDto snackMachineDto)
        {
            var snackMachine = _snackMachineRepository.GetById(snackMachineDto.Id);

            if (snackMachine == null)
            {
                MessageBox.Show("Snack machine was not found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _dialogService.ShowDialog(new SnackMachineViewModel(snackMachine));
            RefreshAll();
        }

        private void UnloadCash(SnackMachineDto snackMachineDto)
        {
            var snackMachine = _snackMachineRepository.GetById(snackMachineDto.Id);

            if (snackMachine == null) return;

            HeadOffice.UnloadCashFromSnackMachine(snackMachine);
            _snackMachineRepository.Save(snackMachine);
            _headOfficeRepository.Save(HeadOffice);

            RefreshAll();
        }
    }
}