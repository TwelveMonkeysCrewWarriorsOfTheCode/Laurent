
using System;
using System.IO;

namespace PalindromeProjectBLL
{
    public class Palindrome
    {
        public static bool Verification(string pText)
        {
            bool isPalindrome = false;           

            string textRebuild = Text.RemoveAllIsNotLetter(pText);
            
            for (int i = 0; i < textRebuild.Length / 2; i++)
            {
                if (textRebuild[i] == textRebuild[textRebuild.Length -1 - i])
                {
                    isPalindrome = true;
                }
                else
                {
                    isPalindrome = false; 
                }
            }           
            return isPalindrome;
        }

        public static bool VerificationFile(string filePath)
        {
            string fileContent = File.ReadAllText(filePath);
            Console.WriteLine($"\n    Le contenu de fichier {Path.GetFileName(filePath)} est : {fileContent}");
            bool isPalindrome = Verification(fileContent);
            
            return isPalindrome;
        }        
    }
} 