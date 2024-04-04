namespace M013;

public static class ExtensionMethods
{
	public static int Quersumme(this int x)
	{
		return x.ToString().Sum(e => (int) char.GetNumericValue(e));
	}
}