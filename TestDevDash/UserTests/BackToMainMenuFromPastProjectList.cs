using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDevDash.UserTests {
  [TestClass]
  public class BackToMainMenuFromPastProjectList : TestHelper {

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
    public void BackToMenuFromCurrentProjectWhenThereAreProjects() {
      GivenThereAreXProjects("past");
      AndIAmOnCurrentProjectsList();
      WhenIClick("Past_Projects_Back_Button");
      ThenIShouldNotSee("Past_Projects_Listbox");
      AndIShouldSee("Current_Projects_Button");
      AndIShouldSee("Past_Projects_Button");
    }

    [TestMethod]
    public void BackToMenuFromCurrentProjectsWhenNoProjects() {
      GivenThereAreNoXProjects("past");
      AndIAmOnCurrentProjectsList();
      WhenIClick("Past_Projects_Back_Button");
      ThenIShouldNotSee("Past_Projects_Listbox");
      AndIShouldSee("Current_Projects_Button");
      AndIShouldSee("Past_Projects_Button");
    }
  }
}
