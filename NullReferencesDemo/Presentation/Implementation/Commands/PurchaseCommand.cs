namespace NullReferencesDemo.Presentation.Implementation.Commands
{
    using System;

    using NullReferencesDemo.Presentation.Implementation.CommandResults;
    using NullReferencesDemo.Presentation.Interfaces;

    internal class PurchaseCommand : ICommand
    {
        private readonly IApplicationServices appServices;

        public PurchaseCommand(IApplicationServices appServices)
        {
            this.appServices = appServices;
        }

        public ICommandResult Execute()
        {
            this.ShowStock();

            Console.Write("Enter item name: ");
            string itemName = Console.ReadLine();

            IPurchaseReport report = this.appServices.Purchase(itemName);

            return new PurchaseResult(report);
        }

        private void ShowStock()
        {
            Console.WriteLine("Available items:");
            foreach (StockItem item in this.appServices.GetAvailableItems())
                Console.WriteLine("{0,10} {1:C}", item.Name, item.Price);
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}