using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDevDash.UserTests {
  [TestClass]
  public class ViewSingleCurrentProject : TestHelper{

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
    public void ViewSingleCurrentProjectWithAllDescriptionFields() {
      GivenThereAreXProjects("current");
      WhenIClick("Current_Projects_Button");
      ThenIAmOnCurrentProjectsList();
      AndIShouldSeeXNumberOfProjectsInXListBox(3,"Current_Projects_Listbox","current");
      WhenISelect(0,"Current_Projects_Listbox");
      AndIClick("View_Current_Project_Button");
      ThenIShouldNotSee("");
      AndIShouldNotSee("View_Past_Projects_Button");
      AndIShouldSee("Edit_Description_Button");
      AndTextBlockShouldBe("Single_Project_Name","angular_project");
      AndTextBlockShouldBe("Github","http://github.com/angular_project");
      AndTextBlockShouldBe("Start_Date","02/03/2015");
      AndTextBlockShouldBe("End_Date","02/20/2015");
      AndTextBlockShouldBe("Description","");
      AndIShouldNotSee("Notes_Listbox");
    }
    
    [TestMethod]
    public void ViewSingleCurrentProjectWithOnlyProjectName() {
      GivenThereAreXProjects("current");
      WhenIClick("Current_Projects_Button");
      ThenIAmOnCurrentProjectsList();
      AndIShouldSeeXNumberOfProjectsInXListBox(3,"Current_Projects_Listbox","current");
      WhenISelect(0,"Current_Projects_Listbox");
      AndIClick("View_Current_Project_Button");
      AndIShouldNotSee("View_Past_Projects_Button");
      AndIShouldSee("Edit_Description_Button");
      AndTextBlockShouldBe("Single_Project_Name","angular_project");
      AndTextBlockShouldBe("Github","");
      AndTextBlockShouldBe("Start_Date","");
      AndTextBlockShouldBe("End_Date","");
      AndTextBlockShouldBe("Description","");
      AndIShouldNotSee("Notes_Listbox");
    }

    [TestMethod]
    public void ViewSingleCurrentProjectWithNotesAndAllDescriptionFields() {
      GivenThereAreXProjects("current");
      GivenThereAreXNotes();
      WhenIClick("Current_Projects_Button");
      ThenIAmOnCurrentProjectsList();
      AndIShouldSeeXNumberOfProjectsInXListBox(3,"Current_Projects_Listbox","current");
      WhenISelect(0,"Current_Projects_Listbox");
      AndIClick("View_Current_Project_Button");
      ThenIShouldNotSee("Main_View");
      AndIShouldNotSee("View_Past_Projects_Button"); 
      AndIShouldSee("Edit_Description_Button");
      AndTextBlockShouldBe("Single_Project_Name","angular_project");
      AndTextBlockShouldBe("Github","");
      AndTextBlockShouldBe("Start_Date","");
      AndTextBlockShouldBe("End_Date","");
      AndTextBlockShouldBe("Description","");
      AndIShouldSee("Notes_Listbox");
      AndIShouldSeeXNumberOfProjectsInXListBox(3,"Past_Projects_Listbox","past");
    }
  }
}
