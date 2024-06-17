
namespace UcenjeCS
{
    internal class E01Z9
    {
        public static void Izvedi()
        {
            Console.Write("Unesi prvi broj: ");
            var b1 = int.Parse(Console.ReadLine());

            Console.Write("Unesi drugi broj: ");
            var b2 = int.Parse(Console.ReadLine());

            Console.Write("Unesi treci broj: ");
            var b3 = int.Parse(Console.ReadLine());

            Console.WriteLine((b2 - b3) + b1);
        }
    }
}
