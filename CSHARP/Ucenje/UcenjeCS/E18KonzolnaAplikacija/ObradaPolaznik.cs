
using UcenjeCS.E18KonzolnaAplikacija.Model;

namespace UcenjeCS.E18KonzolnaAplikacija
{
    internal class ObradaPolaznik
    {
        public List<Polaznik> Polaznici { get; set; }
        public ObradaPolaznik()
        {
            Polaznici = new List<Polaznik>();
            if (Pomocno.DEV)
            {
                UcitajTestnePodatke();
            }
        }
        private void UcitajTestnePodatke()
        {
            for (int i = 0; i < 10; i++)
            {
                Polaznici.Add(new()
                {
                    Ime = Faker.Name.First(),
                    Prezime = Faker.Name.Last()
                });
            }
        }
        public void PrikaziIzbornik()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n-> IZBORNIK ZA RAD S POLAZNICIMA");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Pregled svih polaznika");
            Console.WriteLine("2. Unos novog polaznika");
            Console.WriteLine("3. Promjena podataka postojećeg polaznika");
            Console.WriteLine("4. Brisanje polaznika");
            Console.WriteLine("5. Povratak na glavni izbornik");
            OdabirOpcijeIzbornika();
        }
        private void OdabirOpcijeIzbornika()
        {
            switch (Pomocno.UcitajRasponBroja("\nOdaberite stavku izbornika", 1, 5))
            {
                case 1:
                    PrikaziPolaznike();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UnosNovogPolaznika();
                    PrikaziIzbornik();
                    break;
                case 3:
                    PromjeniPodatakPolaznika();
                    PrikaziIzbornik();
                    break;
                case 4:
                    ObrisiPolaznika();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.Clear();
                    break;
            }
        }
        private void ObrisiPolaznika()
        {
            Console.Clear();
            PrikaziPolaznike();
            if (Polaznici.Count < 1)
            {
                PrikaziIzbornik();
                return;
            }
            var odabrani = Polaznici[Pomocno.UcitajRasponBroja("\n\tOdaberi redni broj polaznika za brisanje", 1, Polaznici.Count) - 1];

            if (odabrani.Sifra == 0) return;
            if (Pomocno.UcitajBool("\tSigurno obrisati " + odabrani.Ime + " " + odabrani.Prezime + "? (DA/NE) (Enter za prekid)", "da"))
            {
                Polaznici.Remove(odabrani);
            }
        }
        private void PromjeniPodatakPolaznika()
        {
            Console.Clear();
            PrikaziPolaznike();
            if (Polaznici.Count < 1)
            {
                PrikaziIzbornik();
                return;
            }
            var odabrani = Polaznici[Pomocno.UcitajRasponBroja("\n\tOdaberi redni broj polaznika za promjenu", 1, Polaznici.Count) - 1];
            var originalSifra = odabrani.Sifra;

            if (Pomocno.UcitajBool("Želite li promijeniti podatke? (DA/NE)", "da"))
            {
                int sifra = Pomocno.UcitajRasponBroja("\tPromjeni šifru polaznika (" + originalSifra + ")", 1, int.MaxValue);
                while (sifra != originalSifra && Polaznici.Exists(p => p.Sifra == sifra))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\tTa šifra već postoji za nekog polaznika!");
                    Console.ForegroundColor = ConsoleColor.White;
                    sifra = Pomocno.UcitajRasponBroja("\tPromjeni šifru polaznika (" + originalSifra + ")", 1, int.MaxValue);
                }
                odabrani.Sifra = sifra;

                odabrani.Ime = Pomocno.UcitajString(odabrani.Ime, "\tUnesi ime polaznika", 50, true);
                odabrani.Prezime = Pomocno.UcitajString(odabrani.Prezime, "\tUnesi prezime polaznika", 50, true);
                odabrani.Email = Pomocno.UcitajString(odabrani.Email, "\tUnesi email polaznika", 50, true);
                odabrani.OIB = Pomocno.UcitajString(odabrani.OIB, "\tUnesi OIB polaznika", 50, true);
            }
        }
        public void PrikaziPolaznike()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-> POLAZNICI U APLIKACIJI");
            Console.ForegroundColor = ConsoleColor.White;

            if (Polaznici.Count < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nema ni jednog polaznika u aplikaciji!");
                Console.ForegroundColor = ConsoleColor.Blue;
                return;
            }
            else
            {
                int rb = 0;
                foreach (var p in Polaznici)
                {
                    Console.WriteLine(++rb + ". " + p.Ime + " " + p.Prezime);
                }
            }
        }
        private void UnosNovogPolaznika()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("UNESITE TRAŽENE PODATKE O POLAZNIKU");
            Console.ForegroundColor = ConsoleColor.White;

            int sifra = Pomocno.UcitajRasponBroja("\tUnesi šifru polaznika", 1, int.MaxValue);
            while (Polaznici.Exists(p => p.Sifra == sifra))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tTa šifra već postoji za nekog polaznika!");
                Console.ForegroundColor = ConsoleColor.White;
                sifra = Pomocno.UcitajRasponBroja("\tUnesi šifru polaznika", 1, int.MaxValue);
            }
            Polaznici.Add(new()
            {
                Sifra = sifra,
                Ime = Pomocno.UcitajString("\tUnesi ime polaznika", 50, true),
                Prezime = Pomocno.UcitajString("\tUnesi prezime polaznika", 50, true),
                Email = Pomocno.UcitajString("\tUnesi email polaznika", 50, true),
                OIB = Pomocno.UcitajString("\tUnesi OIB polaznika", 50, true)
            });
        }
    }
}
