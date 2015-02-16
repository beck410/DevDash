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
      WhenIFillProjectName();
      WhenIFillGithubLink();
      AndIFillProjectDescription();
      AndIFillStartDate();
      AndIFillEndDate();
      AndIClick();
      ThenIShouldSee("Current_Projects_Listbox");
      AndIShouldNotSee("Main_View");
      AndIShouldSeeXNumberOfProjectsInXListBox();
      AndIShouldSeeXNameInXListbox();
    }

    

    [TestMethod]
    public void AddFirstProjectToDBWithRequiredFields() {
      GivenThereAreNoProjects();
      AndIAmAmOnMainWindow();
      ThenIShouldSee("Main_New_Project_Button");
      WhenIFillProjectName();
      AndIFillProjectDescription();
      AndIFillStartDate();
      AndIClick();
      ThenIShouldSee("Current_Projects_Listbox");
      AndIShouldNotSee("Main_View");
      AndIShouldSeeXNumberOfProjectsInXListBox();
      AndIShouldSeeXNameInXListbox();
    }

    [TestMethod]
    public void AddProjectToDBWithExistingProjects() {
      GivenThereAreXProjects();
      AndIAmAmOnMainWindow();
      ThenIShouldSee("Main_New_Project_Button");
      WhenIFillProjectName();
      WhenIFillGithubLink();
      AndIFillProjectDescription();
      AndIFillStartDate();
      AndIFillEndDate();
      AndIClick();
      ThenIShouldSee("Current_Projects_Listbox");
      AndIShouldNotSee("Main_View");
      AndIShouldSeeXNumberOfProjectsInXListBox();
      AndIShouldSeeXNameInXListbox();;
    }

    

    [TestMethod]
    public void AddProjectWithNoData() {
      GivenThereAreNoProjects();
      AndIAmAmOnMainWindow();
      ThenIShouldSee("Main_New_Project_Button");
      WhenIClick();
      ThenIShouldSeeErrorMessage();
      AndDBShouldHaveXProjects();
    }


    [TestMethod]
    public void AddProjectWithInvalidName() {
      GivenThereAreNoProjects();
      AndIAmAmOnMainWindow();
      ThenIShouldSee("Main_New_Project_Button");
      WhenIFillProjectName();
      WhenIFillGithubLink();
      AndIFillProjectDescription();
      AndIFillStartDate();
      AndIFillEndDate();
      AndIClick();
      ThenIShouldSeeErrorMessage();
      AndDBShouldHaveXProjects();
    }

    [TestMethod]
    public void AddProjectWithInvalidNumberOfArguments() { 
       GivenThereAreNoProjects();
      AndIAmAmOnMainWindow();
      ThenIShouldSee("Main_New_Project_Button");
      WhenIFillProjectName();
      WhenIFillGithubLink();
      AndIClick();
      ThenIShouldSeeErrorMessage();
      AndDBShouldHaveXProjects();
    }
  }
}
