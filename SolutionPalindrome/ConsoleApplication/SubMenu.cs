using System;
using System.Linq;

namespace ConsoleApplication
{   
    class SubMenu
    {
        public static InputTest FileListDisplay(string[] pFileList)
        {
            bool choiceDone = false;
            string choice = string.Empty;
            InputTest UserChoice = new InputTest();

            // Affiche la liste des fichiers textes dans le dossier dédié crée par la méthode CreateFileList()
            // qui renvoi un tableau de string qui contient le chemin complet du fichier . txt
            // Boucle while que le choix n'est pas valide, doit être un chiffre et compris de 0 à la taille du tableau des path 
            // si le choix est 0 revoit au menu principale sinon renvoit le path du fichier choisi

            while (!choiceDone)
            {
                Console.Clear();

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("  ***************************************************");
                Console.WriteLine("  |                  PALINDROME                     |");
                Console.WriteLine("  |                  **********                     |");
                Console.WriteLine("  |              Faites votre choix                 |");
                Console.WriteLine("  ***************************************************");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("    0 : Retour menu");


                string[] ListItemAlign = FileList.AlignItemsList(pFileList);
               
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.Write("    Faites votre choix : ");
                choice = Console.ReadLine();

                if (choice.All(char.IsDigit) && !String.IsNullOrEmpty(choice))
                {
                    if (int.Parse(choice) >= 0 && int.Parse(choice) < pFileList.Length + 1)
                    {
                        choiceDone = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine();
                        Console.Write($"    Vous devez entrer un nombre entre 0 et {pFileList.Length}");
                        Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine();
                    Console.Write("    Vous devenez entrer un nombre");
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            if (choice == "0")
            {
                Program.Main();
            }
            else
            {
                UserChoice.Path = pFileList[int.Parse(choice) - 1];
            }
            return UserChoice;
        }
        
        
        public static void MenuReturn()
        {
            //Permet un arrêt avant le retour au menu principal
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.Write("    Appuyez sur enter pour continuer");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
            Program.Main();
        }
    }
}
