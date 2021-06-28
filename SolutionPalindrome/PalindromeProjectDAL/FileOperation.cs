using System;
using System.IO;

namespace PalindromeProjectBLL
{
    public class FileOperation
    {
        public const string FILE_PATH = @"..\..\..\..\Textes\";
        public const string FILE_TYPE = "*.txt";


        public static void FileWrite(string pFilePath, string pText)
        {
            // Crée ou écrasse un fichier texte avec un nom saisi et
            // avec un nom saisi et y écrit le texte rentré par l'utilisateur

            try
            {
                StreamWriter sw = new StreamWriter(pFilePath);
                sw.WriteLine(pText);
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

            string[] fileList = Directory.GetFiles(FILE_PATH, FILE_TYPE);
            return fileList;
        }  
        
        public static string ReadTextFile(string pfilePath)
        {
            string fileText = File.ReadAllText(pfilePath);
            return fileText;
        }
    }
}