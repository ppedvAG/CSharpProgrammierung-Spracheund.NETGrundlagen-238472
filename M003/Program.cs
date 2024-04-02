#region Arrays
//Array: Typ, welcher mehrere Werte halten kann (statt genau einem)
int[] zahlen; //Mit [] ein Array definieren
zahlen = new int[10]; //Hier muss ein Array mit X (hier 10) Stellen definiert werden

zahlen[2] = 10; //Bestimmte Stelle angreifen
zahlen[3] = 20;
Console.WriteLine(zahlen[3]);

int[] direkt1 = new int[] { 1, 2, 3, 4, 5 }; //Hier werden die gegebenen Werte eingetragen (statt 0)
int[] direkt2 = new[] { 1, 2, 3, 4, 5 };
int[] direkt3 = { 1, 2, 3, 4, 5 };
int[] direkt4 = [1, 2, 3, 4, 5]; //seit C# 12

Console.WriteLine(zahlen.Length); //Die Anzahl der Elemente (hier 10)
Console.WriteLine(direkt1.Length); //5

//Contains: Prüft, ob ein Element im Array enthalten ist
Console.WriteLine(zahlen.Contains(10)); //true
Console.WriteLine(zahlen.Contains(15)); //false

zahlen.Average(); //Durchschnitt bilden
zahlen.Sum(); //Summiert das Array auf
#endregion

#region Bedingungen
//Booleschen Operatoren
//==, !=
//<, >
//<=, >=

//Logischen Operatoren
//&&, ||
//XOR: ^
//Not: !

int zahl1 = 4;
int zahl2 = 7;

//Wenn die beiden Zahlen gleich sind, soll eine Ausgabe erscheinen
if (zahl1 == zahl2)
{
    Console.WriteLine("z1 und z2 sind gleich");
}
else
{
	Console.WriteLine("z1 und z2 sind nicht gleich");
}

//Wenn zahl1 größer 0 und zahl2 größer 0, soll eine Ausgabe erscheinen
if (zahl1 > 0 && zahl2 > 0)
{
	Console.WriteLine("z1 und z2 sind größer 0");
}

if (zahl1 > 0 || zahl2 > 0)
{
	//z1 > 0 oder z2 > 0 oder beide > 0
    Console.WriteLine("z1 oder z2 ist größer als 0");
}

if (zahl1 > 0 ^ zahl2 > 0)
{
	//z1 > 0 oder z2 > 0 aber nicht beide > 0
	Console.WriteLine("z1 oder z2 aber nicht beide sind größer als 0");
}

//Wenn zahlen 10 enthält, soll eine Ausgabe erscheinen
if (zahlen.Contains(10))
{
    Console.WriteLine("zahlen enthält 10");
}

//Wenn zahlen nicht 10 enthält, soll eine Ausgabe erscheinen
if (!zahlen.Contains(10))
{
	//Durch ! vor einer Bedingung, wird diese invertiert
	Console.WriteLine("zahlen enthält nicht 10");
}

//Wenn eine if/else eine Zeile hat, können die Klammern weggelassen werden
if (zahl1 == zahl2)
	Console.WriteLine("z1 und z2 sind gleich");
else
	Console.WriteLine("z1 und z2 sind nicht gleich");

//Else-If existiert eigentlich nicht, sondern durch das weglassen der Klammern, kann eine else-if dargestellt werden
if (zahl1 == zahl2)
	Console.WriteLine("z1 und z2 sind gleich");
else if (zahl1 == zahl2)
	Console.WriteLine("z1 und z2 sind nicht gleich");

//Ternary-Operator (?-Operator): If/Elses verkürzen
if (zahl1 == zahl2)
	Console.WriteLine("z1 und z2 sind gleich");
else
	Console.WriteLine("z1 und z2 sind nicht gleich");

Console.WriteLine(
	zahl1 == zahl2 ?
	"z1 und z2 sind gleich" :
	"z1 und z2 sind nicht gleich"); //? ist if, : ist else

//Von zahl1 und zahl2 die größte der beiden in die Variable schreiben
int groessereZahl = zahl1 > zahl2 ? zahl1 : zahl2;

if (zahl1 > zahl2)
	groessereZahl = zahl1;
else
	groessereZahl = zahl2;
#endregion