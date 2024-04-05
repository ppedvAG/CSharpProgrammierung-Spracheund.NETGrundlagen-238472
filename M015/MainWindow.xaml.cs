using System.Diagnostics;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace M015;

public partial class MainWindow : Window
{
	private int Counter;

	public MainWindow()
	{
		InitializeComponent();

		Dropdown.ItemsSource = new int[] { 1, 2, 3, 4, 5 };

		List.ItemsSource = new int[] { 1, 2, 3, 4, 5 };

		DG.ItemsSource = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};
	}

	/// <summary>
	/// Event
	/// 
	/// Zweiseitige Entwicklung
	/// -Entwicklerseite
	/// --Ruft das Event auf, nachdem geprüft wurde, ob das Event gefeuert werden kann
	/// 
	/// -Anwenderseite
	/// --Legt fest, was beim feuern des Events passiert
	/// </summary>
	private void ButtonTop(object sender, RoutedEventArgs e)
	{
		//Aufgabe: Zähler um 1 erhöhen und diesen in der GUI anzeigen
		Counter++;
		CounterTB.Text = "Zähler: " + Counter;
	}

	private void ButtonLinks(object sender, RoutedEventArgs e)
	{
		//Benötigt Microsoft.Win32

		//Aufgabe: File öffnen und Text in einen TextBlock schreiben (nur .txt Dateien)

		/*
			Die bereitgestellte Filterzeichenfolge ist ungültig. 
			Die Filterzeichenfolge muss eine Beschreibung des Filters enthalten, gefolgt von einem vertikalen Strich und dem Filtermuster. 
			Weitere Paare aus Filterbeschreibung und Muster müssen ebenfalls durch einen vertikalen Strich getrennt werden. 
			Mehrere Erweiterungen in Filtermustern werden mit einem Semikolon getrennt. 
			Beispiel: \"Bilddateien (*.bmp, *.jpg)|*.bmp;*.jpg|Alle Dateien (*.*)|*.*\"'
		 */
		OpenFileDialog dialog = new();
		dialog.Multiselect = false;
		dialog.Filter = "Text|*.txt";
		bool? b = dialog.ShowDialog();
		if (b == true)
		{
			FileText.Text = File.ReadAllText(dialog.FileName);
		}
	}

	private void ButtonRechts(object sender, RoutedEventArgs e)
	{
		//Benötigt Microsoft.Win32
		SaveFileDialog dialog = new();
		dialog.ShowDialog();
	}

	private void Dropdown_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
	{
		//Hier gibt es Zugriff auf das Item (Fahrzeug könnte angegriffen werden)
		InfoText.Text = Dropdown.SelectedItem.ToString();
	}

	private void List_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
	{
		//Aufgabe: Alle ausgewählten Items anzeigen
		InfoText.Text = string.Join(", ", List.SelectedItems.OfType<int>());
	}

	private void CheckBox_Checked(object sender, RoutedEventArgs e)
	{

	}

	private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
	{

	}

	private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
	{
		InfoText.Text = e.NewValue.ToString();
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		MessageBoxResult result = MessageBox.Show("Hallo", "Hallo", MessageBoxButton.OK, MessageBoxImage.Information);
		if (result == MessageBoxResult.OK)
		{
			MainWindow mw = new MainWindow();
			mw.Show();
			//...
		}
	}
}

[DebuggerDisplay("Marke: {Marke}, MaxV: {MaxV}")]
public class Fahrzeug
{
	public int MaxV { get; set; }

	public FahrzeugMarke Marke { get; set; }

	public Fahrzeug(int v, FahrzeugMarke fm)
	{
		MaxV = v;
		Marke = fm;
	}

	public Fahrzeug()
	{

	}
}

public enum FahrzeugMarke
{
	Audi, BMW, VW
}