using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cmd_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Zadejte čísla oddělená čárkou: ");
                string a = Console.ReadLine();
                string[] hodnoty = a.Split(',');
                int[] cisla = new int[hodnoty.Length];

                bool validInput = true;

                for (int i = 0; i < hodnoty.Length; i++)
                {
                    if (!int.TryParse(hodnoty[i], out cisla[i]))
                    {
                        Console.WriteLine("Zadejte pouze celá čísla.");
                        validInput = false;
                        break;
                    }
                }

                if (!validInput)
                    continue;

                Console.WriteLine("Největší číslo: " + cisla.Max());
                Console.WriteLine("Nejmenší číslo: " + cisla.Min());

                int postupka = 1;
                int nejdelsiPostupka = 1;

                for (int i = 1; i < cisla.Length; i++)
                {
                    if (cisla[i] > cisla[i - 1])
                    {
                        postupka++;
                        if (postupka > nejdelsiPostupka)
                            nejdelsiPostupka = postupka;
                    }
                    else
                    {
                        postupka = 1;
                    }
                }

                Console.WriteLine("Délka nejdelšího vzestupného intervalu: " + nejdelsiPostupka);
                Console.ReadLine();
            }
        }
    }
}