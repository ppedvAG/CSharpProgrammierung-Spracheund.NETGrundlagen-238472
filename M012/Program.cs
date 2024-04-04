namespace M012;

internal class Program
{
	static void Main(string[] args)
	{
		//Generisches Typargument (Generic)
		//Platzhalter für einen bestimmten Datentypen
		//Ersetzt alle Vorkommnisse innerhalb der Methode/Klasse mit dem angegebenen Typen
		//Wird generell als T bezeichnet/fängt mit T an
		List<int> ints = new List<int>();
		ints.Add(1); //T wird durch int ersetzt

		ints.Remove(1); //T wird durch int ersetzt

		List<string> strings = new List<string>();
		strings.Add("A");

		foreach (int x in ints) //Liste durchgehen genauso wie Array
		{
            Console.WriteLine(x);
        }

        Console.WriteLine(ints.Count); //Length == Count

		Console.WriteLine(ints[0]); //Index genauso wie bei Array

        //Dictionary: Liste von Schlüssel-Wert Paaren
        //Hat 2 Generics (Key, Value)
        Dictionary<string, int> einwohnerzahlen = new(); //Target-typed new: Ergänzt den Typen von links
		einwohnerzahlen.Add("Wien", 2_000_000);
		einwohnerzahlen.Add("Berlin", 3_650_000);
		einwohnerzahlen.Add("Paris", 2_160_000);
        //einwohnerzahlen.Add("Paris", 2_160_000); //Schlüssel müssen eindeutig sein

        Console.WriteLine(einwohnerzahlen.Count); //Count genauso wie bei List

		Console.WriteLine(einwohnerzahlen["Wien"]); //Index per Datentyp vom Key

		//var: Ergänzt den Typen anhand des Inhalts automatisch
		//Strg + .: Use explicit type instead of var
		foreach (KeyValuePair<string, int> x in einwohnerzahlen)
		{
            Console.WriteLine($"Die Stadt {x.Key} hat {x.Value} Einwohner.");
        }

		einwohnerzahlen.ContainsKey("Wien"); //Sollte vor [] verwendet werden

        Console.WriteLine(einwohnerzahlen.Keys); //Nur die Keys
        Console.WriteLine(einwohnerzahlen.Values); //Nur die Values
    }
}
