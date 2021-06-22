using System;
using System.IO;
using System.Linq;

namespace PalindromeProjectBLL
{
    public class Display
    {
        public static void Menu()
        {
            // Affiche le menu principal, le choix se fait par un switch qui se répete par un while
            // tant que le choix ne se trouve pas dans la liste

            string text = "";
            bool result = false;
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
                Console.Write("\n    Faites votre choix : ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "0":                        
                        Environment.Exit(0);
                        break;
                    case "1":
                        Console.Write("\n    Entrez un mot ou un texte pour savoir si c'est un palindrome : ");
                        text = Console.ReadLine();
                        // Appel de la méthode qui vérifie le texte saisi est un palindrome
                        result = Palindrome.Verification(text);
                        choiceDone = true;
                        break;
                    case "2":
                        // Appel de la méthode qui crée/écrase un fichier 
                        string filePath = FileOperation.FileCreation();
                        // Appel la méthode qui vérifie si le texte dans un fichier est un palindrome
                        result = Palindrome.VerificationFile(filePath);
                        choiceDone = true;
                        break;
                    case "3":
                        // Appel de la méthode crée un liste des fichiers .txt dans le dossier dédié
                        string[] fileList = FileOperation.CreateFileList();
                        // Appel de la méthode qui affiche la liste des fihiers .txt dans le dossier dédié
                        string fileChoice = Display.fileListDisplay(fileList);
                        // Appel de la méthode qui vérifie si le texte dans un fichier est un palindrome
                        result = Palindrome.VerificationFile(fileChoice);
                        choiceDone = true;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("\n    Votre choix n'est pas valide !");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadLine();
                        break;
                }
            }
            // Appel la méthode qui affichera le résultat si le texte est un palindrome ou pas

            Display.Result(result);
        }

        public static void Result(bool result)
        {
            // Affiche le résultat de avec un bool venant de la méthode Palindrome.Verification() ou Palindrome.VerificationFile()
            if (result)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\n    Ceci est un palindrome");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n    Ceci n'est pas un palindrome");
                Console.ForegroundColor = ConsoleColor.White;
            }
            // Appel la méthode qui fait un arrêt jusqu'à ce qu'on l'on appuie sur une touche
            MenuReturn();
        }

        public static string fileListDisplay(string[] fileList)
        {
            bool choiceDone = false;
            string choice = "";

            // Affiche la liste des fichiers textes dans le dossier dédié crée par la méthode CreateFileList()
            // qui renvoi un tableau de string qui contient le chemin complet du fichier . txt
            // Boucle while que le choix n'est pas valide, doit être un chiffre et compris de 0 à la taille du tableau des path 
            // si le choix est 0 revoit au menu principale sinon renvoit le path du fichier choisi

            while (!choiceDone)
            {
                int i = 0;

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

                foreach (string file in fileList)
                {
                    string fileWithoutPath = Path.GetFileName(file);

                    string alignNb = Convert.ToString(i + 1);
                    for (int j = 0; j < 5 - alignNb.Length; j++)
                    {
                        Console.Write(" ");
                    }
                    Console.Write($"{i + 1} : {fileWithoutPath}\n");
                    
                    i++;
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("\n    Faites votre choix : ");
                choice = Console.ReadLine();

                if(choice.All(char.IsDigit) && !String.IsNullOrEmpty(choice))
                {
                    if (int.Parse(choice) >= 0 && int.Parse(choice) < fileList.Length + 1)
                    {
                        choiceDone = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write($"\n    Vous devez entrer un nombre entre 0 et {fileList.Length}");
                        Console.ReadLine();
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write("\n    Vous devenez entrer un nombre");
                    Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            string fileChoice = "";

            if (choice == "0")
            {
                Menu();
            }
            else
            {
                fileChoice = fileList[int.Parse(choice) - 1];
            }
            return fileChoice;
        }

        public static void MenuReturn()
        {
            //Permet un arrêt avant le retour au menu principal

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\n    Appuyez sur enter pour continuer\n");
            Console.ForegroundColor = ConsoleColor.White;
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
            Menu();
        }
    }
}