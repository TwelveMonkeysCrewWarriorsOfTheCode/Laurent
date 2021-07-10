using PalindromeDTO;
using PalindromeProjectBLL;
using System;
using System.IO;

namespace ConsoleApplication
{
    class MenuOperation
    {
        FileDTO file = new();
        /// <summary>
        /// Execute la partie du menu pour un texte entré et non sauvegardé
        /// </summary>
        public void OperationForTextInputWhithoutSave()
        {
            file = InputTest.TestingText(file);
            file.Result = PalindromeTest.Verification(file.Text);
            // Appel la méthode qui affichera le résultat si le texte est un palindrome ou pas
            IsPalindromeResultWrite.Result(file.Result);
        }
        /// <summary>
        /// Execute la partie du menu pour un texte entré et sauvegarder dans un fichier texte
        /// </summary>
        public void OperationForTextInputWhithSaveToFile()
        {
            // Appel de la méthode qui crée/écrase un fichier et instancie un objet de class ReadConsole                     
            file = InputTest.FileWriteVisual(file);
            // Appel la méthode qui vérifie si le texte dans un fichier est un palindrome en parametrant
            file.Text = PalindromeTest.VerificationFile(file.Path);
            Console.WriteLine($"    Le contenu de fichier {Path.GetFileName(file.Path)} est : {file.Text}");
            file.Result = PalindromeTest.Verification(file.Text);
            // Appel la méthode qui affichera le résultat si le texte est un palindrome ou pas
            IsPalindromeResultWrite.Result(file.Result);
        }
        /// <summary>
        /// Execute la partie du menu pour un texte enregistré dans un fichier 
        /// </summary>
        public void OperationForTextReadOnFile()
        {
            // Appel de la méthode crée un liste des fichiers .txt dans le dossier dédié
            file = FileTest.FileList(file);
            // Appel de la méthode qui affiche la liste des fihiers .txt dans le dossier dédié
            file = ReadOnFileSubMenu.FileListDisplay(file);
            // Appel de la méthode qui vérifie si le texte dans un fichier est un palindrome            
            file.Text = PalindromeTest.VerificationFile(file.Path);
            Console.WriteLine();
            Console.WriteLine($"    Le contenu de fichier {Path.GetFileName(file.Path)} est : {file.Text}");
            file.Result = PalindromeTest.Verification(file.Text);
            // Appel la méthode qui affichera le résultat si le texte est un palindrome ou pas
            IsPalindromeResultWrite.Result(file.Result);
        }
        /// <summary>
        /// Renvoi au menu principal après avoir appuyé sur une touche
        /// </summary>
        public static void MenuReturn()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.Write("    Appuyez sur enter pour continuer");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
            Program.Main();
        }
    }
}
