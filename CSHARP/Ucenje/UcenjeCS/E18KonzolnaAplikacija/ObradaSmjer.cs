
using UcenjeCS.E18KonzolnaAplikacija.Model;

namespace UcenjeCS.E18KonzolnaAplikacija
{
    internal class ObradaSmjer
    {
        public List<Smjer> Smjerovi { get; set; }
        public ObradaSmjer()
        {
            Smjerovi = new List<Smjer>();
            if (Pomocno.DEV)
            {
                UcitajTestnePodatke();
            }
        }
        private void UcitajTestnePodatke()
        {
            Smjerovi.Add(new() { Sifra = 1, Naziv = "Web programiranje", Cijena = 1250, Trajanje = 225, Verificiran = true, IzvodiSeOd = DateTime.Now });
            Smjerovi.Add(new() { Sifra = 2, Naziv = "Web dizajn", Cijena = 2200, Trajanje = 152, Verificiran = true, IzvodiSeOd = DateTime.Now });
            Smjerovi.Add(new() { Sifra = 3, Naziv = "Serviser", Cijena = 3100, Trajanje = 60, Verificiran = true, IzvodiSeOd = DateTime.Now });
        }
        public void PrikaziIzbornik()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n-> IZBORNIK ZA RAD S SMJEROVIMA");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Pregled svih smjerova");
            Console.WriteLine("2. Unos novog smjera");
            Console.WriteLine("3. Promjena podataka postojećeg smjera");
            Console.WriteLine("4. Brisanje smjera");
            Console.WriteLine("5. Povratak na glavni izbornik");
            OdabirOpcijeIzbornika();
        }
        private void OdabirOpcijeIzbornika()
        {
            switch (Pomocno.UcitajRasponBroja("\nOdaberite stavku izbornika", 1, 5))
            {
                case 1:
                    PrikaziSmjerove();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UnosNovogSmjera();
                    PrikaziIzbornik();
                    break;
                case 3:
                    PromjeniPostojeciSmjer();
                    PrikaziIzbornik();
                    break;
                case 4:
                    ObrisiPostojeciSmjer();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.Clear();
                    break;
            }
        }
        private void ObrisiPostojeciSmjer()
        {
            Console.Clear();
            PrikaziSmjerove();
            if (Smjerovi.Count < 1)
            {
                PrikaziIzbornik();
                return;
            }
            var odabrani = Smjerovi[Pomocno.UcitajRasponBroja("\nOdaberi redni broj smjera za Brisanje", 1, Smjerovi.Count) - 1];

            if (odabrani.Sifra == 0) return;
            if (Pomocno.UcitajBool("Sigurno obrisati " + odabrani.Naziv + "? (DA/NE) (Enter za prekid)", "da"))
            {
                Smjerovi.Remove(odabrani);
            }
        }
        private void PromjeniPostojeciSmjer()
        {
            Console.Clear();
            PrikaziSmjerove();
            if (Smjerovi.Count < 1)
            {
                PrikaziIzbornik();
                return;
            }
            var odabrani = Smjerovi[Pomocno.UcitajRasponBroja("\nOdaberi redni broj smjera za promjenu", 1, Smjerovi.Count) - 1];
            var originalSifra = odabrani.Sifra;

            if (Pomocno.UcitajBool("Želite li promijeniti podatke? (DA/NE)", "da"))
            {
                int sifra = Pomocno.UcitajRasponBroja("\tPromjeni šifru smjera (" + originalSifra + ")", 1, int.MaxValue);
                while (sifra != originalSifra && Smjerovi.Exists(s => s.Sifra == sifra))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\tTa šifra već postoji za neki smjer!");
                    Console.ForegroundColor = ConsoleColor.White;
                    sifra = Pomocno.UcitajRasponBroja("\tPromjeni šifru smjera (" + originalSifra + ")", 1, int.MaxValue);
                }
                odabrani.Sifra = sifra;

                odabrani.Naziv = Pomocno.UcitajString(odabrani.Naziv, "\tUnesi naziv smjera", 50, true);
                odabrani.Trajanje = Pomocno.UcitajRasponBroja("\tUnesi trajanje smjera (" + odabrani.Trajanje + ")", 1, 500);
                odabrani.Cijena = Pomocno.UcitajDecimalniBroj("\tUnesi cijenu smjera (" + odabrani.Cijena + ")", 0, 10000);
                odabrani.IzvodiSeOd = Pomocno.UcitajDatum("\tUnesi datum od kada se izvodi smjer (" + odabrani.IzvodiSeOd + ")", true);
                odabrani.Verificiran = Pomocno.UcitajBool("\tDa li je smjer verificiran (DA/NE) (" + ((bool)odabrani.Verificiran ? "Da" : "Ne") + ")", "da");

            }
        }
        public void PrikaziSmjerove()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-> SMJEROVI U APLIKACIJI");
            Console.ForegroundColor = ConsoleColor.White;

            if (Smjerovi.Count < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nema ni jednog smjera u aplikaciji!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            else
            {
                int rb = 0;
                foreach (var s in Smjerovi)
                {
                    Console.WriteLine(++rb + ". " + s.Naziv);
                }
            }
        }
        private void UnosNovogSmjera()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("UNESITE TRAŽENE PODATKE O SMJERU");
            Console.ForegroundColor = ConsoleColor.White;

            int sifra = Pomocno.UcitajRasponBroja("\tUnesi šifru smjera", 1, int.MaxValue);
            while (Smjerovi.Exists(s => s.Sifra == sifra))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tTa šifra već postoji za neki smjer!");
                Console.ForegroundColor = ConsoleColor.White;
                sifra = Pomocno.UcitajRasponBroja("\tUnesi šifru smjera", 1, int.MaxValue);
            }

            Smjerovi.Add(new()
            {
                Sifra = sifra,
                Naziv = Pomocno.UcitajString("\tUnesi naziv smjera", 50, true),
                Trajanje = Pomocno.UcitajRasponBroja("\tUnesi trajanje smjera", 1, 500),
                Cijena = Pomocno.UcitajDecimalniBroj("\tUnesi cijenu smjera", 0, 10000),
                IzvodiSeOd = Pomocno.UcitajDatum("\tUnesi datum od kada se izvodi smjer", true),
                Verificiran = Pomocno.UcitajBool("\tDa li je smjer verificiran (DA/NE)", "da")
            });
        }
    }
}
