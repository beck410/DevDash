using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using DevDash;
using TestStack.White.UIItems.Finders;

namespace InitialState {
  [TestClass]
  public class InitialState {

    private static TestContext test_context;
    private static Window window;
    private static Application application;
    private static Button Current_Projects;
    private static Button Past_Projects;
    private static Button New_Project;
    private static TextBox New_Project_Github;
    private static TextBox New_Project_Name;
    private static TextBox New_Project_Description;

    [ClassInitialize]
    public static void Setup(TestContext _context) {
      test_context = _context;
      var applicationDir = _context.DeploymentDirectory;
      var applicationPath = Path.Combine(applicationDir, "..\\..\\..\\DevDash\\bin\\Debug\\DevDash");
      application = Application.Launch(applicationPath);
      window = application.GetWindow("MainWindow", InitializeOption.NoCache);
      Current_Projects = window.Get<Button>("Current_Projects_Button");
      Past_Projects = window.Get<Button>("Past_Projects_Button");
      New_Project = window.Get<Button>("Main_New_Project_Button");
      New_Project_Description = window.Get<TextBox>("New_Project_Description");
      New_Project_Github = window.Get<TextBox>("New_Project_Github");
      New_Project_Name = window.Get<TextBox>("New_Project_Name");
      
    }

    [TestMethod]
    public void TestInitialStateOfProjectListButtons() {
      Assert.IsTrue(Current_Projects.Enabled);
      Assert.IsTrue(Past_Projects.Enabled);
    }

    [TestMethod]
    public void TestInitialStateOfNewProjectForm() {
      Assert.IsTrue(New_Project_Name.Enabled);
      Assert.IsTrue(New_Project_Description.Enabled);
      Assert.IsTrue(New_Project_Github.Enabled);
    }

    [ClassCleanup]
    public static void TearDown()
    {
        window.Close();
        application.Close();
    }
  }
}
