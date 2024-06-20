
namespace UcenjeCS
{
    internal class E07WhilePetlja
    {
        public static void Izvedi()
        {
            int brojDo = 1;
            for (int i = 1; i < brojDo; i++)
            {
                Console.WriteLine("Kod u petlji for");
            }

            int b = 1;
            while (b < brojDo)
            {
                Console.WriteLine("Kod u petlji while");
            }

            while (true)
            {
                Console.WriteLine("Kod u beskončnoj petlji while");
                break;
            }

            b = 0;
            while (b < 10)
            {
                Console.WriteLine(++b);
            }

            Console.WriteLine("*********************");

            brojDo = 10;
            b = 1;
            int j = 2;
            while(j > b && j < brojDo)
            {
                Console.WriteLine(j++);
            }
        }
    }
}
