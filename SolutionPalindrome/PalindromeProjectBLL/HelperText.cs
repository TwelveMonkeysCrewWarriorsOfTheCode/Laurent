using System;
using System.Text;

namespace PalindromeProjectBLL
{
    public class HelperText
    {
        /// <summary>
        /// Dissocie l'accent de la lettre par la méthode Normalize puis met le texte
        /// en minuscule puis par un boucle for recopie dans une nouvelle string
        /// si le caractére est une lettre ou un nombre par StringBuilder
        /// grace à un bool, en minuscule et retourne le nouveau texte
        /// </summary>
        /// <param name="pText">string</param>
        /// <returns>string text cleaned</returns>
        public static string RemoveAllIsNotLetterOrNumber(string pText)
        {  
            string text = pText.Normalize(NormalizationForm.FormD);
            text = text.ToLower();
            StringBuilder sbCleanText = new ();
            
            for (int i = 0; i < text.Length; i++)
            {
                bool isLetter = Char.IsLetter(text[i]);
                bool isNumber = Char.IsNumber(text[i]);
                
                if (isLetter || isNumber)
                {
                    sbCleanText.Append(text[i]);
                }
            }
            string cleanText = sbCleanText.ToString();
            return cleanText;
        }
    }
}