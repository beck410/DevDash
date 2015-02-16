using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDevDash.UserTests {
  [TestClass]
  public class ViewPastProjects : TestHelper {

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
    public void ViewPastProjectsListWithPastProjectsInDB() {
      GivenThereAreXProjects("past");
      WhenIClick("Past_Projects_Button");
      ThenIShouldNotSee("Past_Projects_Button");
      AndIShouldNotSee("Current_Projects_Button");
      AndIShouldNotSee("Main_New_Project_Button");
      AndIShouldNotSee("No_Past_Projects_Message");
      AndIShouldSee("Past_Projects_Listbox");
      AndIShouldSeeXNumberOfProjectsInXListBox(3,"Past_Projects_Listbox","past");
      AndIShouldSee("View_Current_Projects_Button");
      AndIShouldSee("View_Past_Project_Button");
      AndIShouldSee("Delete_Past_Project_Button");
    }

    [TestMethod]
    public void ViewPastProjectListWithNoPastProjectsInDB() {
      GivenThereAreNoXProjects("PAst");
      WhenIClick("Past_Projects_Button");
      ThenIShouldNotSee("Past_Projects_Button");
      AndIShouldNotSee("Current_Projects_Button");
      AndIShouldNotSee("Past_Projects_Listbox");
      AndIShouldSee("View_Current_Projects_Button");
      AndIShouldSeeXNumberOfProjectsInXListBox(0,"Past_Projects_Listbox","past");
      AndIShouldSee("No_Past_Projects_Message");
    }
  }
}
