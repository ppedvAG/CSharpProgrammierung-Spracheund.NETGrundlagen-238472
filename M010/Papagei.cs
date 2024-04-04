namespace M010;

public class Papagei : Vogel, ISprechen
{
	public Papagei(int alter) : base(alter)	{ }

	public string Sprache { get; set; }

	public string SprachInfo()
	{
		return $"Dieser Papagei spricht {Sprache}";
	}

	public void Sprechen(string text)
	{
        Console.WriteLine(text);
    }
}