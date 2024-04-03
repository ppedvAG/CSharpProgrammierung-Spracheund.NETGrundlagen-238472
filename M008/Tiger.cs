namespace M008;

/// <summary>
/// Tiger erbt alles von Katze
/// Katze erbt alles von Lebewesen
/// -> Tiger erbt alles von Lebewesen
/// </summary>
public class Tiger : Katze
{
	public Tiger(int alter) : base(alter) { }
}