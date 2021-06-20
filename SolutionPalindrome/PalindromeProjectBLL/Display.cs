using System;
using System.IO;
using System.Linq;

namespace PalindromeProjectBLL
{
    public class Display
    {
        public static void Menu()
        {
            string text = "";
            bool result = false;
            bool choiceDone = false;

            Console.Clear();

            while (!choiceDone)
            {
                Console.Clear();
                Console.WriteLine("  ***************************************************");
                Console.WriteLine("  |              Faites votre choix                 |");
                Console.WriteLine("  ***************************************************");
                Console.WriteLine("  | 0 : Quitter                                     |");
                Console.WriteLine("  | 1 : Tester en entrant au clavier                |");
                Console.WriteLine("  | 2 : Tester en sauvegardant dans un fichier .txt |");
                Console.WriteLine("  | 3 : Tester en chargeant un fichier .txt         |");
                Console.WriteLine("  ***************************************************");

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
                        result = Palindrome.Verification(text);
                        choiceDone = true;
                        break;
                    case "2":
                        string filePath = FileOperation.FileWrite();
                        result = Palindrome.VerificationFile(filePath);
                        choiceDone = true;
                        break;
                    case "3":
                        string[] fileList = FileOperation.CreateFileList();
                        string fileChoice = Display.fileListDisplay(fileList);
                        result = Palindrome.VerificationFile(fileChoice);
                        choiceDone = true;
                        break;

                    default:
                        Console.WriteLine("\n    Votre choix n'est pas valide !");
                        Console.ReadLine();
                        break;
                }
            }
            Display.Result(result);
        }

        public static void Result(bool result)
        {
            if (result)
            {
                Console.WriteLine("\n    Ceci est un palindrome");
            }
            else
            {
                Console.WriteLine("\n    Ceci n'est pas un palindrome");
            }
            MenuReturn();
        }

        public static string fileListDisplay(string[] fileList)
        {
            bool choiceDone = false;
            string choice = "";

            while (!choiceDone)
            {
                int i = 0;

                Console.Clear();

                Console.WriteLine("  ***************************************************");
                Console.WriteLine("  |              Faites votre choix                 |");
                Console.WriteLine("  ***************************************************");
                Console.WriteLine("    0 : Retour menu");

                foreach (string file in fileList)
                {
                    string fileWithoutPath = Path.GetFileName(file);
                    Console.WriteLine($"    {i + 1} : {fileWithoutPath}");
                    i++;
                }

                Console.Write("\n    Faites votre choix : ");
                choice = Console.ReadLine();

                if(choice.All(char.IsDigit))
                {
                    if (int.Parse(choice) >= 0 && int.Parse(choice) < fileList.Length + 1)
                    {
                        choiceDone = true;
                    }
                    else
                    {
                        Console.Write($"\n    Vous devez entrer un nombre entre 0 et {fileList.Length}");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.Write("\n    Vous devenez entrer un nombre");
                    Console.ReadLine();
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

        private static void MenuReturn()
        {
            Console.Write("\n    Appuyez sur enter pour continuer\n");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
            Menu();
        }
    }
}