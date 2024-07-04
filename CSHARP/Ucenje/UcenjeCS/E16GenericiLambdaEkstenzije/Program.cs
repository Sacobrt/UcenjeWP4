
namespace UcenjeCS.E16GenericiLambdaEkstenzije
{
    internal class Program
    {
        public Program()
        {
            List<int> brojevi = new List<int>();
            brojevi.Add(1);
            brojevi.Add(2);

            Console.WriteLine(brojevi[0]);

            foreach (int i in brojevi)
            {
                Console.WriteLine(i);
            }

            List<string> imena = new List<string>();
            imena.Add("Pero");
            imena.Add("Marko");

            imena.ForEach(Console.WriteLine);

            List<Smjer> smjerovi = new List<Smjer>();
            smjerovi.Add(new() { Sifra = 1, Naziv = "Web programiranje" });

            smjerovi.ForEach(Console.WriteLine);

            Obrada<Smjer> os = new Obrada<Smjer>();
            os.ObjektObrade = smjerovi[0];
            os.Obradi();

            Obrada<Polaznik> op = new Obrada<Polaznik>();
            op.ObjektObrade = new() { Sifra = 1, Ime = "Marko", Prezime = "Perić" };
            op.Obradi();

            op = new Obrada<Polaznik>();
            op.Obradi();

            // Lambda expressions
            Console.WriteLine(KlasicnaMetoda(2, 2));

            var Zbroj = (int a, int b) => a + b;
            Console.WriteLine(Zbroj(2, 2));

            var algoritam = (int x, int y) =>
            {
                var t = ++x - y;
                return t + y;
            };

            Console.WriteLine(algoritam(2, 2));
            Console.WriteLine(algoritam(1, 1));

            // ekstenzije
            //smjerovi[0].OdradiPosao();
            Smjer s = new Smjer();
            s.Naziv = "WP";
            //s.OdradiPosao();

            smjerovi.Add(new() { Sifra = 2, Naziv = "Java programiranje" });
            smjerovi.ForEach(Console.WriteLine);
            smjerovi.Sort();
            Console.WriteLine("***************");
            smjerovi.ForEach(Console.WriteLine);

            os.Lista = smjerovi;
            os.IspisStavaka(MojIspis);
            os.IspisStavaka(DrugaMetoda);

            Console.WriteLine();

            os.IspisStavaka(s =>
            {
                Console.WriteLine("Nisam više znao kako nazvati metodu: " + s);
            });

            smjerovi.ForEach(s =>
            {
                Console.WriteLine("Vrtim stavke liste: ");
            });

            smjerovi.ForEach(MojIspis);

            Console.WriteLine(smjerovi.Sum(s => s.Sifra));
        }
        private void MojIspis(Smjer s)
        {
            Console.WriteLine("Prilagođeni ispis " + s.Naziv);
        }
        private void DrugaMetoda(Smjer smjer)
        {
            Console.Write(smjer.Sifra);
        }
        private int KlasicnaMetoda(int a, int b)
        {
            return a + b;
        }
    }
}
