namespace DddInPractice.UI.Common
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            this.InitializeComponent();

            this.DataContext = new MainViewModel();
        }
    }
}