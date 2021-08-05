using ArithmeticOperatorDAL;
using ArithmeticOperatorDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticOperatorBLL
{
    public class FileOperationBLL
    {
        /// <summary>
        /// Transformer les données des objets fraction en string par l'override de ToString dans l'objet DTO 
        /// et ajoute l'opérateur et le type d'opérateur pour les sauvegarder
        /// </summary>
        /// <param name="pFraction1">Fraction</param>
        /// <param name="pFraction2">Fraction</param>
        /// <param name="pResult">Fraction</param>
        /// <param name="pOperative">String</param>
        /// <param name="pTypeOperative">String</param>
        public static void SaveToFileBLL(Fraction pFraction1, Fraction pFraction2, Fraction pResult, string pOperative, string pTypeOperative)
        {
            DTO Data = new($"{pFraction1}", $"{pFraction2}", $"{pResult}", pOperative, pTypeOperative);
                       
            FileOperationDAL.SaveToFileDAL(Data);
        }

        /// <summary>
        /// Transformer les données des objets fraction en string par l'override de ToString dans l'objet DTO, 
        /// transforme le bool en string, ajoute l'opérateur et le type d'opérateur pour les sauvegarder
        /// </summary>
        /// <param name="pFraction1">Fraction</param>
        /// <param name="pFraction2">Fraction</param>
        /// <param name="pResult">bool</param>
        /// <param name="pOperative">String</param>
        /// <param name="pTypeOperative">String</param>
        public static void SaveToFileBLL(Fraction pFraction1, Fraction pFraction2, bool pResult, string pOperative, string pTypeOperative)
        {
            DTO Data = new($"{pFraction1}", $"{pFraction2}", Convert.ToString(pResult), pOperative, pTypeOperative);

            FileOperationDAL.SaveToFileDAL(Data);
        }

        /// <summary>
        /// Appel la méthode ReadSavedFileDAL avec le paramètre pOperatorType qui est le type d'opérante
        /// qui permet de travailler sur le fichier par rapport à ce type
        /// </summary>
        /// <param name="pOperatorType">string</param>
        /// <returns>List<DTO></returns>
        public static List<DTO> ReadSavedFileBLL(string pOperatorType)
        {
            List<DTO> ListItemsSaved = FileOperationDAL.ReadSavedFileDAL(pOperatorType);
            return ListItemsSaved;
        }
    }
}
