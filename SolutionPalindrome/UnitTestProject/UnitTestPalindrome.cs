using Microsoft.VisualStudio.TestTools.UnitTesting;
using PalindromeProjectBLL;

namespace UnitTestProject
{      
    [TestClass]
    public class UnitTestPalindrome
    {
        [DataRow(true ,"aa", DisplayName = "cas le plus simple")] //Cas n°1
        [DataRow(true , "ada", DisplayName = "cas impair")] //Cas n°2
        [DataRow(true, "alla", DisplayName = "cas pair au dessus de 2")] //Cas n°3
        [DataRow(true, "ressasser", DisplayName = "cas impair au dessus de 3")] // cas n°4
        [DataRow(true, "ce reptile lit perec", DisplayName = "cas texte")] // cas n°5
        [DataRow(true, "Ce reptile lit Perec", DisplayName = "cas texte avec majuscule")] //cas n°6
        [DataRow(true, "La mariée ira mal" ,DisplayName = "cas texte avec accent")] //cas n°7
        [DataRow(true, "Et si l'arôme des bottes révèle madame, le verset t'obsède, moraliste !", DisplayName = "cas complet")] //cas n°8
        [DataRow(true, "121", DisplayName = "cas avec chiffre")] //cas n°9
        [DataRow(false, "15487", DisplayName = "cas avec mauvais chiffre")]

        [TestMethod]
        public void PalindromeTestMethod(bool pExpectedValue ,string pText)
        {
            //Arrengement
            string text = pText;

            //Action
            bool result = Palindrome.Verification(text);

            //Assert
            Assert.AreEqual(pExpectedValue, result);
        }

        [DataRow(true, @"..\..\..\..\Textes\palindrome.txt", DisplayName ="cas avec fichier txt")]
        [DataRow(true, @"..\..\..\..\Textes\palindromeMoyen.txt", DisplayName = "cas avec fichier txt moyen")]
        [DataRow(true, @"..\..\..\..\Textes\palindromeComplexe.txt", DisplayName = "cas avec fichier txt difficile")]

        [TestMethod]

        public void PalindromeFileTestMethod(bool pExpectedValue, string pPath)
        {
            //Arrengement
            string path = pPath;

            //Action
            bool result = Palindrome.VerificationFile(path);

            //Assert
            Assert.AreEqual(pExpectedValue, result);
        }
    } 
}
