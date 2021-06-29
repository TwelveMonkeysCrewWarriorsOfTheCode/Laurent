using System;
using PalindromeProjectBLL;

namespace ConsoleApplication
{
    class InputTest

    {
        private string m_Path;
        private string m_Name;
        private string m_Text;

        public InputTest()
        {
            m_Path = @"..\..\..\..\Textes\";
            m_Name = string.Empty;
            m_Text = string.Empty;
        }

        public string Path
        {
            get
            {
                return m_Path;
            }
            set
            {
                m_Path = value;
            }
        }

        public string Name
        {
            get
            {
                return m_Name;
            }
        }

        public string Text
        {
            get
            {
                return m_Text;
            }
            set
            {
                m_Text = value;
            }
        }

        public void TestingText()
        {
            bool twoCaractAtLeast = false;
            while (!twoCaractAtLeast)
            {
                Console.Write("    Entrez un mot ou un texte pour savoir si c'est un palindrome : ");
                m_Text = Console.ReadLine();
                m_Text = HelperText.RemoveAllIsNotLetterOrNumber(m_Text);
                if (m_Text.Length > 1)
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
        }

        public void FileWriteVisual()
        {           
            bool fileNameOk = false;

            while (!fileNameOk)
            {
                Console.WriteLine();
                Console.Write("    Entrez le nom du fichier à enregistrer :");
                m_Name = Console.ReadLine();

                while (String.IsNullOrEmpty(m_Name))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine();
                    Console.WriteLine("    Vous n'avez rien ecris !");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine();
                    Console.Write("    Entrez le nom du fichier à enregistrer :");
                    m_Name = Console.ReadLine();
                }

                bool fileExist = FileTest.CheckFileNameExist(m_Name);
               
                bool overwrite = false;

                if (!fileExist)
                {
                    overwrite = true;
                    fileNameOk = true;
                }

                while (!overwrite)
                {
                    Console.WriteLine();
                    Console.Write($"    Le fichier {m_Name} existe déjà ! Voulez vous ecraser le fichier ou abandonner ? (Y/N/A)");
                    string responseOverwrite = Console.ReadLine();
                    if (responseOverwrite.Length == 0) responseOverwrite = "error";

                    if (char.ToLower(responseOverwrite[0]) == 'y' || char.ToLower(responseOverwrite[0]) == 'n' || char.ToLower(responseOverwrite[0]) == 'a')
                    {
                        if (char.ToLower(responseOverwrite[0]) == 'y')
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine();
                            Console.WriteLine($"    Fichier {m_Name} va être écrasé !");
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
            
            m_Path = m_Path + m_Name + ".txt";
            TestingText();
            FileTest.FileCreation(Path, Text);
        }
    }
}
