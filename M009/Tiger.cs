namespace M009;

/// <summary>
/// Tiger erbt alles von Katze
/// Katze erbt alles von Lebewesen
/// -> Tiger erbt alles von Lebewesen
/// </summary>
public class Tiger : Katze
{
	public Tiger(int alter) : base(alter) { }

	public override void WasBinIch()
	{
        Console.WriteLine("Ich bin ein Tiger");
    }
}