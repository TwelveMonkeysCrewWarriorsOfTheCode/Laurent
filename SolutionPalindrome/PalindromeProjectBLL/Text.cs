using System;
using System.Text;

namespace PalindromeProjectBLL
{
    internal class HelperText
    {
        internal static string RemoveAllIsNotLetterOrNumber(string pText)
        {  
            // Dissocie l'accent de la lettre par la méthode Normalize puis par un boucle for
            // recopie dans une nouvelle string si le caractére est une lettre ou un nombre
            // grace à un bool, en minuscule et retourne le nouveau texte.

            string text = pText.Normalize(NormalizationForm.FormD);
            string cleanText = "";

            for (int i = 0; i < text.Length; i++)
            {
                bool isNotLetter = Char.IsLetter(text[i]);
                bool isNotNumber = Char.IsNumber(text[i]);
                
                if (isNotLetter || isNotNumber)
                {
                    cleanText += Char.ToLower(text[i]);
                }
            }
            return cleanText;
        }
    }
}