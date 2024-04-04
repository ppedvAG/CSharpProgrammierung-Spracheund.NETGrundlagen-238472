namespace M009;

internal class Program
{
	static void Main(string[] args)
	{
		#region Polymorphismus
		//Polymorphismus
		//Welche Typen sind mit welchen anderen Typen kompatibel?
		//-> Typkompatibilität

		//Ein Objekt ist immer mit einer seiner Oberklassen kompatibel
		Mensch m = new Mensch(33, "");
		Lebewesen l = m; //Immer möglich

		Lebewesen k = new Katze(2);
		//Mensch m2 = (Mensch) k; //Kann funktionieren, muss aber nicht

		//object: Oberklasse von allen Klassen in C#
		//-> Alle Objekte sind mit object kompatibel
		object o = m;
		o = k;
		o = 123;
		o = "Hallo";
		o = false;
		o = new object();

		//Polymorphismus gilt an allen Stellen im Code
		//Variablen, Rückgabewerten, Parametern, ...

		SetLebewesen(m);
		SetLebewesen(l);
		SetLebewesen(k);
		#endregion

		#region Typen
		//Typen
		//Jedes Objekt hat einen Typen und dieser beschreibt wie das Objekt mit Polymorphismus funktioniert
		//Über den Typen kann herausgefunden werden, was das Objekt kann (Funktionen, Properties, ... hat)

		//Zwei Möglichkeiten einen Typen zu erhalten
		//.GetType()
		//typeof(...)

		//GetType(): Typ einer Variable/eines Objektes erhalten
		Type t = o.GetType();
        Console.WriteLine(t.Name);

		//typeof(...): Typ über einen Klassennamen erhalten
		Type to = typeof(Lebewesen);
		Console.WriteLine(to.Name);

		//Typvergleich mit GetType und typeof
		//Genauer Typvergleich
		if (l.GetType() == typeof(Lebewesen))
		{
			//Hier muss sich in l genau ein Lebewesen befinden, und kein Mensch, keine Katze oder Tiger
			//-> false
		}

		//Typvergleich mit is
		//Vererbungshierarchietypvergleich
		if (l is Lebewesen)
		{
			//Hier muss sich ein Lebewesen oder einer Unterklasse von Lebewesen befinden
			//-> true
		}
		#endregion

		#region Abstract
		//abstract
		//Definiert, das eine Klasse nurnoch eine Strukturklasse darstellt
		//Eigenschaften:
		//- Kann nicht mehr instanziert werden (mittels new)
		//- Stellt nur Definitionen bereit (Methoden ohne Body)
		//- Kann nur vererbt werden

		//Aufgabe: Einen Zoo erstellen
		Lebewesen[] zoo = new Lebewesen[5];
		zoo[0] = new Mensch(33, "");
		zoo[1] = new Tiger(0);
		zoo[2] = new Katze(0);
		zoo[3] = new Katze(0);
		zoo[4] = new Mensch(0, "");

		foreach (Lebewesen lw in zoo)
		{
			//Typvergleich um herauszufinden um welches Objekt es sich handelt
			if (lw is Mensch)
			{
				//Funktioniert hier immer, weil durch die if gegeben ist, das es sich hier um einen Menschen handelt
				Mensch mensch = (Mensch) lw;
				mensch.Sprechen("Hallo");
			}

			//Jede Klasse hat durch die abstrakte Lebewesen Klasse die WasBinIch() Methode implementiert
			lw.WasBinIch();
		}
		#endregion

		#region	ToString
		//ToString()
		//Wenn eine Funktion einen string erwartet, aber der Parameter kein string ist, wird die ToString() verwendet
		//Standardmäßig wird bei dieser Methode der volle Typname ausgegeben (Namespace + Typname)

		Lebewesen lebewesen = new Mensch(0, "");
        Console.WriteLine(lebewesen); //M009.Mensch

		//Die ToString() Methode kann überschrieben werden
		#endregion
	}

	/// <summary>
	/// Der Rückgabewert dieser Funktion kann ein Lebewesen oder ein Objekt einer Unterklasse von Lebewesen zurückgeben
	/// </summary>
	/// <returns></returns>
	public static Lebewesen GetLebewesen()
	{
		return new Mensch(0, "");
		return new Katze(0);
		//return new Lebewesen(0);
		return new Tiger(0);
	}

	public static void SetLebewesen(Lebewesen l)
	{
		//...
	}
}
