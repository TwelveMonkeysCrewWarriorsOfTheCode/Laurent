using System;
using PalindromeDTO;
using PalindromeProjectBLL;

namespace ConsoleApplication
{
    class InputTest

    {
        /// <summary>
        /// Teste si le texte entré contient au moins 2 caractères, si oui appel la
        /// méthode RemoveAllIsNotLetterOrNumber qui nettoie la chaine de caractère 
        /// des espaces, des caractères spéciaux  et des accents
        /// </summary>
        /// <param name="file">Objet FileDTO contenant string Path, string Name, string Text,
        /// string[] ListFile, bool Result</param>
        /// <returns>Objet FileDTO</returns>
        public static FileDTO TestingText(FileDTO file)
        {
            bool twoCaractAtLeast = false;
            while (!twoCaractAtLeast)
            {
                Console.Write("    Entrez un mot ou un texte pour savoir si c'est un palindrome : ");
                file.Text = Console.ReadLine();
                file.Text = HelperText.RemoveAllIsNotLetterOrNumber(file.Text);
                if (file.Text.Length > 1)
                {
                    twoCaractAtLeast = true;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("    Vous devez au minimum entrez deux chiffres ou deux lettre !");
                    Console.ForegroundColor = ConsoleColor.White;
                }               
            }
            return file;
        }

        /// <summary>
        /// Teste si le nom de fichier existe déjà, si oui, propose d'ecraser ou non et d'abandonner
        /// Met dans path le nom + .text
        /// </summary>
        /// <param name="file">Objet FileDTO contenant string Path, string Name, string Text,
        /// string[] ListFile, bool Result</param>
        /// <returns>Objet FileDTO</returns>
        public static FileDTO FileWriteVisual(FileDTO file)
        {           
            bool fileNameOk = false;

            while (!fileNameOk)
            {
                Console.WriteLine();
                Console.Write("    Entrez le nom du fichier à enregistrer :");
                file.Name = Console.ReadLine();

                while (String.IsNullOrEmpty(file.Name))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("    Vous n'avez rien ecris !");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    Console.Write("    Entrez le nom du fichier à enregistrer :");
                    file.Name = Console.ReadLine();
                }

                bool fileExist = FileTest.CheckFileNameExist(file.Name);
               
                bool overwrite = false;

                if (!fileExist)
                {
                    overwrite = true;
                    fileNameOk = true;
                }

                while (!overwrite)
                {
                    Console.WriteLine();
                    Console.Write($"    Le fichier {file.Name} existe déjà ! Voulez vous ecraser le fichier ou abandonner ? (Y/N/A)");
                    string responseOverwrite = Console.ReadLine();
                    if (responseOverwrite.Length == 0) responseOverwrite = "error";

                    if (char.ToLower(responseOverwrite[0]) == 'y' || char.ToLower(responseOverwrite[0]) == 'n' || char.ToLower(responseOverwrite[0]) == 'a')
                    {
                        if (char.ToLower(responseOverwrite[0]) == 'y')
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine();
                            Console.WriteLine($"    Fichier {file.Name} va être écrasé !");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.ReadKey();
                            fileNameOk = true;
                        }
                        else
                        {
                            if (char.ToLower(responseOverwrite[0]) == 'n')
                            {
                                Console.WriteLine();
                                Console.Write("    Choisiez un autre nom de fichier");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.Write("    Retour vers le menu principal");
                                MenuOperation.MenuReturn();
                            }
                        }
                        overwrite = true;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine();
                        Console.Write("    Votre choix n'est pas valide !");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.ReadKey();
                    }
                }                                               
            }
            
            file.Path = file.Path + file.Name + ".txt";
            file = TestingText(file);
            FileTest.FileCreation(file);
            return file;
        }
    }
}
