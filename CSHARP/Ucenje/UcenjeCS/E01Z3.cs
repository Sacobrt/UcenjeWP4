
namespace UcenjeCS
{
    internal class E01Z3
    {
        public static void Izvedi()
        {
            int a;
            Console.Write("Unesi broj: ");
            a = int.Parse(Console.ReadLine());

            bool m = a % 2 == 0;
            Console.WriteLine(m);
        }
    }
}
