
namespace UcenjeCS
{
    internal class E07Z1
    {
        public static void Izvedi()
        {
            // Program od korisnika unosi cijeli broj
            // Koristeći while petlju program ispisuje 
            // zbroj svih parnih brojeva od 1 do unesenog broja (skupa s njim)
            // unos 10 ispis 30
            // unos 12 ispis 42

            Console.Write("Unesite cijeli broj: ");
            int b = int.Parse(Console.ReadLine());
            int i = 1;
            int a = 0;

            while (i <= b)
            {
                if (i % 2 == 0)
                {
                    a += i;
                }
                i++;
            }
            Console.WriteLine(a);
        }
    }
}
