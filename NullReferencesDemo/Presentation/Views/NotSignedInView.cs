namespace NullReferencesDemo.Presentation.Views
{
    using System;

    using NullReferencesDemo.Presentation.Interfaces;

    public class NotSignedInView : IView
    {
        public void Render()
        {
            Console.WriteLine("No user is signed in.");
        }
    }
}