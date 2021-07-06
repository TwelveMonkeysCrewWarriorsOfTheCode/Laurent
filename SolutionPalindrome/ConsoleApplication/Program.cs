using System;

namespace ConsoleApplication
{
    class Program
    {
        public static void Main()
        {
            // Affiche le menu principal, le choix se fait par un switch qui se répete par un while
            // tant que le choix ne se trouve pas dans la liste
            bool choiceDone = false;            

            Console.Clear();

            while (!choiceDone)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("  ***************************************************");
                Console.WriteLine("  |                  PALINDROME                     |");
                Console.WriteLine("  |                  **********                     |");
                Console.WriteLine("  |              Faites votre choix                 |");
                Console.WriteLine("  ***************************************************");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("  | 0 : Quitter                                     |");
                Console.WriteLine("  | 1 : Tester en entrant au clavier                |");
                Console.WriteLine("  | 2 : Tester en sauvegardant dans un fichier .txt |");
                Console.WriteLine("  | 3 : Tester en chargeant un fichier .txt         |");
                Console.WriteLine("  ***************************************************");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.Write("    Faites votre choix : ");
                string choice = Console.ReadLine();
                Console.WriteLine();

                MenuOperation ope = new();

                switch (choice)
                {
                    case "0":
                        Environment.Exit(0);
                        break;
                    case "1":                        
                        ope.OperationForTextInputWhithoutSave();
                        choiceDone = true;
                        break;
                    case "2":
                        ope.OperationForTextInputWhithSaveToFile();
                        choiceDone = true;
                        break;
                    case "3":
                        ope.OperationForTextReadOnFile();
                        choiceDone = true;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine();
                        Console.WriteLine("    Votre choix n'est pas valide !");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        break;
                }
            }           
        }       
    }    
}
