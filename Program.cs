using CA24110502;
using System.Text;

const string FILE = @"..\..\..\src\forras.txt";
const int AKTUALIS_EV = 2014;

List<Versenyzo> versenyzok = [];

using StreamReader sr = new(FILE, Encoding.UTF8);
while (!sr.EndOfStream) versenyzok.Add(new(sr.ReadLine()));

Console.WriteLine($"versenyt befejezok szama: {versenyzok.Count} fo");

/////////////////////////////////////////////////////////////

var f01 = versenyzok.Count(v => v.Kategoria == "elit");
var f02 = versenyzok
    .Where(v => !v.Nem)
    .Average(v => AKTUALIS_EV - v.SzulEv);
var f03 = versenyzok.Sum(v => v.VersenyIdok["Kerékpár"].TotalHours);
var f04 = versenyzok
    .Where(v => v.Kategoria == "elit junior")
    .Average(v => v.VersenyIdok["Úszás"].TotalMinutes);
var f05 = versenyzok
    .Where(v => v.Nem)
    .MinBy(v => v.OsszIdo);
var f06 = versenyzok
    .GroupBy(v => v.Kategoria)
    .OrderBy(g => g.Key)
    .ToDictionary(g => g.Key, g => g.Count());
var f07 = versenyzok
    .GroupBy(v => v.Kategoria)
    .OrderBy(g => g.Key)
    .ToDictionary(g => g.Key, g => g.Average(
        v => v.VersenyIdok["I. depó"].TotalMinutes
        + v.VersenyIdok["II. depó"].TotalMinutes));

/////////////////////////////////////////////////////////////

Console.WriteLine($"versenyzok szama elit kategoriaban: {f01} fo");
Console.WriteLine($"noi versenyzok atlageletkora: {f02:0.00} ev");
Console.WriteLine($"kerekparozassal toltott osszido: {f03:0.00} ora");
Console.WriteLine($"atlag elit junior uszas ido: {f04:0.00} perc");
Console.WriteLine($"elosokent celba ero ferfi: {f05}");
Console.WriteLine("a versenyt befejezok szama kategoriankent:");
foreach (var kvp in f06) Console.WriteLine($"\t{kvp.Key,11}: {kvp.Value,2} fo");
Console.WriteLine("atlag depoban toltott ido kategoriankent:");
foreach (var kvp in f07) Console.WriteLine($"\t{kvp.Key,11}: {kvp.Value:0.00} perc");