using System;
using System.IO;
using PalindromeProjectDAL;

namespace PalindromeProjectBLL
{
    public class PalindromeTest
    {
        /// <summary>
        /// Compare les caractères de la string revoyé par la méthode RemoveAllIsNotLetter()
        /// par un boucle for caractère[indice] comparé à caractère[(taille de la string - 1) -indice]
        /// tant que l'indice est plus petit que la moitié de la taille de la string
        /// Si les 2 caractères sont égaux le bool devient true sinon devient false 
        /// </summary>
        /// <param name="pText">string texte</param>
        /// <returns>bool=true c'est un palindrome</returns>
        public static bool Verification(string pText)
        {            
            bool isPalindrome = true;           
            string textRebuild = HelperText.RemoveAllIsNotLetterOrNumber(pText);

            int i = 0;

            while (isPalindrome && i < textRebuild.Length / 2)
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

        /// <summary>
        /// Appel la méthode ReadTextFile() qui lit le fichier texte
        /// </summary>
        /// <param name="pfilePath">string path du fichier</param>
        /// <returns>string contenu du fichier txt</returns>
        public static string VerificationFile(string pfilePath)
        {
            string fileContent = FileOperation.ReadTextFile(pfilePath);
            return fileContent;
        }        
    }
} 