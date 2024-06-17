
namespace UcenjeCS
{
    internal class E01Z6
    {
        public static void Izvedi()
        {
            Console.Write("Unesi ime grada: ");
            var a = Console.ReadLine();

            Console.Write("Unesi broj stanovnika: ");
            var b = Console.ReadLine();

            Console.WriteLine("U {0} živi {1} ljudi.", a, b);
        }
    }
}
