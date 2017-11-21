using System.ComponentModel;
using System.Runtime.CompilerServices;
using DddInPractice.UI.Utils;

namespace DddInPractice.UI.Common
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        protected static readonly DialogService _dialogService = new DialogService();

        private bool? _dialogResult;

        public virtual string Caption => string.Empty;

        public bool? DialogResult
        {
            get => _dialogResult;

            protected set
            {
                _dialogResult = value;
                Notify();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void Notify([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}