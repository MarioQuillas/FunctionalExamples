namespace NullReferencesDemo.Presentation.Implementation.Commands
{
    using System;

    using NullReferencesDemo.Presentation.Implementation.CommandResults;
    using NullReferencesDemo.Presentation.Interfaces;

    public class DepositCommand : ICommand
    {
        private readonly IApplicationServices appServices;

        public DepositCommand(IApplicationServices appServices)
        {
            this.appServices = appServices;
        }

        public ICommandResult Execute()
        {
            Console.Write("Enter amount to deposit: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            this.appServices.Deposit(amount);

            return new DepositResult(this.appServices.LoggedInUsername, amount, this.appServices.LoggedInUserBalance);
        }
    }
}