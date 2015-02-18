using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDevDash.UserTests {
  [TestClass]
  public class AddNewProjectFromMainWindow : TestHelper {

    [ClassInitialize]
    public static void Setup(TestContext _context) {
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
    public void AddFirstProjectToDBWithAllFields() {
      GivenThereAreNoProjects();
      AndIAmAmOnMainWindow();
      ThenIShouldSee("Main_New_Project_Button");
      WhenIFillProjectName("angular_project");
      AndIFillGithubLink("http://www.github.com/angular_project"); 
      AndIFillStartDate(new DateTime(2015, 02, 11));
      AndIFillEndDate(new DateTime(2015, 03, 11));
      AndIClick("Main_New_Project_Button");
      AndIShouldNotSee("Current_Projects_Button");
      AndIShouldNotSee("New_Project_Error");
      AndIShouldNotSee("Past_Projects_Button");
      AndIShouldSeeXNumberOfProjectsInXListBox(1,"Current_Projects_Listbox","current");
      AndIShouldSeeXNameInXListbox("angular_project","Current_Projects_Listbox");
    }

    

    [TestMethod]
    public void AddFirstProjectToDBWithRequiredFields() {
      GivenThereAreNoProjects();
      AndIAmAmOnMainWindow();
      ThenIShouldSee("Main_New_Project_Button");
      WhenIFillProjectName("csharp-project");
      AndIFillStartDate(new DateTime(2015,01,30));
      AndIClick("Main_New_Project_Button");
      ThenIShouldSee("Current_Projects_Listbox");
      AndIShouldNotSee("Past_Projects_Button");
      AndIShouldNotSee("New_Project_Error");
      AndIShouldSeeXNumberOfProjectsInXListBox(1,"Current_Projects_Listbox","current");
      AndIShouldSeeXNameInXListbox("csharp-project","Current_Projects_Listbox");
    }

    [TestMethod]
    public void AddProjectToDBWithExistingProjects() {
      GivenThereAreXProjects("current");
      AndIAmAmOnMainWindow();
      ThenIShouldSee("Main_New_Project_Button");
      WhenIFillProjectName("js_project");
      AndIFillGithubLink("http://github.com/js_project");
      AndIFillStartDate(new DateTime(2015,01,30));
      AndIFillEndDate(new DateTime(2015,02,15));
      AndIClick("Main_New_Project_Button");
      ThenIShouldSee("Current_Projects_Listbox");
      AndIShouldNotSee("Current_Projects_Button");
      AndIShouldNotSee("New_Project_Error");
      AndIShouldSeeXNumberOfProjectsInXListBox(4,"Current_Projects_Listbox","current");
      AndIShouldSeeXNameInXListbox("js_project","Current_Projects_Listbox");
    }

    

    [TestMethod]
    public void AddProjectWithNoData() {
      GivenThereAreNoProjects();
      AndIAmAmOnMainWindow();
      ThenIShouldSee("Main_New_Project_Button");
      WhenIClick("Main_New_Project_Button");
      ThenIShouldSeeErrorMessage("New_Project_Error","Name, Description and Start Date are Required To Add A Project");
      AndDBShouldHaveXProjects(0);
    }


    [TestMethod]
    public void AddProjectWithInvalidName() {
      GivenThereAreNoProjects();
      AndIAmAmOnMainWindow();
      ThenIShouldSee("Main_New_Project_Button");
      WhenIFillProjectName("css project");
      AndIFillGithubLink("http://github.com/css_project");;
      AndIFillStartDate(new DateTime(2015,02,17));
      AndIFillEndDate(new DateTime(2015,02,25));
      AndIClick("Main_New_Project_Button");
      ThenIShouldSeeErrorMessage("New_Project_Error","Please Put In Valid Project Name - no spaces");
      AndDBShouldHaveXProjects(0);
    }
  }
}
