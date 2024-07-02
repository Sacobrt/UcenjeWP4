
namespace UcenjeCS.E14Nasljedivanje
{
    internal class Smjer : Entitet
    {
        public string? Naziv { get; set; }

        public override string ToString()
        {
            Console.WriteLine(VidiSeUPodKlasi);
            return this.Naziv;
        }
    }
}
