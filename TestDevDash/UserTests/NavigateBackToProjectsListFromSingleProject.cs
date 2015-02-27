using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDevDash.UserTests {
  [TestClass]
  public class NavigateBackToProjectsListFromSingleProject : TestHelper{

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
    public void NavigateBackToProjectsListFromSingleCurrentProject() {
      GivenThereAreXProjects("current");
      WhenIClick("Current_Projects_Button");
      ThenIAmOnCurrentProjectsList();
      AndIShouldSeeXNumberOfProjectsInXListBox(3,"Current_Projects_Listbox","current");
      WhenISelect(0,"Current_Projects_Listbox");
      AndIClick("View_Current_Project_Button");
      AndTextBlockShouldBe("Single_Project_Name","angular_project");
      WhenIClick("Back_Button");
      ThenIShouldSee("Current_Projects_Button");
      AndIShouldSee("Past_Projects_Button");
      AndIShouldNotSee("Single_Project_Name");
    }
  }
}
