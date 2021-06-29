using PalindromeProjectBLL;
using System;
using System.IO;

namespace ConsoleApplication
{
    class Program
    {
        public static void Main()
        {
            // Affiche le menu principal, le choix se fait par un switch qui se répete par un while
            // tant que le choix ne se trouve pas dans la liste
            bool result = false;
            bool choiceDone = false;
            InputTest userInput = new InputTest();

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
                switch (choice)
                {
                    case "0":
                        Environment.Exit(0);
                        break;
                    case "1":
                        Console.WriteLine();
                        // Appel de la méthode qui verifie si l'utilisateur entre au moins 2 lettres ou 2 chiffres
                        // et instancie un objet de class ReadConsole 
                        // Appel de la méthode qui vérifie le texte saisi est un palindrome
                        userInput.TestingText();
                        result = PalindromeTest.Verification(userInput.Text);
                        //result = PalindromeTest.Verification(Text.Text);
                        choiceDone = true;
                        break;
                    case "2":
                        // Appel de la méthode qui crée/écrase un fichier et instancie un objet de class ReadConsole                     
                        userInput.FileWriteVisual();
                        //userInput = InputTest.FileWriteVisual();
                        // Appel la méthode qui vérifie si le texte dans un fichier est un palindrome en parametrant                      
                        userInput.Text = PalindromeTest.VerificationFile(userInput.Path);
                        Console.WriteLine($"    Le contenu de fichier {Path.GetFileName(userInput.Path)} est : {userInput.Text}");
                        result = PalindromeTest.Verification(userInput.Text);
                        choiceDone = true;
                        break;
                    case "3":
                        // Appel de la méthode crée un liste des fichiers .txt dans le dossier dédié
                        string[] fileList = FileTest.FileList();
                        // Appel de la méthode qui affiche la liste des fihiers .txt dans le dossier dédié
                        userInput = SubMenu.FileListDisplay(fileList);
                        // Appel de la méthode qui vérifie si le texte dans un fichier est un palindrome
                        userInput.Text = PalindromeTest.VerificationFile(userInput.Path);
                        Console.WriteLine();
                        Console.WriteLine($"    Le contenu de fichier {Path.GetFileName(userInput.Path)} est : {userInput.Text}");
                        result = PalindromeTest.Verification(userInput.Text);
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
            // Appel la méthode qui affichera le résultat si le texte est un palindrome ou pas
            Result(result);
        }



        private static void Result(bool pResult)
        {
            // Affiche le résultat de avec un bool venant de la méthode Palindrome.Verification() ou Palindrome.VerificationFile()
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
            // Appel la méthode qui fait un arrêt jusqu'à ce qu'on l'on appuie sur une touche
            SubMenu.MenuReturn();
        }
    }    
}
