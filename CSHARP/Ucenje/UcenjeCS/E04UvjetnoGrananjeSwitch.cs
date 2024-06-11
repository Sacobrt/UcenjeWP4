
namespace UcenjeCS
{
    internal class E04UvjetnoGrananjeSwitch
    {
        public static void Izvedi()
        {
            int i = 0;

            switch (i)
            {
                case 0:
                    Console.WriteLine("DOBAR");
                    break;
                case 1:
                    Console.WriteLine("LOŠ");
                    break;
                case 2:
                    Console.WriteLine("ZAO");
                    break;
                default:
                    Console.WriteLine("Nije definirano");
                    break;
            }
        }
    }
}
