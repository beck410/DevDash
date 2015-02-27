using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDevDash.UserTests {
  [TestClass]
  public class AddNewNoteToProject : TestHelper{
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
    public void AddNewNoteWhenNoNotesExist() {
      GivenThereAreXProjects("current");
      WhenIClick("Current_Projects_Button");
      ThenIAmOnCurrentProjectsList();
      AndIShouldSeeXNumberOfProjectsInXListBox(3,"Current_Projects_Listbox","current");
      WhenISelect(0,"Current_Projects_Listbox");
      AndIClick("View_Current_Project_Button");
      AndTextBlockShouldBe("Single_Project_Name","angular_project");
      AndIShouldNotSee("Notes_Listbox");
      WhenIClick("Add_Note_Button");
      ThenIShouldSeeInModal("AddNoteModal","Modal_New_Note_Button");
      WhenIFillNoteTextBox("AddNoteModal","this is a new note");
      AndIClickInModal("AddNoteModal","Modal_New_Note_Button");
      ThenIShouldSee("Notes_Listbox");
      AndIShouldSeeXNumberOfNotesInListBox(1);
    }
    
    [TestMethod]
    public void AddNewNoteWhenNotesExist() {
      GivenThereAreXProjects("current");
      GivenThereAreXNotes();
      WhenIClick("Current_Projects_Button");
      ThenIAmOnCurrentProjectsList();
      AndIShouldSeeXNumberOfProjectsInXListBox(3,"Current_Projects_Listbox","current");
      WhenISelect(0,"Current_Projects_Listbox");
      AndIClick("View_Current_Project_Button");
      AndTextBlockShouldBe("Single_Project_Name","angular_project");
      AndIShouldSeeXNumberOfNotesInListBox(2);
      AndTextBlockShouldBe("Single_Project_Name","angular_project");
      WhenIClick("Add_Note_Button");
      ThenIShouldSeeInModal("AddNoteModal","Modal_New_Note_Button");
      WhenIFillNoteTextBox("AddNoteModal","this is a new note");
      AndIClickInModal("AddNoteModal","Modal_New_Note_Button");
      ThenIShouldSee("Notes_Listbox");
      AndIShouldSeeXNumberOfNotesInListBox(3);
    }
  }
}
