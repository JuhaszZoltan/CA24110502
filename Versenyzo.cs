namespace CA24110502;

internal class Versenyzo
{
    public string Nev { get; set; }
    public int SzulEv { get; set; }
    public string RajtSzam { get; set; }
    public bool Nem { get; set; }
    public string Kategoria { get; set; }
    public Dictionary<string, TimeSpan> VersenyIdok { get; set; }

    public int OsszIdo => (int)VersenyIdok.Values.Sum(x => x.TotalSeconds);

    public override string ToString() => 
        $"[{RajtSzam}] {Nev} ({Kategoria}, {(Nem ? "férfi" : "nő")})";

    public Versenyzo(string sor)
    {
        var v = sor.Split(';');
        Nev = v[0];
        SzulEv = int.Parse(v[1]);
        RajtSzam = v[2];
        Nem = v[3] == "f";
        Kategoria = v[4];
        VersenyIdok = new()
        {
            { "Úszás",    TimeSpan.Parse(v[5]) },
            { "I. depó",  TimeSpan.Parse(v[6]) },
            { "Kerékpár", TimeSpan.Parse(v[7]) },
            { "II. depó", TimeSpan.Parse(v[8]) },
            { "Futás",    TimeSpan.Parse(v[9]) },
        };
    }
}
