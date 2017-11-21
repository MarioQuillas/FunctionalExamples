using System;
using System.Collections.Generic;
using System.Linq;
using NullReferencesDemo.Presentation.Implementation.Commands;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Implementation
{
    public class UserInterface : IUserInterface
    {
        private readonly IApplicationServices appServices;

        private readonly IEnumerable<MenuItem> menu;

        private readonly ViewLocator viewLocator;

        private ICommand currentCommand = new DoNothingCommand();

        public UserInterface(IApplicationServices appServices, ViewLocator viewLocator)
        {
            this.appServices = appServices;

            menu = new[]
            {
                MenuItem.CreateNonTerminal(
                    "Register new user",
                    'R',
                    new RegisterCommand(appServices),
                    () => true),
                MenuItem.CreateNonTerminal("Login", 'L', new LoginCommand(appServices), () => true),
                MenuItem.CreateNonTerminal(
                    "LogOut",
                    'O',
                    new LogoutCommand(appServices),
                    () => appServices.IsUserLoggedIn),
                MenuItem.CreateNonTerminal(
                    "Deposit",
                    'D',
                    new DepositCommand(appServices),
                    () => appServices.IsUserLoggedIn),
                MenuItem.CreateNonTerminal(
                    "Purchase",
                    'P',
                    new PurchaseCommand(appServices),
                    () => true),
                MenuItem.CreateTerminal("Quit", 'Q')
            };

            this.viewLocator = viewLocator;
        }

        private string BalanceDisplay
        {
            get
            {
                if (appServices.IsUserLoggedIn) return appServices.LoggedInUserBalance.ToString("C");
                return "N/A";
            }
        }

        private string LoggedInUserDisplay
        {
            get
            {
                if (appServices.IsUserLoggedIn) return appServices.LoggedInUsername;
                return "none";
            }
        }

        public void ExecuteCommand()
        {
            var result = currentCommand.Execute();

            var view = viewLocator.LocateServiceFor(result);

            Render(view);

            Console.WriteLine();
            Console.Write("Press ENTER to continue...");
            Console.ReadLine();
        }

        public bool ReadCommand()
        {
            RefreshDisplay();

            var selectedMenuItem = SelectMenuItem();

            if (selectedMenuItem.IsTerminalCommand) return false;

            currentCommand = selectedMenuItem.Command;
            return true;
        }

        private void Highlight(string message)
        {
            var prevColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(message);
            Console.ForegroundColor = prevColor;
        }

        private void RefreshDisplay()
        {
            Console.Clear();
            ShowStatus();
            ShowMenu();
        }

        private void Render(IView view)
        {
            var message = $"Rendering {view.GetType().Name}";
            var delimiter = new string('-', message.Length);

            Console.WriteLine("\n{0}\n{1}\n{0}\n", delimiter, message);

            view.Render();

            Console.WriteLine("\n{0}", delimiter);
        }

        private MenuItem SelectMenuItem()
        {
            var key = Console.ReadKey(true);

            var selectedItem = menu.Single(item => item.MatchesKey(key.KeyChar));

            return selectedItem;
        }

        private void ShowMenu()
        {
            Console.WriteLine("Select operation:");
            Console.WriteLine();

            foreach (var menuItem in menu) menuItem.Display();

            Console.WriteLine();
        }

        private void ShowStatus()
        {
            Console.Write("Logged in user: ");
            Highlight(LoggedInUserDisplay);
            Console.WriteLine();

            Console.Write("       Balance: ");
            Highlight(BalanceDisplay);
            Console.WriteLine();

            Console.WriteLine();
        }
    }
}