namespace M007;

/// <summary>
/// class
/// Stellt die Struktur von den fertigen Objekten dar
/// Enthält Felder, Properties, Methoden, Konstruktoren, Destruktor
/// Wenn aus dieser Klasse ein Objekt erstellt wird, bekommt dieses Objekt alle definierten Member der Klasse
/// 
/// WICHTIG: Innerhalb einer Klasse sollten keine konkreten Werte definiert werden
/// </summary>
public class Person
{
	#region Feld
	/// <summary>
	/// private: Kann nur innerhalb der Klasse angegriffen werden
	/// </summary>
	private string vorname;

	/// <summary>
	/// Get-Methode gibt nur den Wert zurück
	/// </summary>
	public string GetVorname()
	{
		return vorname;
	}

	/// <summary>
	/// Set-Methode schreibt einen neuen Wert in das Feld hinein
	/// Bietet u.a. Sicherheit (z.B. Überprüfungen)
	/// </summary>
	public void SetVorname(string vorname)
	{
		if (vorname.Length >= 3 && vorname.Length <= 15 && vorname.All(char.IsLetter))
		{
			this.vorname = vorname; //this: Greife aus der Methode hinaus, wird verwendet wenn zwei Felder den gleichen Namen haben
		}
		else
			Console.WriteLine("Name darf nur aus Buchstaben bestehen und muss zw. 3 und 15 Zeichen haben!");
	}
	#endregion

	#region Eigenschaft/Property
	private string nachname;

	/// <summary>
	/// Property
	/// Vereinfacht Get-/Set Methoden
	/// Selbiges wie Get/Set, aber einfacher in der Verwendung
	/// </summary>
	public string Nachname
	{
		get
		{
			return nachname;
		}
		set
		{
			//Oben: SetVorname(string vorname), Hier: set + value Keyword
			if (value.Length >= 3 && value.Length <= 15 && value.All(char.IsLetter))
				nachname = value;
			else
				Console.WriteLine("Name darf nur aus Buchstaben bestehen und muss zw. 3 und 15 Zeichen haben!");
		}
	}

	//Typen von Properties
	//- Full-Property: Property mit Getter und Setter + private Feld dahinter (siehe oben)
	//- Auto-Property: Property ohne private Feld mit { get; set; }
	//- Get-Only-Property: Property ohne Setter, welches nur einen Wert berechnet/zurückgibt/weitergibt

	//Anwendungsfälle:
	//GUI Verbindung zw. Backend und Oberfläche
	//Serialisierung bei XML, JSON
	//Access Modifier (private, ...) auf den Setter geben
	public int Alter { get; private set; } = 20;

	public string VollerName
	{
		get
		{
			return vorname + " " + nachname;
		}
	}

	public string VollerName2
	{
		get => vorname + " " + nachname;
	}

	public string VollerName3 => vorname + " " + nachname;
	#endregion

	#region Funktionen
	/// <summary>
	/// Funktionen beziehen sich auf das fertige Objekt
	/// Wenn eine Funktion aufgerufen werden soll, MUSS ein Objekt dieser Klasse existieren
	/// Jede Funktion hat Zugriff auf die Werte des Objekts von dem sie aufgerufen wird
	/// p.Print() -> p.VollerName, p.Alter
	/// 
	/// WICHTIG: Nicht static benutzen
	/// static: Global, bezieht sich nicht auf die umliegende Klasse/Objekt
	/// </summary>
	public void Print()
	{
        Console.WriteLine($"Mein Name ist {VollerName} und ich bin {Alter} Jahre alt.");
    }
    #endregion

    #region Konstruktor
	/// <summary>
	/// Konstruktor
	/// Initialcode bei Erstellung (per new) des Objekts
	/// Wird immer ausgeführt, wenn das Objekt erstellt wird
	/// Standardmäßig gibt es immer den leeren Konstruktor
	/// </summary>
    public Person()
	{
        Console.WriteLine("Person wurde erstellt");
		Zaehler++;
    }

	/// <summary>
	/// Hier können jetzt per Parameter Standardwerte verlangt werden
	/// Es darf jetzt keine Person mehr angelegt werden ohne vorname und nachname
	/// 
	/// Wenn ein eigener Konstruktor angelegt wird, wird der Standardkonstruktor gelöscht
	/// </summary>
	public Person(string vorname, string nachname) : this()
	{
		this.vorname = vorname;
		this.nachname = nachname;

		//SetVorname(vorname);
		//Nachname = nachname;
	}

	/// <summary>
	/// Konstruktoren verketten
	/// Mit this(...) können mehrere Konstruktoren miteinander verkettet werden
	/// D.h. wenn dieser Konstruktor aufgerufen wird, wird der darüber auch aufgerufen
	/// </summary>
	public Person(string vorname, string nachname, int alter) : this(vorname, nachname) //Hier müssen die Werte des verketteten Konstruktors mitgegeben werden
	{
		//this.vorname = vorname;
		//this.nachname = nachname;
		Alter = alter;
	}
    #endregion

	~Person()
	{
        Console.WriteLine("Person zerstört");
    }

	//Global
	public static int Zaehler { get; private set; }
}