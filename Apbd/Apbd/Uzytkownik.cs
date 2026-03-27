namespace Apbd;

public abstract class Uzytkownik
{
    private static int _idCounter = 1;

    public int Id { get; }
    public string Imie { get; set; }
    public string Nazwisko { get; set; }

    protected Uzytkownik(string imie, string nazwisko)
    {
        Id = _idCounter++;
        Imie = imie;
        Nazwisko = nazwisko;
    }

    public abstract int MaksWypozyczen { get; }

    public override string ToString()
    {
        return $"{Id}: {Imie} {Nazwisko}";
    }
}