using System;
using NullReferencesDemo.Presentation.Implementation.CommandResults;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Implementation.Commands
{
    internal class PurchaseCommand : ICommand
    {
        private readonly IApplicationServices appServices;

        public PurchaseCommand(IApplicationServices appServices)
        {
            this.appServices = appServices;
        }

        public ICommandResult Execute()
        {
            ShowStock();

            Console.Write("Enter item name: ");
            var itemName = Console.ReadLine();

            var report = appServices.Purchase(itemName);

            return new PurchaseResult(report);
        }

        private void ShowStock()
        {
            Console.WriteLine("Available items:");
            foreach (var item in appServices.GetAvailableItems())
                Console.WriteLine("{0,10} {1:C}", item.Name, item.Price);
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}