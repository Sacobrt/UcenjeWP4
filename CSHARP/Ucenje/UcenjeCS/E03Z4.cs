
namespace UcenjeCS
{
    internal class E03Z4
    {
        public static void Izvedi()
        {
            Console.Write("Unesi ime grada: ");
            var g = Console.ReadLine();

            if (g == "Osijek")
                Console.WriteLine("Slavonija");
            else if (g == "Zadar")
                Console.WriteLine("Dalmacija");
            else if (g == "Čakovec")
                Console.WriteLine("Međimurje");
            else if (g == "Pula")
                Console.WriteLine("Istra");
            else
                Console.WriteLine("Ne znam regiju!");

            switch (g)
            {
                case "Osijek":
                    Console.WriteLine("Slavonija");
                    break;
                case "Zadar":
                    Console.WriteLine("Dalmacija");
                    break;
                case "Čakovec":
                    Console.WriteLine("Međimurje");
                    break;
                case "Pula":
                    Console.WriteLine("Istra");
                    break;
                default:
                    Console.WriteLine("Ne znam regiju!");
                    break;
            }
        }
    }
}
