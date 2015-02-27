using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDevDash.UserTests {
  [TestClass]
  public class ViewSinglePastProject : TestHelper {

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
    public void ViewSinglePastProjectWithAllDescriptionFields() {
      GivenThereAreXProjects("current");
      WhenIClick("Current_Projects_Button");
      ThenIAmOnCurrentProjectsList();
      AndIShouldSeeXNumberOfProjectsInXListBox(3,"Current_Projects_Listbox","current");
      WhenISelect(0,"Current_Projects_Listbox");
      WhenIClick("Move_Current_Project_Button");
      AndIClick("View_Past_Projects_Button");
      WhenISelect(0,"Past_Projects_Listbox");
      AndIClick("View_Past_Project_Button");
      AndIShouldSee("Edit_Description_Button");
      AndTextBlockShouldBe("Single_Project_Name","angular_project");
      AndTextBlockShouldBe("Github","Github Link: http://github.com/angular_project");
      AndTextBlockShouldBe("Start_Date","Start Date: 02/03/2015");
      AndTextBlockShouldBe("End_Date","End Date: 02/20/2015");
      AndTextBlockShouldBe("Description","Description: ");
      AndIShouldNotSee("Notes_Listbox");
    }
  }
}
