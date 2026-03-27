namespace Apbd;

class Program
{
    static void Main()
    {
        var serwis = new SerwisWypozyczen();

        Console.WriteLine("==== SCENARIUSZ ====");

        // SPRZĘT
        var lap1 = new Laptop("Dell XPS", "Windows", 512, "i7");
        var lap2 = new Laptop("MacBook", "macOS", 256, "M1");
        var lap3 = new Laptop("Lenovo ThinkPad", "Windows", 1024, "i5");

        var pro1 = new Projektor("Epson", "FullHD", 3000, "E-100");
        var pro2 = new Projektor("BenQ", "4K", 3500, "B-200");

        var kam1 = new Kamera("Canon", "Lustrzanka", true, 24);
        var kam2 = new Kamera("Sony", "Analogowa", false, 12);

        serwis.DodajSprzet(lap1);
        serwis.DodajSprzet(lap2);
        serwis.DodajSprzet(lap3);
        serwis.DodajSprzet(pro1);
        serwis.DodajSprzet(pro2);
        serwis.DodajSprzet(kam1);
        serwis.DodajSprzet(kam2);

        Console.WriteLine("---- Dodano sprzęt ----");

        // UŻYTKOWNICY
        var s1 = new Student("Adam", "Kowalski");
        var s2 = new Student("Adam", "Nowak");
        var s3 = new Student("Jan", "Wiśniewski");

        var p1 = new Pracownik("Adam", "Zieliński");
        var p2 = new Pracownik("Adam", "Mazur");

        serwis.DodajUzytkownika(s1);
        serwis.DodajUzytkownika(s2);
        serwis.DodajUzytkownika(s3);
        serwis.DodajUzytkownika(p1);
        serwis.DodajUzytkownika(p2);

        Console.WriteLine("---- Dodano użytkowników ----");

        // POPRAWNE WYPOŻYCZENIA
        Console.WriteLine("---- Poprawne wypożyczenia ----");
        serwis.Wypozycz(s1.Id, lap1.Id, 3);
        serwis.Wypozycz(s2.Id, lap2.Id, 5);
        serwis.Wypozycz(p1.Id, pro1.Id, 7);
        

        // BŁĘDY
        Console.WriteLine("---- Niepoprawne wypożyczenia ----");

        // sprzęt już zajęty
        try
        {
            serwis.Wypozycz(s3.Id, lap1.Id, 2);
        }
        catch (Exception e)
        {
            Console.WriteLine("Błąd (sprzęt zajęty): " + e.Message);
        }

        // przekroczenie limitu studenta
        try
        {
            serwis.Wypozycz(s1.Id, lap3.Id, 3);
            serwis.Wypozycz(s1.Id, pro2.Id, 3);
        }
        catch (Exception e)
        {
            Console.WriteLine("Błąd (limit studenta): " + e.Message);
        }

        // próba wypożyczenia nieistniejącego sprzętu
        try
        {
            serwis.Wypozycz(s1.Id, 999, 3);
        }
        catch (Exception e)
        {
            Console.WriteLine("Błąd (brak sprzętu): " + e.Message);
        }

        
        // próba wypożyczenia niedostępnego sprzętu
        lap3.Status = StatusSprzetu.Niedostepny;

        try
        {
            serwis.Wypozycz(s2.Id, lap3.Id, 2);
        }
        catch (Exception e)
        {
            Console.WriteLine("Błąd (sprzęt uszkodzony): " + e.Message);
        }

        // ================= 15. ZWROTY W TERMINIE =================
        Console.WriteLine("---- Zwroty w terminie ----");
        serwis.Zwroc(lap1.Id);
        serwis.Zwroc(lap2.Id);

        

        //  ZWROTY PO TERMINIE
        Console.WriteLine("---- Zwroty po terminie (kara naliczona) ----");
        // celowo przeterminowane (ujemna liczba dni)
        serwis.Wypozycz(p2.Id, kam1.Id, -3);
        serwis.Wypozycz(p1.Id, kam2.Id, -1);

        serwis.Zwroc(kam1.Id);
        serwis.Zwroc(kam2.Id);
        

        // APORT KOŃCOWY 
        serwis.Raport();
    }
}