#region Variablen
Console.WriteLine("Hello World"); //cw + Tab

//Kommentar

/*
	Mehrzeiliger
	Kommentar
*/

//Variable: Behälter für einen Wert
//Aufbau: <Typ> <Name>;

int Zahl; //int: Ganze Zahl
Zahl = 5; //In Zahl einen Wert eintragen

Console.WriteLine(Zahl);

string Text = "Das ist ein Text"; //string: Text, doppelte Hochkomma um den Text herum
Console.WriteLine(Text);

//Wichtigste Typen: int, double, string, bool

//int: Ganze Zahl
//Alternativen: byte, short, long (unterschiedliche Längen)

//double: Kommazahl
//Alternativen: float, decimal (unterschiedliche Längen)
float f = 259.2358f;
decimal d = 328.231848m;

//string: Text
//char: Einzelnes Zeichen
char c = 'A'; //Einzelne Hochkomma

//bool: Wahr-/Falschwert
bool t = true;
bool f = false;
#endregion

#region Strings
//Strings verknüpfen
string zahlText = "Deine Zahl ist " + Zahl; //Mit + können beliebige Werte zusammengebaut werden
Console.WriteLine(zahlText);

string kombination = "Deine Zahl ist " + Zahl + ", der Text ist: " + Text + ", dein Zeichen ist: " + c; //Anstrengend
Console.WriteLine(kombination);

//$-String (String Interpolation): Code in einen String einbauen
//Normalerweise wird Code in einem String nicht ausgeführt

string interpolation = $"Deine Zahl ist {Zahl}, der Text ist: {Text}, dein Zeichen ist: {c}";
Console.WriteLine(interpolation);

Console.WriteLine(kombination == interpolation);

//Escape-Sequenzen: Undruckbare Zeichen in einen String einbauen
//https://docs.microsoft.com/en-us/cpp/c-language/escape-sequences?view=msvc-170
//Wichtigste: \n (Zeilenumbruch)
string umbruch = "Umbruch \n Umbruch";
Console.WriteLine(umbruch);

//@-String (Verbatim String): Ignoriert Escape Sequenzen/Nimmt den String genau so wie er geschrieben wurde
string pfad = @"C:\Program Files\dotnet\shared\Microsoft.NETCore.App\8.0.1\System.Security.AccessControl.dll";
string pfad2 = "C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\8.0.1\\System.Security.AccessControl.dll";

Console.WriteLine(pfad2);
#endregion

#region Eingabe
Console.ReadLine(); //Eingabe vom Benutzer verlangen
//Rückgabewerte: Jede Funktion hat ein Ergebnis, dieses Ergebnis kann später weiterverwendet werden

string eingabe = Console.ReadLine(); //Rückgabewert der Funktion steht in der Eingabe Variable
Console.WriteLine($"Du hast {eingabe} eingegeben");

ConsoleKeyInfo info = Console.ReadKey(true); //Wartet auf ein einzelnes Zeichen vom Benutzer
Console.WriteLine($"Du hast {info.Key} getippt");
#endregion

#region Konvertierung
//Drei Möglichkeiten:
//Zahl zu String
//String zu Zahl
//Zahl zu Zahl


//Zahl zu String: Interpolation ($-String), ToString()
int zs = 123;
string zsString = zs.ToString(); //Nicht einfach so kompatibel
zsString = $"{zs}";


//String zu Zahl: Parse
//Parse-Funktion: Lese den String aus, und versuchen diesen umzuwandeln
string zahlString = "123";
//int doppelt = zahlString * 2; //Strings können nicht multipliziert werden
int parse = int.Parse(zahlString); //Rückgabewert: Die Zahl die ausgelesen wurde
int doppelt = parse * 2;
Console.WriteLine(doppelt);


//Zahl zu Zahl
double kommazahl = 2.5;
//int x = kommazahl; //Nicht möglich, weil int keine Kommastellen hat

//Cast, Typecast, Casting: Umwandlung von einer Variable in einen anderen Typen erzwingen
int x = (int) kommazahl; //Konvertierung erzwingen -> expliziter Cast
Console.WriteLine(x);

double y = x; //int passt immer in double -> impliziter Cast
#endregion

#region	Arithmetik
//Grundrechenarten: +, -, *, /
int zahl1 = 4;
int zahl2 = 7;

//zahl1 + zahl2; //Berechne die Summe und gib diese zurück
Console.WriteLine(zahl1 + zahl2); //Hier muss das Ergebnis irgendwo verwendet werden
int summe = zahl1 + zahl2;

Console.WriteLine(zahl1); //7
zahl1 += zahl2; //Berechne die Summe und schreibt diese in die linke Variable hinein ("aufsummieren")
Console.WriteLine(zahl1); //11

//Modulo (%): Gibt den Rest einer Division zurück
Console.WriteLine(zahl1 % 2); //Ist die Zahl gerade oder ungerade?
Console.WriteLine(zahl1 % 10); //Die Einserstelle
Console.WriteLine(zahl1 % 100); //Die Zehner- und Einserstelle

zahl1++; //Erhöhe die Zahl um 1
zahl1--; //Verringere die Zahl um 1

//Rundungsfunktionen
Math.Floor(4.5); //Abrunden
Math.Ceiling(4.5); //Aufrunden

Math.Round(4.5); //Rundet auf oder ab, rundet bei .5 zur nächsten geraden Zahl

Math.Round(4.5); //4
Math.Round(5.5); //6

double gerundet = Math.Round(9329.2318573219);
Console.WriteLine(gerundet);

gerundet = Math.Round(9329.2318573219, 2); //Auf X Kommastellen runden
Console.WriteLine(gerundet);

//Divisionen
Console.WriteLine(8 / 5); //1, weil die beiden Zahlen ints sind -> int-Division
Console.WriteLine(8.0 / 5);
Console.WriteLine(8d / 5);
Console.WriteLine(8 / 5d);
Console.WriteLine(8f / 5);
Console.WriteLine(8m / 5);
Console.WriteLine((double) zahl1 / zahl2); //Hier per Cast eine der beiden Zahlen zu einer Kommazahl dividieren
#endregion