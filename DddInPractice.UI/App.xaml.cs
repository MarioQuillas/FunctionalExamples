namespace DddInPractice.UI
{
    using DddInPractice.Logic.Utils;

    public partial class App
    {
        public App()
        {
            Initer.Init(@"Server=.;Database=DddInPractice;Trusted_Connection=true");
        }
    }
}