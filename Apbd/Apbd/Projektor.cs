namespace Apbd;

public class Projektor : Sprzet
{
    public string Rozdzielczosc { get; set; }
    public int Jasnosc { get; set; }
    public string Model { get; set; }

    public Projektor(string nazwa, string rozdzielczosc, int jasnosc, string model)
        : base(nazwa)
    {
        Rozdzielczosc = rozdzielczosc;
        Jasnosc = jasnosc;
        Model = model;
    }

    public override string ToString()
    {
        return base.ToString() +
               $" | Model: {Model}, Rozdzielczość: {Rozdzielczosc}, Jasność: {Jasnosc} lm";
    }
}