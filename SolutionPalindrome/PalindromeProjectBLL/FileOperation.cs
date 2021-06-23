using System;
using System.IO;

namespace PalindromeProjectBLL
{
    public class FileOperation
    {
        public static string FileCreation()
        {
            // Crée ou écrasse un fichier texte avec un nom saisi
            // Boucle while tant que l'on a pas choisi un nom de fichier inexistant,
            // validé l'écrasement du fichier existant ou abandonné
            // Boucle for qui permet de comparer le nom entré à la liste de fichier .txt existant
            // Appel la méthode FileWrite() pour créer ou écrasser le fichier
            // Renvoi le path 

            string filePath = "C:\\Users\\Laurent\\Desktop\\Dev.NET-SquareCode\\C#\\SolutionPalindrome\\UnitTestProject\\";            
            string fileName = "";
            bool fileNameOk = false;
            bool fileExist = false;

            while (!fileNameOk)
            {
                string[] fileList = CreateFileList();

                Console.Write("\n    Entrez le nom du fichier à enregistrer :");
                fileName = Console.ReadLine();

                while (String.IsNullOrEmpty(fileName))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n    Vous n'avez rien ecris !");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\n    Entrez le nom du fichier à enregistrer :");
                    fileName = Console.ReadLine();
                }                

                for (int i = 0; i < fileList.Length; i++)
                {   
                    if (Path.GetFileName(fileList[i]) == fileName + ".txt")
                    {
                        fileExist = true;
                    }
                }

                bool overwrite = false;

                if (!fileExist)
                {
                    overwrite = true;
                    fileNameOk = true;
                }
                
                while (!overwrite)
                {
                    Console.Write($"\n    Le fichier {fileName} existe déjà ! Voulez vous ecraser le fichier ou abandonner ? (Y/N/A)");
                    string responseOverwrite = Console.ReadLine();

                    if (char.ToLower(responseOverwrite[0]) == 'y' || char.ToLower(responseOverwrite[0]) == 'n' || char.ToLower(responseOverwrite[0]) == 'a')
                    {
                        if (char.ToLower(responseOverwrite[0]) == 'y')
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine($"\n    Fichier {fileName} va être écrasé !");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadKey();
                            fileNameOk = true;
                        }
                        else
                        {
                            if (char.ToLower(responseOverwrite[0]) == 'n')
                            {
                                Console.Write("\n    Choisiez un autre nom de fichier");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.Write("\n    Retour vers le menu principal");
                                Display.MenuReturn();
                            }                            
                        }
                        overwrite = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.Write("\n    Votre choix n'est pas valide !");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadKey();
                    }
                }   
            }
           
            filePath += fileName + ".txt";

            FileWrite(filePath);

            return filePath;
        }

        private static void FileWrite(string filePath)
        {
            // Enregistre le texte saisi dans un fichier .txt

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\n    Entrez le texte à sauvegarder :");
            Console.ForegroundColor = ConsoleColor.White;
            string text = Console.ReadLine();

            try
            {
                StreamWriter sw = new StreamWriter(filePath);
                sw.WriteLine(text);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Le fichier n'a pas pu être crée !");
                Console.WriteLine("Exception: " + e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public static string[] CreateFileList()
        {
            // Crée un tableau de string avec tous les fichier .txt dans le dossié dédié et retourne ce tableau

            string[] fileList = Directory.GetFiles(@"..\..\..\..\UnitTestProject\","*.txt");
            return fileList;
        }        
    }
}