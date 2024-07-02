
namespace UcenjeCS.E14Nasljedivanje
{
    internal class Program
    {
        public Program()
        {
            //Console.WriteLine("Hello");

            Smjer s = new Smjer();
            s.Naziv = "Web programiranje";
            Console.WriteLine(s);

            var p = new Polaznik()
            {
                Ime = "Pero",
                Sifra = 1
            };
            Console.WriteLine(p);

            //var e = new Entitet();

            var sd = new StraniDrzavljanin();


            Obrada[] poslovi = new Obrada[2];
            poslovi[0] = new ObradaIzlazniRacun();
            poslovi[1] = new ObradaUlaziRacun();

            foreach (Obrada o in poslovi)
            {
                o.Procesuiraj();
            }
        }
        public Program(string s)
        {
            Console.WriteLine(s);
        }
    }
}
