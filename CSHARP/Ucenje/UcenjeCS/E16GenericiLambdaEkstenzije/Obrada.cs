
namespace UcenjeCS.E16GenericiLambdaEkstenzije
{
    internal class Obrada<T> where T : Entitet
    {
        public T? ObjektObrade { get; set; }
        public List<T>? Lista { get; set; }
        public void Obradi()
        {
            ObjektObrade?.PredstaviSe();
        }
        public void IspisStavaka(Action<T> akcija)
        {
            Lista?.ForEach(s => akcija(s));
        }
    }
}
