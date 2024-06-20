
namespace UcenjeCS
{
    internal class E10Z1
    {
        public static void Izvedi()
        {
            int ub = 10;
            int[] brojevi = new int[ub];

            for (int i = 0; i < ub; i++)
            {
                Console.WriteLine("Unesi {0}. broj:", i + 1);
                brojevi[i] = int.Parse(Console.ReadLine());
            }

            int zbroj = 0;
            foreach (var b in brojevi)
            {
                zbroj += b;
            }
            Console.WriteLine(zbroj);

            int index = 0;
            while (index < ub)
            {
                Console.WriteLine(brojevi[index++]);
            }
        }
    }
}
