using ArithmeticOperatorBLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ArithmeticOperationTestProject
{
    [TestClass]
    public class UnitTestFraction
    {
        ///Testes constructeur 1 argument
        [DataRow(6, 0, 6, 1)]
        [DataRow(0, -1, 1, 1)]
        [DataRow(8, 0, 8, 1)]

        [TestMethod]
        public void Constructor1arg(int pInteger,int pIntegerExpected, int pNumetorExpected, int pDenominatorExpected)
        {
            //Arrengement
            int IntArg = pInteger;
            int IntegerExpected = pIntegerExpected;
            int NumetorExpected = pNumetorExpected;
            int DenominatorExpected = pDenominatorExpected;

            //Action
            Fraction Fraction = new(IntArg);

            //Assert
            Assert.AreEqual(Fraction.Integer, IntegerExpected);
            Assert.AreEqual(Fraction.Numerator, NumetorExpected);
            Assert.AreEqual(Fraction.Denominator, DenominatorExpected);
        }

        ///Testes constructeur 2 argument
        [DataRow(6, 3, 2, 0, 3)]
        [DataRow(1, 3, 0, 1, 3)]
        [DataRow(2, -5, 0, -2, 5)]

        [TestMethod]
        public void Constructor2arg(int pNumerator, int pDenominator, int pIntegerExpected, int pNumetorExpected, int pDenominatorExpected)
        {
            //Arrengement
            int NumeratorArg = pNumerator;
            int DenominatorArg = pDenominator;
            int IntegerExpected = pIntegerExpected;
            int NumetorExpected = pNumetorExpected;
            int DenominatorExpected = pDenominatorExpected;

            //Action
            Fraction Fraction = new(NumeratorArg, DenominatorArg);

            //Assert
            Assert.AreEqual(Fraction.Integer, IntegerExpected);
            Assert.AreEqual(Fraction.Numerator, NumetorExpected);
            Assert.AreEqual(Fraction.Denominator, DenominatorExpected);
        }

        ///Testes constructeur 3 argument
        [DataRow(1, 6, 3, 1, 6, 3)]
        [DataRow(2, 1, 3, 2, 1, 3)]
        [DataRow(0, -2, -5, 0, 2, 5)]

        [TestMethod]
        public void Constructor3arg(int pInteger, int pNumerator, int pDenominator, int pIntegerExpected, int pNumetorExpected, int pDenominatorExpected)
        {
            //Arrengement
            int IntegerArg = pInteger;
            int NumeratorArg = pNumerator;
            int DenominatorArg = pDenominator;
            int IntegerExpected = pIntegerExpected;
            int NumetorExpected = pNumetorExpected;
            int DenominatorExpected = pDenominatorExpected;

            //Action
            Fraction Fraction = new(IntegerArg ,NumeratorArg, DenominatorArg);

            //Assert
            Assert.AreEqual(Fraction.Integer, IntegerExpected);
            Assert.AreEqual(Fraction.Numerator, NumetorExpected);
            Assert.AreEqual(Fraction.Denominator, DenominatorExpected);
        }

        ///Testes conversion de Fraction en Decimal
        [DataRow(0, 1, 2)]
        [DataRow(0, 1, 3)]
        [DataRow(-2, -2, 5)]

        [TestMethod]
        public void ConversionFractionToFloat(int pInteger, int pNumerator, int pDenominator)
        {
            //Arrengement
            int IntegerArg = pInteger;
            int NumeratorArg = pNumerator;
            int DenominatorArg = pDenominator;
            
            decimal ResultExpected = Convert.ToDecimal(pInteger) + (Convert.ToDecimal(pNumerator) / Convert.ToDecimal(pDenominator));
            System.Console.WriteLine(ResultExpected);
            //Action
            Fraction FractionArg = new(IntegerArg, NumeratorArg, DenominatorArg);
            decimal Result = (decimal)FractionArg;
            Console.WriteLine(Result);
            //Assert
            Assert.AreEqual(Result, ResultExpected);            
        }

        ///Testes conversion de Decimal en Fraction
        [DataRow(0, -1, 2)]
        [DataRow(0, 1, 4)]
        [DataRow(-2, 1, 5)]

        [TestMethod]
        public void ConversionFloatToFraction(int pInteger, int pNumerator, int pDenominator)
        {
            //Arrengement
            int IntegerArg = pInteger;
            int NumeratorArg = pNumerator;
            int DenominatorArg = pDenominator;

            Fraction fraction = new(IntegerArg, NumeratorArg, pDenominator);
            decimal ResultExpected = (decimal)fraction;
            string s = Convert.ToString(ResultExpected);
            Console.WriteLine(s);
            //Action            
            Fraction FractionArg = new(ResultExpected);
            Console.WriteLine($"{FractionArg.Integer}:{FractionArg.Numerator}/{FractionArg.Denominator}");

            //Assert
            Assert.AreEqual(FractionArg.Integer, IntegerArg);
            Assert.AreEqual(FractionArg.Numerator, NumeratorArg);
            Assert.AreEqual(FractionArg.Denominator, DenominatorArg);
        }

        [DataRow(0,6,4,0,10,11,2,9,22)]
        [DataRow(0,6,5,0,10,11, 2,6,55)]
        [DataRow(0,8,4,0,15,24,2,5, 8)]
               
        [TestMethod]
        public void FractionTestMethodAddition(int Integer1,int Numerator1, int Denominator1, int Integer2, int Numerator2, int Denominator2, int IntegerResult, int NumeratorResult, int DenominatorResult)
        {
            //Arrengement
            Fraction Fraction1 = new (Integer1, Numerator1, Denominator1);
            Fraction Fraction2 = new (Integer2, Numerator2, Denominator2);
            Fraction FractionExpectedValue = new (IntegerResult, NumeratorResult, DenominatorResult);

            //Action
            Fraction FractionResult = Fraction1 + Fraction2;
            System.Console.WriteLine($"{Fraction1.Integer}:{Fraction1.Numerator}/{Fraction1.Denominator} + {Fraction2.Integer}:{Fraction2.Numerator}/{Fraction2.Denominator} = {FractionResult.Integer}:{FractionResult.Numerator}/{FractionResult.Denominator}");
            //Assert
            Assert.AreEqual(FractionExpectedValue.Numerator, FractionResult.Numerator);
            Assert.AreEqual(FractionExpectedValue.Denominator, FractionResult.Denominator);
            Assert.AreEqual(FractionExpectedValue.Integer, FractionResult.Integer);
        }

        [DataRow(0, 6, 4, 0, 10, 11, 0, 13, 22)]
        [DataRow(0, 6, 5, 0, 10, 11, 0, 16, 55)]
        [DataRow(0, 8, 4, 0, 15, 24, 1, 3, 8)]

        [TestMethod]
        public void FractionTestMethodSubstraction(int Integer1, int Numerator1, int Denominator1, int Integer2, int Numerator2, int Denominator2, int IntegerResult, int NumeratorResult, int DenominatorResult)
        {
            //Arrengement
            Fraction Fraction1 = new (Integer1, Numerator1, Denominator1);
            Fraction Fraction2 = new (Integer2, Numerator2, Denominator2);
            Fraction FractionExpectedValue = new(IntegerResult, NumeratorResult, DenominatorResult);

            //Action
            Fraction FractionResult = Fraction1 - Fraction2;
            System.Console.WriteLine($"{Fraction1.Integer}:{Fraction1.Numerator}/{Fraction1.Denominator} - {Fraction2.Integer}:{Fraction2.Numerator}/{Fraction2.Denominator} = {FractionResult.Integer}:{FractionResult.Numerator}/{FractionResult.Denominator}");
            Console.WriteLine($"{FractionExpectedValue.Integer}:{FractionExpectedValue.Numerator}/{FractionExpectedValue.Denominator}");
            //Assert
            Assert.AreEqual(FractionExpectedValue.Numerator, FractionResult.Numerator);
            Assert.AreEqual(FractionExpectedValue.Denominator, FractionResult.Denominator);
            Assert.AreEqual(FractionExpectedValue.Integer, FractionResult.Integer);
        }

        [DataRow(0, 6, 4, 0, 10, 11, 1, 4, 11)]
        [DataRow(0, 6, 5, 0, 10, 11, 1, 1, 11)]
        [DataRow(0, 8, 4, 0, 15, 24, 1, 1, 4)]

        [TestMethod]
        public void FractionTestMethodMultiplication(int Integer1, int Numerator1, int Denominator1, int Integer2, int Numerator2, int Denominator2, int IntegerResult, int NumeratorResult, int DenominatorResult)
        {
            //Arrengement
            Fraction Fraction1 = new(Integer1, Numerator1, Denominator1);
            Fraction Fraction2 = new(Integer2, Numerator2, Denominator2);
            Fraction FractionExpectedValue = new(IntegerResult, NumeratorResult, DenominatorResult);

            //Action
            Fraction FractionResult = Fraction1 * Fraction2;
            System.Console.WriteLine($"{Fraction1.Integer}:{Fraction1.Numerator}/{Fraction1.Denominator} * {Fraction2.Integer}:{Fraction2.Numerator}/{Fraction2.Denominator} = {FractionResult.Integer}:{FractionResult.Numerator}/{FractionResult.Denominator}");
            //Assert
            Assert.AreEqual(FractionExpectedValue.Numerator, FractionResult.Numerator);
            Assert.AreEqual(FractionExpectedValue.Denominator, FractionResult.Denominator);
            Assert.AreEqual(FractionExpectedValue.Integer, FractionResult.Integer);
        }

        [DataRow(0, 6, 4, 0, 10, 11, 1, 13, 20)]
        [DataRow(0, 6, 5, 0, 10, 11, 1, 8, 25)]
        [DataRow(0, 8, 4, 0, 15, 24, 3, 1, 5)]

        [TestMethod]
        public void FractionTestMethodDivision(int Integer1, int Numerator1, int Denominator1, int Integer2, int Numerator2, int Denominator2, int IntegerResult, int NumeratorResult, int DenominatorResult)
        {
            //Arrengement
            Fraction Fraction1 = new(Integer1, Numerator1, Denominator1);
            Fraction Fraction2 = new(Integer2, Numerator2, Denominator2);
            Fraction FractionExpectedValue = new(IntegerResult, NumeratorResult, DenominatorResult);

            //Action
            Fraction FractionResult = Fraction1 / Fraction2;
            System.Console.WriteLine($"{Fraction1.Integer}:{Fraction1.Numerator}/{Fraction1.Denominator} / {Fraction2.Integer}:{Fraction2.Numerator}/{Fraction2.Denominator} = {FractionResult.Integer}:{FractionResult.Numerator}/{FractionResult.Denominator}");
            //Assert
            Assert.AreEqual(FractionExpectedValue.Numerator, FractionResult.Numerator);
            Assert.AreEqual(FractionExpectedValue.Denominator, FractionResult.Denominator);
            Assert.AreEqual(FractionExpectedValue.Integer, FractionResult.Integer);
        }

        [DataRow(false, 0, 6, 4, 0, 12, 8)]
        [DataRow(false, 0, 6, 5, 0, 10, 11)]
        [DataRow(true, 0, 6, 5, 0, 20, 11)]

        [TestMethod]
        public void FractionTestMethodSmaller(bool Result, int Integer1, int Numerator1, int Denominator1, int Integer2, int Numerator2, int Denominator2)
        {
            //Arregement
            Fraction Fraction1 = new(Integer1, Numerator1, Denominator1);
            Fraction Fraction2 = new(Integer2, Numerator2, Denominator2);
            bool ExpectedValue = Result;
            
            //Action
            Result = Fraction1 < Fraction2;
            System.Console.WriteLine($"{Fraction1.Integer}:{Fraction1.Numerator}/{Fraction1.Denominator} < {Fraction2.Integer}:{Fraction2.Numerator}/{Fraction2.Denominator} = {Result}");

            //Assert
            Assert.AreEqual(ExpectedValue, Result);
        }

        [DataRow(false, 0, 6, 4, 0, 12, 8)]
        [DataRow(false, 0, 1, 15, 0, 10, 11)]
        [DataRow(true, 0, 54, 7, 0, 20, 11)]

        [TestMethod]
        public void FractionTestMethodBigger(bool Result, int Integer1, int Numerator1, int Denominator1, int Integer2, int Numerator2, int Denominator2)
        {
            //Arregement
            Fraction Fraction1 = new(Integer1, Numerator1, Denominator1);
            Fraction Fraction2 = new(Integer2, Numerator2, Denominator2);
            bool ExpectedValue = Result;

            //Action
            Result = Fraction1 > Fraction2;
            System.Console.WriteLine($"{Fraction1.Integer}:{Fraction1.Numerator}/{Fraction1.Denominator} > {Fraction2.Integer}:{Fraction2.Numerator}/{Fraction2.Denominator} = {Result}");

            //Assert
            Assert.AreEqual(ExpectedValue, Result);
        }

        [DataRow(false, 61, 4, 12, 8)]
        [DataRow(true, 10, 5, 2, 1)]

        [TestMethod]
        public void FractionTestMethodEqual(bool Result, int FracNumerator1, int FracDenominator1, int FracNumerator2, int FracDenominator2)
        {
            //Arregement
            Fraction Fraction1 = new() { Numerator = FracNumerator1, Denominator = FracDenominator1 };
            Fraction Fraction2 = new() { Numerator = FracNumerator2, Denominator = FracDenominator2 };
            bool ExpectedValue = Result;

            //Action
            Result = Fraction1 == Fraction2;
            System.Console.WriteLine($"{Fraction1.Numerator}/{Fraction1.Denominator} = {Fraction2.Numerator}/{Fraction2.Denominator} = {Result}");

            //Assert
            Assert.AreEqual(ExpectedValue, Result);
        }

        [DataRow(true, 61, 4, 12, 8)]
        [DataRow(false, 10, 5, 2, 1)]

        [TestMethod]
        public void FractionTestMethodNotEqual(bool Result, int FracNumerator1, int FracDenominator1, int FracNumerator2, int FracDenominator2)
        {
            //Arregement
            Fraction Fraction1 = new() { Numerator = FracNumerator1, Denominator = FracDenominator1 };
            Fraction Fraction2 = new() { Numerator = FracNumerator2, Denominator = FracDenominator2 };
            bool ExpectedValue = Result;

            //Action
            Result = Fraction1 != Fraction2;
            System.Console.WriteLine($"{Fraction1.Numerator}/{Fraction1.Denominator} = {Fraction2.Numerator}/{Fraction2.Denominator} = {Result}");

            //Assert
            Assert.AreEqual(ExpectedValue, Result);
        }
    }
}
