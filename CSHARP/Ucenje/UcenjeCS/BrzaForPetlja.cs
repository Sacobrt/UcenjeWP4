
namespace UcenjeCS
{
    internal class BrzaForPetlja
    {
        public static void Izvedi()
        {
            var startTime = DateTime.Now;
            int[] niz = PodaciInt.niz;

            Array.Sort(niz);
            Console.WriteLine("Broj podataka: " + niz.Length);

            for (int i = 1; i < niz.Length; i++)
            {
                if (niz[i] == niz[i - 1])
                {
                    Console.WriteLine("Isti broj je: " + niz[i]);
                    goto kraj;
                }
            }
        kraj:
            Console.WriteLine("Trajanje: " + (DateTime.Now - startTime));
        }
    }
}
