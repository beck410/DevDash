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
      ThenIClickProjectDeleteButton("past"); 
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
      ThenIClickProjectDeleteButton("Delete_Current_Project_Button");
      ThenIShouldSeeXNumberOfProjectsInXListBox(2,"Current_Projects_Listbox","current");
      AndDBShouldHaveXProjects(2);

    }
  }
}
