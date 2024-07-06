
namespace UcenjeCS.E17Subota
{
    internal class Program
    {

        public Program() 
        {
            //for(int i = 0; i < 100; i++)
            //{
            //    Console.WriteLine(Faker.Name.FullName(NameFormats.StandardWithMiddleWithPrefix));

            //}

            string br = "6";
            int b;
            if (!int.TryParse(br,out b)){
                Console.WriteLine("Ne valja");
            }
            Console.WriteLine(b);

            int kratko;
            int.TryParse("7", out kratko);

            Console.WriteLine(kratko);

        }
    }
}
