
namespace UcenjeCS
{
    internal class E03Z1
    {
        public static void Izvedi()
        {
            int godina;
            Console.Write("Unesi koliko godina imas: ");
            godina = int.Parse(Console.ReadLine());

            if(godina >= 18)
            {
                Console.WriteLine("Punoljetan si");
            }
            else
            {
                Console.WriteLine("Nisi punoljetan");
            }
        }
    }
}
