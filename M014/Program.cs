using System.Diagnostics;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace M014;

internal class Program
{
	static void Main(string[] args)
	{
		//3 Klassen: Path, Directory, File

		//Aufgabe: Einen Ordner erstellen und einen Dateipfad anlegen
		string folderPath = "Test";
		string filePath = Path.Combine(folderPath, "Text.txt");

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		StreamWriter sw = new StreamWriter(filePath);
		sw.WriteLine("Test1");
		sw.WriteLine("Test2");
		sw.WriteLine("Test3"); //Die Werte werden nur in einen Buffer geschrieben
		//sw.Flush(); //Buffer in die unterliegende Datei schreiben
		sw.Close(); //Gibt den Zugriff auf die Datei frei

		using (StreamWriter sw2 = new StreamWriter(filePath))
		{
			sw2.WriteLine("Test1");
			sw2.WriteLine("Test2");
			sw2.WriteLine("Test3");
		} //.Dispose() wird hier automatisch durchgeführt

		//Using Statement: Schließt 
		using StreamWriter sw3 = new(filePath);
		sw3.WriteLine("Test1");
		sw3.WriteLine("Test2");
		sw3.WriteLine("Test3");

		sw3.Close();

		using StreamReader sr = new StreamReader(filePath);
		string str = sr.ReadToEnd(); //Ganzes File in einen String lesen

		List<string> lines = []; //Ganzes File in eine Liste lesen (Zeilenweise)
		while (!sr.EndOfStream)
			lines.Add(sr.ReadLine());

		sr.Close();

		//Schnelle Methoden
		File.WriteAllText(filePath, "Test1\nTest2\nTest3\n");
		File.WriteAllLines(filePath, lines);

		string x = File.ReadAllText(filePath);
		string[] y = File.ReadAllLines(filePath);

		////////////////////////////////////////////////////////////////

		//System.Text.Json

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		//string json = JsonSerializer.Serialize(fahrzeuge);
		//File.WriteAllText(filePath, json);

		//string readJson = File.ReadAllText(filePath);
		//Fahrzeug[] fzg = JsonSerializer.Deserialize<Fahrzeug[]>(readJson);

		//NuGet-Packages
		//Externe Pakete
		//Tools -> NuGet Package Manager -> Manage NuGet Packages

		//Newtonsoft.Json
		string json = JsonConvert.SerializeObject(fahrzeuge);
		File.WriteAllText(filePath, json);

		string readJson = File.ReadAllText(filePath);
		Fahrzeug[] fzg = JsonConvert.DeserializeObject<Fahrzeug[]>(readJson);

		//XML
		XmlSerializer xml = new(fahrzeuge.GetType());
		using (StreamWriter sw4 = new(filePath))
		{
			xml.Serialize(sw4, fahrzeuge);
		}

		using (StreamReader sr2 = new(filePath))
		{
			List<Fahrzeug> readFzg = xml.Deserialize(sr2) as List<Fahrzeug>;
		}
		
		xml.Serialize(filePath, fahrzeuge);
		xml.Deserialize<Fahrzeug[]>(filePath);
	}
}

public static class XmlExtensions
{
	public static void Serialize(this XmlSerializer xml, string path, object o)
	{
		using StreamWriter sw4 = new(path);
		xml.Serialize(sw4, o);
	}

	public static T Deserialize<T>(this XmlSerializer xml, string path)
	{
		using StreamReader sr2 = new(path);
		return (T) xml.Deserialize(sr2);
	}
}

[DebuggerDisplay("Marke: {Marke}, MaxV: {MaxV}")]
public class Fahrzeug
{
	public int MaxV { get; set; }

	public FahrzeugMarke Marke { get; set; }

	public Fahrzeug(int v, FahrzeugMarke fm)
	{
		MaxV = v;
		Marke = fm;
	}

    public Fahrzeug()
    {
        
    }
}

public enum FahrzeugMarke
{
	Audi, BMW, VW
}