namespace M008;

/// <summary>
/// Vererbung
/// Gemeinsamkeiten zwischen Klassen ermöglichen
/// Oberklassen vererben ihre Felder, Properties und Methoden nach unten in die Unterklassen
/// </summary>
public class Lebewesen
{
	//Alter und WasBinIch() werden in die Unterklassen vererbt
	public int Alter { get; set; }

	public void WasBinIch()
	{
        Console.WriteLine("Ich bin ein Lebewesen");
    }

	/// <summary>
	/// Problem: Methoden können nicht einfach überschrieben werden
	/// 
	/// Lösung: virtual + override
	/// In der Oberklasse wird die Methode als virtual gekennzeichnet
	/// In der Unterklasse wird diese Methode per override überschrieben
	/// 
	/// virtual Methoden müssen nicht überschrieben werden
	/// Wenn diese nicht überschrieben werden, wird die Standardimplementation ausgeführt (Code der Oberklasse)
	/// </summary>
	public virtual void WasBinIch2()
	{
		Console.WriteLine("Ich bin ein Lebewesen");
	}

	/// <summary>
	/// Wenn in einer Oberklasse ein Konstruktor angelegt wird, muss dieser in den Unterklassen verkettet werden
	/// </summary>
	public Lebewesen(int alter)
	{
		Alter = alter;
	}
}
