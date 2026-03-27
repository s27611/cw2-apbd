namespace Apbd;

public class Pracownik : Uzytkownik
{
    public Pracownik(string imie, string nazwisko) : base(imie, nazwisko) { }

    public override int MaksWypozyczen => 5;
}