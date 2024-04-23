using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cmd_3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Vytvoření instance třídy Slovnik
            Slovnik slovnik = new Slovnik();

            while (true)
            {
                // Vytvoření proměné příkaz s datovým typem string
                string prikaz = Console.ReadLine();

                // Pokuď je zadáno do konzole Pridat: a nějaká hodnota za tím tak se to uloží 
                if (prikaz.StartsWith("Pridat:"))
                {
                    string slovo = prikaz.Substring(7);
                    slovnik.PridatSlovo(slovo);
                }
                // Když je zadán příkaz Zpet: tak to vrátí na poslední přidanou hodnotu
                else if (prikaz == "Zpet")
                {
                    slovnik.Zpet();
                }
                //Když je zadán příkaz Vpred: tak to vrací hodnotu která byla před použitím zpět
                else if (prikaz == "Vpred")
                {
                    slovnik.Vpred();
                }
                // Když příkaz nepozná vyhodí to hlášku neznámý příkaz
                else
                {
                    slovnik.NeznamyPrikaz();
                }
            }
        }
    }

    class Slovnik
    {
        // Seznam slov
        private List<string> slova;

        // Aktuální index slova v seznamu slov
        private int aktualniIndex;

        // Konstruktor třídy Slovnik
        public Slovnik()
        {
            slova = new List<string>();
            aktualniIndex = -1; // Index -1 znamená, že žádné slovo není aktuální
        }

        // Metoda pro přidání slova do slovníku
        public void PridatSlovo(string slovo)
        {
            slova.Add(slovo); // Přidání slova do seznamu slov
            aktualniIndex = slova.Count - 1; // Nastavení aktuálního indexu na poslední přidané slovo
            Console.WriteLine(slovo); // Vypsání přidaného slova
        }

        // Metoda Zpět
        public void Zpet()
        {
            if (aktualniIndex > 0)
            {
                aktualniIndex--; // Snížení aktuálního indexu o 1
                Console.WriteLine(slova[aktualniIndex]); // Vypsání předchozího slova
            }
            else
            {
                Console.WriteLine(slova[0]); // Pokud je aktuální index 0, vypíše první slovo
            }
        }

        // Metoda Vpřed 
        public void Vpred()
        {
            if (aktualniIndex < slova.Count - 1)
            {
                aktualniIndex++; // Zvýšení aktuálního indexu o 1
                Console.WriteLine(slova[aktualniIndex]); // Vypsání následujícího slova
            }
            else
            {
                Console.WriteLine(slova[slova.Count - 1]); // Pokud je aktuální index poslední, vypíše poslední slovo
            }
        }

        // Metoda Neznámý Příkaz
        public void NeznamyPrikaz()
        {
            Console.WriteLine("Neznamy prikaz"); // Vypsání do konzole když nepozná příkaz
        }
    }
}