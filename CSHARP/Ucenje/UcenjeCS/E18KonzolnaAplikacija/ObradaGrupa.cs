
using UcenjeCS.E18KonzolnaAplikacija.Model;

namespace UcenjeCS.E18KonzolnaAplikacija
{
    internal class ObradaGrupa
    {
        public List<Grupa> Grupe { get; set; }
        public ObradaGrupa()
        {
            Grupe = new List<Grupa>();
        }
        public void PrikaziIzbornik()
        {
            Console.WriteLine("Izbornik za rad s grupama");
            Console.WriteLine("1. Pregled svih grupa");
            Console.WriteLine("2. Unos nove grupe");
            Console.WriteLine("3. Promjena podataka postojeće grupe");
            Console.WriteLine("4. Brisanje grupe");
            Console.WriteLine("5. Povratak na glavni izbornik");
            OdabirOpcijeIzbornika();
        }
        private void OdabirOpcijeIzbornika()
        {
            switch (Pomocno.UcitajRasponBroja("Odaberite stavku izbornika", 1, 5))
            {
                case 1:
                    PrikaziGrupe();
                    PrikaziIzbornik();
                    break;
                case 2:
                    UnosNoveGrupe();
                    PrikaziIzbornik();
                    break;
                case 5:
                    Console.Clear();
                    break;
            }
        }
        private void PrikaziGrupe()
        {
            Console.WriteLine("*****************************");
            Console.WriteLine("Smjerovi u aplikaciji");
            foreach (var g in Grupe)
            {
                Console.WriteLine(g); // prepisati metodu toString
            }
            Console.WriteLine("****************************");
        }
        private void UnosNoveGrupe()
        {
            Console.WriteLine("***************************");
            Console.WriteLine("Unesite tražene podatke o grupi");

            Grupa g = new Grupa();
            g.Sifra = Pomocno.UcitajRasponBroja("Unesi šifru grupe", 1, int.MaxValue);
            g.Naziv = Pomocno.UcitajString("Unesi naziv grupe", 50, true);
            //smjer
            g.Predavac = Pomocno.UcitajString("Unesi ime i prezime predavača", 50, true);
            g.MaksimalnoPolaznika = Pomocno.UcitajRasponBroja("Unesi maksimalno polaznika", 1, 30);
            // polaznici
            Grupe.Add(g);
        }
    }
}
