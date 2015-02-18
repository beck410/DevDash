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
      GivenThereAreXProjects("past");      
      WhenIClick("Current_Projects_Button");
      ThenIAmOnCurrentProjectsList();
      WhenIClick("");
      ThenIShouldNotSee("Past_Projects_Listbox");
      AndIShouldSee("Current_Projects_Button");
      AndIShouldSee("Past_Projects_Button");
      AndIShouldSeeXNumberOfProjectsInXListBox(3,"Current_Projects_Listbox","current");
    }

    [TestMethod]
    public void CurrentProjectsFromCurrentProjectsWhenNoProjects() {
      GivenThereAreNoXProjects("past");
      WhenIClick("Current_Projects_Button");
      ThenIAmOnCurrentProjectsList();
      WhenIClick("Past_Projects_Back_Button");
      ThenIShouldNotSee("Past_Projects_Listbox");
      AndIShouldSee("Current_Projects_Button");
      AndIShouldSee("Past_Projects_Button");
      AndIShouldSeeXNumberOfProjectsInXListBox(0,"Current_Projects_Listbox","current");
    } 
  }
}
