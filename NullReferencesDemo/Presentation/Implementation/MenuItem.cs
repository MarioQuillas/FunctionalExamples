using System;
using NullReferencesDemo.Presentation.Implementation.Commands;
using NullReferencesDemo.Presentation.Interfaces;

namespace NullReferencesDemo.Presentation.Implementation
{
    internal class MenuItem
    {
        private readonly string caption;

        private readonly char hotkey;

        private readonly Func<bool> isVisible;

        private MenuItem(string caption, char hotkey, bool isTerminal, ICommand command, Func<bool> isVisible)
        {
            this.caption = caption;
            this.hotkey = hotkey;
            IsTerminalCommand = isTerminal;
            Command = command;
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
            if (!isVisible()) return;

            var pos = caption.IndexOf(hotkey);

            if (pos > 0) Console.Write(caption.Substring(0, pos));

            var previousColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(hotkey);
            Console.ForegroundColor = previousColor;

            if (pos < caption.Length - 1) Console.Write(caption.Substring(pos + 1));

            Console.WriteLine();
        }

        public bool MatchesKey(char key)
        {
            return isVisible() && char.ToLower(hotkey) == char.ToLower(key);
        }
    }
}