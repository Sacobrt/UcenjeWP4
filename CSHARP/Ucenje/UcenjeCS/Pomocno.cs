
using System.Text.RegularExpressions;

namespace UcenjeCS
{
    internal class Pomocno
    {
        public static int UcitajCijeliBroj()
        {
            while (true)
            {
                try
                {
                    Console.Write("Unesi cijeli broj: ");
                    return int.Parse(Console.ReadLine());
                }
                catch // i ne mora se staviti Exception
                {
                    Console.WriteLine("Pogreška prilikom unosa!");
                }
            }
        }

        public static int UcitajCijeliBroj(string poruka)
        {
            while (true)
            {
                try
                {
                    Console.Write(poruka + ": ");
                    return int.Parse(Console.ReadLine());
                }
                catch // i ne mora se staviti Exception
                {
                    Console.WriteLine("Pogreška prilikom unosa!");
                }
            }
        }

        public static int UcitajCijeliBroj(string poruka, int min, int max)
        {
            int i;
            while (true)
            {
                Console.Write(poruka + ": ");
                if (int.TryParse(Console.ReadLine(), out i) && i >= min && i <= max)
                {
                    return i;
                }
                Console.WriteLine("Broj mora biti od " + min + " do " + max + "!");
            }
        }

        public static string UcitajString(string poruka)
        {
            while (true)
            {
                Console.Write(poruka + ": ");
                string s = Console.ReadLine();

                if (string.IsNullOrEmpty(s))
                {
                    Console.WriteLine("Polje ne može biti prazno!");
                    continue;
                }
                else if (!Regex.IsMatch(s, @"^[a-zA-Z]+$"))
                {
                    Console.WriteLine("Unos smije sadržavati samo slova!");
                    continue;
                }
                return s;
            }
        }
    }
}
