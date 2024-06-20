
namespace UcenjeCS
{
    internal class E10TryCatch
    {
        public static void Izvedi()
        {
            int i;
            while (true)
            {
                Console.Write("Unesi cijeli pozitivni broj: ");
                try
                {
                    i = int.Parse(Console.ReadLine());
                    if (i > 0 && i < 100)
                    {
                        break;
                    }
                    Console.WriteLine("Uneseni broj nije veći od 0 i manji od 100");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Niste unijeli cijeli pozitivni broj.");
                }
            }

            Console.WriteLine("Unijeli ste broj " + i);
        }
    }
}
