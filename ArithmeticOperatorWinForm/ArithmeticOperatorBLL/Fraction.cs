using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ArithmeticOperatorBLL
{
    public class Fraction : IEquatable<Fraction>, IComparable<Fraction>
    {
        public int Integer;
        public int Numerator;
        public int Denominator;


        #region Constructors
        /// <summary>
        /// Constructeur Fraction à 0 arguments
        /// </summary>
        public Fraction() {}

        /// <summary>
        /// Constructeur Fraction à 1 arguments
        /// </summary>
        /// <param name="pIntNum">int</param>
        public Fraction(int pIntNum)
        {
            if (pIntNum == 0)
            {
                Numerator = 1;
                Denominator = 1;
                Integer = -1;
            }
            else
            {
                Numerator = pIntNum;
                Denominator = 1;
                Integer = 0;
            }
            
        }
        /// <summary>
        /// Constructeur Fraction à 2 arguments
        /// </summary>
        /// <param name="pNumerator">int</param>
        /// <param name="pDenominator">int</param>
        public Fraction(int pNumerator, int pDenominator)
        {
            if(pDenominator == 0) throw new ArgumentException("Denominator == 0");
            this.NegativeVerification(pNumerator, pDenominator);
            Integer = Numerator / Denominator;
            Numerator %= Denominator;

        }

        /// <summary>
        /// Constructeur Fraction à 3 arguments
        /// </summary>
        /// <param name="pIntNum">int</param>
        /// <param name="pNumerator">int</param>
        /// <param name="pDenominator">int</param>
        public Fraction(int pIntNum, int pNumerator, int pDenominator)
        {
            if (pDenominator == 0) throw new ArgumentException("Denominator == 0");
            //this.NegativeVerification(pIntNum, pNumerator, pDenominator);
            Integer = pIntNum;
            Numerator = pNumerator;
            Denominator = pDenominator;            
        }

        /// <summary>
        /// Transforme une décimal en fraction et le signe négatif
        /// </summary>
        /// <param name="pFractionFloat">decimal</param>
        public Fraction(decimal pFractionFloat)
        {
            bool IsNegative = (pFractionFloat < 0);
            if (IsNegative) pFractionFloat = -pFractionFloat;
            
            string fraction = Convert.ToString(pFractionFloat);                                  
            int pointPosition = fraction.IndexOf(",");
            
            if (pointPosition == -1 || pointPosition > 1)
            {
                 if(!int.TryParse(fraction, out Integer)) throw new ArgumentOutOfRangeException("Impossible de transformer la partie entière de la decimal en int");              
            }
            else Integer = (int)Char.GetNumericValue(fraction[0]);

            bool parseToInt = int.TryParse(fraction.Substring(pointPosition + 1), out Numerator);
            if (!parseToInt) int.TryParse(fraction.Substring(pointPosition + 1,9), out Numerator);

            int i = 0;
            Denominator = 1;
            while (i != Convert.ToString(Numerator).Length)
            {                
                Denominator *= 10;
                i++;
            }

            if (IsNegative)
            {
                if (Integer != 0) Integer = -Integer;
                Numerator = -Numerator;
            }
            this.MinimunDenominator();
            if (Integer < 0 && Numerator < 0) Numerator = -Numerator;
        }
        #endregion

        #region Methods        
        /// <summary>
        /// Crée un Tuple avec 2 Fraction avec le dénominateur commum de 2 Fractions 
        /// </summary>
        /// <param name="pFractionLeft"></param>
        /// <param name="pFractionRight"></param>
        /// <returns>Object Fraction</returns>
        private static (Fraction, Fraction) CommonDenominator(Fraction pFraction1, Fraction pFraction2)
        {
            Fraction FractionCommunDenominator1 = new();
            FractionCommunDenominator1.Numerator = pFraction1.Numerator * pFraction2.Denominator;
            FractionCommunDenominator1.Denominator = pFraction1.Denominator * pFraction2.Denominator;
            
            Fraction FractionCommunDenominator2 = new();
            FractionCommunDenominator2.Numerator = pFraction2.Numerator * pFraction1.Denominator;
            FractionCommunDenominator2.Denominator = pFraction2.Denominator * pFraction1.Denominator;
            
            (Fraction, Fraction) fractions = (FractionCommunDenominator1, FractionCommunDenominator2);
            return fractions;
        }

        /// <summary>
        /// Divise le numérateur et dénominateur avec le plus grand diviseur commun
        /// pour simplifier la fraction
        /// </summary>
        private void MinimunDenominator()
        {
            int i = 1;
            int maxDivider = 1;
            
            if(Numerator != 0)
            {
                while (Denominator / i != 1 && Numerator / i != 0)
                {
                    i++;
                    if (Denominator % i == 0 && Numerator % i == 0) maxDivider = i;
                }
                Numerator /= maxDivider;
                Denominator /= maxDivider;
            }            
        }

        private static (Fraction, Fraction) MinimunDenominator(Fraction pFraction1, Fraction pFraction2)
        {
            Fraction FractionSimplified1 = new();            
            if (pFraction1.Integer < 0) FractionSimplified1.Numerator = -pFraction1.Numerator + (pFraction1.Integer * pFraction1.Denominator);
            else FractionSimplified1.Numerator = pFraction1.Numerator + (pFraction1.Integer * pFraction1.Denominator);
            FractionSimplified1.Denominator = pFraction1.Denominator;
            FractionSimplified1.MinimunDenominator();

            Fraction FractionSimplified2 = new();
            if(pFraction2.Integer < 0) FractionSimplified2.Numerator = -pFraction2.Numerator + (pFraction2.Integer * pFraction2.Denominator);
            else FractionSimplified2.Numerator = pFraction2.Numerator + (pFraction2.Integer * pFraction2.Denominator);
            FractionSimplified2.Denominator = pFraction2.Denominator;
            FractionSimplified2.MinimunDenominator();
            
            (Fraction, Fraction) fractions = (FractionSimplified1, FractionSimplified2);
            return fractions;
        }

        private void NegativeVerification()
        {
            if(Integer < 0 && Numerator < 0) Numerator = -Numerator;
        }

        /// <summary>
        /// Gère les signes négatif de la fraction à 2 arguments
        /// </summary>
        /// <param name="pNumerator">Numérateur</param>
        /// <param name="pDenominator">Dénominateur</param>
        private void NegativeVerification(int pNumerator, int pDenominator)
        {
            if (pDenominator > 0)
            {
                Numerator = pNumerator;
                Denominator = pDenominator;
            }
            else
            {
                Numerator = -pNumerator;
                Denominator = -pDenominator;
            }
        }        
        
        /// <summary>
        /// Soustrait le 1er numérateur au 2ème après avoir trouver le denomonateur commun
        /// Si revoi 0 les 2 fraction sont égales
        /// </summary>
        /// <param name="other"></param>
        /// <returns>int</returns>
        public int CompareTo([AllowNull] Fraction other)
        {
            if (other == null) return 1;
            else
            {
                (Fraction, Fraction) fractions = MinimunDenominator(this, other);
                fractions = CommonDenominator(fractions.Item1, fractions.Item2);
                return fractions.Item1.Numerator - fractions.Item2.Numerator;
            }
        }

        public override bool Equals(object other) => Equals(other as Fraction);


        public bool Equals(Fraction other)
        {
            (Fraction, Fraction) fractions = MinimunDenominator(this, other);
            fractions = CommonDenominator(fractions.Item1, fractions.Item2);
            return (other != null && fractions.Item1.Numerator == fractions.Item2.Numerator);
        }

        public override int GetHashCode() => Numerator.GetHashCode() ^ Denominator.GetHashCode();

        /// <summary>
        /// Crée un formatage de Tostring pour une fraction
        /// format sans l'entieer si il est à 0
        /// </summary>
        /// <returns>string</returns>
        public override string ToString() => (Integer != 0) ? $"{Integer} : {Numerator}/{Denominator}" : $" {Numerator}/{Denominator}";
        #endregion

        #region Operators
        /// <summary>
        /// Tranforme un Fraction en decimal
        /// </summary>
        /// <param name="pFraction">Fraction</param>
        public static explicit operator decimal(Fraction pFraction)

        {
            if (pFraction.Integer < 0 && pFraction.Numerator > 0) pFraction.Numerator = -pFraction.Numerator;
            return ((decimal)pFraction.Numerator / pFraction.Denominator) + pFraction.Integer;
        }

        /// <summary>
        /// Surcharge de l'opérateur + pour l'addition de 2 fractions
        /// Gère le signe négatif dans le cadre de l'addition
        /// </summary>
        /// <param name="pFraction1">Fraction</param>
        /// <param name="pFraction2">Fraction</param>
        /// <returns>Fraction<returns>
        public static Fraction operator +(Fraction pFraction1, Fraction pFraction2)
        {
            (Fraction, Fraction) fractions = MinimunDenominator(pFraction1, pFraction2);
            fractions = CommonDenominator(fractions.Item1, fractions.Item2);
            Fraction FractionResult = new(fractions.Item1.Numerator + fractions.Item2.Numerator, fractions.Item1.Denominator);
            FractionResult.MinimunDenominator();
            FractionResult.NegativeVerification();
            return FractionResult;
        }

        public static Fraction operator -(Fraction pFraction1, Fraction pFraction2)
        {
            (Fraction, Fraction) fractions = MinimunDenominator(pFraction1, pFraction2);
            fractions = CommonDenominator(fractions.Item1, fractions.Item2);
            Fraction FractionResult = new(fractions.Item1.Numerator - fractions.Item2.Numerator, fractions.Item1.Denominator);
            FractionResult.MinimunDenominator();
            FractionResult.NegativeVerification();
            return FractionResult;
        }

        public static Fraction operator *(Fraction pFraction1, Fraction pFraction2)
        {
            (Fraction, Fraction) fractions = MinimunDenominator(pFraction1, pFraction2);
            fractions = CommonDenominator(fractions.Item1, fractions.Item2);
            Fraction FractionResult = new(fractions.Item1.Numerator * fractions.Item2.Numerator, fractions.Item1.Denominator * fractions.Item2.Denominator);            
            FractionResult.MinimunDenominator();
            FractionResult.NegativeVerification();
            
            return FractionResult;
        }

        public static Fraction operator /(Fraction pFraction1, Fraction pFraction2)
        {
            if(pFraction1.Numerator == 0 || pFraction2.Numerator == 0) throw new ArgumentException("Numerator == 0 for a division");
            (Fraction, Fraction) fractions = MinimunDenominator(pFraction1, pFraction2);
            Fraction FractionResult = new(fractions.Item1.Numerator * fractions.Item2.Denominator, fractions.Item1.Denominator * fractions.Item2.Numerator);
            FractionResult.MinimunDenominator();
            FractionResult.NegativeVerification();
            return FractionResult;
        }

        public static bool operator <(Fraction pFraction1, Fraction pFraction2)
        {
            (Fraction, Fraction) fractions = MinimunDenominator(pFraction1, pFraction2);
            fractions = CommonDenominator(pFraction1, pFraction2);
            return (fractions.Item1.Numerator < fractions.Item2.Numerator);
        }

        public static bool operator >(Fraction pFraction1, Fraction pFraction2)
        {
            (Fraction, Fraction) fractions = MinimunDenominator(pFraction1, pFraction2);
            fractions = CommonDenominator(pFraction1, pFraction2);
            return (fractions.Item1.Numerator > fractions.Item2.Numerator);
        }

        public static bool operator ==(Fraction pFraction1, Fraction pFraction2) => EqualityComparer<Fraction>.Default.Equals(pFraction1, pFraction2);

        public static bool operator !=(Fraction pFraction1, Fraction pFraction2) => !(pFraction1 == pFraction2);
        #endregion
    }
}
