using DevDash.Model;
using DevDash.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White.UIItems;

namespace TestDevDash.UserTests {
  [TestClass]
  public class ZeroStateUserTest : TestHelper {

    [ClassInitialize]
    public static void SetUpTests(TestContext _context) {
      TestHelper.SetUpClass(_context);
    }

    [TestInitialize]
    public void SetUpTests() {
      TestHelper.TestPrep();
    }

    [TestCleanup]
    public void CleanUp() {
      TestHelper.CleanThisUp();
    }

    [TestMethod]
    public void TestZeroState(){
      Button past = window.Get<Button>("Past_Projects_Button");
      Button current = window.Get<Button>("Current_Projects_Button");
      Button add = window.Get<Button>("Main_New_Project_Button");

      Assert.IsTrue(past.Enabled);
      Assert.IsTrue(current.Enabled);
      Assert.IsTrue(add.Enabled);
    }
  } 
}
