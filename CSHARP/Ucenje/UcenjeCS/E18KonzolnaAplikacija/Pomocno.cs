
namespace UcenjeCS.E18KonzolnaAplikacija
{
    internal class Pomocno
    {
        public static bool DEV = false;
        internal static bool UcitajBool(string poruka, string trueValue)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(poruka + ": ");
            Console.ForegroundColor = ConsoleColor.White;
            return Console.ReadLine().Trim().ToLower() == trueValue;
        }
        internal static DateTime UcitajDatum(string poruka, bool kontrolaPrijeDanasnjegDatuma)
        {
            DateTime d;
            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Format unosa je yyyy-MM-dd, za današnji datum {0}",
                        DateTime.Now.ToString("yyyy-MM-dd"));
                    Console.ForegroundColor = ConsoleColor.White;
                    if (kontrolaPrijeDanasnjegDatuma)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Uneseni datum ne smije biti prije današnjeg datuma!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(poruka + ": ");
                    Console.ForegroundColor = ConsoleColor.White;
                    d = DateTime.Parse(Console.ReadLine());
                    if (kontrolaPrijeDanasnjegDatuma && d < DateTime.Now)
                    {
                        throw new Exception();
                    }
                    return d;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Unos datuma nije dobar");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        internal static float UcitajDecimalniBroj(string poruka, int min, float max)
        {
            float b;
            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(poruka + ": ");
                    Console.ForegroundColor = ConsoleColor.White;
                    b = float.Parse(Console.ReadLine());
                    if (b < min || b > max)
                    {
                        throw new Exception();
                    }
                    return b;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Decimalni broj mora biti u rasponu {0} i {1}", min, max);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        internal static int UcitajRasponBroja(string poruka, int min, int max)
        {
            int b;
            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(poruka + ": ");
                    Console.ForegroundColor = ConsoleColor.White;
                    b = int.Parse(Console.ReadLine());
                    if (b < min || b > max)
                    {
                        throw new Exception();
                    }
                    return b;
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Unos nije dobar, unos mora biti u rasponu {0} do {1}", min, max);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        internal static string UcitajString(string poruka, int max, bool obavezno)
        {
            string s;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(poruka + ": ");
                Console.ForegroundColor = ConsoleColor.White;
                s = Console.ReadLine().Trim();
                if ((obavezno && s.Length == 0) || s.Length > max)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Unos obavezan, maksimalno dozvoljeno {0} znakova", max);
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                return s;
            }
        }
        internal static string UcitajString(string stara, string poruka, int max, bool obavezno)
        {
            string s;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(poruka + " (" + stara + "): ");
                Console.ForegroundColor = ConsoleColor.White;
                s = Console.ReadLine().Trim();
                if (s.Length == 0)
                {
                    return stara;
                }
                if ((obavezno && s.Length == 0) || s.Length > max)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Unos obavezan, maksimalno dozvoljeno {0} znakova", max);
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                return s;
            }
        }
    }
}
