using DddInPractice.UI.Common;

namespace DddInPractice.UI.Utils
{
    public class DialogService
    {
        public bool? ShowDialog(ViewModel viewModel)
        {
            var window = new CustomWindow(viewModel);
            return window.ShowDialog();
        }
    }
}