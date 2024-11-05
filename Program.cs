using CA24110502;
using System.Text;

const string FILE = @"..\..\..\src\forras.txt";
const int AKTUALIS_EV = 2014;

List<Versenyzo> versenyzok = [];

using StreamReader sr = new(FILE, Encoding.UTF8);
while (!sr.EndOfStream) versenyzok.Add(new(sr.ReadLine()));

Console.WriteLine($"versenyt befejezok szama: {versenyzok.Count} fo");

/////////////////////////////////////////////////////////////

var f1 = versenyzok.Count(v => v.Kategoria == "elit");
var f2 = versenyzok
    .Where(v => !v.Nem)
    .Average(v => AKTUALIS_EV - v.SzulEv);
var f3 = versenyzok.Sum(v => v.VersenyIdok["Kerékpár"].TotalHours);
var f4 = versenyzok
    .Where(v => v.Kategoria == "elit junior")
    .Average(v => v.VersenyIdok["Úszás"].TotalMinutes);
var f5 = versenyzok
    .Where(v => v.Nem)
    .MinBy(v => v.OsszIdo);
var f6 = versenyzok
    .GroupBy(v => v.Kategoria)
    .OrderBy(g => g.Key)
    .ToDictionary(g => g.Key, g => g.Count());

/////////////////////////////////////////////////////////////

Console.WriteLine($"versenyzok szama elit kategoriaban: {f1} fo");
Console.WriteLine($"noi versenyzok atlageletkora: {f2:0.00} ev");
Console.WriteLine($"kerekparozassal toltott osszido: {f3:0.00} ora");
Console.WriteLine($"atlag elit junior uszas ido: {f4:0.00} perc");
Console.WriteLine($"elosokent celba ero ferfi: {f5}");
Console.WriteLine("a versenyt befejezok szama kategoriankent:");
foreach (var kvp in f6) Console.WriteLine($"\t{kvp.Key,11}: {kvp.Value,2} fo");