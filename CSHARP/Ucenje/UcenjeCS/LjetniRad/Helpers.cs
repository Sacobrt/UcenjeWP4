
using System.Text.RegularExpressions;

namespace UcenjeCS.LjetniRad
{
    internal class Helpers
    {
        public static bool DEV = false;
        public static string EmailInput(string poruka, int max, bool obavezno)
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
        public static string EmailInput(string? stara, string poruka, int max, bool obavezno)
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
        public static string StringInput(string poruka)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(poruka + ": ");
                Console.ForegroundColor = ConsoleColor.White;
                string s = Console.ReadLine();

                if (string.IsNullOrEmpty(s))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Polje ne može biti prazno!");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                else if (!Regex.IsMatch(s, @"^[a-zA-Z]+$"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Unos smije sadržavati samo slova!");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                return s;
            }
        }
        public static string StringInput(string poruka, int max)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(poruka + ": ");
                Console.ForegroundColor = ConsoleColor.White;
                string s = Console.ReadLine();

                if (string.IsNullOrEmpty(s))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Polje ne može biti prazno!");
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                if (s.Length == 0 || s.Length > max)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Unos obavezan, maksimalno dozvoljeno {0} znakova", max);
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                return s;
            }
        }
        public static string StringInput(string? stara, string poruka, int max, bool obavezno)
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
        public static string PasswordInput(string? stara, string poruka, int min, int max, bool obavezno)
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
                if ((obavezno && s.Length == 0) || s.Length < min || s.Length > max)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Lozinka mora imati minimalno {0} te {1} maksimalno znakova!", min, max);
                    Console.ForegroundColor = ConsoleColor.White;
                    continue;
                }
                return s;
            }
        }
        public static bool BoolInput(string poruka, string trueValue)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(poruka + ": ");
            Console.ForegroundColor = ConsoleColor.White;
            return Console.ReadLine().Trim().ToLower() == trueValue;
        }
        internal static DateTime DateInput(DateTime? date, string poruka, bool kontrolaPrijeDanasnjegDatuma)
        {
            DateTime d;
            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Format unosa je yyyy-MM-dd, za današnji datum {0}", DateTime.Now.ToString("yyyy-MM-dd"));
                    Console.ForegroundColor = ConsoleColor.White;

                    if (kontrolaPrijeDanasnjegDatuma)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Uneseni datum ne smije biti prije današnjeg datuma!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(poruka + " (" + (date.HasValue ? date.Value.ToString("yyyy-MM-dd") : "nema") + "): ");
                    Console.ForegroundColor = ConsoleColor.White;

                    string input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input))
                    {
                        if (date.HasValue)
                        {
                            return date.Value;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Polje ne može biti prazno ako datum nije već definiran!");
                            Console.ForegroundColor = ConsoleColor.White;
                            continue;
                        }
                    }

                    d = DateTime.ParseExact(input, "yyyy-MM-dd", null);

                    if (kontrolaPrijeDanasnjegDatuma && d < DateTime.Now.Date)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Uneseni datum ne smije biti prije današnjeg datuma!");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }

                    return d;
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Unos datuma nije dobar");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        public static int NumberInput(string poruka, int min, int max)
        {
            int i;
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(poruka + ": ");
                Console.ForegroundColor = ConsoleColor.White;
                if (int.TryParse(Console.ReadLine(), out i) && i >= min && i <= max)
                {
                    return i;
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Broj mora biti od " + min + " do " + max + "!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        public static int NumberInput()
        {
            while (true)
            {
                try
                {
                    Console.Write("Unesi cijeli broj: ");
                    return int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Pogreška prilikom unosa!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        public static int NumberInput(string poruka)
        {
            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(poruka + ": ");
                    Console.ForegroundColor = ConsoleColor.White;
                    return int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Pogreška prilikom unosa!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        public static int NumberInput(int? ID, string poruka, int min, int max)
        {
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(poruka + " (" + ID + "): ");
                Console.ForegroundColor = ConsoleColor.White;

                string input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    if (ID.HasValue)
                    {
                        return ID.Value;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Polje ne može biti prazno ako ID nije već definiran!");
                        Console.ForegroundColor = ConsoleColor.White;
                        continue;
                    }
                }

                if (int.TryParse(input, out int i) && i >= min && i <= max)
                {
                    return i;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Broj mora biti od " + min + " do " + max + "!");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        internal static DateTime DateInput(string poruka, bool control)
        {
            DateTime d;
            while (true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Format unosa je yyyy-MM-dd, za današnji datum {0}",
                        DateTime.Now.ToString("yyyy-MM-dd"));
                    Console.ForegroundColor = ConsoleColor.White;
                    if (control)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Uneseni datum ne smije biti prije današnjeg datuma!");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(poruka + ": ");
                    Console.ForegroundColor = ConsoleColor.White;
                    d = DateTime.Parse(Console.ReadLine());
                    if (control && d < DateTime.Now)
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
    }
}
