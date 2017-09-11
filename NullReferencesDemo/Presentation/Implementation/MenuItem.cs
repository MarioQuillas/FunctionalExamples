namespace NullReferencesDemo.Presentation.Implementation
{
    using System;

    using NullReferencesDemo.Presentation.Implementation.Commands;
    using NullReferencesDemo.Presentation.Interfaces;

    internal class MenuItem
    {
        private readonly string caption;

        private readonly char hotkey;

        private readonly Func<bool> isVisible;

        private MenuItem(string caption, char hotkey, bool isTerminal, ICommand command, Func<bool> isVisible)
        {
            this.caption = caption;
            this.hotkey = hotkey;
            this.IsTerminalCommand = isTerminal;
            this.Command = command;
            this.isVisible = isVisible;
        }

        public ICommand Command { get; }

        public bool IsTerminalCommand { get; }

        public static MenuItem CreateNonTerminal(string caption, char hotkey, ICommand command, Func<bool> isVisible)
        {
            return new MenuItem(caption, hotkey, false, command, isVisible);
        }

        public static MenuItem CreateTerminal(string caption, char hotkey)
        {
            return new MenuItem(caption, hotkey, true, new DoNothingCommand(), () => true);
        }

        public void Display()
        {
            if (!this.isVisible()) return;

            int pos = this.caption.IndexOf(this.hotkey);

            if (pos > 0) Console.Write(this.caption.Substring(0, pos));

            ConsoleColor previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(this.hotkey);
            Console.ForegroundColor = previousColor;

            if (pos < this.caption.Length - 1) Console.Write(this.caption.Substring(pos + 1));

            Console.WriteLine();
        }

        public bool MatchesKey(char key)
        {
            return this.isVisible() && char.ToLower(this.hotkey) == char.ToLower(key);
        }
    }
}