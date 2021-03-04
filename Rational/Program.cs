using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RationalNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Rational q1 = new Rational(-1, 2);
            Console.WriteLine(q1);
            Rational q2 = new Rational(-4, 5);
            Console.WriteLine(q2);
            Rational q3 = new Rational(10, 5);
            Console.WriteLine(q3);
            Rational q4 = new Rational(4, -2);
            Console.WriteLine(q4);
            Rational q5 = new Rational(-1, -2);
            Console.WriteLine(q5);
            Rational q6 = new Rational(0, 2);
            Console.WriteLine(q6);
            Rational q7 = new Rational(2, 0);
            Console.WriteLine(q7);
            Console.WriteLine();

            Rational suma = q1.Add(q2);
            Console.WriteLine($"{q1} + {q2} = {suma}");
            Console.WriteLine($"{q1} + {q2} = {q1 + q2}");

            Rational sub = q1.Substract(q2);
            Console.WriteLine($"{q1} - {q2} = {sub}");
            Console.WriteLine($"{q1} - {q2} = {q1 - q2}");

            Console.WriteLine();

        }
    }
}
