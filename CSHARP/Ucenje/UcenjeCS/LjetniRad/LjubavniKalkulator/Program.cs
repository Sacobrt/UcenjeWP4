
namespace UcenjeCS.LjetniRad.LjubavniKalkulator
{
    internal class Program
    {
        public Program()
        {
            Console.Title = "Ljubavni Kalkulator";
            while (true)
            {
                string name1 = Helpers.StringInput("Unesi svoje ime");
                string name2 = Helpers.StringInput("Unesi ime simpatije");
                int combinedNames = ConvertNumbers(name1.ToLower(), name2.ToLower());

                Console.WriteLine();
                int lovePercentage = CalculateLove(combinedNames);
                if (lovePercentage > 50)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\t" + name1.ToUpper() + " i " + name2.ToUpper() + " imaju šansu za ljubav: " + lovePercentage + "%");
                    Console.WriteLine();
                    Console.WriteLine(" .*.        /~ .~\\    /~  ~\\    /~ .~\\    /~  ~\\\r\n ***       '      `\\/'      *  '      `\\/'      *\r\n  V       (                .*)(               . *)\r\n/\\|/\\      \\            . *./  \\            . *./\r\n  |         `\\ .      . .*/'    `\\ .      . .*/'       .*.\r\n  |           `\\ * .*. */' _    _ `\\ * .*. */'         ***\r\n                `\\ * */'  ( `\\/'*)  `\\ * */'          /\\V\r\n                  `\\/'     \\   */'    `\\/'              |/\\\r\n                            `\\/'                        |\r\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.WriteLine("\t" + name1.ToUpper() + " i " + name2.ToUpper() + " imaju šansu za ljubav: " + lovePercentage + "%");
                    Console.WriteLine();
                    Console.WriteLine("                .-\"\"\"-.    .-\"\"\"-.\r\n               /       `..'       \\\r\n        _     |                    |\r\n     .-' /    |                    |    /////\r\n    <   <======\\                  /====<<<<<\r\n     '-._\\      \\                /      \\\\\\\\\\\r\n                 `\\            /'\r\n                   `\\        /'\r\n                     `\\    /'\r\n                       `\\/'\r\n");
                }

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Želite li još koristiti Ljubavni Kalkulator? (DA/NE): ");
                Console.ForegroundColor = ConsoleColor.White;
                string response = Console.ReadLine().Trim().ToUpper();
                if (response == "NE") break;
            }
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
        private static int CompressDigits(string num)
        {
            while (num.Length > 2)
            {
                string result = "";
                for (int i = 0; i < num.Length - 1; i += 2)
                {
                    int sum = (num[i] - '0') + (num[i + 1] - '0');
                    result += sum.ToString();
                }
                if (num.Length % 2 == 1)
                {
                    result += num[num.Length - 1];
                }
                num = result;
            }
            return int.Parse(num);
        }
        private static int CalculateLove(int love)
        {
            while (love > 100)
            {
                love = CompressDigits(love.ToString());
            }
            return love;
        }
    }
}
