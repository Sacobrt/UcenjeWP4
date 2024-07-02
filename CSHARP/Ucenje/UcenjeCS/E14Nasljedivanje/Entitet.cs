
namespace UcenjeCS.E14Nasljedivanje
{
    internal abstract class Entitet : object
    {
        public int? Sifra { get; set; }

        protected int VidiSeUPodKlasi = 7;
        private int VidiSeSamoUKlasiUKojojJeDefinirano = 2;
        public override string ToString()
        {
            Console.WriteLine(VidiSeSamoUKlasiUKojojJeDefinirano);
            return Sifra.ToString();
        }
    }
}
