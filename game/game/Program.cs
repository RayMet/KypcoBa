using System;

namespace BatlleSpace
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (BatlleSpace game = new BatlleSpace())
            {
                game.Run();
          
            }
        }
    }
}


