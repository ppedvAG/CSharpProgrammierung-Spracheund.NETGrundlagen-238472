namespace M007;

internal class Program
{
	static void Main(string[] args)
	{
		#region GC
		for (int i = 0; i < 5; i++)
		{
			Person p = new Person();
		}
		GC.Collect();
		GC.WaitForPendingFinalizers();

		//Enumerable.Range(0, 1_000_000_000).ToList(); //4GB anlegen und löschen
		#endregion

		#region Static
		//static: Global, separat von Objekten

		//Console ist static, existiert nur einmal
		//Console c = new Console(); //Nicht möglich, weil static
		//c.WriteLine();
		Console.WriteLine();

		//Person.Print(); //Nicht möglich, weil sich nicht-statische Methoden immer auf ein Objekt beziehen
		Person p2 = new Person();
		p2.Print();

		Console.WriteLine(DateTime.Now); //Jetzt-Zeit ist einfach da

		//Aufgabe: Personenzähler anlegen
		//Sollte in Person.cs sein, kann aber auch in Program.cs sein
		Person p3 = new Person();

        Console.WriteLine(Person.Zaehler);
		#endregion

		#region Datumswerte
		//Zwei Klassen: DateTime, TimeSpan
		DateTime d = new DateTime(2024, 4, 3);
        Console.WriteLine(d.Day);
        Console.WriteLine(d.Month);
        Console.WriteLine(d.Year);
        Console.WriteLine(d.DayOfWeek); //Wednesday
        Console.WriteLine(d.DayOfYear); //94

		d += new TimeSpan(180, 0, 0, 0);
		d -= TimeSpan.FromDays(180);
        Console.WriteLine(d);

        //Aufgabe: Wieviele Tage bin ich alt?
        Console.WriteLine(DateTime.Now - new DateTime(1998, 7, 18));
		#endregion

		#region Werte-/Referenztypen
		//class und struct

		//class
		//Referenztyp
		//Wenn ein Objekt einer Klasse in eine Variable geschrieben wird, wird ein Zeiger angelegt auf das Objekt
		Person p4 = new Person(); //Hier wird ein Objekt angelegt und ein Zeiger in p4 geschrieben
		Person p5 = p4; //Hier wird ein Zeiger auf das Objekt hinter p4 gelegt
		p5.Nachname = "XYZ";

        //Wenn zwei Objekte von Referenztypen verglichen werden, werden die Speicheradressen verglichen
        Console.WriteLine(p4 == p5);
        Console.WriteLine(p4.GetHashCode());
        Console.WriteLine(p5.GetHashCode());

		//struct
		//Wertetyp
		//Wenn ein Objekt eines Structs in eine Variable geschrieben wird, wird der Wert abgelegt
		int original = 10; //Hier wird ein Objekt angelegt und der Wert wird in die Variable geschrieben
		int x = original; //Hier wird der Inhalt von original in x kopiert
		x = 50;

		//Wenn zwei Objekte von Wertetypen verglichen werden, werden die Inhalte verglichen
		Console.WriteLine(original == x);
		Console.WriteLine(original.GetHashCode());
		Console.WriteLine(x.GetHashCode());

		ref int y = ref x; //Structs referenzieren
		y = 100; //Hier wird x auch verändert
		#endregion

		#region Null
		int z; //Leer, 0
		Person p6 = null; //Leer, null

		if (p6 != null) //Wenn in p6 Inhalt enthalten ist ...
			Console.WriteLine(p6.Alter);

		Person[] personen = new Person[1000]; //Array mit 1000 leeren Plätzen

        Console.WriteLine(p6?.Alter); //Kurzer Null-Check

		//z = null;
		int? a; //? am Ende eines Typen: Nullable Typ
		a = null;
        #endregion
    }

	//static void Test(Person x!!) { }
}
