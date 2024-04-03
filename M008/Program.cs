namespace M008;

internal class Program
{
	static void Main(string[] args)
	{
		Mensch m = new Mensch(30, "Max");
		m.Alter = 30;
		m.WasBinIch();
	}
}