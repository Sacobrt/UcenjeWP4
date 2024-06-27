
namespace UcenjeCS
{
    internal class E11Z1
    {
        // za dva učitana broja koja unosi korisnik ispiši zbroj
        public static void Izvedi()
        {
            int b1 = Pomocno.UcitajCijeliBroj("Unesi 1. broj");
            int b2 = Pomocno.UcitajCijeliBroj();
            Console.WriteLine(b1+b2);
        }
    }
}
