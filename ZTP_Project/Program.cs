public class ManagerBudzetu
{
    private static ManagerBudzetu instance;
    private List<Wydatki> wydatki;
    private List<Przychody> przychody;

    private ManagerBudzetu()
    {
        wydatki = new List<Wydatki>();
        przychody = new List<Przychody>();
    }

    public static ManagerBudzetu Instance
    {
        get
        {
            if (instance == null)
                instance = new ManagerBudzetu();
            return instance;
        }
    }

    public void DodajWydatki(Wydatki wydatki)
    {
        this.wydatki.Add(wydatki);
    }

    public void DodajPrzychody(Przychody przychody)
    {
        this.przychody.Add(przychody);
    }

    public List<Wydatki> GetWydatki()
    {
        return this.wydatki;
    }

    public List<Przychody> GetPrzychody()
    {
        return this.przychody;
    }
}

public class Wydatki
{
    public string Nazwa { get; set; }
    public double Kwota { get; set; }
    public string Kategoria { get; set; }

    public Wydatki(string nazwa, double kwota, string kategoria)
    {
        Nazwa = nazwa;
        Kwota = kwota;
        Kategoria = kategoria;
    }
}

public class Przychody
{
    public string Nazwa { get; set; }
    public double Kwota { get; set; }

    public Przychody(string nazwa, double kwota)
    {
        Nazwa = nazwa;
        Kwota = kwota;
    }
}
