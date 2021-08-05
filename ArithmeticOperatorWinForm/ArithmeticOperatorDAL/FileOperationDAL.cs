using ArithmeticOperatorDTO;
using System;
using System.Collections.Generic;
using System.IO;

namespace ArithmeticOperatorDAL
{
    public class FileOperationDAL
    {
        const string FILE_PATH = @"..\..\..\..\Save\FractionData";

        /// <summary>
        /// Sauver l'opération dans un fichier .csv
        /// si c'est une première saugarde crée le nom des colonnes
        /// </summary>
        /// <param name="pData">object DTO</param>
        public static void SaveToFileDAL(DTO pData)
        {
            string textToSave = string.Empty;
            string filePath = string.Empty;
            filePath += FILE_PATH + pData.OperativeType + ".csv";
            bool fileExist = File.Exists(filePath);
            try
            {  
                if(!fileExist) textToSave = "Date;Fraction1;Operateur;Fraction2;Resultat;" + Environment.NewLine;
                textToSave += DateTime.UtcNow.ToString() + ";" + pData.Fraction1 + ";" + pData.Operative + ";" + pData.Fraction2 + ";" + pData.Result + ";"  + Environment.NewLine;                
                File.AppendAllText(filePath, textToSave);
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pOperatorType"></param>
        /// <returns></returns>
        public static List<DTO> ReadSavedFileDAL(string pOperatorType)
        {
            string filePath = string.Empty;
            filePath += FILE_PATH + pOperatorType + ".csv";
            bool fileExist = File.Exists(filePath);
            List<DTO> ListItemsSaved = new();

            if (fileExist)
            {
                IEnumerable<string> linesReaded = File.ReadLines(filePath);
                
                foreach (var line in linesReaded)
                {
                    DTO dto = ConvertStringToObjectDTO(line);
                    ListItemsSaved.Add(dto);
                }
            }
            else 
            {
                DTO dto = new();
                //dto = null;
                //dto.Date = "Vous n'avez encore rien sauvegarder dans le fichier";
                //ListItemsSaved.Add(dto);
            }
            
            return ListItemsSaved;
        }

        private static DTO ConvertStringToObjectDTO(string line)
        {
            string[] splitted = line.Split(';', StringSplitOptions.None);
            DTO dto = new DTO
            {
                Date = splitted[0],
                Fraction1 = splitted[1],
                Operative = splitted[2],
                Fraction2 = splitted[3],
                Result = splitted[4]
                
            };
            return dto;
        }
    }
}
