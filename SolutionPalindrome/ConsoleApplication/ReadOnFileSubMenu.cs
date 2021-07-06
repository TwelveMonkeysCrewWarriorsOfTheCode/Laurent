using PalindromeDTO;
using System;
using System.IO;
using System.Linq;

namespace ConsoleApplication
{   
    class ReadOnFileSubMenu
    {
        /// <summary>
        /// Sous menu qui affiche la liste des fichers enregistrés et permet de choisir un fichier
        /// </summary>
        /// <param name="file">Objet FileDTO contenant string Path, string Name, string Text,
        /// string[] ListFile, bool Result</param>
        /// <returns>Objet FileDTO</returns>
        public static FileDTO FileListDisplay(FileDTO file)
        {
            bool choiceDone = false;
            string choice = string.Empty;

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

                AlignItemsList(file);
               
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                Console.Write("    Faites votre choix : ");
                choice = Console.ReadLine();

                if (choice.All(char.IsDigit) && !String.IsNullOrEmpty(choice))
                {
                    if (int.Parse(choice) >= 0 && int.Parse(choice) < file.ListFile.Length + 1)
                    {
                        choiceDone = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine();
                        Console.Write($"    Vous devez entrer un nombre entre 0 et {file.ListFile.Length}");
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
                file.Path = file.ListFile[int.Parse(choice) - 1];
            }
            return file;
        }
        /// <summary>
        /// Aligne et affiche la liste des fichier .txt sans le path 
        /// </summary>
        /// <param name="file">Objet FileDTO contenant string Path, string Name, string Text,
        /// string[] ListFile, bool Result</param>
        public static void AlignItemsList(FileDTO file)
        {
            int i = 0;

            foreach (string fileName in file.ListFile)
            {
                string fileWithoutPath = Path.GetFileName(fileName);
                string alignNb = Convert.ToString(i + 1);

                for (int j = 0; j < 5 - alignNb.Length; j++)
                {
                    Console.Write(" ");
                }
                Console.Write($"{i + 1} : {fileWithoutPath}");
                Console.WriteLine();

                i++;
            }
        }
    }
}
