namespace DddInPractice.UI.Common
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using DddInPractice.UI.Utils;

    public abstract class ViewModel : INotifyPropertyChanged
    {
        protected static readonly DialogService _dialogService = new DialogService();

        private bool? _dialogResult;

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual string Caption => string.Empty;

        public bool? DialogResult
        {
            get
            {
                return this._dialogResult;
            }

            protected set
            {
                this._dialogResult = value;
                this.Notify();
            }
        }

        protected void Notify([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}