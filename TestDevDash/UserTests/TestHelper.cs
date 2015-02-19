﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevDash.Model;
using TestStack.White.UIItems.WindowItems;
using TestStack.White;
using System.IO;
using System.Reflection;
using TestStack.White.Factory;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems;
using DevDash.Repositories;
using DevDash;
using System.Windows.Automation;

namespace TestDevDash.UserTests {
  public class TestHelper {

    private static TestContext test_context;
    protected static Window window;
    private static Application application;
    private static ProjectsRepository ProjectRepo = new ProjectsRepository();
    private static ProjectContext context;
    private static String applicationPath;

    // SETUP/TEARDOWN FUNCTIONS

    public static void SetUpClass(TestContext _context) {
      var applicationDir = _context.DeploymentDirectory;
      applicationPath = Path.Combine(applicationDir, "..\\..\\..\\TestDevDash\\bin\\Debug\\DevDash");
      ProjectRepo.Clear();
    }

    public static void TestPrep() {
      application = Application.Launch(applicationPath);
      window = application.GetWindow("MainWindow", InitializeOption.NoCache);
      context = ProjectRepo.Context(); 
    }

    public static void CleanThisUp() {
      window.Close();
      application.Close();
      ProjectRepo.Clear();
    }

    // USER TEST FUNCTIONS 

    //given there are/not projects 
 
    public void GivenThereAreNoProjects() {
      Assert.AreEqual(0,ProjectRepo.GetCount());
    }
   
    public void GivenThereAreNoXProjects(string project_type) {
      if(project_type == "current")
        Assert.AreEqual(0, ProjectRepo.AllCurrentProjects().Count);
      else
        Assert.AreEqual(0, ProjectRepo.AllPastProjects().Count);
    }

    public void AndIAmOnCurrentProjectsList() {
      ThenIAmOnCurrentProjectsList();
    }

    public void ThenIAmOnCurrentProjectsList() {
      Button back_button = window.Get<Button>("View_Past_Projects_Button");
    }

    public void GivenThereAreXProjects(string project_type) {

      if (project_type == "current") {
        ProjectRepo.Add(new Project("angular_project",1,"02/03/2015","02/20/2015","http://github.com/angular_project"));
        ProjectRepo.Add(new Project("js_project",1,"10/03/2015","10/20/2015","http://github.com/js_project"));
        ProjectRepo.Add(new Project("CSharp_project",1,"02/21/2015", "02/28/2015","http://github.com/csharp"));
      }
      else if(project_type == "past"){
        ProjectRepo.Add(new Project("angular_project",0,"02/03/2015","02/20/2015","http://github.com/angular_project"));
        ProjectRepo.Add(new Project("js_project",0,"10/03/2015","10/20/2015","http://github.com/js_project"));
        ProjectRepo.Add(new Project("CSharp_project",0,"02/21/2015", "02/28/2015","http://github.com/csharp"));
      }
      else {
        throw new ArgumentException("Not a valid project type");
      }

      Assert.AreEqual(3,ProjectRepo.GetCount());
    }

    // I should not/see 

    public void AndIShouldSeeXNumberOfProjectsInXListBox(int project_number, string list, string project_type) {
      SearchCriteria search_criteria = SearchCriteria.ByAutomationId(list).AndIndex(0);

      ListBox list_box = (ListBox)window.Get(search_criteria);

      if(project_type == "current") {
        Assert.AreEqual(project_number,ProjectRepo.AllCurrentProjects().Count);
        Assert.AreEqual(project_number,list_box.Items.Count);
      }

      if (project_type == "past") {
        Assert.AreEqual(project_number,ProjectRepo.AllPastProjects().Count);
        Assert.AreEqual(project_number,list_box.Items.Count);
      }
    }

    public void ThenIShouldSeeXNumberOfProjectsInXListBox(int project_number, string list, string project_type) {
      AndIShouldSeeXNumberOfProjectsInXListBox(project_number, list, project_type);
    }


    public void WhenISelect(int index, string list ) {
      SearchCriteria search_criteria = SearchCriteria.ByAutomationId(list).AndIndex(0);

      ListBox list_box = (ListBox)window.Get(search_criteria);
      list_box.Select(0);
      Assert.IsTrue(list_box.Item(0).IsSelected);
    }

    public void ThenIShouldSee(string element) {
      AndIShouldSee(element);
    }

    public void AndIShouldSee(string name) {
      var element = window.Get(SearchCriteria.ByAutomationId(name));
      Assert.IsTrue(element.Visible);
    } 

    public void ThenIShouldNotSee(string name) {
      var element = window.Get(SearchCriteria.ByAutomationId(name));
      Assert.IsFalse(element.Visible);
    }

    public void AndIShouldNotSee(string name) {
      ThenIShouldNotSee(name);
    }

    public void WhenIClick(string button_name) {
      Button button = window.Get<Button>(button_name);
      button.Click();
    }

    public void AndIShouldSeeXNameInXListbox(string name, string list) {
      SearchCriteria searchCriteria = SearchCriteria.ByAutomationId(list).AndIndex(0);
      ListBox list_box = (ListBox)window.Get(searchCriteria);
      var item = list_box.Items.Find(i => i.Text == name);
      Assert.AreEqual(name, item.Text);
    }

    public void AndIClick(string element) {
      WhenIClick(element);
    }

    public void AndIFillEndDate(DateTime date) {
       DateTimePicker picker = window.Get<DateTimePicker>("New_Project_End_Date");
      picker.Date = date;
      Assert.AreEqual(date, picker.Date);
    }

    public void AndIFillStartDate(DateTime date) {
      DateTimePicker picker = window.Get<DateTimePicker>("New_Project_Start_Date");
      picker.Date = date;
      Assert.AreEqual(date, picker.Date);
    }

    public void AndIFillGithubLink(string link) {
      TextBox textbox = window.Get<TextBox>("New_Project_Github");
      textbox.SetValue(link);
      Assert.AreEqual(link, textbox.Text);
    }

    public void WhenIFillProjectName(string name) {
      TextBox textbox = window.Get<TextBox>("New_Project_Name");
      textbox.SetValue(name);
      Assert.AreEqual(name, textbox.Text);
    }


    public void AndIAmAmOnMainWindow() {
      Button past_project = window.Get<Button>("Current_Projects_Button");
        Button current_project = window.Get<Button>("Past_Projects_Button");
      Assert.IsTrue(past_project.Enabled); 
      Assert.IsTrue(current_project.Enabled); 
    }

    public void AndDBShouldHaveXProjects(int count) {
      int db_count = ProjectRepo.GetCount();
      Assert.AreEqual(count,db_count);
    }

    public void ThenIShouldSeeErrorMessage(string element,string error_message) {
      var error = window.Get(SearchCriteria.ByAutomationId(element));
      
      Assert.IsTrue(error.Visible);
    }
  }
}
