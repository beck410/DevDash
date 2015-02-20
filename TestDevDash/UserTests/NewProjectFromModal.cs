using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDevDash.UserTests {
  [TestClass]
  public class NewProjectFromModal : TestHelper {
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
    public void AddProjectFromNewProjectModalWithExistingProjects() {
      GivenThereAreXProjects("current"); 
      WhenIClick("Current_Projects_Button");
      ThenIAmOnCurrentProjectsList();
      WhenIClick("List_Add_New_Project");
      ThenIShouldSeeInModal("AddProjectModal","Modal_New_Project_Button");
      AndIShouldSeeInModal("AddProjectModal","Modal_Close_Button");
      WhenIFillModalProjectName("angular_project");
      AndIClickInModal("AddProjectModal","Modal_New_Project_Button");
      AndIShouldSeeXNumberOfProjectsInXListBox(4,"Current_Projects_Listbox","current");
      AndIShouldSeeXNameInXListbox("angular_project","Current_Projects_Listbox");
    }

    [TestMethod]
    public void AddProjectFromNewProjectModalWithNoExistingProjects() {
      GivenThereAreNoProjects();
      WhenIClick("Current_Projects_Button");
      ThenIAmOnCurrentProjectsList();
      WhenIClick("List_Add_New_Project");
      ThenIShouldSeeInModal("AddProjectModal","Modal_New_Project_Button");
      AndIShouldSeeInModal("AddProjectModal","Modal_Close_Button");
      WhenIFillModalProjectName("angular_project");
      AndIClickInModal("AddProjectModal","Modal_New_Project_Button");
      AndIShouldSeeXNumberOfProjectsInXListBox(1,"Current_Projects_Listbox","current");
      AndIShouldSeeXNameInXListbox("angular_project","Current_Projects_Listbox");
    }

    [TestMethod]
    public void AddProjectWhenNewProjectWindowCancelled(){
      GivenThereAreNoProjects();
      WhenIClick("Current_Projects_Button");
      ThenIAmOnCurrentProjectsList();
      WhenIClick("List_Add_New_Project");
      ThenIShouldSeeInModal("AddProjectModal","Modal_New_Project_Button");
      AndIShouldSeeInModal("AddProjectModal","Modal_Close_Button");
      WhenIFillModalProjectName("angular_project");
      AndIClickInModal("AddProjectModal","Modal_Close_Button");
      AndIShouldSeeXNumberOfProjectsInXListBox(0,"Current_Projects_Listbox","current");
    }

   [TestMethod]
    public void AddProjectWhenNewProjectWindowCancelledWithExistingProjects(){
      GivenThereAreXProjects("current");
      WhenIClick("Current_Projects_Button");
      ThenIAmOnCurrentProjectsList();
      WhenIClick("List_Add_New_Project");
      ThenIShouldSeeInModal("AddProjectModal","Modal_New_Project_Button");
      AndIShouldSeeInModal("AddProjectModal","Modal_Close_Button");
      WhenIFillModalProjectName("angular_project");
      AndIClickInModal("AddProjectModal","Modal_Close_Button");
      AndIShouldSeeXNumberOfProjectsInXListBox(3,"Current_Projects_Listbox","current");
    }
    
    [TestMethod]
    public void AddProjectFromNewProjectModalWithInvalidName() {
      GivenThereAreNoProjects();
      WhenIClick("Current_Projects_Button");
      ThenIAmOnCurrentProjectsList();
      WhenIClick("List_Add_New_Project");
      ThenIShouldSeeInModal("AddProjectModal","Modal_New_Project_Button");
      AndIShouldSeeInModal("AddProjectModal","Modal_Close_Button");
      WhenIFillModalProjectName("angular project");
      AndIClickInModal("AddProjectModal","Modal_New_Project_Button");
      ThenIShouldSeeErrorMessageInModal("AddProjectModal","Modal_New_Project_Error");
    }

    
  }
}
