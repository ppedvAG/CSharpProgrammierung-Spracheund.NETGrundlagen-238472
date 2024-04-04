namespace M009;

/// <summary>
/// Mit : <Klasse> eine Vererbung herstellen
/// Mensch erbt Alter und WasBinIch()
/// 
/// Strg + .: Generate Constructor
/// </summary>
public class Mensch : Lebewesen
{
	public string Name { get; set; }

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
}
