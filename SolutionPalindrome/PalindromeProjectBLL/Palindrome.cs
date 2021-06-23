
using System;
using System.IO;

namespace PalindromeProjectBLL
{
    public class Palindrome
    {
        public static bool Verification(string pText)
        {
            // Compare les caractères de la string revoyé par la méthode RemoveAllIsNotLetter()
            // par un boucle for caractère[indice] comparé à caractère[(taille de la string -1) - indice] 
            // tant que l'indice est plus petit que la moitié de la taille de la string
            // Si les 2 caractères sont égaux le bool devient true sinon devient false 
            // Renvoi un bool

            bool isPalindrome = true;           

            string textRebuild = HelperText.RemoveAllIsNotLetter(pText);

            int i = 0;
            while (isPalindrome == true && i < textRebuild.Length / 2)
            {
                if (textRebuild[i] == textRebuild[textRebuild.Length -1 - i])
                {
                    isPalindrome = true;
                }
                else
                {
                    isPalindrome = false; 
                }
                i++;
            }           
            return isPalindrome;
        }

        public static bool VerificationFile(string filePath)
        {
            // Met dans une string le contenu du fichier par le méthode ReadAllText()
            // Puis appel le méthode Verification() avec cette string et revoit un bool

            string fileContent = File.ReadAllText(filePath);
            Console.WriteLine($"\n    Le contenu de fichier {Path.GetFileName(filePath)} est : {fileContent}");
            bool isPalindrome = Verification(fileContent);
            
            return isPalindrome;
        }        
    }
} 