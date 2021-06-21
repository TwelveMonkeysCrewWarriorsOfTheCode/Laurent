using System;
using System.Text;

namespace PalindromeProjectBLL
{
    internal class Text
    {
        internal static string RemoveAllIsNotLetter(string pText)
        {  
            // Dissocie l'accent de la lettre par la méthode Normalize puis par un boucle for
            // recopie dans une nouvelle string si le caractére est une lettre grace à un bool,
            // en minuscule et retourne le nouveau texte

            string text = pText.Normalize(NormalizationForm.FormD);
            string cleanText = "";

            for (int i = 0; i < text.Length; i++)
            {
                bool isNotLetter = Char.IsLetter(text[i]);
                
                if (isNotLetter)
                {
                    cleanText += Char.ToLower(text[i]);
                }
            }
            return cleanText;
        }
    }
}