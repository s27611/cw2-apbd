namespace Apbd;

public class Laptop : Sprzet
{
    public string SystemOperacyjny { get; set; }
    public int PamiecGB { get; set; }
    public string Procesor { get; set; }

    public Laptop(string nazwa, string system, int pamiec, string procesor)
        : base(nazwa)
    {
        SystemOperacyjny = system;
        PamiecGB = pamiec;
        Procesor = procesor;
    }

    public override string ToString()
    {
        return base.ToString() +
               $" | OS: {SystemOperacyjny}, RAM: {PamiecGB}GB, CPU: {Procesor}";
    }
}