namespace Apbd;

public class Kamera : Sprzet
{
    public string Typ { get; set; }
    public bool CzyKolorowe { get; set; }
    public int Megapiksele { get; set; }

    public Kamera(string nazwa, string typ, bool czyKolorowe, int megapiksele)
        : base(nazwa)
    {
        Typ = typ;
        CzyKolorowe = czyKolorowe;
        Megapiksele = megapiksele;
    }

    public override string ToString()
    {
        return base.ToString() +
               $" | Typ: {Typ}, Kolor: {(CzyKolorowe ? "Tak" : "Nie")}, MP: {Megapiksele}";
    }
}