
using System.Text;

namespace UcenjeCS.LjetniRad.GeneratorLozinki
{
    internal class Program
    {
        public Program()
        {
            var passwordOptions = GetPasswordOptions();
            var generatedPasswords = GeneratePasswords(passwordOptions);
            DisplayPasswords(generatedPasswords);
        }
        private static PasswordOptions GetPasswordOptions()
        {
            int passwordLength = Helpers.NumberInput("Dužina lozinke", 5, 100);
            bool capitalLetters = Helpers.BoolInput("Uključena velika slova (DA/NE)", "da");
            bool smallLetters = Helpers.BoolInput("Uključena mala slova (DA/NE)", "da");
            bool numbers = Helpers.BoolInput("Uključeni brojevi (DA/NE)", "da");
            bool punctuation = Helpers.BoolInput("Uključeni interpunkcijski znakovi (DA/NE)", "da");

            bool startWithNumber = Helpers.BoolInput("Lozinka počinje s brojem (DA/NE)", "da");
            bool startWithPunctuation = !startWithNumber && Helpers.BoolInput("Lozinka počinje s interpunkcijskim znakom (DA/NE)", "da");

            bool endWithNumber = Helpers.BoolInput("Lozinka završava s brojem (DA/NE)", "da");
            bool endWithPunctuation = !endWithNumber && Helpers.BoolInput("Lozinka završava s interpunkcijskim znakom (DA/NE)", "da");

            bool noRepeatingSigns = Helpers.BoolInput("Lozinka nema ponavljajuće znakove (DA/NE)", "da");
            int passwordCount = Helpers.NumberInput("Broj lozinki koje je potrebno generirati", 1, 5000);

            return new PasswordOptions(passwordLength, capitalLetters, smallLetters, numbers, punctuation, startWithNumber, startWithPunctuation, endWithNumber, endWithPunctuation, noRepeatingSigns, passwordCount);
        }
        private static List<string> GeneratePasswords(PasswordOptions options)
        {
            var generatedPasswords = new List<string>();
            for (int i = 0; i < options.PasswordCount; i++)
            {
                var password = GeneratePassword(options);
                generatedPasswords.Add(password);
            }
            return generatedPasswords;
        }
        private static string GeneratePassword(PasswordOptions options)
        {
            var characterSet = new StringBuilder();
            var random = new Random();

            if (options.CapitalLetters) characterSet.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            else characterSet.Append(random.Next(2) == 0 ? "abcdefghijklmnopqrstuvwxyz" : "ABCDEFGHIJKLMNOPQRSTUVWXYZ");

            if (options.SmallLetters) characterSet.Append("abcdefghijklmnopqrstuvwxyz");

            if (options.Numbers) characterSet.Append("0123456789");
            else characterSet.Append(random.Next(2) == 0 ? "!@#$%^&*()_+-=[]{}|;:'\",.<>?" : "0123456789");

            if (options.Punctuation) characterSet.Append("!@#$%^&*()_+-=[]{}|;:'\",.<>?");
            else characterSet.Append(random.Next(2) == 0 ? "0123456789" : "!@#$%^&*()_+-=[]{}|;:'\",.<>?");

            var characters = characterSet.ToString();
            var password = new char[options.PasswordLength];
            var usedCharacters = new HashSet<char>();

            password[0] = options.StartWithNumber ? GetRandomCharacter("0123456789") : options.StartWithPunctuation ? GetRandomCharacter("!@#$%^&*()_+-=[]{}|;:'\",.<>?") : GetRandomCharacter(characters);
            usedCharacters.Add(password[0]);
            password[options.PasswordLength - 1] = options.EndWithNumber ? GetRandomCharacter("0123456789") : options.EndWithPunctuation ? GetRandomCharacter("!@#$%^&*()_+-=[]{}|;:'\",.<>?") : GetRandomCharacter(characters);
            usedCharacters.Add(password[options.PasswordLength - 1]);

            for (int i = 1; i < options.PasswordLength - 1; i++)
            {
                char nextChar;
                do
                {
                    nextChar = GetRandomCharacter(characters);
                } while (options.NoRepeatingSigns && usedCharacters.Contains(nextChar));

                password[i] = nextChar;
                usedCharacters.Add(nextChar);
            }
            return new string(password);
        }
        private static char GetRandomCharacter(string characters)
        {
            var random = new Random();
            return characters[random.Next(characters.Length)];
        }
        private static void DisplayPasswords(List<string> passwords)
        {
            for (int i = 0; i < passwords.Count; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[{i + 1}] {passwords[i]}");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
    internal class PasswordOptions
    {
        public int PasswordLength { get; }
        public bool CapitalLetters { get; }
        public bool SmallLetters { get; }
        public bool Numbers { get; }
        public bool Punctuation { get; }
        public bool StartWithNumber { get; }
        public bool StartWithPunctuation { get; }
        public bool EndWithNumber { get; }
        public bool EndWithPunctuation { get; }
        public bool NoRepeatingSigns { get; }
        public int PasswordCount { get; }

        public PasswordOptions(int passwordLength, bool capitalLetters, bool smallLetters, bool numbers, bool punctuation, bool startWithNumber, bool startWithPunctuation, bool endWithNumber, bool endWithPunctuation, bool noRepeatingSigns, int passwordCount)
        {
            PasswordLength = passwordLength;
            CapitalLetters = capitalLetters;
            SmallLetters = smallLetters;
            Numbers = numbers;
            Punctuation = punctuation;
            StartWithNumber = startWithNumber;
            StartWithPunctuation = startWithPunctuation;
            EndWithNumber = endWithNumber;
            EndWithPunctuation = endWithPunctuation;
            NoRepeatingSigns = noRepeatingSigns;
            PasswordCount = passwordCount;
        }
    }
}
