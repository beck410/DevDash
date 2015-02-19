using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDevDash.UserTests {
  [TestClass]
  public class DeleteProjects : TestHelper {
    
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
    public void DeletePastProject() {
      GivenThereAreXProjects("past");
      WhenIClick("Past_Projects_Button");
      ThenIAmOnCurrentProjectsList();
      AndIShouldSeeXNumberOfProjectsInXListBox(3,"Past_Projects_Listbox","past");
      WhenISelect(0,"Past_Projects_Listbox");
      AndIClick("Delete_Past_Project_Button"); 
      ThenIShouldSeeXNumberOfProjectsInXListBox(2,"Past_Projects_Listbox","past");
      AndDBShouldHaveXProjects(2);
    }

    [TestMethod]
    public void DeleteCurrentProject() {
      GivenThereAreXProjects("current");
      WhenIClick("Current_Projects_Button");
      ThenIAmOnCurrentProjectsList();
      AndIShouldSeeXNumberOfProjectsInXListBox(3,"Current_Projects_Listbox","current");
      WhenISelect(0,"Current_Projects_Listbox");
      AndIClick("Delete_Current_Project_Button");
      ThenIShouldSeeXNumberOfProjectsInXListBox(2,"Current_Projects_Listbox","current");
      AndDBShouldHaveXProjects(2);
    }

    [TestMethod]
    public void DeletePastProjectWithoutSelectingFirst() {
      GivenThereAreXProjects("past");
      WhenIClick("Past_Projects_Button");
      ThenIAmOnCurrentProjectsList();
      AndIShouldSeeXNumberOfProjectsInXListBox(3,"Past_Projects_Listbox","past");
      AndIClick("Delete_Past_Project_Button");
      ThenIShouldSeeXNumberOfProjectsInXListBox(3,"Past_Projects_Listbox","past");
      AndIShouldSee("Delete_Past_Project_Message"); 
    }

    [TestMethod]
    public void DeleteCurrentProjectWithoutSelectingFirst() {
      GivenThereAreXProjects("current");
      WhenIClick("Current_Projects_Button");
      ThenIAmOnCurrentProjectsList();
      AndIShouldSeeXNumberOfProjectsInXListBox(3,"Current_Projects_Listbox","current");
      AndIClick("Delete_Current_Project_Button");
      ThenIShouldSeeXNumberOfProjectsInXListBox(3,"Current_Projects_Listbox","current");
      AndIShouldSee("Delete_Current_Project_Message"); 
    }
  }
}
