using System;

namespace UsingParameters
{
    class Program
    {
        static void Main(string[] args)
        {
            // Exemple de passage de paramètres avec des variables de type valeur
            int value1, value2;
            value1 = 8;
            value2 = 2;
            int result = Add(ref value1, ref value2);
            string s = "Le résultat de l'addition des valeurs " + value1 + " et " + value2 + " est " + result;
            Console.WriteLine(s);
            Console.WriteLine($"Le résultat de l'addition des valeurs {value1} et {value2} est {result}");
            Console.WriteLine();


            Console.WriteLine("Calcules avec la classe Time :");
            Time time1, time2, timeResult;
            int entier;

            time1 = new Time(4, 50);
            time2 = new Time(3, 25);
            timeResult = time1 + time2;
            Console.WriteLine($"{time1} + {time2} = {timeResult}");

            time1 = new Time(4, 50);
            time2 = new Time(3, 25);
            timeResult = time1 - time2;
            Console.WriteLine($"{time1} - {time2} = {timeResult}");

            time1 = new Time(4, 50);
            time2 = new Time(2, 55);
            timeResult = time1 - time2;
            Console.WriteLine($"{time1} - {time2} = {timeResult}");

            time1 = new Time(3, 25);
            time2 = new Time(4, 50);
            timeResult = time1 - time2;
            Console.WriteLine($"{time1} - {time2} = {timeResult}");

            time1 = new Time(3, 25);
            entier = 3;
            timeResult = time1 * entier;
            Console.WriteLine($"{time1} * {entier} = {timeResult}");

            time1 = new Time(10, 15);
            entier = 3;
            timeResult = time1 / entier;
            Console.WriteLine($"{time1} / {entier} = {timeResult}");

            time1 = new Time(40, 0);
            entier = 3;
            timeResult = time1 / entier;
            Console.WriteLine($"{time1} / {entier} = {timeResult}");

            time1 = new Time(40, 30);
            entier = 3;
            timeResult = time1 / entier;
            Console.WriteLine($"{time1} / {entier} = {timeResult}");


            Console.WriteLine();
            Console.WriteLine("Casting avec la classe Time :");
            float floatValue;

            time1 = new Time(3, 15);
            entier = (int)time1;
            Console.WriteLine($"{time1} => {entier}");

            time1 = new Time(3, 45);
            floatValue = (float)time1;
            Console.WriteLine($"{time1} => {floatValue}f");

            entier = 150;
            time1 = (Time)entier;
            Console.WriteLine($"{entier} => {time1}");

            floatValue = 3.16666f;
            time1 = (Time)floatValue;
            Console.WriteLine($"{floatValue}f => {time1}");
    }

    private static int Add(ref int pLeftValue, ref int pRightValue)
        {
            pLeftValue = pLeftValue * 10;
            pRightValue *= 10;
            int result = pLeftValue + pRightValue;
            return result;
        }
    }
}
