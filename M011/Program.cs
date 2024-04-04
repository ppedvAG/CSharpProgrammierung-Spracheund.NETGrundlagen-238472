namespace M011;

internal class Program
{
	static void Main(string[] args)
	{
		//Hier wird der Loggingcode an das Event angehängt
		AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
		//throw new Exception("Hallo");

		try //Codeblock markieren -> Rechtsklick -> Snippet -> Surround With
		{
			string eingabe = Console.ReadLine();
			int x = int.Parse(eingabe); //Maus über Methode -> Exceptions

			if (x == 0)
				throw new ArgumentException("Zahl darf nicht 0 sein"); //throw: Exception verursachen

			//Warum Exceptions werfen?
			//Console.WriteLine("Zahl darf nicht 0 sein"); //Console funktioniert nur in Konsolenanwendungen
			//Exception Handling funktioniert in jeder Anwendung (Konsole, GUI, Web, ...)
		}
		catch (FormatException)
		{
            Console.WriteLine("Keine Zahl eingegeben");
        }
		catch (OverflowException)
		{
            Console.WriteLine("Zahl zu groß/klein");
        }
		catch (Exception e)
		{
			Console.WriteLine("Anderer Fehler");
			Console.WriteLine(e.Message); //C# interne Nachricht
			Console.WriteLine(e.StackTrace); //Zurückverfolgung, wo die Exception aufgetreten ist
		}
		finally
		{
            Console.WriteLine("Parsen beendet");
        }
	}

	private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
	{
		Exception ex = e.ExceptionObject as Exception;
		File.WriteAllText("Log.txt", ex.Message + "\n" + ex.StackTrace);
	}
}
