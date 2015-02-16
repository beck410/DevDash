using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDevDash.UserTests {
  [TestClass]
  public class ViewCurrentProject : TestHelper {
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
    public void ViewCurrentProjectsListWithCurrentProjectsInDB() {
      GivenThereAreXProjects("current");
      WhenIClick("Current_Projects_Button");
      ThenIShouldNotSee("Current_Projects_Button");
      AndIShouldNotSee("Past_Projects_Button");
      AndIShouldNotSee("Main_New_Project_Button");
      AndIShouldNotSee("No_Current_Projects_Message");
      AndIShouldSee("Current_Projects_Listbox");
      AndIShouldSeeXNumberOfProjectsInListBox(3,"Current_Projects_Listbox");
      AndIShouldSee("List_Add_New_Project");
      AndIShouldSee("View_Button");
      AndIShouldSee("Delete_Button");
      AndIShouldSee("Move_Button");
    }

    [TestMethod]
    public void ViewCurrentProjectListWithNoCurrentProjectsInDB() {
      GivenThereAreNoXProjects("current");
      WhenIClick("Current_Projects_Button");
      ThenIShouldNotSee("Past_Projects_Button");
      ThenIShouldNotSee("Current_Projects_Button");
      AndIShouldNotSee("Current_Projects_Listbox");
      AndIShouldSeeXNumberOfProjectsInListBox(0,"Current_Projects_Listbox");
      AndIShouldSee("No_Current_Projects_Message");
      AndIShouldNotSee("List_Add_New_Project");
      AndIShouldNotSee("View_Current_Project");
      AndIShouldNotSee("DeleteCurrentProject");
    }
  }
}
