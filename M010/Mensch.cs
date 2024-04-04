namespace M010;

/// <summary>
/// Mit : <Klasse> eine Vererbung herstellen
/// Mensch erbt Alter und WasBinIch()
/// 
/// Strg + .: Generate Constructor
/// </summary>
public class Mensch : Lebewesen, ISprechen
{
	public string Name { get; set; }

	public string Sprache { get; set; }

	public Mensch(int alter, string name) : base(alter) => Name = name;

	/// <summary>
	/// Strg + .: Implement abstract class
	/// </summary>
	public override void WasBinIch()
	{
        Console.WriteLine("Ich bin ein Mensch");
    }

	public void Sprechen(string s)
	{
        Console.WriteLine(s);
    }

	public string SprachInfo()
	{
		return $"Dieser Mensch spricht {Sprache}";
	}
}
