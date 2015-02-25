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
      AndIShouldNotSee("View_Past_Projects_Button");
      AndIShouldSee("Edit_Description_Button");
      AndTextBlockShouldBe("Single_Project_Name","angular_project");
      AndTextBlockShouldBe("Github","Github Link: http://github.com/angular_project");
      AndTextBlockShouldBe("Start_Date","Start Date: 02/03/2015");
      AndTextBlockShouldBe("End_Date","End Date: 02/20/2015");
      AndTextBlockShouldBe("Description","Description:");
      AndIShouldNotSee("Notes_Listbox");
      WhenIClick("Edit_Project_Details");
      ThenIShouldSeeInModal("AddProjectModal","Modal_New_Project_Button");
      AndIShouldSeeInModal("AddProjectModal","Add_Project_Description");
      AndIShouldSeeInModal("AddProjectModal","Modal_Close_Button");
      AndTextBlockShouldBe("Modal_New_Project_Name","angular_project");
      AndTextBlockShouldBe("Modal_New_Project_Start_Date","02/03/2015");
      AndTextBlockShouldBe("Modal_New_Project_End_Date","02/20/2015");
      AndTextBlockShouldBe("Modal_New_Project_Github","http://github.com/angular_project");
      AndTextBlockShouldBe("Modal_New_Project_Description","");
      WhenIFillModalProjectName("new_angular_project");
      AndIFillStartDateInModal("02/04/2015");
      AndIFillEndDateInModal("02/21/2015");
      AndIFillProjectDescription("this is an awesome angular app");
      AndIFillProjectGithub("http://github.com/new_angular_app");
      AndIClickInModal("AddProjectModal","Modal_New_Project_Button");
      AndTextBlockShouldBe("Single_Project_Name","new_angular_project");
      AndTextBlockShouldBe("Github","Github Link: http://github.com/new_angular_app");
      AndTextBlockShouldBe("Start_Date","Start Date: 02/04/2015");
      AndTextBlockShouldBe("End_Date","End Date: 02/21/2015");
      AndTextBlockShouldBe("Description","Description: this is an awesome angular app");
    }

    public void EditProjectWithExistingDescription() {
      GivenThereAreXProjects("current");
      AndIAddProjectDescription("this is a project");
      WhenIClick("Current_Projects_Button");
      ThenIAmOnCurrentProjectsList();
      AndIShouldSeeXNumberOfProjectsInXListBox(3,"Current_Projects_Listbox","current");
      WhenISelect(0,"Current_Projects_Listbox");
      AndIClick("View_Current_Project_Button");
      AndIShouldNotSee("View_Past_Projects_Button");
      AndIShouldSee("Edit_Description_Button");
      AndTextBlockShouldBe("Single_Project_Name","angular_project");
      AndTextBlockShouldBe("Github","Github Link: http://github.com/angular_project");
      AndTextBlockShouldBe("Start_Date","Start Date: 02/03/2015");
      AndTextBlockShouldBe("End_Date","End Date: 02/20/2015");
      AndTextBlockShouldBe("Description","Description: this is a project");
      AndIShouldNotSee("Notes_Listbox");
      WhenIClick("Edit_Project_Details");
      ThenIShouldSeeInModal("AddProjectModal","Modal_New_Project_Button");
      AndIShouldSeeInModal("AddProjectModal","Add_Project_Description");
      AndIShouldSeeInModal("AddProjectModal","Modal_Close_Button");
      AndTextBlockShouldBe("Modal_New_Project_Name","angular_project");
      AndTextBlockShouldBe("Modal_New_Project_Start_Date","02/03/2015");
      AndTextBlockShouldBe("Modal_New_Project_End_Date","02/20/2015");
      AndTextBlockShouldBe("Modal_New_Project_Github","http://github.com/angular_project");
      AndTextBlockShouldBe("Modal_New_Project_Description","");
      WhenIFillModalProjectName("new_angular_project");
      AndIFillStartDateInModal("02/04/2015");
      AndIFillEndDateInModal("02/21/2015");
      AndIFillProjectDescription("this is an awesome angular app");
      AndIFillProjectGithub("http://github.com/new_angular_app");
      AndIClickInModal("AddProjectModal","Modal_New_Project_Button");
      AndTextBlockShouldBe("Single_Project_Name","new_angular_project");
      AndTextBlockShouldBe("Github","Github Link: http://github.com/new_angular_app");
      AndTextBlockShouldBe("Start_Date","Start Date: 02/04/2015");
      AndTextBlockShouldBe("End_Date","End Date: 02/21/2015");
      AndTextBlockShouldBe("Description","Description: this is an awesome angular app");
    } 

    [TestMethod]
    public void EditOnlyProjectStartDate() {
      GivenThereAreXProjects("current");
      WhenIClick("Current_Projects_Button");
      ThenIAmOnCurrentProjectsList();
      AndIShouldSeeXNumberOfProjectsInXListBox(3,"Current_Projects_Listbox","current");
      WhenISelect(0,"Current_Projects_Listbox");
      AndIClick("View_Current_Project_Button");
      AndIShouldNotSee("View_Past_Projects_Button");
      AndIShouldSee("Edit_Description_Button");
      AndTextBlockShouldBe("Single_Project_Name","angular_project");
      AndTextBlockShouldBe("Github","Github Link: http://github.com/angular_project");
      AndTextBlockShouldBe("Start_Date","Start Date: 02/03/2015");
      AndTextBlockShouldBe("End_Date","End Date: 02/20/2015");
      AndTextBlockShouldBe("Description","Description:");
      AndIShouldNotSee("Notes_Listbox");
      WhenIClick("Edit_Project_Details");
      ThenIShouldSeeInModal("AddProjectModal","Modal_New_Project_Button");
      AndIShouldSeeInModal("AddProjectModal","Add_Project_Description");
      AndIShouldSeeInModal("AddProjectModal","Modal_Close_Button");
      AndTextBlockShouldBe("Modal_New_Project_Name","angular_project");
      AndTextBlockShouldBe("Modal_New_Project_Start_Date","02/03/2015");
      AndTextBlockShouldBe("Modal_New_Project_End_Date","02/20/2015");
      AndTextBlockShouldBe("Modal_New_Project_Github","http://github.com/angular_project");
      AndTextBlockShouldBe("Modal_New_Project_Description","");
      AndIFillStartDateInModal("02/04/2015");
      AndIClickInModal("AddProjectModal","Modal_New_Project_Button");
      AndTextBlockShouldBe("Single_Project_Name","angular_project");
      AndTextBlockShouldBe("Github","Github Link: http://github.com/angular_project");
      AndTextBlockShouldBe("Start_Date","Start Date: 02/04/2015");
      AndTextBlockShouldBe("End_Date","End Date: 02/20/2015");
      AndTextBlockShouldBe("Description","Description:");
    }


    [TestMethod]
    public void EditOnlyProjectName() {
      GivenThereAreXProjects("current");
      WhenIClick("Current_Projects_Button");
      ThenIAmOnCurrentProjectsList();
      AndIShouldSeeXNumberOfProjectsInXListBox(3,"Current_Projects_Listbox","current");
      WhenISelect(0,"Current_Projects_Listbox");
      AndIClick("View_Current_Project_Button");
      AndIShouldNotSee("View_Past_Projects_Button");
      AndIShouldSee("Edit_Description_Button");
      AndTextBlockShouldBe("Single_Project_Name","angular_project");
      AndTextBlockShouldBe("Github","Github Link: http://github.com/angular_project");
      AndTextBlockShouldBe("Start_Date","Start Date: 02/03/2015");
      AndTextBlockShouldBe("End_Date","End Date: 02/20/2015");
      AndTextBlockShouldBe("Description","Description:");
      AndIShouldNotSee("Notes_Listbox");
      WhenIClick("Edit_Project_Details");
      ThenIShouldSeeInModal("AddProjectModal","Modal_New_Project_Button");
      AndIShouldSeeInModal("AddProjectModal","Add_Project_Description");
      AndIShouldSeeInModal("AddProjectModal","Modal_Close_Button");
      AndTextBlockShouldBe("Modal_New_Project_Name","angular_project");
      AndTextBlockShouldBe("Modal_New_Project_Start_Date","02/03/2015");
      AndTextBlockShouldBe("Modal_New_Project_End_Date","02/20/2015");
      AndTextBlockShouldBe("Modal_New_Project_Github","http://github.com/angular_project");
      AndTextBlockShouldBe("Modal_New_Project_Description","");
      WhenIFillModalProjectName("new_angular_app");
      AndIClickInModal("AddProjectModal","Modal_New_Project_Button");
      AndTextBlockShouldBe("Single_Project_Name","new_angular_app");
      AndTextBlockShouldBe("Github","Github Link: http://github.com/angular_project");
      AndTextBlockShouldBe("Start_Date","Start Date: 02/03/2015");
      AndTextBlockShouldBe("End_Date","End Date: 02/20/2015");
      AndTextBlockShouldBe("Description","Description:");
    }


    [TestMethod]
    public void EditOnlyProjectEndDate(){
      GivenThereAreXProjects("current");
      WhenIClick("Current_Projects_Button");
      ThenIAmOnCurrentProjectsList();
      AndIShouldSeeXNumberOfProjectsInXListBox(3,"Current_Projects_Listbox","current");
      WhenISelect(0,"Current_Projects_Listbox");
      AndIClick("View_Current_Project_Button");
      AndIShouldNotSee("View_Past_Projects_Button");
      AndIShouldSee("Edit_Description_Button");
      AndTextBlockShouldBe("Single_Project_Name","angular_project");
      AndTextBlockShouldBe("Github","Github Link: http://github.com/angular_project");
      AndTextBlockShouldBe("Start_Date","Start Date: 02/03/2015");
      AndTextBlockShouldBe("End_Date","End Date: 02/20/2015");
      AndTextBlockShouldBe("Description","Description:");
      AndIShouldNotSee("Notes_Listbox");
      WhenIClick("Edit_Project_Details");
      ThenIShouldSeeInModal("AddProjectModal","Modal_New_Project_Button");
      AndIShouldSeeInModal("AddProjectModal","Add_Project_Description");
      AndIShouldSeeInModal("AddProjectModal","Modal_Close_Button");
      AndTextBlockShouldBe("Modal_New_Project_Name","angular_project");
      AndTextBlockShouldBe("Modal_New_Project_Start_Date","02/03/2015");
      AndTextBlockShouldBe("Modal_New_Project_End_Date","02/20/2015");
      AndTextBlockShouldBe("Modal_New_Project_Github","http://github.com/angular_project");
      AndTextBlockShouldBe("Modal_New_Project_Description","");
      AndIFillEndDateInModal("02/21/2014");
      AndIClickInModal("AddProjectModal","Modal_New_Project_Button");
      AndTextBlockShouldBe("Single_Project_Name","angular_project");
      AndTextBlockShouldBe("Github","Github Link: http://github.com/angular_project");
      AndTextBlockShouldBe("Start_Date","Start Date: 02/03/2015");
      AndTextBlockShouldBe("End_Date","End Date: 02/21/2015");
      AndTextBlockShouldBe("Description","Description:");
    }


    [TestMethod]
    public void EditOnlyProjectGithubLink(){
      GivenThereAreXProjects("current");
      WhenIClick("Current_Projects_Button");
      ThenIAmOnCurrentProjectsList();
      AndIShouldSeeXNumberOfProjectsInXListBox(3,"Current_Projects_Listbox","current");
      WhenISelect(0,"Current_Projects_Listbox");
      AndIClick("View_Current_Project_Button");
      AndIShouldNotSee("View_Past_Projects_Button");
      AndIShouldSee("Edit_Description_Button");
      AndTextBlockShouldBe("Single_Project_Name","angular_project");
      AndTextBlockShouldBe("Github","Github Link: http://github.com/angular_project");
      AndTextBlockShouldBe("Start_Date","Start Date: 02/03/2015");
      AndTextBlockShouldBe("End_Date","End Date: 02/20/2015");
      AndTextBlockShouldBe("Description","Description:");
      AndIShouldNotSee("Notes_Listbox");
      WhenIClick("Edit_Project_Details");
      ThenIShouldSeeInModal("AddProjectModal","Modal_New_Project_Button");
      AndIShouldSeeInModal("AddProjectModal","Add_Project_Description");
      AndIShouldSeeInModal("AddProjectModal","Modal_Close_Button");
      AndTextBlockShouldBe("Modal_New_Project_Name","angular_project");
      AndTextBlockShouldBe("Modal_New_Project_Start_Date","02/03/2015");
      AndTextBlockShouldBe("Modal_New_Project_End_Date","02/20/2015");
      AndTextBlockShouldBe("Modal_New_Project_Github","http://github.com/angular_project");
      AndTextBlockShouldBe("Modal_New_Project_Description","");
      AndIFillGithubLink("http://github/new_project_app");
      AndIClickInModal("AddProjectModal","Modal_New_Project_Button");
      AndTextBlockShouldBe("Single_Project_Name","angular_project");
      AndTextBlockShouldBe("Github","Github Link: http://github.com/new_angular_app");
      AndTextBlockShouldBe("Start_Date","Start Date: 02/03/2015");
      AndTextBlockShouldBe("End_Date","End Date: 02/20/2015");
      AndTextBlockShouldBe("Description","Description:");
    }
  }
}
