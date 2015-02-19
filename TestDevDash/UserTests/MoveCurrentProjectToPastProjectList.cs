using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDevDash.UserTests {
  [TestClass]
  public class MoveCurrentProjectToPastProjectList : TestHelper {

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
    public void MoveCurrentProjectsToPastProjects() {
      GivenThereAreXProjects("past");
      GivenThereAreXProjects("current");
      WhenIClick("Current_Projects_Button");
      ThenIShouldNotSee("Current_Projects_Button");
      AndIShouldSeeXNumberOfProjectsInXListBox(3,"Current_Projects_Listbox","current");
      WhenISelect(0,"Current_Projects_Listbox");
      AndIClick("Move_Current_Project_Button");
      AndThereAreXProjectsInXDB(2,"current"); 
      AndThereAreXProjectsInXDB(4,"past");
      AndIShouldSeeXNumberOfProjectsInXListBox(2,"Current_Projects_Listbox","current");
    }

    [TestMethod]
    public void MoveCurrentProjectWithoutSelectingFirst() {
      GivenThereAreXProjects("current");
      WhenIClick("Current_Projects_Button");
      ThenIAmOnCurrentProjectsList();
      AndIShouldSeeXNumberOfProjectsInXListBox(3,"Current_Projects_Listbox","current");
      AndIClick("Move_Current_Project_Button");
      ThenIShouldSeeXNumberOfProjectsInXListBox(3,"Current_Projects_Listbox","current");
      AndThereAreXProjectsInXDB(0,"past");
      AndThereAreXProjectsInXDB(3,"current");
      AndIShouldSee("Delete_Current_Project_Message"); 
    }
  }
}
