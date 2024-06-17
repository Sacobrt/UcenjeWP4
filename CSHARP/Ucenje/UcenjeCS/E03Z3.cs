
namespace UcenjeCS
{
    internal class E03Z3
    {
        public static void Izvedi()
        {
            Console.Write("Unesi prvi broj: ");
            var b1 = int.Parse(Console.ReadLine());

            Console.Write("Unesi drugi broj: ");
            var b2 = int.Parse(Console.ReadLine());

            Console.Write("Unesi treći broj: ");
            var b3 = int.Parse(Console.ReadLine());

            if (b1 < b2 && b1 < b3)
                Console.WriteLine(b1);
            else if (b2 < b1 && b2 < b3)
                Console.WriteLine(b2);
            else if (b3 < b1 && b3 < b2)
                Console.WriteLine(b3);
            else
                Console.WriteLine(b1);
        }
    }
}
