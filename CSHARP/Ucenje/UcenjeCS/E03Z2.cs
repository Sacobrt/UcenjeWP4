
namespace UcenjeCS
{
    internal class E03Z2
    {
        public static void Izvedi()
        {
            float[] b = new float[2];

            Console.Write("Unesi prvi decimalni broj: ");
            b[0] = float.Parse(Console.ReadLine());

            Console.Write("Unesi drugi decimalni broj: ");
            b[1] = float.Parse(Console.ReadLine());

            if(b[0] == b[1])
            {
                Console.WriteLine("Brojevi su jednaki");
            }
            else
            {
                Console.WriteLine("Brojevi nisu jednaki");
            }
        }
    }
}
