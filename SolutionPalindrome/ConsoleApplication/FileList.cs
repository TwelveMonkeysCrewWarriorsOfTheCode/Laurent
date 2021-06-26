using System;
using System.IO;

namespace ConsoleApplication
{
    class FileList
    {
        public static string[] AlignItemsList(string[] pFileList)
        {
            int i = 0;
            
            // Aligne la liste des fichier .txt
            foreach (string file in pFileList)
            {
                string fileWithoutPath = Path.GetFileName(file);
                string alignNb = Convert.ToString(i + 1);

                for (int j = 0; j < 5 - alignNb.Length; j++)
                {
                    Console.Write(" ");
                }
                Console.Write($"{i + 1} : {fileWithoutPath}");
                Console.WriteLine();

                i++;
            }
            return pFileList;
        }
    }
}
