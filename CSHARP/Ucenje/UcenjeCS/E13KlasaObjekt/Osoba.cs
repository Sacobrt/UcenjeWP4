
namespace UcenjeCS.E13KlasaObjekt
{
    internal class Osoba
    {
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public int Sifra { get; set; }
        public Mjesto? Mjesto { get; set; }

        public string ImePrezime()
        {
            return Ime + " " + Prezime;
        }
    }
}
