using System;
using MonocleDemoNamespace.Logic;
using Monocle;

namespace MonocleDemoNamespace
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new MonoDemo())
            {
                game.Run();
            }
        }
    }
}
