
namespace UcenjeCS
{
    internal class E03UvjetnoGranjanjeIf
    {

        public static void Izvedi()
        {
            int i = 8;

            bool uvjet = i == 7;

            Console.WriteLine(uvjet);

            if (uvjet)
            {
                Console.WriteLine("1. Ušao sam u if granu, uvjet je zadovoljen");
            }
            else
            {
                Console.WriteLine("2: Uvjet nije zadovoljen, otišao u else granu");
            }

            if (i > 2)
                Console.WriteLine("3. Ušao u if bez vitičastih zagrada");
            Console.WriteLine("4. ovo se izvodi bez obzira na gornji if");


            var j = 2;

            if (i < 2 && j == 2)
            {
                Console.WriteLine("5. logičko and &");
            }

            if (j == 2 || i < 2)
            {
                Console.WriteLine("6. logičko or |");
            }

            if (i != 5)
            {
                Console.WriteLine("7. i nema vrijednost 5");
            }

            var ocjena = 4;

            if (ocjena == 1)
            {
                Console.WriteLine("8. nedovoljan");
            }
            else if (ocjena == 2)
            {
                Console.WriteLine("9. dovoljan");
            }
            else
            {
                Console.WriteLine("10. Ocjena nije dobra");
            }

            if (ocjena == 4)
            {
                Console.WriteLine("11. Vrlo dobar si");
            }
            else
            {
                Console.WriteLine("12. Ok si");
            }

            Console.WriteLine(ocjena == 4 ? "11. Vrlo dobar si" : "12. Ok si");

            if(i > 0)
            {
                if(ocjena == 4)
                {
                    Console.WriteLine("13. Gnježđenje se može zapravo zamjeniti s &&");
                }
            }
        }

    }
}
