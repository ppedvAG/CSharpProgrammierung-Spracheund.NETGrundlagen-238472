namespace M009;

public class Katze : Lebewesen
{
	public Katze(int alter) : base(alter) { }

	public override void WasBinIch()
	{
		Console.WriteLine("Ich bin eine Katze");
	}
}
