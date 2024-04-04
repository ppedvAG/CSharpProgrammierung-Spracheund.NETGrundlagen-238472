using System.Diagnostics;
using System.Runtime.InteropServices;

namespace M013;

internal class Program
{
	static void Main(string[] args)
	{
		#region	Linq Einführung
		//Linq: Effektiv SQL in C#
		//Daten verarbeiten

		List<int> list = Enumerable.Range(1, 20).ToList();
        Console.WriteLine(list.Average());
        Console.WriteLine(list.Sum());
        Console.WriteLine(list.Min());
        Console.WriteLine(list.Max());

		//Lambda-Expression: e =>
		//Bei Linq-Funktionen wird generell e => benötigt
		list.Where(e => e % 2 == 0); //Alle Zahlen die durch 2 teilbar sind

		//IEnumerable
		//Nur eine Anleitung zum Erstellen der fertigen Liste
		//Wenn auf ein IEnumerable eine Schleife, ToList, ToArray, ... ausgeführt wird, werden die Elemente erstellt

		var x = Enumerable.Range(0, (int) 1E9); //Anleitung zum Erstellen der ints -> 1ms
        //var y = Enumerable.Range(0, (int) 1E9).ToList(); //Ausführen der Anleitung -> 5s, 4GB RAM

        Console.WriteLine(list.First());
        Console.WriteLine(list.Last());

		Console.WriteLine(list.FirstOrDefault());
		Console.WriteLine(list.LastOrDefault());

		//Console.WriteLine(list.First(e => e % 50 == 0)); //Absturz
		Console.WriteLine(list.FirstOrDefault(e => e % 50 == 0)); //0
		#endregion

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		#region Linq mit Objekten
		//Alle Fahrzeuge finden die mindestens 200km/h fahren können
		fahrzeuge.Where(e => e.MaxV > 200);

		//Alle VWs finden die mindestens 200km/h fahren können
		fahrzeuge.Where(e => e.Marke == FahrzeugMarke.VW && e.MaxV > 200);

		//Die Schnellsten Fahrzeuge finden
		fahrzeuge.OrderByDescending(e => e.MaxV); //WICHTIG: Hier wird nicht die originale Liste sortiert

		//Zuerst nach Marke, danach V sortieren
		fahrzeuge.OrderBy(e => e.Marke).ThenByDescending(e => e.MaxV);

		//All & Any
		//Prüfen, ob jedes oder mindestens ein Element einer Bedingung entsprechen

		//Fahren alle Fahrzeuge mindestens 200km/h?
		if (fahrzeuge.All(e => e.MaxV > 200))
		{
			//false
			//...
		}

		//Fährt mindestens ein Fahrzeug mindestens 200km/h?
		if (fahrzeuge.Any(e => e.MaxV > 200))
		{
			//true
			//...
		}

		//Wieviele BMWs haben wir?
		fahrzeuge.Count(e => e.Marke == FahrzeugMarke.BMW); //Die Anzahl statt den Elementen selbst (4)
		fahrzeuge.Where(e => e.Marke == FahrzeugMarke.BMW).Count(); //Kann vereinfacht werden

		//Was ist die geringste Geschwindigkeit?
		fahrzeuge.Min(e => e.MaxV); //Nur die V: 125
		fahrzeuge.MinBy(e => e.MaxV); //Das Fahrzeug mit der V

		//Was ist die Durchschnittsgeschwindigkeit aller Fahrzeuge?
		fahrzeuge.Average(e => e.MaxV); //208.1666666

		//Was sind die 3 schnellsten Fahrzeuge?
		fahrzeuge.OrderByDescending(e => e.MaxV).Take(3); //1-3
		fahrzeuge.OrderByDescending(e => e.MaxV).Skip(3).Take(7); //4-10

		//Select
		//Wandelt jedes Element der Liste in eine andere Form um
		//2 Anwendungsfälle:

		//1. Fall (80%): Einzelnes Feld entnehmen
		//Welche Automarken haben wir?
		fahrzeuge
			.Select(e => e.Marke) //Liste der Marken
			.Distinct(); //Marken einzigartig machen

		//2. Fall (20%): Liste transformieren
		//Wandle jedes Fahrzeug zu einer String-Repräsentation um
		fahrzeuge.Select(e => $"Das Fahrzeug hat die Marke {e.Marke} und kann maximal {e.MaxV}km/h fahren.");
		//Fahrzeug-Liste -> String-Liste

		//Liste von Kommazahlen von 0 bis 10 erzeugen mit 0.5 Schritten
		Enumerable.Range(0, 21).Select(e => e / 2.0);

		//GroupBy
		//Gruppiert die Liste anhand eines Kriteriums
		//-> Es wird für jedes Kriterium eine Gruppe erzeugt und die Elemente die dem Kriterium entsprechen kommen in die Gruppe hinein
		fahrzeuge.GroupBy(e => e.Marke); //3 Gruppen: Audi-Gruppe, BMW-Gruppe, VW-Gruppe
		var groups = fahrzeuge.GroupBy(e => e.Marke).ToLookup(e => e.Key);
		groups[FahrzeugMarke.BMW].First().ToList();
		#endregion

		#region Erweiterungsmethoden
		//Erweiterungsmetoden
		//Ermöglichen, belibige Typen mit eigenen Methoden zu versehen

		int zahl = 247;
        Console.WriteLine(zahl.Quersumme());
        Console.WriteLine(23957239.Quersumme());
        #endregion
    }
}

[DebuggerDisplay("Marke: {Marke}, MaxV: {MaxV}")]
public class Fahrzeug
{
	public int MaxV;

	public FahrzeugMarke Marke;

	public Fahrzeug(int v, FahrzeugMarke fm)
	{
		MaxV = v;
		Marke = fm;
	}
}

public enum FahrzeugMarke
{
	Audi, BMW, VW
}