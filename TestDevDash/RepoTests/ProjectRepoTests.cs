using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevDash.Repositories;
using DevDash.Model;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;

namespace TestDevDash.RepoTests {
  [TestClass]
  public class ProjectRepoTests {

    private static ProjectsRepository repo;

    [ClassInitialize]
    public static void SetUp(TestContext _context){
      repo = new ProjectsRepository();
      repo.Clear();
    }

    [ClassCleanup]
    public static void CleanUp() {
      repo.Clear();
    }

    [TestCleanup]
    public void ClearDB() {
      repo.Clear();
    }
    
    [TestMethod]
    public void TestProjectAddFirstProjectToDatabaseWithAllFields() 
    {
      Assert.AreEqual(0, repo.GetCount());
      repo.Add(new Project("Simple_Project",0, "02/31/2015","04/01/2015","wwww.github.com/beck410/Simple_Project"));
      Assert.AreEqual(1, repo.GetCount());
    }

    [TestMethod]
    public void TestProjectAllMethod() {
       repo.Add(new Project("Simple_Project",0, "02/31/2015","04/01/2015","wwww.github.com/beck410/Simple_Project"));
      repo.Add(new Project("Angular_Project",1,"02/14/2015","02/20/2015","http://www.github.com"));
      Assert.AreEqual(2, repo.GetCount());
    }

    public void TestProjectGetCount() {
       repo.Add(new Project("Simple_Project",0, "02/31/2015","04/01/2015","wwww.github.com/beck410/Simple_Project"));
      repo.Add(new Project("Angular_Project",1,"02/14/2015","04/01/2015","http://www.github.com/Angular_Project"));
      repo.Add(new Project("CSharpProject",0,"02/14/2015","04/01/2015","http://www.github.com/CSharpProject"));

      Assert.AreEqual(3, repo.GetCount());
    }

    [TestMethod]
    public void TestProjectClear() {
      repo.Add(new Project("Angular_Project",1,"02/14/2015","04/01/2015","http://www.github.com/Angular_Project"));
      repo.Clear();
      Assert.AreEqual(0, repo.GetCount());
    }

    [TestMethod]
    public void TestProjectGetById() {
      repo.Add(new Project("Angular_Project",1,"02/14/2015","04/01/2015","http://www.github.com/Angular_Project"));
      repo.Add(new Project("Js_Project",1,"02/14/2015","04/01/2015","http://www.github.com/Angular_Project"));
      int project_id = repo.All()[0].ProjectId;
      Assert.AreEqual("Angular_Project",repo.GetById(project_id).ProjectName);
    }

    [TestMethod]
    public void TestProjectGetAllCurrentProjects() {
      Project angular = new Project("Angular_Project", 1, "02/14/2015","04/01/2015", "http://www.github.com/Angular_Project"); 
      Project js = new Project("JS_Project",1,"02/14/2015","04/01/2015","http://www.github.com/Angular_Project");
      Project cSharp = new Project("CSharp_Project",0,"02/14/2015","04/01/2015","http://www.github.com/Angular_Project");
      List<Project> projects = new List<Project>();
      projects.Add(angular);
      projects.Add(js);
      repo.Add(angular);
      repo.Add(js);
      repo.Add(cSharp);

      CollectionAssert.AreEquivalent(projects, repo.AllCurrentProjects());
    }

    [TestMethod]
    public void TestProjectGetAllPastProjects() {
      Project angular = new Project("Angular_Project", 0, "02/14/2015","04/01/2015", "http://www.github.com/Angular_Project"); 
      Project js = new Project("JS_Project",0,"02/14/2015","04/01/2015","http://www.github.com/Angular_Project");
      Project cSharp = new Project("CSharp_Project",1,"02/14/2015","04/01/2015","http://www.github.com/Angular_Project");
      List<Project> projects = new List<Project>();
      projects.Add(angular);
      projects.Add(js);
      repo.Add(angular);
      repo.Add(js);
      repo.Add(cSharp);

      CollectionAssert.AreEquivalent(projects, repo.AllPastProjects());
    }

    [TestMethod]
    public void TestProjectDelete() {
      Project angular = new Project("Angular_Project", 1, "02/14/2015","04/01/2015", "http://www.github.com/Angular_Project"); 
      Project js = new Project("JS_Project",1,"02/14/2015","04/01/2015","http://www.github.com/Angular_Project");
      Project cSharp = new Project("CSharp_Project",1,"02/14/2015","04/01/2015","http://www.github.com/Angular_Project");
      repo.Add(angular);
      repo.Add(js);
      repo.Add(cSharp);
      int last_project = repo.All().Find(c => c.ProjectName == "Angular_Project").ProjectId;
      Assert.AreEqual(3, repo.All().Count);
      repo.Delete(last_project);
      Assert.AreEqual(2, repo.All().Count);
    }

    [TestMethod]
    public void TestProjectMoveProject() {
      Project angular = new Project("Angular_Project", 1, "02/14/2015","04/01/2015", "http://www.github.com/Angular_Project"); 
      Project js = new Project("JS_Project",1,"02/14/2015","04/01/2015","http://www.github.com/Angular_Project");
      Project cSharp = new Project("CSharp_Project",1,"02/14/2015","04/01/2015","http://www.github.com/Angular_Project");

      repo.Add(angular);
      repo.Add(js);
      repo.Add(cSharp);

      int project_id =repo.All().Find(c => c.ProjectName == "Angular_Project").ProjectId;
      Assert.AreEqual(3, repo.All().Count);

      List<Project> current_projects_before = repo.All().FindAll(c => c.ProjectState == 1);
      Assert.AreEqual(3, current_projects_before.Count);
      
      List<Project> past_projects_before = repo.All().FindAll(c => c.ProjectState == 0);
      Assert.AreEqual(0, past_projects_before.Count);

      repo.MoveProject(project_id);

      List<Project> past_projects_after = repo.All().FindAll(c => c.ProjectState == 0);
      List<Project> current_projects_after = repo.All().FindAll(c => c.ProjectState == 1);
      Assert.AreEqual(3, repo.All().Count);
      Assert.AreEqual(2, current_projects_after.Count);
      Assert.AreEqual(1, past_projects_after.Count);
    }

    [TestMethod]
    public void TestProjectEdit() {
      Project cSharp = new Project("CSharp_Project",1,"02/14/2015","04/01/2015","http://www.github.com/csharp");
      repo.Add(cSharp);

      Project project_details_before = repo.All().Find(c => c.ProjectName == "CSharp_Project");
      
     
      Assert.AreEqual("CSharp_Project", project_details_before.ProjectName);
      Assert.AreEqual(1, project_details_before.ProjectState);
      Assert.AreEqual("02/14/2015", project_details_before.ProjectStartDate);
      Assert.AreEqual("04/01/2015", project_details_before.ProjectEndDate);
      Assert.AreEqual("http://www.github.com/csharp", project_details_before.GithubLink);
      Assert.AreEqual("", project_details_before.Description);

      repo.Edit(project_details_before.ProjectId, "Angular", "03/12/2014", "09/17/2015", "http://www.github.com/angular", "this is now an angular app");
      
      Assert.AreEqual("Angular", project_details_before.ProjectName);
      Assert.AreEqual(1, project_details_before.ProjectState);
      Assert.AreEqual("03/12/2014", project_details_before.ProjectStartDate);
      Assert.AreEqual("09/17/2015", project_details_before.ProjectEndDate);
      Assert.AreEqual("http://www.github.com/angular", project_details_before.GithubLink);
      Assert.AreEqual("this is now an angular app", project_details_before.Description);
    }
  }
}