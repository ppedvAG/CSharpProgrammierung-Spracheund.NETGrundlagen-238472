using System.Windows;

namespace M017;

public partial class MainWindow : Window
{
	Events e = new();

	public MainWindow()
	{
		InitializeComponent();

		//Hier wird jetzt der Code festgelegt, welcher ausgeführt wird, wenn das Event gefeuert wird
		e.StartEvent += E_StartEvent;
		e.EndEvent += E_EndEvent;
		e.ProgressEvent += E_ProgressEvent;
		e.ProgressEvent2 += E_ProgressEvent2;
		//Das Events Objekt ist jetzt Plattformunabhängig (Web, GUI, Konsole, ...)
	}

	private void E_StartEvent(object? sender, EventArgs e) => Output.Text = "Prozess gestartet";

	private void E_EndEvent(object? sender, EventArgs e) => Output.Text = "Prozess beendet";

	private void E_ProgressEvent2(int obj) => Progress.Value = obj;

	private void E_ProgressEvent(object? sender, ProgressEventArgs e) { }

	private async void Button_Click(object sender, RoutedEventArgs e)
	{
		await this.e.StartProcess();
	}
}