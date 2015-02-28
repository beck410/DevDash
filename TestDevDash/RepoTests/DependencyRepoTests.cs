using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevDash.Repositories;
using DevDash.Model;
using DevDash;
using System.Collections.Generic;

namespace TestDevDash.RepoTests {
  [TestClass]
  public class DependencyRepoTests {
    
    private static DependencyRepository dependency_repo;
    private static ProjectsRepository project_repo;

    [ClassInitialize]
    public static void SetUp(TestContext _context){
      dependency_repo = new DependencyRepository();
      project_repo = new ProjectsRepository();
      project_repo.Add(new Project("Angular",1,"03/02/2013","03/04/2014","www.github.com/angular"));
      project_repo.Add(new Project("js",1,"03/02/2013","03/04/2014","www.github.com/js"));
      dependency_repo.Clear();
    }

    [TestInitialize]
    public void TestSetUp() {
      
    }

    [ClassCleanup]
    public static void CleanUp() {
      dependency_repo.Clear();
      project_repo.Clear();
    }

    [TestCleanup]
    public void ClearDB() {
      dependency_repo.Clear();
    }
    [TestMethod]
    public void TestAddDependencyMethod() {
      var projects = project_repo.All();
      Assert.AreEqual(projects.Count, 2);
      int project_id = projects[0].ProjectId;
      dependency_repo.Add(new Dependency("this is a test note", project_id));

      Assert.AreEqual(dependency_repo.GetCount(), 1);
    }
 
    [TestMethod]
    public void TestDependencysGetAllByProjectIdMethod() {
      int project_id = project_repo.All()[0].ProjectId;
      dependency_repo.Add(new Dependency("this is a test note", project_id));
      dependency_repo.Add(new Dependency("this is a note 2", project_id));

      var notes = dependency_repo.GetAllByProjectId(project_id);
      Assert.AreEqual(notes.Count, 2);

      int first_note_id = notes[0].DependencyId;
      int second_note_id = notes[1].DependencyId;

      Assert.AreEqual("this is a test note", dependency_repo.GetById(first_note_id).DependencyDetails);
      Assert.AreEqual("this is a note 2", dependency_repo.GetById(second_note_id).DependencyDetails);
    }

    [TestMethod]
    public void TestDependencysGetById() {
      int project_id = project_repo.All()[0].ProjectId;
      dependency_repo.Add(new Dependency("this is a test note", project_id));
      dependency_repo.Add(new Dependency("this is note 2", project_id));
    }

    [TestMethod]
    public void TestDependencyClear() {

      List<Project> project_list = project_repo.All();
      var project = project_list[0];
      int project_id = project.ProjectId;
      dependency_repo.Add(new Dependency("this is a test note", project_id));
      dependency_repo.Add(new Dependency("this is note 2", project_id));

      dependency_repo.Clear();

      Assert.AreEqual(0, dependency_repo.GetCount());
    }

    [TestMethod]
    public void TestDependencyEdit() {
      int project_id = project_repo.All()[0].ProjectId;
      dependency_repo.Add(new Dependency("this is a test note", project_id));
      dependency_repo.Add(new Dependency("this is note 2", project_id));

      Dependency note = dependency_repo.GetAllByProjectId(project_id)[1];

      Assert.AreEqual(note.DependencyDetails, "this is note 2");

      dependency_repo.Edit(note.DependencyId,"this is note 2 - edited");

      Dependency note_edited = dependency_repo.GetAllByProjectId(project_id)[1];

      Assert.AreEqual("this is note 2 - edited", note_edited.DependencyDetails);

    }

    [TestMethod]
      public void TestDependencyDelete() {
      List<Project> project_list = project_repo.All();
      var project = project_list[0];
      int project_id = project.ProjectId;

      dependency_repo.Add(new Dependency("this is a test note", project_id));
      dependency_repo.Add(new Dependency("this is note 2", project_id));

      int last_note_id = dependency_repo.GetAllByProjectId(project_id)[0].DependencyId;
      
      Assert.AreEqual(2, dependency_repo.GetAllByProjectId(project_id).Count);
      dependency_repo.Delete(last_note_id);
      Assert.AreEqual(1, dependency_repo.GetAllByProjectId(project_id).Count);
      }
    
  } 
}
