namespace Apbd;

using System;
using System.Collections.Generic;
using System.Linq;

public class SerwisWypozyczen
{
    public List<Uzytkownik> Uzytkownicy { get; } = new();
    public List<Sprzet> Sprzety { get; } = new();
    public List<Wypozyczenie> Wypozyczenia { get; } = new();

    public void DodajUzytkownika(Uzytkownik u) => Uzytkownicy.Add(u);
    public void DodajSprzet(Sprzet s) => Sprzety.Add(s);

    public void Wypozycz(int uid, int sid, int dni)
    {
        var u = Uzytkownicy.First(x => x.Id == uid);
        var s = Sprzety.First(x => x.Id == sid);

        if (s.Status != StatusSprzetu.Dostepny)
            throw new Exception("Sprzęt niedostępny");

        if (Wypozyczenia.Count(w => w.Uzytkownik.Id == uid && w.Aktywne) >= u.MaksWypozyczen)
            throw new Exception("Przekroczono limit");

        var w = new Wypozyczenie(u, s, dni);
        Wypozyczenia.Add(w);
        s.Status = StatusSprzetu.Wypozyczony;
    }

    public void Zwroc(int sid)
    {
        var w = Wypozyczenia.First(x => x.Sprzet.Id == sid && x.Aktywne);
        w.Zwroc();
        w.Sprzet.Status = StatusSprzetu.Dostepny;

        Console.WriteLine($"Kara: {w.Kara} zł");
    }

    public void Raport()
    {
        Console.WriteLine("\n=== RAPORT KOŃCOWY ===");
        Console.WriteLine($"Sprzęt: {Sprzety.Count}");
        Console.WriteLine($"Użytkownicy: {Uzytkownicy.Count}");
        Console.WriteLine($"Aktywne: {Wypozyczenia.Count(x => x.Aktywne)}");
        Console.WriteLine($"Zaległe: {Wypozyczenia.Count(x => x.Aktywne && x.TerminZwrotu < DateTime.Now)}");
    }
}