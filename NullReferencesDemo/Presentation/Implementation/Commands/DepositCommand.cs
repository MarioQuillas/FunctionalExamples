using System;
using NullReferencesDemo.Presentation.Implementation.CommandResults;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Implementation.Commands
{
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
            var amount = decimal.Parse(Console.ReadLine());

            appServices.Deposit(amount);

            return new DepositResult(appServices.LoggedInUsername, amount, appServices.LoggedInUserBalance);
        }
    }
}