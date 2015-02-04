using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;


namespace InitialState {
  [TestClass]
  public class InitialState {

    private static TestContext test_context;
    private static Window window;
    private static Application application;
    
    [ClassInitialize]
    public static void Setup(TestContext _context) {
      test_context = _context;
      var applicationDir = _context.DeploymentDirectory;
      var applicationPath = Path.Combine(applicationDir, "..\\..\\..\\DevDash\\bin\\Debug\\DevDash");
      application = Application.Launch(applicationPath);
      window = application.GetWindow("MainWindow", InitializeOption.NoCache);
    }

    [TestMethod]
    public void TestZeroState() {
      Button Current_Projects = window.Get<Button>("Current_Projects_Button");
      Button Past_Projects = window.Get<Button>("Past_Projects_Button");
      Button New_Project = window.Get<Button>("Main_New_Project_Button");

      Assert.IsFalse(Current_Projects.Enabled);
      Assert.IsFalse(Past_Projects.Enabled);
      Assert.IsTrue(New_Project.Enabled);
    }

    [ClassCleanup]
    public static void TearDown() {
      window.Close();
      application.Close();
    }
  }
}
