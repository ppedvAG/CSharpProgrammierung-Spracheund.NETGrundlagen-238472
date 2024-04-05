namespace M016;

internal class Program
{
	static void Main(string[] args)
	{
		//Delegate
		//Eigener Typ, welcher Methodenzeiger halten kann
		//Besteht immer aus einem Methodenaufbau (Rückgabewert Name(Parameter1, Parameter2, ...))
		//Symbol: Koffer
		//Häufige Delegates: Action, Func, EventHandler

		//Action: Methode ohne Rückgabewert und Parameter
		Action a = PrintHelloWorld; //Methode an Action anhängen
		a(); //Action ausführen
		a?.Invoke(); //Action ausführen mit Null-Check

		Action<int> b = PrintZahl; //Methode mit einem int Parameter an die Action hängen
		b?.Invoke(20);

		Action<int, int> addiere = Addiere;
		addiere?.Invoke(3, 4);

		//Func: Methode mit Rückgabewert und bis zu 16 Parameter
		Func<double> c = Random0To1;
		double? ergebnis = c?.Invoke(); //Wenn die Funktion null ist, ist ergebnis auch null -> double?

		//Aufgabe: Divisionsfunktion, 2 int Parameter, double Rückgabewert
		Func<int, int, double> d = Dividiere; //WICHTIG: Letzter Parameter ist immer der Rückgabewert
        Console.WriteLine(d?.Invoke(5, 3));

		List<int> ints = [];
		ints.Where(e => e % 2 == 0); //Func<int, bool> -> eine Funktion welche einen bool zurückgibt und einen int Parameter hat
		ints.Where(Div2);

		//Anwendungsfälle: Linq, Multithreading/Multitasking, Reflection, EFCore (teilweise), ...

		//Anonyme Funktion (e => ...)
		//Funktion die nicht dediziert als Methode definiert wird (static void ...), sondern nur einmal verwendet wird
		//z.B. bei Where, Count, new Task(...), ...

		//Aufgabe: Eigene Where Funktion
		//Was macht die Where Funktion?
		//Die Where Funktion geht mit einer Schleife über die Liste, und ruft bei jedem Element die übergebene Funktion auf (e => ...)

		Where(ints, e => e % 5 == 0);

		IEnumerable<int> Where(IEnumerable<int> list, Func<int, bool> bedingung)
		{
			List<int> ergebnis = [];
			foreach (int i in list)
			{
				//Hier muss für jedes Element die Funktion verwendet werden
				if (bedingung(i) == true)
					ergebnis.Add(i);
			}
			return ergebnis;
		}
	}

	static void PrintHelloWorld() => Console.WriteLine("Hello World");

	static void PrintZahl(int x) => Console.WriteLine(x);

	static void Addiere(int x, int y) => Console.WriteLine($"{x} + {y} = {x + y}");

	static double Random0To1() => Random.Shared.NextDouble();

	static double Dividiere(int x, int y) => (double) x / y;

	static bool Div2(int x)
	{
		return x % 2 == 0;
	}
}
