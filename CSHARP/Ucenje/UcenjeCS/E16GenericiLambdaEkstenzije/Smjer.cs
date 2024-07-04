
using System.Text;

namespace UcenjeCS.E16GenericiLambdaEkstenzije
{
    internal class Smjer : Entitet, ISucelje, IComparable<Smjer>
    {
        public string? Naziv { get; set; }
        public override void PredstaviSe()
        {
            Console.WriteLine(Sifra + " - " + Naziv);
        }
        public override string ToString()
        {
            //return Sifra + " - " + Naziv;
            return new StringBuilder().Append(Sifra).Append(" - ").Append(Naziv).ToString();
        }
        public void Posao()
        {
            Console.WriteLine("Radim na klasi Smjer, naziv je: " + Naziv);
        }
        public int CompareTo(Smjer? other)
        {
            return Naziv?.CompareTo(other?.Naziv) ?? 0;
        }
    }
}
