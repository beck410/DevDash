using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDevDash.UserTests {
  [TestClass]
  public class AddNewNoteToProject : TestHelper{
    [TestMethod]
    public void AddNewNoteWhenNoNotesExist() {
      GivenThereAreXProjects("current");
      WhenIClick("Current_Projects_Button");
      ThenIAmOnCurrentProjectsList();
      AndIShouldSeeXNumberOfProjectsInXListBox(3,"Current_Projects_Listbox","current");
      AndIShouldNotSee("Notes_Listbox");
      WhenISelect(0,"Current_Projects_Listbox");
      AndIClick("View_Current_Project_Button");
      AndTextBlockShouldBe("Single_Project_Name","angular_project");
      WhenIClick("Add_Note");
      ThenIShouldSeeInModal("AddNoteModal","Modal_New_Note_Button");
      WhenIFillNoteTextBox("this is a new note");
      AndIClickInModal("AddNoteModal","Modal_New_Note_Button");
      ThenIShouldSee("Notes_Listbox");
      AndIShouldSeeXNumberOfNotesInListBox(1);
    }

    public void AddNewNoteWhenNoNotesExist() {
      GivenThereAreXProjects("current");
      GivenThereAreXNotes();
      WhenIClick("Current_Projects_Button");
      ThenIAmOnCurrentProjectsList();
      AndIShouldSeeXNumberOfProjectsInXListBox(3,"Current_Projects_Listbox","current");
      AndIShouldSeeXNumberOfNotesInListBox(2);
      WhenISelect(0,"Current_Projects_Listbox");
      AndIClick("View_Current_Project_Button");
      AndTextBlockShouldBe("Single_Project_Name","angular_project");
      WhenIClick("Add_Note");
      ThenIShouldSeeInModal("AddNoteModal","Modal_New_Note_Button");
      WhenIFillNoteTextBox("this is a new note");
      AndIClickInModal("AddNoteModal","Modal_New_Note_Button");
      ThenIShouldSee("Notes_Listbox");
      AndIShouldSeeXNumberOfNotesInListBox(3);
    }


  }
}
