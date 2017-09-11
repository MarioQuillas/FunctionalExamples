namespace NullReferencesDemo.Presentation.Implementation
{
    using NullReferencesDemo.Common;
    using NullReferencesDemo.Presentation.Interfaces;

    public class ViewLocator : ServiceLocator<ICommandResult, IView>
    {
    }
}