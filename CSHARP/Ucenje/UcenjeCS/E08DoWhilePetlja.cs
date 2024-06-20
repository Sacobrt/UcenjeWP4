
namespace UcenjeCS
{
    internal class E08DoWhilePetlja
    {
        public static void Izvedi()
        {
            int i = 0;

            do
            {
                Console.WriteLine(i);
            }
            while (i > 0);

            while(i > 0)
            {
                Console.WriteLine("u while " + i);
            }
        }
    }
}
