using PalindromeDTO;
using System;
using System.IO;

namespace PalindromeProjectDAL
{
    public class FileOperation
    {
        private const string FILE_PATH = @"..\..\..\..\Textes\";
        private const string FILE_TYPE = "*.txt";

        /// <summary>
        /// Crée ou écrasse un fichier texte avec un nom saisi et
        /// avec un nom saisi et y écrit le texte rentré par l'utilisateur
        /// </summary>
        /// <param name="file">Objet FileDTO</param>
        public static void FileWrite(FileDTO file)
        {
            using StreamWriter sw = new(file.Path);
            sw.WriteLine(file.Text);            
        }

        /// <summary>
        ///  Crée un tableau de string avec tous les fichier .txt dans le dossié dédié et retourne ce tableau
        /// </summary>
        /// <returns>string[] liste des fichiers txr</returns>
        public static string[] CreateFileList()
        {
            string[] fileList = Directory.GetFiles(FILE_PATH, FILE_TYPE);
            return fileList;
        }

        /// <summary>
        /// Lit le contenu du fichier txt
        /// </summary>
        /// <param name="pfilePath">string path du fichier txt</param>
        /// <returns>string avec le contenu du fichier txt</returns>
        public static string ReadTextFile(string pfilePath)
        {
            string fileText = File.ReadAllText(pfilePath);
            return fileText;
        }
    }
}
