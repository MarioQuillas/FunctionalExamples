namespace DddInPractice.UI.Common
{
    using DddInPractice.UI.Management;

    public class MainViewModel : ViewModel
    {
        public MainViewModel()
        {
            this.Dashboard = new DashboardViewModel();
        }

        public DashboardViewModel Dashboard { get; private set; }
    }
}