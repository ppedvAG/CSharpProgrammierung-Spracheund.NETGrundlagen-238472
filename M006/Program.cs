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

		//Namespaces
		//- Beispiele
		//- Eigene Klassen
		//Assozation
		//- Beispiel Kurs
	}
}