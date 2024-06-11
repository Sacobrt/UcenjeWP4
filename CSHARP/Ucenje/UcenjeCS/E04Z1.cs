
namespace UcenjeCS
{
    internal class E04Z1
    {
        public static void Izvedi()
        {
            Console.Write("Unesi ocjenu: ");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.WriteLine("Nedovoljan");
                    break;
                case 2:
                    Console.WriteLine("Dovoljan");
                    break;
                case 3:
                    Console.WriteLine("Dobar");
                    break;
                case 4:
                    Console.WriteLine("Vrlo dobar");
                    break;
                case 5:
                    Console.WriteLine("Odličan");
                    break;
                default:
                    Console.WriteLine("Nije definirano");
                    break;
            }
        }
    }
}
