
namespace UcenjeCS
{
    internal class E10Z2
    {
        public static void Izvedi()
        {
            Console.WriteLine("Unesi riječ: ");
            string rijec = Console.ReadLine();
            bool pali = true;

            for (int i = 0; i < rijec.Length / 2; i++)
            {
                if (rijec[i] != rijec[rijec.Length - 1] - i)
                {
                    pali = false;
                    break;
                }
            }
            Console.WriteLine("Riječ {0} {1} palindrom", rijec, pali ? "Je": "Nije");
        }
    }
}
