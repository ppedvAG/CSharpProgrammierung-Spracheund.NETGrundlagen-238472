namespace M016;

/// <summary>
/// Event
/// 
/// Zweiseitige Entwicklung
/// -Entwicklerseite
/// --Ruft das Event auf, nachdem geprüft wurde, ob das Event gefeuert werden kann
/// 
/// -Anwenderseite
/// --Legt fest, was beim feuern des Events passiert (+=)
/// </summary>
public class Events
{
	public event EventHandler StartEvent; //Entwicklerseite

	public event EventHandler EndEvent;

	public event EventHandler<ProgressEventArgs> ProgressEvent;

	public event Action<int> ProgressEvent2; //Events können beliebige Delegates haben

	public void StartProcess()
	{
		StartEvent?.Invoke(this, EventArgs.Empty); //sender: this, EventArgs.Empty: keine Daten
		for (int i = 0; i < 10; i++)
		{
			Thread.Sleep(200);
			//Progress Event mit i als Datenpunkt
			ProgressEvent?.Invoke(this, new ProgressEventArgs() { Progress = i });
			ProgressEvent2?.Invoke(i);
		}
		EndEvent?.Invoke(this, EventArgs.Empty);
	}
}

public class ProgressEventArgs : EventArgs
{
	public int Progress { get; set; }
}