using PalindromeDTO;
using PalindromeProjectDAL;
using System.IO;

namespace PalindromeProjectBLL
{
    public class FileTest
    {
        /// <summary>
        /// Appel la fonction FileWrite() qui crée/écrase le fichier txt
        /// avec le nom entré par l'utilisateur
        /// </summary>
        /// <param name="file">Objet FileDTO</param>
        public static void FileCreation(FileDTO file)
        {
            FileOperation.FileWrite(file);
        }

        /// <summary>
        /// Crée une liste des fichiers txt par le méthode CreateFileList()
        /// dans un tableau de string puis compare avec le nom entré par l'utilisateur
        /// </summary>
        /// <param name="pFileName">String nom du fichier txt</param>
        /// <returns>bool=true si le nom existe déjà</returns>
        public static bool CheckFileNameExist(string pFileName)
        {
            bool fileExist = false;

            string[] fileList = FileOperation.CreateFileList();

            for (int i = 0; i < fileList.Length; i++)
            {
                if (Path.GetFileName(fileList[i]) == pFileName + ".txt")
                {
                    fileExist = true;
                }
            }
            return fileExist;
        }

        /// <summary>
        /// Appel la méthode qui crée la liste des fichiers existants
        /// récupéré dans un tableau et retourne ce tableau
        /// </summary>
        /// <param name="file">Objet FileDTO</param>
        /// <returns>Objet FileDTO</returns>
        public static FileDTO FileList(FileDTO file)
        {
            file.ListFile = FileOperation.CreateFileList();
            return file;
        }
    }
}
