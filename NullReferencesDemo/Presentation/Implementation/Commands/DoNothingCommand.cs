namespace NullReferencesDemo.Presentation.Implementation.Commands
{
    using NullReferencesDemo.Presentation.Implementation.CommandResults;
    using NullReferencesDemo.Presentation.Interfaces;

    internal class DoNothingCommand : ICommand
    {
        public ICommandResult Execute() => new NoResult();
    }
}