
using System;

namespace ArithmeticOperatorDTO
{
    public class DTO
    {
        public string Date { get; set; }
        public string Fraction1 { get; set; }
        public string Fraction2 { get; set; }
        public string Result { get; set; }
        public string Operative { get; set; }
        public string OperativeType { get; set; }

        public DTO() { }
        
        public DTO(string pFraction1, string pFraction2, string pResult, string pOperative, string pOperativeType)
        {
            Fraction1 = $"{pFraction1}";
            Fraction2 = $"{pFraction2}";
            Result = $"{pResult}";
            Operative = pOperative;
            OperativeType = pOperativeType;
        }
    }
}
