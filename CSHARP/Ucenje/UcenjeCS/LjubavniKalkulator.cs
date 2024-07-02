
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
        private static int ConvertNumbers(string name1, string name2)
        {
            string combined = "";
            for (int i = 0; i < Math.Max(name1.Length, name2.Length); i++)
            {
                int sum1 = (i < name1.Length) ? CountLetters(name1, name1[i]) + CountLetters(name2, name1[i]) : 0;
                int sum2 = (i < name2.Length) ? CountLetters(name1, name2[i]) + CountLetters(name2, name2[i]) : 0;
                combined += (sum1 + sum2).ToString();
            }
            return int.Parse(CompressDigits(combined));
        }
        private static int CountLetters(string name, char c)
        {
            int count = 0;
            foreach (char letter in name)
            {
                if (letter == c)
                {
                    count++;
                }
            }
            return count;
        }
        private static string CompressDigits(string num)
        {
            string result = "";
            for (int i = 0; i < num.Length / 2; i++)
            {
                int sum = (num[i] - '0') + (num[num.Length - 1 - i] - '0');
                result += sum.ToString();
            }
            if (num.Length % 2 == 1)
            {
                result += num[num.Length / 2];
            }
            return result;
        }
        private static int CalculateLove(int love)
        {
            while (love > 100)
            {
                love = int.Parse(CompressDigits(love.ToString()));
            }
            return love;
        }
    }
}
