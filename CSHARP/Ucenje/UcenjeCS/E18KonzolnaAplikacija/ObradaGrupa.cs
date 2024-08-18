
using UcenjeCS.E18KonzolnaAplikacija.Model;

namespace UcenjeCS.E18KonzolnaAplikacija
{
    internal class ObradaGrupa
    {
        public List<Grupa> Grupe { get; set; }
        private Izbornik Izbornik;
        public ObradaGrupa()
        {
            Grupe = new List<Grupa>();
        }
        public ObradaGrupa(Izbornik izbornik) : this()
        {
            this.Izbornik = izbornik;
        }
        public void PrikaziIzbornik()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n-> IZBORNIK ZA RAD S GRUPAMA");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Pregled svih grupa");
            Console.WriteLine("2. Unos nove grupe");
            Console.WriteLine("3. Promjena podataka postojeće grupe");
            Console.WriteLine("4. Brisanje grupe");
            Console.WriteLine("5. Statistika grupa");
            Console.WriteLine("6. Povratak na glavni izbornik");
            OdabirOpcijeIzbornika();
        }
        private void OdabirOpcijeIzbornika()
        {
            switch (Pomocno.UcitajRasponBroja("\nOdaberite stavku izbornika", 1, 6))
            {
                case 1:
                    PrikaziGrupe();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UnosNoveGrupe();
                    PrikaziIzbornik();
                    break;
                case 3:
                    PromjeniPodatkeGrupe();
                    PrikaziIzbornik();
                    break;
                case 4:
                    ObrisiGrupu();
                    PrikaziIzbornik();
                    break;
                case 5:
                    PrikaziStatistiku();
                    PrikaziIzbornik();
                    break;
                case 6:
                    Console.Clear();
                    break;
            }
        }
        private void PrikaziStatistiku()
        {
            if (Grupe == null || !Grupe.Any())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNema podataka za prikaz!");
                Console.ForegroundColor = ConsoleColor.White;
                PrikaziIzbornik();
                return;
            }

            int ukupnoPolaznika = Grupe.Sum(g => g.Polaznici?.Count ?? 0);
            float prosjecanBrojPolaznika = Grupe.Any() ? (float)Grupe.Average(g => g.Polaznici?.Count ?? 0) : 0;
            float ukupniPrihod = Grupe.Sum(g => (g.Polaznici?.Count ?? 0) * (g.Smjer?.Cijena ?? 0));
            float prosjecanPrihodPoPolazniku = ukupniPrihod / ukupnoPolaznika;

            var datumi = Grupe.Where(g => g.Smjer?.IzvodiSeOd.HasValue ?? false).Select(g => g.Smjer.IzvodiSeOd.Value).ToList();

            DateTime najranijiDatum = datumi.Any() ? datumi.Min() : DateTime.MinValue;
            DateTime najkasnijiDatum = datumi.Any() ? datumi.Max() : DateTime.MaxValue;
            TimeSpan razlikaDatuma = najkasnijiDatum - najranijiDatum;

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-> STATISTIKA GRUPA");
            Console.WriteLine("\nUkupno polaznika u svim grupama: " + ukupnoPolaznika);
            Console.WriteLine("Prosječan broj polaznika: " + prosjecanBrojPolaznika);
            Console.WriteLine("Ukupan iznos prihoda po smjerovima: " + ukupniPrihod);
            Console.WriteLine("Prosječan iznos prihoda po polazniku: " + prosjecanPrihodPoPolazniku);
            Console.WriteLine("Razlika između najranijeg i najkasnijeg datuma: " + razlikaDatuma.Days + " dana");
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void ObrisiGrupu()
        {
            Console.Clear();
            PrikaziGrupe();
            if (Grupe.Count < 1)
            {
                PrikaziIzbornik();
                return;
            }
            var g = Grupe[Pomocno.UcitajRasponBroja("\tOdaberi redni broj grupe za brisanje", 1, Grupe.Count) - 1];

            if (g.Sifra == 0) return;
            if (Pomocno.UcitajBool("\tSigurno obrisati " + g.Naziv + "? (DA/NE) (Enter za prekid)", "da"))
            {
                Grupe.Remove(g);
            }
        }
        private void PromjeniPodatkeGrupe()
        {
            Console.Clear();
            PrikaziGrupe();
            if (Grupe.Count < 1)
            {
                PrikaziIzbornik();
                return;
            }
            var g = Grupe[Pomocno.UcitajRasponBroja("\n\tOdaberi redni broj grupe za promjenu", 1, Grupe.Count) - 1];
            var originalSifra = g.Sifra;

            if (Pomocno.UcitajBool("Želite li promijeniti podatke? (DA/NE)", "da"))
            {
                int sifra = Pomocno.UcitajRasponBroja("\tPromjeni šifru grupe (" + originalSifra + ")", 1, int.MaxValue);
                while (sifra != originalSifra && Grupe.Exists(p => p.Sifra == sifra))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\tTa šifra već postoji za neku grupu!");
                    Console.ForegroundColor = ConsoleColor.White;
                    sifra = Pomocno.UcitajRasponBroja("\tPromjeni šifru grupe (" + originalSifra + ")", 1, int.MaxValue);
                }
                g.Sifra = sifra;
                g.Naziv = Pomocno.UcitajString(g.Naziv, "\tUnesi naziv grupe", 50, true);

                //smjer
                Izbornik.ObradaSmjer.PrikaziSmjerove();
                g.Smjer = Izbornik.ObradaSmjer.Smjerovi[Pomocno.UcitajRasponBroja("\tOdaberi redni broj smjera (" + g.Smjer.Naziv + ")", 1, Izbornik.ObradaSmjer.Smjerovi.Count) - 1];
                g.Predavac = Pomocno.UcitajString(g.Predavac, "\tUnesi ime i prezime predavača", 50, true);
                g.MaksimalnoPolaznika = Pomocno.UcitajRasponBroja("\tUnesi maksimalno polaznika (" + g.MaksimalnoPolaznika + ")", 1, 30);

                // polaznici
                g.Polaznici = UcitajPolaznike();
            }
        }
        private void PrikaziGrupe()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-> GRUPE U APLIKACIJI");
            Console.ForegroundColor = ConsoleColor.White;

            if (Grupe.Count < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nema ni jedne grupe u aplikaciji!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            else
            {
                int rb = 0, rbp;
                foreach (var g in Grupe)
                {
                    Console.WriteLine(++rb + ". " + g.Naziv + " (" + g.Smjer?.Naziv + "), " + g.Polaznici?.Count + " polaznika");
                    rbp = 0;
                    g.Polaznici.Sort();
                    foreach (var p in g.Polaznici)
                    {
                        Console.WriteLine("\t" + ++rbp + ". " + p.Ime + " " + p.Prezime);
                    }
                }
            }
        }
        private void UnosNoveGrupe()
        {
            Console.Clear();

            if (Izbornik.ObradaSmjer.Smjerovi.Count < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tNema ni jednog smjera u aplikaciji, ne mozete kreirati grupu!");
                Console.ForegroundColor = ConsoleColor.White;
                PrikaziIzbornik();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\tUNESITE TRAŽENE PODATKE O GRUPI");
            Console.ForegroundColor = ConsoleColor.White;

            Grupa g = new Grupa();

            int sifra = Pomocno.UcitajRasponBroja("\tUnesi šifru grupe", 1, int.MaxValue);
            while (Grupe.Exists(g => g.Sifra == sifra))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tTa šifra već postoji za neku grupu!");
                Console.ForegroundColor = ConsoleColor.White;
                sifra = Pomocno.UcitajRasponBroja("\tUnesi šifru grupe", 1, int.MaxValue);
            }

            g.Sifra = sifra;
            g.Naziv = Pomocno.UcitajString("\tUnesi naziv grupe", 50, true);

            //smjer
            Izbornik.ObradaSmjer.PrikaziSmjerove();
            g.Smjer = Izbornik.ObradaSmjer.Smjerovi[Pomocno.UcitajRasponBroja("\n\tOdaberi redni broj smjera", 1, Izbornik.ObradaSmjer.Smjerovi.Count) - 1];
            g.Predavac = Pomocno.UcitajString("\tUnesi ime i prezime predavača", 50, true);
            g.MaksimalnoPolaznika = Pomocno.UcitajRasponBroja("\tUnesi maksimalno polaznika", 1, 30);

            // polaznici
            if (Izbornik.ObradaPolaznik.Polaznici.Count < 1)
            {
                PrikaziIzbornik();
                return;
            }
            else g.Polaznici = UcitajPolaznike();

            Grupe.Add(g);
        }
        private List<Polaznik> UcitajPolaznike()
        {
            List<Polaznik> lista = new List<Polaznik>();
            while (Pomocno.UcitajBool("\tZa unos polaznika unesi DA", "da"))
            {
                Izbornik.ObradaPolaznik.PrikaziPolaznike();
                int odabrani = Pomocno.UcitajRasponBroja("\tOdaberi redni broj polaznika", 1, Izbornik.ObradaPolaznik.Polaznici.Count) - 1;
                Polaznik polaznik = Izbornik.ObradaPolaznik.Polaznici[odabrani];

                // provjera polaznika
                if (lista.Contains(polaznik))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\tPolaznik je već dodan u tu grupu!");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    lista.Add(polaznik);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\tPolaznik uspješno dodan u grupu.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            return lista;
        }
    }
}
