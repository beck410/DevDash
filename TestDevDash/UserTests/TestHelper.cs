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
    
    public void GivenThereAreNoXProjects(string p) {
      throw new NotImplementedException();
    }

    public void GivenThereAreXProjects(string project_type) {

      if (project_type == "current") {
        ProjectRepo.Add(new Project("angular_project",1,"02/03/2015"));
        ProjectRepo.Add(new Project("js_project",1,"10/03/2015"));
        ProjectRepo.Add(new Project("CSharp_project",1,"02/21/2015"));
      }
      else if(project_type == "past"){
        ProjectRepo.Add(new Project("angular_project",0,"02/03/2015"));
        ProjectRepo.Add(new Project("js_project",0,"10/03/2015"));
        ProjectRepo.Add(new Project("CSharp_project",0,"02/21/2015"));
      }
      else {
        throw new ArgumentException("Not a valid project type");
      }

      Assert.AreEqual(3,ProjectRepo.GetCount());
    }
    public void AndIShouldSeeXNumberOfProjectsInListBox(int project_number, string name) {
      SearchCriteria search_criteria = SearchCriteria.ByAutomationId(name).AndIndex(0);
      ListBox list_box = (ListBox)window.Get(search_criteria);
      Assert.AreEqual(3, ProjectRepo.AllCurrentProjects().Count);
      Assert.AreEqual(project_number,list_box.Items.Count);
    }

    public void AndIShouldSee(string name) {
      var element = window.Get(SearchCriteria.ByAutomationId(name));
      Assert.IsTrue(element.Visible);
    }

    public void ThenIShouldNotSee(string name) {
      var element = window.Get(SearchCriteria.ByAutomationId(name));
      Assert.IsFalse(element.Visible);
    }

    public void AndIShouldNotSee(string p) {
      ThenIShouldNotSee(p);
    }

    public void WhenIClick(string button_name) {
      Button button = window.Get<Button>(button_name);
      button.Click();
    }
  }
}
