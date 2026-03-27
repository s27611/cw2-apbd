namespace Apbd;

public abstract class Sprzet
{
    private static int _idCounter = 1;

    public int Id { get; }
    public string Nazwa { get; set; }
    public StatusSprzetu Status { get; set; }

    public Sprzet(string nazwa)
    {
        Id = _idCounter++;
        Nazwa = nazwa;
        Status = StatusSprzetu.Dostepny;
    }

    public override string ToString()
    {
        return $"{Id}: {Nazwa} ({Status})";
    }
}