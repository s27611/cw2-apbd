namespace Apbd;

public class Student : Uzytkownik
{
    public Student(string imie, string nazwisko) : base(imie, nazwisko) { }

    public override int MaksWypozyczen => 2;
}