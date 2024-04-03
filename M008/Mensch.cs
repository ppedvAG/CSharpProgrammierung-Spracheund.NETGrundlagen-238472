namespace M008;

/// <summary>
/// Mit : <Klasse> eine Vererbung herstellen
/// Mensch erbt Alter und WasBinIch()
/// 
/// Strg + .: Generate Constructor
/// </summary>
public class Mensch : Lebewesen
{
	public string Name { get; set; }
	
	/// <summary>
	/// Wie kommt Name jetzt in diesen Konstruktor?
	/// -> Einfach dazu schreiben
	/// 
	/// base: Selbiges wie this, aber bewegt sich in Vererbungshierarchien
	/// </summary>
	public Mensch(int alter, string name) : base(alter) //Verkettung erzwungen
	{
		Name = name;
	}

	/// <summary>
	/// override eintippen -> Abstand -> Methode auswählen -> Enter
	/// </summary>
	public override void WasBinIch2()
	{
        //base.WasBinIch2(); //base: Führe die Methode der Oberklasse aus
        Console.WriteLine("Ich bin ein Mensch");
    }
}
