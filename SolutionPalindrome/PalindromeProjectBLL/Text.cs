using System;
using System.Text;

namespace PalindromeProjectBLL
{
    internal class Text
    {
        internal static string RemoveAllIsNotLetter(string pText)
        {          
            string text = pText.Normalize(NormalizationForm.FormD);
            string cleanText = "";

            for (int i = 0; i < text.Length; i++)
            {
                bool isNotLetter = Char.IsLetter(text[i]);
                
                if (isNotLetter)
                {
                    cleanText += text[i];
                }
            }
            return cleanText;
        }
    }
}