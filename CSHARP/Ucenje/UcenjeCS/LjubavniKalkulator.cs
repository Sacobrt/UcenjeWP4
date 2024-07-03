
namespace UcenjeCS
{
    internal class LjubavniKalkulator
    {
        public static void Izvedi()
        {
            Console.Title = "Ljubavni Kalkulator";
            do
            {
                string name1 = Pomocno.UcitajString("Unesi svoje ime");
                string name2 = Pomocno.UcitajString("Unesi ime simpatije");
                int combinedNames = ConvertNumbers(name1.ToLower(), name2.ToLower());

                Console.WriteLine();
                if (CalculateLove(combinedNames) > 50)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t" + name1.ToUpper() + " i " + name2.ToUpper() + " imaju šansu za ljubav: " + CalculateLove(combinedNames) + "%");
                    Console.WriteLine();
                    Console.WriteLine(" .*.        /~ .~\\    /~  ~\\    /~ .~\\    /~  ~\\\r\n ***       '      `\\/'      *  '      `\\/'      *\r\n  V       (                .*)(               . *)\r\n/\\|/\\      \\            . *./  \\            . *./\r\n  |         `\\ .      . .*/'    `\\ .      . .*/'       .*.\r\n  |           `\\ * .*. */' _    _ `\\ * .*. */'         ***\r\n                `\\ * */'  ( `\\/'*)  `\\ * */'          /\\V\r\n                  `\\/'     \\   */'    `\\/'              |/\\\r\n                            `\\/'                        |\r\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine("\t" + name1.ToUpper() + " i " + name2.ToUpper() + " imaju šansu za ljubav: " + CalculateLove(combinedNames) + "%");
                    Console.WriteLine();
                    Console.WriteLine("                .-\"\"\"-.    .-\"\"\"-.\r\n               /       `..'       \\\r\n        _     |                    |\r\n     .-' /    |                    |    /////\r\n    <   <======\\                  /====<<<<<\r\n     '-._\\      \\                /      \\\\\\\\\\\r\n                 `\\            /'\r\n                   `\\        /'\r\n                     `\\    /'\r\n                       `\\/'\r\n");
                }
            } while (Pomocno.UcitajString("Za prekid aplikacije - q") != "q");
        }
        private static int ConvertNumbers(string name1, string name2, int index = 0, string combined = "")
        {
            if (index >= Math.Max(name1.Length, name2.Length))
            {
                return CompressDigits(combined);
            }
            int sum1 = (index < name1.Length) ? name1.Count(c => c == name1[index]) + name2.Count(c => c == name1[index]) : 0;
            int sum2 = (index < name2.Length) ? name1.Count(c => c == name2[index]) + name2.Count(c => c == name2[index]) : 0;
            combined += (sum1 + sum2).ToString();
            return ConvertNumbers(name1, name2, index + 1, combined);
        }
        private static int CompressDigits(string num, string result = "")
        {
            if (num.Length <= 2)
            {
                return int.Parse(num);
            }
            for (int i = 0; i < num.Length / 2; i++)
            {
                int sum = (num[i] - '0') + (num[num.Length - 1 - i] - '0');
                result += sum.ToString();
            }
            if (num.Length % 2 == 1)
            {
                result += num[num.Length / 2];
            }
            return CompressDigits(result);
        }
        private static int CalculateLove(int love)
        {
            if (love <= 100)
            {
                return love;
            }
            return CalculateLove(CompressDigits(love.ToString()));
        }
    }
}
