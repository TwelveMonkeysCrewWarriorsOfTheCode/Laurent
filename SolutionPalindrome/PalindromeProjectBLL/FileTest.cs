using System.IO;


namespace PalindromeProjectBLL
{
    public class FileTest
    {
        public string[] List;

        public static void FileCreation(string pFilePath, string pText)
        {
            // Appel la méthode qui crée ou écrasse un fichier texte avec un nom saisi et
            // avec un nom saisi et y écrit le texte rentré par l'utilisateur
            FileOperation.FileWrite(pFilePath, pText);
        }

        public static bool CheckFileNameExist(string pFileName)
        {
            bool fileExist = false;

            // Appel la méthode qui crée la liste es fichiers existants
            // récupérée dans un tableau
            string[] fileList = FileOperation.CreateFileList();

            // For qui qui compare les éléments du tableau avec le nom entré
            // par l'utilisateur et retourne un bool
            for (int i = 0; i < fileList.Length; i++)
            {
                if (Path.GetFileName(fileList[i]) == pFileName + ".txt")
                {
                    fileExist = true;
                }
            }
            return fileExist;
        }

        public static string[] FileList()
        {
            FileTest createdList = new FileTest();

            // Appel la méthode qui crée la liste des fichiers existants
            // récupéré dans un tableau et retourne ce tableau
            createdList.List = FileOperation.CreateFileList();

            return createdList.List;
        }       
    }
}
