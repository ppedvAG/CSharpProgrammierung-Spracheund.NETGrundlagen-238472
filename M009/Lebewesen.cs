namespace M009;

public abstract class Lebewesen
{
	public int Alter { get; set; }

	/// <summary>
	/// abstract auf Methode: Methode ohne Body -> MUSS von jeder Unterklasse implementiert werden
	/// </summary>
	public abstract void WasBinIch();

	public Lebewesen(int alter) => Alter = alter;

	public override string ToString()
	{
		return $"Ich bin ein Lebewesen und bin {Alter} Jahre alt.";
	}
}
