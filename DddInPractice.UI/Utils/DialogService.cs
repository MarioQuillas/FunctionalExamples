namespace DddInPractice.UI.Utils
{
    using DddInPractice.UI.Common;

    public class DialogService
    {
        public bool? ShowDialog(ViewModel viewModel)
        {
            CustomWindow window = new CustomWindow(viewModel);
            return window.ShowDialog();
        }
    }
}