namespace DddInPractice.UI.Common
{
    public partial class CustomWindow
    {
        public CustomWindow(ViewModel viewModel)
        {
            this.InitializeComponent();

            // Owner = Application.Current.MainWindow;
            this.DataContext = viewModel;
        }
    }
}