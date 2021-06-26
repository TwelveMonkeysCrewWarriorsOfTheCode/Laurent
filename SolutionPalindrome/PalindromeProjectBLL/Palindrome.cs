﻿using System;
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
<<<<<<< HEAD
            string textRebuild = HelperText.RemoveAllIsNotLetterOrNumber(pText);

=======

            string textRebuild = HelperText.RemoveAllIsNotLetter(pText);

>>>>>>> 8669b0e5aceff66af4990fd7fbc503cdaec81695
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

        public static bool VerificationFile(string pfilePath)
        {
            // Met dans une string le contenu du fichier par le méthode ReadAllText()
            // Puis appel le méthode Verification() avec cette string et revoit un bool

            string fileContent = File.ReadAllText(pfilePath);
            Console.WriteLine();
            Console.WriteLine($"    Le contenu de fichier {Path.GetFileName(pfilePath)} est : {fileContent}");
            bool isPalindrome = Verification(fileContent);
            
            return isPalindrome;
        }        
    }
} 