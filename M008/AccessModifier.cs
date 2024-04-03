namespace M008;

public class AccessModifier
{
	private int FeldPrivate { get; set; } //Nur innerhalb der Klasse sichtbar

	public int FeldPublic { get; set; } //Überall sichtbar, auch außerhalb des Projekts

	internal int FeldInternal { get; set; } //Überall sichtbar, aber nur innerhalb des Projekts

	///////////////////////////////////////////////////////////////////////////////////////////
	
	protected int FeldProtected { get; set; } //Wie private, aber auch in Unterklassen (auch außerhalb vom Projekt)

	protected private int FeldProtectedPrivate { get; set; }  //Wie private, aber auch in Unterklassen (nur innerhalb vom Projekt)

	protected internal int FeldProtectedInternal { get; set; } //Wie internal, aber auch in Unterklassen außerhalb
}