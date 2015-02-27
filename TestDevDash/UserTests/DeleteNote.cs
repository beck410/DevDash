using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDevDash.UserTests {
  [TestClass]
  public class DeleteNote : TestHelper {

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
    public void DeleteNoteFromListBox() {
      GivenThereAreXProjects("current");
      GivenThereAreXNotes();
      WhenIClick("Current_Projects_Button");
      ThenIAmOnCurrentProjectsList();
      AndIShouldSeeXNumberOfProjectsInXListBox(3,"Current_Projects_Listbox","current");
      WhenISelect(0,"Current_Projects_Listbox");
      AndIClick("View_Current_Project_Button");
      AndTextBlockShouldBe("Single_Project_Name","angular_project");
      AndIShouldSeeXNumberOfNotesInListBox(2);
      WhenISelect(0,"Notes_Listbox");
      AndIClick("Delete_Note_Button"); 
      AndIShouldSeeXNumberOfNotesInListBox(1); 
    }

    [TestMethod]
    public void DeleteNoteWithoutSelectingFirst() {
      GivenThereAreXProjects("current");
      GivenThereAreXNotes();
      WhenIClick("Current_Projects_Button");
      ThenIAmOnCurrentProjectsList();
      AndIShouldSeeXNumberOfProjectsInXListBox(3,"Current_Projects_Listbox","current");
      WhenISelect(0,"Current_Projects_Listbox");
      AndIClick("View_Current_Project_Button");
      AndTextBlockShouldBe("Single_Project_Name","angular_project");
      AndIShouldSeeXNumberOfNotesInListBox(2);
      AndIClick("Delete_Note_Button"); 
      AndIShouldSeeXNumberOfNotesInListBox(2);
      AndIShouldSee("Delete_Note_Error_Message");
    }
  }
}
