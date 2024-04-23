using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Ukol2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zadej reálnou složku prvního čísla");
            double r = double.Parse(Console.ReadLine());
            Console.WriteLine("Zadej imaginární složku prvního čísla");
            double i = double.Parse(Console.ReadLine());
            ComplexNumber complex1 = new ComplexNumber(r, i);
            ComplexNumber complex2 = new ComplexNumber(r, i);
            Console.WriteLine("Zadej reálnou složku druhého čísla");
            r = double.Parse(Console.ReadLine());
            Console.WriteLine("Zadej imaginární složku druhého čísla");
            i = double.Parse(Console.ReadLine());

            complex1.Add(new ComplexNumber(r,i));
            Console.WriteLine("sčítání " + complex1);
            complex2.Subtract(new ComplexNumber(r, i));
            Console.WriteLine("odčítání "+ complex2);
            Console.Read();
        }

    }
    class ComplexNumber
    {
        public double real;
        public double imaginary;
        public ComplexNumber(double Real, double Imaginary)
        {
            real = Real;
            imaginary = Imaginary;
        }
        public void Add(ComplexNumber other)
        {
            real += other.real;
            imaginary += other.imaginary;
        }
        public void Subtract(ComplexNumber other)
        {
            real -= other.real;
            imaginary -= other.imaginary;
        }

        public override string ToString()
        {
            return $"reálná část = {real}, imaginární část = {imaginary}";
        }
    }
}
