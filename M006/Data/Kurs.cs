namespace M006.Data;

public class Kurs
{
	public string Titel { get; set; }

	public int Dauer { get; set; }

	public Kurstyp Typ { get; set; }

	public Person Trainer { get; set; }

	public Person[] Teilnehmer { get; set; }

	public Kurs(string titel, int dauer, Kurstyp typ, Person trainer, params Person[] teilnehmer)
	{
		Titel = titel;
		Dauer = dauer;
		Typ = typ;
		Trainer = trainer;
		Teilnehmer = teilnehmer;
	}
}