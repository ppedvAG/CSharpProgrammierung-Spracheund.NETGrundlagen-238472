namespace M005;

internal class Program
{
	/// <summary>
	/// Funktionen
	/// Code auslagern, damit dieser wiederverwendet kann
	/// Der ausgelagerte Code kann auch angepasst werden durch Parameter
	/// Über den Rückgabetyp kann eine Funktion auch einen Wert zurückliefern
	/// </summary>
	static void Main(string[] args)
	{
		PrintAddiere(2, 3);
		PrintAddiere(5, 3);
		PrintAddiere(9, 4);

		Addiere(3, 4);
		int summe = Addiere(3, 4); //Eine Variable anlegen um den Rückgabewert zu speichern und weiter zu verwenden

		//Überladung/Overloading
		//Gibt die Möglichkeit, mehrere Funktionen mit dem selben Namen zu definieren, wenn sich die Parameter unterscheiden
		Addiere(3, 4);
		Addiere(3.0, 4);

		Console.WriteLine(1); //Anhand des Parameters wird hier auch der Overload ausgewählt
        Console.WriteLine(1.0);
        Console.WriteLine("Hallo");

		//params: Ermöglicht, beliebig viele Parameter bei einer Funktion zu übergeben
		Summiere(1, 2, 3);
		Summiere(1, 2, 3, 4, 5);
		Summiere(3);
		Summiere();

		int[] zahlen = [1, 2, 3];
		Summiere(zahlen);

		//Optionale Parameter: Parameter können vorbelegt werden/einen Standardwert haben, dieser kann überschrieben werden (oder auch nicht)
		AddiereOderSubtrahiere(4, 5);
		AddiereOderSubtrahiere(4, 5);
		AddiereOderSubtrahiere(4, 5);
		AddiereOderSubtrahiere(4, 5);
		AddiereOderSubtrahiere(4, 5);
		AddiereOderSubtrahiere(4, 5);
		AddiereOderSubtrahiere(4, 5, false);
		AddiereOderSubtrahiere(4, 5);
		AddiereOderSubtrahiere(4, 5);
		AddiereOderSubtrahiere(4, 5);

		PrintPerson(nachname: "Mustermann", adresse: "Zuhause"); //Vorname, Alter auslassen
		PrintPerson(vorname: "Max", alter: 20, adresse: "Unterwegs");

		//out: Bei einer Funktion kann normalerweise nur ein Wert zurückgegeben werden, durch out Parameter können mehrere Werte zurückgegeben werden

		int ergebnis; //Hier muss eine separate Variable angelegt werden
		bool hatFunktioniert = int.TryParse("123", out ergebnis); //Über out die Variable mit dem Parameter "verbinden"
		if (hatFunktioniert)
		{
            Console.WriteLine("Zahl: " + ergebnis);
        }
		else
		{
            Console.WriteLine("Parsen hat nicht funktioniert");
        }

		//bool hatFunktioniert = int.TryParse("123", out int ergebnis); //Selbiges wie oben, aber kompakter

		(int summe, int min, int max, double avg) x = Berechne(3, 8, 5, 1, 4);
		(bool funktioniert, int parsed) y = TryParse("123");
	}

	/// <summary>
	/// Rückgabewert: void -> kein Ergebnis/kein Return, nicht void -> benötigt return
	/// </summary>
	static void PrintAddiere(int z1, int z2)
	{
		Console.WriteLine($"{z1} + {z2} = {z1 + z2}");
	}

	static int Addiere(int z1, int z2)
	{
		return z1 + z2;
	}

	static double Addiere(double z1, double z2)
	{
		return z1 + z2;
	}

	/// <summary>
	/// params: Ermöglicht, beliebig viele Parameter bei einer Funktion zu übergeben
	/// </summary>
	static int Summiere(params int[] zahlen)
	{
		return zahlen.Sum();
	}

	/// <summary>
	/// Hier kann über den add Parameter konfiguriert werden, ob diese Funktion Addiert oder Subtrahiert
	/// </summary>
	static int AddiereOderSubtrahiere(int z1, int z2, bool add = true)
	{
		if (add)
			return z1 + z2; 
		else 
			return z1 - z2;
	}

	/// <summary>
	/// Methode konfigurieren: Hier können nur die benötigten Parameter übergeben werden, und alle anderen können übersprungen werden
	/// </summary>
	static void PrintPerson(string vorname = "", string nachname = "", int alter = 0, string adresse = "")
	{
		//...
	}

	//Tupel: Sammlung von Werten (wie bei Array), aber jeder hat einen Namen
	static (int summe, int min, int max, double avg) Berechne(params int[] zahlen)
	{
		return (zahlen.Sum(), zahlen.Min(), zahlen.Max(), zahlen.Average());
	}

	static (bool, int) TryParse(string s)
	{
		bool b = int.TryParse(s, out int erg);
		return (b, erg);
	}

	/// <summary>
	/// Enum Parameter: Hier können nur bestimmte Werte übergeben werden
	/// </summary>
	static string Wochentag(DayOfWeek day)
	{
		switch (day)
		{
			case DayOfWeek.Sunday:
				return "Sonntag";
			case DayOfWeek.Monday:
				return "Montag";
			case DayOfWeek.Tuesday:
				return "Dienstag";
			case DayOfWeek.Wednesday:
				return "Miitwoch";
			case DayOfWeek.Thursday:
				return "Donnerstag";
			case DayOfWeek.Friday:
				return "Freitag";
			case DayOfWeek.Saturday:
				return "Samstag";
			default: //Default nicht vergessen!
				return "Fehler";
		}
	}
}