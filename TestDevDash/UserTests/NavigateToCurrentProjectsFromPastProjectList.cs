using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDevDash.UserTests {
  [TestClass]
  public class NavigateToCurrentProjectsFromPastProjectList : TestHelper {

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
    public void CurrentProjectsListFromPastProjectWhenThereAreCurrentProjects() {
      GivenThereAreXProjects("current");      
      WhenIClick("Past_Projects_Button");
      ThenIAmOnCurrentProjectsList();
      WhenIClick("View_Current_Projects_Button");
      ThenIShouldNotSee("View_Current_Projects_Button");
      AndIShouldSee("View_Past_Projects_Button");
      AndIShouldSeeXNumberOfProjectsInXListBox(3,"Current_Projects_Listbox","current");
    }

    [TestMethod]
    public void CurrentProjectsFromPastProjectsWhenNoProjects() {
      GivenThereAreNoXProjects("past");
      WhenIClick("Past_Projects_Button");
      ThenIAmOnCurrentProjectsList();
      WhenIClick("View_Current_Projects_Button");
      AndIShouldNotSee("View_Current_Projects_Button");
      AndIShouldSee("View_Past_Projects_Button");
      AndIShouldSeeXNumberOfProjectsInXListBox(0,"Current_Projects_Listbox","current");
    } 
  }
}
