
namespace UcenjeCS
{
    internal class E09ForEachPetlja
    {
        public static  void Izvedi()
        {
            string rijec = "Osijek";

            for(int i = 0; i < rijec.Length; i++)
            {
                Console.WriteLine(rijec[1]);
            }

            Console.WriteLine("***********");

            foreach (var slovo in rijec)
            {
                Console.WriteLine(slovo);
            }
        }
    }
}
