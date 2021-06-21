using System;
using System.IO;

namespace PalindromeProjectBLL
{
    public class FileOperation
    {
        public static string FileCreation()
        {
            string filePath = "C:\\Users\\Laurent\\Desktop\\Dev.NET-SquareCode\\C#\\SolutionPalindrome\\UnitTestProject\\";            
            string fileName = "";
            bool fileNameOk = false;
            bool fileExist = false;

            while (!fileNameOk)
            {
                string[] fileList = CreateFileList();
                
                Console.Write("\n    Etrez le nom du fichier à enregistrer :");
                fileName = Console.ReadLine();

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
                    Console.Write($"\n    Le fichier {fileName} existe déjà ! Voulez vous ecraser le fichier ? (Y/N)");
                    string responseOverwrite = Console.ReadLine();

                    if (responseOverwrite == "y" || responseOverwrite == "n")
                    {
                        if (responseOverwrite == "y")
                        {
                            Console.WriteLine($"\n    Fichier {fileName} à été écrasé !");
                            Console.ReadKey();
                            fileNameOk = true;
                        }
                        else
                        {
                            Console.Write("\n    Choisiez un autre nom de fichier");
                            Console.ReadKey();
                        }
                        overwrite = true;
                    }
                    else
                    {
                        Console.Write("\n    Votre choix n'est pas valide !");
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
            Console.Write("\n    Entrez le texte à sauvegarder :");
            string text = Console.ReadLine();

            try
            {
                StreamWriter sw = new StreamWriter(filePath);
                sw.WriteLine(text);
                sw.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine("Exception: " + e.Message);
            }
        }

        public static string[] CreateFileList()
        {
            string[] fileList = Directory.GetFiles(@"C:\Users\Laurent\Desktop\Dev.NET-SquareCode\C#\SolutionPalindrome\UnitTestProject\","*.txt");
            return fileList;
        }        
    }
}