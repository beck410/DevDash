using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDevDash.UserTests {
  [TestClass]
  public class EditSingleProjectDetails : TestHelper {
  
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
    public void EditAllProjectDescriptionProperties() {
      GivenThereAreXProjects("current");
      WhenIClick("Current_Projects_Button");
      ThenIAmOnCurrentProjectsList();
      AndIShouldSeeXNumberOfProjectsInXListBox(3,"Current_Projects_Listbox","current");
      WhenISelect(0,"Current_Projects_Listbox");
      AndIClick("View_Current_Project_Button");
      AndTextBlockShouldBe("Single_Project_Name","angular_project");
      AndTextBlockShouldBe("Github","Github Link: http://github.com/angular_project");
      AndTextBlockShouldBe("Start_Date","Start Date: 02/03/2015");
      AndTextBlockShouldBe("End_Date","End Date: 02/20/2015");
      AndTextBlockShouldBe("Description","Description: ");
      AndIShouldNotSee("Notes_Listbox");
      WhenIClick("Edit_Description_Button");
      ThenIShouldSeeInModal("EditProjectDetailsModal","Modal_Edit_Project_Button");
      AndIShouldSeeInModal("EditProjectDetailsModal","Modal_Edit_Project_Description");
      AndIShouldSeeInModal("EditProjectDetailsModal","Modal_Close_Button");
      AndTextBoxInModalShouldBe("EditProjectDetailsModal","Modal_Edit_Project_Name","angular_project");
      AndDatePickerInModalShouldBe("EditProjectDetailsModal","Modal_Edit_Project_Start_Date","2/3/2015 12:00:00 AM");
      AndDatePickerInModalShouldBe("EditProjectDetailsModal","Modal_Edit_Project_End_Date","2/20/2015 12:00:00 AM");
      AndTextBoxInModalShouldBe("EditProjectDetailsModal","Modal_Edit_Project_Github","http://github.com/angular_project");
      AndTextBoxInModalShouldBe("EditProjectDetailsModal","Modal_Edit_Project_Description","");
      WhenIFillProjectNameInEditModal("new_angular_project");
      AndIFillStartDateInModal(new DateTime(2015, 02, 04));
      AndIFillEndDateInModal(new DateTime(2015, 02, 21));
      AndIFillProjectDescription("this is an awesome angular app");
      AndIFillProjectGithubInModal("http://github.com/new_angular_app");
      AndIClickInModal("EditProjectDetailsModal","Modal_Edit_Project_Button");
      AndTextBlockShouldBe("Single_Project_Name","new_angular_project");
      AndTextBlockShouldBe("Github","Github Link: http://github.com/new_angular_app");
      AndTextBlockShouldBe("Start_Date","Start Date: 02/04/2015");
      AndTextBlockShouldBe("End_Date","End Date: 02/21/2015");
      AndTextBlockShouldBe("Description","Description: this is an awesome angular app");
    } 
  }
}
