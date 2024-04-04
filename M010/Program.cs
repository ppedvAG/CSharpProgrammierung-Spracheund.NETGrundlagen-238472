namespace M010;

internal class Program
{
	static void Main(string[] args)
	{
		//Interfaces
		//Selbiges wie Abstrake Klassen
		//- Kann nicht instanziert werden
		//- Muss vererbt werden
		//- Implementiert keinen Code, sondern nur Strukturen
		//aber, eine Klasse kann beliebig viele Interfaces als Oberklassen haben

		//Warum Interfaces?
		//-> Polymorphismus
		//Klassen "gruppieren", die keine Gemeinsamkeiten haben

		//Aufgabe: Mensch und Papagei sollen sprechen können
		//Problem: Vererbungstechnisch haben diese zwei Klassen nichts gemeinsam
		//Lösung: Interfaces

		Mensch m = new Mensch(0, "");
		Papagei p = new Papagei(0);

		ISprechen s = m;
		s = p;
		s.SprachInfo();

		ISprechen[] x = new ISprechen[2];
		x[0] = m;
		x[1] = p;
		foreach (ISprechen sp in x)
			sp.Sprechen("Hallo");

		if (m is ISprechen)
		{

		}

		//Beispiel: IEnumerable
		//Die Basis von allen Listentypen in C#
		IEnumerable<int> e = new int[10];
		IEnumerable<int> f = new List<int>();
		IEnumerable<int> g = new Queue<int>();

		ListeVerarbeiten(e);
		ListeVerarbeiten(f);
		ListeVerarbeiten(g);
	}

	/// <summary>
	/// Egal welche Liste wir haben, sie passt hier hinein
	/// </summary>
	public static void ListeVerarbeiten(IEnumerable<int> x)
	{
		foreach (int i in x)
            Console.WriteLine(i);
    }
}

public interface ISprechen
{
	string Sprache { get; set; }

	void Sprechen(string text);

	string SprachInfo();
}