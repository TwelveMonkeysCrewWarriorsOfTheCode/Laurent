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
        public Fraction() {}

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

        public Fraction(int pNumerator, int pDenominator)
        {
            if(pDenominator == 0) throw new ArgumentException("Denominator == 0");            
            this.NegativeVerification(pNumerator, pDenominator);
            Integer = Numerator / Denominator;
            Numerator %= Denominator;                       
        }

        public Fraction(int pIntNum, int pNumerator, int pDenominator)
        {
            if (pDenominator == 0) throw new ArgumentException("Denominator == 0");
            this.NegativeVerification(pNumerator, pDenominator);
            Integer = pIntNum;
        }

        /// <summary>
        /// Transforme une décimal en fraction
        /// </summary>
        /// <param name="pFractionFloat"></param>
        public Fraction(decimal pFractionFloat)
        {
            int i = 0;
            Numerator = 1;
            while(pFractionFloat % 1 == 0 || i == 7)
            {
                pFractionFloat *= 10;
                Numerator *= 10;
            }
            string fraction = Convert.ToString(pFractionFloat);
            int indexPoint = fraction.IndexOf('.');
            fraction = fraction.Substring(0, '.');
            Denominator = Convert.ToInt32(fraction);
            this.MinimunDenominator();
        }
        #endregion

        #region Methods        
        /// <summary>
        /// Crée un nouvel objet Fraction avec le dénominateur commum de 2 Fractions
        /// par 
        /// </summary>
        /// <param name="pFractionLeft"></param>
        /// <param name="pFractionRight"></param>
        /// <returns>Object Fraction</returns>
        public static Fraction CommonDenominator(Fraction pFractionLeft, Fraction pFractionRight)
        {
            Fraction FractionCommunDenominator = new()
            {
                Numerator = ((pFractionLeft.Numerator + (pFractionLeft.Integer * pFractionLeft.Denominator)) * pFractionRight.Denominator),
                Denominator = (pFractionLeft.Denominator * pFractionRight.Denominator)                                            
            };
            return FractionCommunDenominator;
        }

        /// <summary>
        /// Divise le numérateur et dénominateur avec le plus grand diviseur commun
        /// pour simplifier la fraction
        /// </summary>
        private void MinimunDenominator()
        {
            int i = 1;
            int maxDivider = 1;
            while (i <= Denominator && i <= Numerator)
            {
                if (Denominator % i == 0 && Numerator % i == 0) maxDivider = i;
                i++;
            }
            Numerator /= maxDivider;
            Denominator /= maxDivider;
        }

        /// <summary>
        /// Gère les signes négatif de la fraction 
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
                Fraction Fraction1 = CommonDenominator(this, other);
                Fraction Fraction2 = CommonDenominator(other, this);
                return Fraction1.Numerator - Fraction2.Numerator;
            }
        }

        public override bool Equals(object other) => Equals(other as Fraction);


        public bool Equals(Fraction other)
        {
            Fraction Fraction1 = CommonDenominator(this, other);
            Fraction Fraction2 = CommonDenominator(other, this);

            return (other != null && Fraction1.Numerator == Fraction2.Numerator);
        }

        public override int GetHashCode() => Numerator.GetHashCode() ^ Denominator.GetHashCode();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString() => (Integer != 0) ? $"{Integer} : {Numerator}/{Denominator}" : $" {Numerator}/{Denominator}";
        #endregion

        #region Operators
        public static explicit operator decimal(Fraction pFraction) => ((decimal)pFraction.Numerator / pFraction.Denominator) + pFraction.Integer;

        public static Fraction operator +(Fraction pFraction1, Fraction pFraction2)
        {
            Fraction Fraction1 = CommonDenominator(pFraction1, pFraction2);
            Fraction Fraction2 = CommonDenominator(pFraction2, pFraction1);
            Fraction FractionResult = new(Fraction1.Numerator + Fraction2.Numerator, Fraction1.Denominator);
            FractionResult.MinimunDenominator();
            return FractionResult;
        }

        public static Fraction operator -(Fraction pFraction1, Fraction pFraction2)
        {
            Fraction Fraction1 = CommonDenominator(pFraction1, pFraction2);
            Fraction Fraction2 = CommonDenominator(pFraction2, pFraction1);
            Fraction FractionResult = new(Fraction1.Numerator - Fraction2.Numerator, Fraction1.Denominator);
            FractionResult.MinimunDenominator();
            return FractionResult;
        }

        public static Fraction operator *(Fraction pFraction1, Fraction pFraction2)
        {
            Fraction FractionResult = new(pFraction1.Numerator * pFraction2.Numerator, pFraction1.Denominator * pFraction2.Denominator);
            FractionResult.MinimunDenominator();
            return FractionResult;
        }

        public static Fraction operator /(Fraction pFraction1, Fraction pFraction2)
        {
            if(pFraction1.Numerator == 0 || pFraction2.Numerator == 0) throw new ArgumentException("Numerator == 0 for a division");
            Fraction FractionResult = new(pFraction1.Numerator * pFraction2.Denominator, pFraction1.Denominator * pFraction2.Numerator);
            FractionResult.MinimunDenominator();
            return FractionResult;
        }

        public static bool operator <(Fraction pFraction1, Fraction pFraction2)
        {
            Fraction Fraction1 = CommonDenominator(pFraction1, pFraction2);
            Fraction Fraction2 = CommonDenominator(pFraction2, pFraction1);

            bool equalityResult = (Fraction1.Numerator < Fraction2.Numerator);

            return equalityResult;
        }

        public static bool operator >(Fraction pFraction1, Fraction pFraction2)
        {
            Fraction Fraction1 = CommonDenominator(pFraction1, pFraction2);
            Fraction Fraction2 = CommonDenominator(pFraction2, pFraction1);

            bool equalityResult = (Fraction1.Numerator > Fraction2.Numerator);

            return equalityResult;
        }

        public static bool operator ==(Fraction pFraction1, Fraction pFraction2) => EqualityComparer<Fraction>.Default.Equals(pFraction1, pFraction2);

        public static bool operator !=(Fraction pFraction1, Fraction pFraction2) => !(pFraction1 == pFraction2);
        #endregion
    }
}
