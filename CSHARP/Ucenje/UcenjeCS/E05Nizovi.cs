
namespace UcenjeCS
{
    internal class E05Nizovi
    {
        public static void Izvedi()
        {
            int[] godine = new int[12];

            godine[0] = 43;
            godine[godine.Length - 1] = 23;

            Console.WriteLine(godine);
            Console.WriteLine(string.Join(",", godine));

            int[] niz = { 2, 3, 5, 6, 7, 9, 2, 6, 1, 1, 6, 2, 4 };
            Console.WriteLine(niz[1]);

            string[] gradovi = { "Osijek", "Donji Miholjac", "Valpovo" };

            int[,] tablica = { { 1, 2, 3 }, { 6, 8, 2 }, { 1, 7, 8 } };
            Console.WriteLine(tablica[0, 2]);

            int[,,,,] multiverse = new int[10, 10, 10, 10, 10];

            object[] objekti = { 1, "Pero", true, 2.2 };
        }
    }
}
