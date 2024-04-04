using M011;

namespace M011_Tests;

[TestClass]
public class RechnerTests
{
	//View -> Test Explorer

	//Rechtsklick auf Dependencies -> Add Project Reference -> Projekt auswählen

	Rechner r;

	[TestInitialize]
	public void Setup() => r = new Rechner();

	[TestCleanup]
	public void Cleanup() => r = null;

	[TestMethod]
	[TestCategory("Addiere")]
	public void TesteAddiere()
	{
		double ergebnis = r.Addiere(3, 4);

		//Assert: Wird benötigt, um den Test auszuwerten
		Assert.AreEqual(7, ergebnis);
	}

	[TestMethod]
	[TestCategory("Subtrahiere")]
	public void TesteSubtrahiere()
	{
		double ergebnis = r.Subtrahiere(3, 4);

		//Assert: Wird benötigt, um den Test auszuwerten
		Assert.AreEqual(-1, ergebnis);
	}
}