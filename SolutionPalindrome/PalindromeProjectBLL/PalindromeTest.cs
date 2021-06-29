using System;
using System.IO;

namespace PalindromeProjectBLL
{
    public class PalindromeTest
    {
        public static bool Verification(string pText)
        {
            // Compare les caractères de la string revoyé par la méthode RemoveAllIsNotLetter()
            // par un boucle for caractère[indice] comparé à caractère[(taille de la string -1) - indice] 
            // tant que l'indice est plus petit que la moitié de la taille de la string
            // Si les 2 caractères sont égaux le bool devient true sinon devient false 
            // Renvoi un bool

            bool isPalindrome = true;           
            string textRebuild = HelperText.RemoveAllIsNotLetterOrNumber(pText);

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

        public static string VerificationFile(string pfilePath)
        {
            // Met dans une string le contenu du fichier par le méthode ReadAllText()
            string fileContent = FileOperation.ReadTextFile(pfilePath);
            return fileContent;
        }        
    }
} 