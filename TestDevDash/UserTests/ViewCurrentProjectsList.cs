using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDevDash.UserTests {
  [TestClass]
  public class ViewCurrentProjectsList : TestHelper {

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
      AndIShouldSeeXNumberOfProjectsInXListBox(3,"Current_Projects_Listbox","current");
      AndIShouldSee("List_Add_New_Project");
      AndIShouldSee("View_Past_Projects_Button");
      AndIShouldSee("View_Current_Project_Button");
      AndIShouldSee("Delete_Current_Project_Button");
      AndIShouldSee("Move_Current_Project_Button");
    }

    [TestMethod]
    public void ViewCurrentProjectListWithNoCurrentProjectsInDB() {
      GivenThereAreNoXProjects("current");
      WhenIClick("Current_Projects_Button");
      ThenIShouldNotSee("Past_Projects_Button");
      AndIShouldNotSee("Current_Projects_Button");
      AndIShouldNotSee("Current_Projects_Listbox");
      AndIShouldSee("View_Past_Projects_Button");
      AndIShouldSeeXNumberOfProjectsInXListBox(0,"Current_Projects_Listbox","current");
      AndIShouldSee("No_Current_Projects_Message");
      AndIShouldSee("List_Add_New_Project");
    }
  }
}
