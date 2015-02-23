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

      int project_id = repo.AllCurrentProjects().Find(c => c.ProjectName == "Angular_Project").ProjectId;
      Assert.AreEqual(3, repo.All().Count);
      Assert.AreEqual(3, repo.AllCurrentProjects().Count);
      Assert.AreEqual(0, repo.AllPastProjects().Count);

      repo.MoveProject(project_id);

      Assert.AreEqual(3, repo.All().Count);
      Assert.AreEqual(2, repo.AllCurrentProjects().Count);
      Assert.AreEqual(1, repo.AllPastProjects().Count);
    }
  }
}