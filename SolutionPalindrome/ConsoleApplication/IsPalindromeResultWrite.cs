using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class IsPalindromeResultWrite
    {       
        /// <summary>
        /// Affiche le resultat si c'est un palindrome grace au bool en paramètre
        /// </summary>
        /// <param name="pResult">bool</param>
        public static void Result(bool pResult)
        {
            if (pResult)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine();
                Console.WriteLine("    Ceci est un palindrome");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine();
                Console.WriteLine("    Ceci n'est pas un palindrome");
                Console.ForegroundColor = ConsoleColor.White;
            }
            MenuOperation.MenuReturn();
        }
    }
}
