using M006.Data;

namespace M006;

internal class Program
{
	static void Main(string[] args)
	{
		//Hier werden die konkreten Werte angelegt

		Person p = new Person(); //new: Neues Objekt aus einer Klasse erstellen
		p.SetVorname("Max"); //Hier muss eine Methode aufgerufen werden
		p.Nachname = "Mustermann"; //Hier kann einfach per = eine Zuweisung gemacht werden

        Console.WriteLine(p.Alter);
        //p.Alter = 30;

        Console.WriteLine(p.VollerName);
		//p.VollerName = "";

		p.Print();

		/////////////////////////////////////////////////////

		Person p2 = new Person("Max", "Mustermann");
		Console.WriteLine(p2.VollerName);

		Person p3 = new Person("Max", "Mustermann", 30);

		//Namespaces (Package)
		//Organisationseinheit in der eine beliebige Anzahl an Typen existieren kann
		//Jedes Projekt hat einen Wurzelnamespace (z.B. M006)
		//Jeder Namespace kann Unternamespaces haben (z.B. M006.Data)
		//Jeder Namespace sollte mit seiner Ordnerstruktur übereinstimmen

		//Person ist jetzt in einem anderen Namespace -> Import
		//using: Importiert alle Typen aus dem gegebenen Namespace

		//System: Standarddinge
		//System.IO: Dateiverarbeitung
		//System.Net.Http: Web Requests (HttpClient)


		//Assozation von Objekten
		//-> Verschachteln von Objekten, Objekte innerhalb anderer Objekte ablegen
		//Beispiel: Kurs[Personen, ...], Person[Vorname, Nachname, Alter, ...]
		Person trainer = new Person("Lukas", "Kern");
		Person tn1 = new Person("", "");
		Person tn2 = new Person("", "");
		Person tn3 = new Person("", "");
		Person tn4 = new Person("", "");

		Kurs k = new Kurs("C# Grundkurs", 4, Kurstyp.Virtuell, trainer, tn1, tn2, tn3, tn4);
	}
}