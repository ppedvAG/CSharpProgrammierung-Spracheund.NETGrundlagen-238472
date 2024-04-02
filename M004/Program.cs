#region Schleifen
//while: Läuft solange die Bedingung true ist
using System.Net;

int a = 0;
int b = 10;

while (a < b)
{
    Console.WriteLine("while: " + a);
    a++;
}

//do-while: Selbiges wie while, wird aber IMMER einmal ausgeführt (auch wenn die Bedingung von Anfang an false ist)
do
{
	Console.WriteLine("do-while: " + a);
	a++;
}
while (a < b);

//do-while mit while (true)
while (true)
{
	a++;

	if (a == 5)
		continue; //Überspringt den Output von 5

	Console.WriteLine("while-true: " + a);

	if (a >= b)
		break; //Sobald break ausgeführt wird, springt der Programmzeiger auf Zeile 29
}
Console.WriteLine("Nach break wird dieses Statement ausgeführt");

//break und continue
//break: Beendet die Schleife
//continue: Überspringe ab hier den Rest der Schleife und springe zum Schleifenkopf zurück


//for-Schleife: Wie while, aber hat einen Zähler mitintegriert
int c = 10;
for (int i = 0; i < c; i++) //Selbiges wie while (a < b) von oben
{
    Console.WriteLine("for: " + i);
}

for (int i = 10 - 1; i >= 0; i--)
{
	Console.WriteLine("forr: " + i);
}

for (int i = 1, j = 2, k = -5; i < 10 && j < 10 && k < 10; i++, j--, k *= 2) { }


//Array durchgehen
int[] zahlen = [1, 2, 3, 4, 5];

//Aufgabe: Alle Zahlen ausgeben
Console.WriteLine(zahlen[0]);
Console.WriteLine(zahlen[1]);
Console.WriteLine(zahlen[2]);
Console.WriteLine(zahlen[3]);
Console.WriteLine(zahlen[4]);

//Mit Schleife
for (int i = 0; i < zahlen.Length; i++) //Schleife von 0 bis zahlen.Length (5)
{
	//i++; //Schleife kann daneben greifen, nicht möglich bei foreach
	Console.WriteLine(zahlen[i]); //Index der Schleife in das Array eingeben
}

//foreach: Schleife die einen direkten Zugriff auf das Element gibt
foreach (int zahl in zahlen)
{
    Console.WriteLine(zahl);
}

string[] namen = ["Max", "Tim", "Udo"];
//Aufgabe: Länge aller Namen ausgeben
foreach (string name in namen)
{
	Console.WriteLine(name.Length);
	Console.WriteLine(name[0]);
}

for (int i = 0; i < namen.Length; i++)
{
	Console.WriteLine(namen[i].Length); //Länge des Namens ausgeben
	Console.WriteLine(namen[i][0]); //Anfangsbuchstabe ausgeben

	//2 * 3 = 6 Arrayzugriffe
}
#endregion

#region Enum
//Enum: Liste von Konstanten
//z.B. Wochentage, Monate

//Eigene Enums müssen unten im Programm definiert werden
//Jeder Enumwert hat immer eine Zahl dahinter, beginnend bei 0

Wochentag tag = Wochentag.Di; //Wir haben jetzt effektiv einen eigenen Typen definiert

if (tag == Wochentag.Di)
{
    Console.WriteLine("Heute ist Dienstag");
}

Console.WriteLine(HttpStatusCode.NotFound);

//Nachdem hinter jedem Enumwert eine Zahl steckt, kann auch hier gecasted werden

//Aufgabe: Der User soll einen Tag eingeben
int eingabe = int.Parse(Console.ReadLine());
Wochentag eingabeTag = (Wochentag) eingabe; //int -> Wochentag
Console.WriteLine($"Dein eingegebener Tag ist {eingabeTag}");
Console.WriteLine($"Die Zahl hinter dem Tag ist {(int) eingabeTag}");

//Jedem Enumwert kann eine Zahl zugewiesen werden
//Mo = 1, ..., So = 7

//Die Enum Klasse
Wochentag[] tage = Enum.GetValues<Wochentag>();

//Aufgabe: Alle HttpCodes ausgeben
foreach (HttpStatusCode code in Enum.GetValues<HttpStatusCode>())
{
    Console.WriteLine(code);
}

//Aufabe: Der Benutzer soll den Tag als Text eingeben
Wochentag eingabe2 = Enum.Parse<Wochentag>(Console.ReadLine());
Console.WriteLine($"Dein eingegebener Tag ist {eingabe2}");
#endregion

#region Switch
//Switch: Einfachere Darstellung eines if/else Baumes
Wochentag switchTag = Wochentag.So;

switch (switchTag) //Hier der Wert der verarbeitet werden soll
{
	case Wochentag.Mo: //case: effektiv eine if
	case Wochentag.Di:
	case Wochentag.Mi:
	case Wochentag.Do:
	case Wochentag.Fr:
        Console.WriteLine("Unter der Woche");
        break; //break muss am Ende jedes Cases gemacht werden
	case Wochentag.Sa:
	case Wochentag.So:
        Console.WriteLine("Wochenende");
        break;
	default: //default: else
        Console.WriteLine("Fehler");
        break;
}

//Boolescher Switch
switch (switchTag)
{
	case >= Wochentag.Mo and <= Wochentag.Fr:
		Console.WriteLine("Unter der Woche");
		break;
	case Wochentag.Sa or Wochentag.So:
        Console.WriteLine("Wochenende");
		break;
	default:
		Console.WriteLine("Fehler");
		break;
}

if (switchTag == Wochentag.Mo || switchTag == Wochentag.Di) { }
if (switchTag is Wochentag.Mo or Wochentag.Di) { }
#endregion

enum Wochentag
{
	Mo = 1, Di, Mi, Do, Fr, Sa, So
}