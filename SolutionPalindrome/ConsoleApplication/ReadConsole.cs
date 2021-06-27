using System;
using PalindromeProjectBLL;

namespace ConsoleApplication
{
    public class ReadConsole
    {
        public string Path;
        public string Name;
        public string Text;

        public ReadConsole()
        {
            Path = @"..\..\..\..\Textes\";
            Name = string.Empty;
            Text = string.Empty;
        }

        public static ReadConsole TestingText(ReadConsole pText)
        {
            ReadConsole File = pText;

            bool twoCaractAtLeast = false;
            while (!twoCaractAtLeast)
            {
                Console.Write("    Entrez un mot ou un texte pour savoir si c'est un palindrome : ");
                File.Text = Console.ReadLine();
                File.Text = HelperText.RemoveAllIsNotLetterOrNumber(File.Text);
                if (File.Text.Length > 1)
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
            return File;
        }

        public static ReadConsole FileWriteVisual()
        {
            ReadConsole File = new ReadConsole();
            
            bool fileNameOk = false;

            while (!fileNameOk)
            {
                Console.WriteLine();
                Console.Write("    Entrez le nom du fichier à enregistrer :");
                File.Name = Console.ReadLine();

                while (String.IsNullOrEmpty(File.Name))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("    Vous n'avez rien ecris !");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    Console.Write("    Entrez le nom du fichier à enregistrer :");
                    File.Name = Console.ReadLine();
                }

                bool fileExist = FileTest.CheckFileNameExist(File.Name);
               
                bool overwrite = false;

                if (!fileExist)
                {
                    overwrite = true;
                    fileNameOk = true;
                }

                while (!overwrite)
                {
                    Console.WriteLine();
                    Console.Write($"    Le fichier {File.Name} existe déjà ! Voulez vous ecraser le fichier ou abandonner ? (Y/N/A)");
                    string responseOverwrite = Console.ReadLine();

                    if (char.ToLower(responseOverwrite[0]) == 'y' || char.ToLower(responseOverwrite[0]) == 'n' || char.ToLower(responseOverwrite[0]) == 'a')
                    {
                        if (char.ToLower(responseOverwrite[0]) == 'y')
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine();
                            Console.WriteLine($"    Fichier {File.Name} va être écrasé !");
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
                                SubMenu.MenuReturn();
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
            File.Path += File.Name + ".txt";
            File = TestingText(File);
            FileTest.FileCreation(File.Path, File.Text);
            return File;
        }
    }
}
