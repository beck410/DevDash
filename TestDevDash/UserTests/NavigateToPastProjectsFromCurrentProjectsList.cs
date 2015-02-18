using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDevDash.UserTests {
  [TestClass]
  public class NavigateToPastProjectsFromCurrentProjectsList : TestHelper {

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
    public void PastProjectsListFromCurrentProjectsWhenThereAreCurrentProjects() {
      GivenThereAreXProjects("past");      
      WhenIClick("Current_Projects_Button");
      ThenIAmOnCurrentProjectsList();
      WhenIClick("View_Past_Projects_Button");
      ThenIShouldNotSee("View_Past_Projects_Button");
      AndIShouldSee("View_Current_Projects_Button");
      AndIShouldSeeXNumberOfProjectsInXListBox(3,"Past_Projects_Listbox","past");
    }

    [TestMethod]
    public void PastProjectsListFromCurrentProjectsWhenNoProjects() {
      GivenThereAreNoXProjects("past");
      WhenIClick("Current_Projects_Button");
      ThenIAmOnCurrentProjectsList();
      WhenIClick("View_Past_Projects_Button");
      AndIShouldNotSee("View_Past_Projects_Button");
      AndIShouldSee("View_Current_Projects_Button");
      AndIShouldSeeXNumberOfProjectsInXListBox(0,"Past_Projects_Listbox","past");
    }
  }
}
