namespace Apbd;

public class Wypozyczenie
{
    public Uzytkownik Uzytkownik { get; }
    public Sprzet Sprzet { get; }
    public DateTime DataWypozyczenia { get; }
    public DateTime TerminZwrotu { get; }
    public DateTime? DataZwrotu { get; private set; }
    public decimal Kara { get; private set; }

    public bool Aktywne => DataZwrotu == null;

    public Wypozyczenie(Uzytkownik uzytkownik, Sprzet sprzet, int dni)
    {
        Uzytkownik = uzytkownik;
        Sprzet = sprzet;
        DataWypozyczenia = DateTime.Now;
        TerminZwrotu = DataWypozyczenia.AddDays(dni);
    }

    public void Zwroc()
    {
        DataZwrotu = DateTime.Now;

        if (DataZwrotu > TerminZwrotu)
        {
            int opoznienie = (DataZwrotu.Value - TerminZwrotu).Days;
            Kara = opoznienie * 5;
        }
    }

    public override string ToString()
    {
        return $"{Sprzet.Nazwa} -> {Uzytkownik.Imie} (Do: {TerminZwrotu.ToShortDateString()})";
    }
}