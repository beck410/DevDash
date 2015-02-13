using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevDash.Repositories;
using DevDash.Model;
using System.Collections;
using System.Collections.Generic;

namespace TestDevDash.RepoTests {
  [TestClass]
  public class ProjectRepoTests {

    private static ProjectsRepository repo;

    [ClassInitialize]
    public void SetUp(TestContext _context){
      repo = new ProjectsRepository();
      repo.Clear();
    }

    [ClassCleanup]
    public void CleanUp() {
      repo.Clear();
    }

    [TestCleanup]
    public void ClearDB() {
      repo.Clear();
    }

    [TestMethod]
    public void TestAddFirstProjectToDatabaseWithOnlyRequiredFields() 
    {
      Assert.AreEqual(0, repo.GetCount());
      repo.Add(new Project("Simple_Project",0, "02/31/2015"));
      Assert.AreEqual(1, repo.GetCount());
    }
    
    [TestMethod]
    public void TestAddFirstProjectToDatabaseWithAllFields() 
    {
      Assert.AreEqual(0, repo.GetCount());
      repo.Add(new Project("Simple_Project",0, "02/31/2015","04/01/2015","wwww.github.com/beck410/Simple_Project"));
      Assert.AreEqual(1, repo.GetCount());
    }

    [TestMethod]
    public void TestAllMethod() {
       repo.Add(new Project("Simple_Project",0, "02/31/2015","04/01/2015","wwww.github.com/beck410/Simple_Project"));
      repo.Add(new Project("Angular_Project",1,"02/14/2015","http://www.github.com"));
      Assert.AreEqual(2, repo.GetCount());
    }

    public void TestGetCount() {
       repo.Add(new Project("Simple_Project",0, "02/31/2015","04/01/2015","wwww.github.com/beck410/Simple_Project"));
      repo.Add(new Project("Angular_Project",1,"02/14/2015","http://www.github.com/Angular_Project"));
      repo.Add(new Project("CSharpProject",0,"02/14/2015","http://www.github.com/CSharpProject"));
      Assert.AreEqual(3, repo.GetCount());
    }

    [TestMethod]
    public void TestClear() {
      repo.Add(new Project("Angular_Project",1,"02/14/2015","http://www.github.com/Angular_Project"));
      repo.Clear();
      Assert.AreEqual(0, repo.GetCount());
    }

    [TestMethod]
    public void TestGetById() {
      Project project = new Project("Angular_Project",1,"02/14/2015","http://www.github.com/Angular_Project");
      repo.Add(new Project("Angular_Project",1,"02/14/2015","http://www.github.com/Angular_Project"));
      Assert.AreEqual(project,repo.GetById(1));
    }

    [TestMethod]
    public void TestGetAllCurrentProjects() {
      Project angular = new Project("Angular_Project", 1, "02/14/2015", "http://www.github.com/Angular_Project"); 
      Project js = new Project("JS_Project",1,"02/14/2015","http://www.github.com/Angular_Project");
      Project cSharp = new Project("CSharp_Project",0,"02/14/2015","http://www.github.com/Angular_Project");
      List<Project> projects = new List<Project>();
      projects.Add(angular);
      projects.Add(js);
      repo.Add(angular);
      repo.Add(js);
      repo.Add(cSharp);

      CollectionAssert.AreEquivalent(projects, repo.AllCurrentProjects());
    }

    [TestMethod]
    public void TestGetAllPastProjects() {
      Project angular = new Project("Angular_Project", 0, "02/14/2015", "http://www.github.com/Angular_Project"); 
      Project js = new Project("JS_Project",0,"02/14/2015","http://www.github.com/Angular_Project");
      Project cSharp = new Project("CSharp_Project",1,"02/14/2015","http://www.github.com/Angular_Project");
      List<Project> projects = new List<Project>();
      projects.Add(angular);
      projects.Add(js);
      repo.Add(angular);
      repo.Add(js);
      repo.Add(cSharp);

      CollectionAssert.AreEquivalent(projects, repo.AllPastProjects());
    }
  }
}
