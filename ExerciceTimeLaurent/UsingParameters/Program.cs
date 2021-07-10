using System;

namespace UsingParameters
{
    class Program
    {
        //Exemple de passage de paramètre avec des variables de type valeur
        static void Main(string[] args)
        {
            Time Time1, Time2;           
            int time1Hour = 16;
            int time1Minute = 45;
            int time2Hour = 10;
            int time2Minute = 45;
            int numDivOrMult = 8;
            int timeInt = 786;
            int modulo = 60;
            float timeFloat = 16.583334f;

            Console.WriteLine(Time1);

            Time1 = new Time(time1Hour, time1Minute);
            Time2 = new Time(time2Hour, time2Minute);

            //Resultat de Time1 + Time2  
            Console.WriteLine($"{Time1} + {Time2} = {Time1 + Time2}");
            //Resultat de Time1 - Time2
            Console.WriteLine($"{Time1} - {Time2} = {Time1 - Time2}");
            //Resultat de Time1 * Time2
            Console.WriteLine($"{Time1} * {numDivOrMult} = {Time1 * numDivOrMult}");
            //Resultat de Time1 / Time2
            Console.WriteLine($"{Time1} - {numDivOrMult} = {Time1 / numDivOrMult}");
            //Resultat d'un int transformé en Time
            Console.WriteLine($"int : {timeInt} => Time : {(Time)timeInt}");
            //Resultat d'un Time transformé en int
            Console.WriteLine($"time : {Time1} => int : {(int)Time1}");
            //Resultat d'un float transformé en Time
            Console.WriteLine($"float : {timeFloat} => Time : {(Time)timeFloat}");
            //Resultat d'un Time transformé en float
            Console.WriteLine($"Time : {Time1} => float : {(float)Time1}");
            //Resultat de Time1 > Time2
            Console.WriteLine($"{Time1} > {Time2} = {Time1 > Time2}");
            //Resultat de Time1 < Time2
            Console.WriteLine($"{Time1} < {Time2} = {Time1 < Time2}");
            //Resultat de Time1 >= Time2
            Console.WriteLine($"{Time1} >= {Time2} = {Time1 >= Time2}");
            //Resultat de Time1 <= Time2
            Console.WriteLine($"{Time1} <= {Time2} = {Time1 <= Time2}");
            //Resultat de Time1 == Time2
            Console.WriteLine($"{Time1} {Time1 == Time2} {Time2}");
            //Resultat de Time1 != Time2
            Console.WriteLine($"{Time1} {Time1 != Time2} {Time2}");
            //Result de % d'un Time
            Console.WriteLine($"{Time1} % {modulo} = {Time1 % modulo}");
            Console.WriteLine($"dd {8/60}");
        }
    }
}
