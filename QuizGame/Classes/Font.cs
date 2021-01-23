using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace QuizGame.Classes
{
    class Font
    {
        public void FontGameOver()
        {
            string title = @"
                 _____                  _____             
                |   __|___ _____ ___   |     |_ _ ___ ___ 
                |  |  | .'|     | -_|  |  |  | | | -_|  _|
                |_____|__,|_|_|_|___|  |_____|\_/|___|_|                              
                                                                 ";

            Console.WriteLine(title);
            Console.WriteLine("\n\tPress any key to Exit\n");
            Console.ReadKey();
            Environment.Exit(0);
        }

        public void BonusRound()
        {
            string title = @"
             
                               
                 _____ _____ _____ _____ _____ 
                | __  |     |   | |  |  |   __|
                | __ -|  |  | | | |  |  |__   |
                |_____|_____|_|___|_____|_____|                             
                                                                 ";

            Console.WriteLine(title);
        }
    }
}
