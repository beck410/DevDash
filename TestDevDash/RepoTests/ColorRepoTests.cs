using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevDash.Repositories;
using DevDash.Model;
using System.Collections.Generic;

namespace TestDevDash.RepoTests {
  [TestClass]
  public class ColorRepoTests {
    private static ColorRepository color_repo;
    private static ProjectsRepository project_repo;

    [ClassInitialize]
    public static void SetUp(TestContext _context){
      color_repo = new ColorRepository();
      project_repo = new ProjectsRepository();
      project_repo.Add(new Project("Angular",1,"03/02/2013","03/04/2014","www.github.com/angular"));
      project_repo.Add(new Project("js",1,"03/02/2013","03/04/2014","www.github.com/js"));
      color_repo.Clear();
    }
    
    [TestInitialize]
    public void TestSetUp() {
      
    }

    [ClassCleanup]
    public static void CleanUp() {
      color_repo.Clear();
      project_repo.Clear();
    }

    [TestCleanup]
    public void ClearDB() {
      color_repo.Clear();
    }
    [TestMethod]
    public void TestAddColorMethod() {
      var projects = project_repo.All();
      Assert.AreEqual(projects.Count, 2);
      int project_id = projects[0].ProjectId;
      color_repo.Add(new Color(project_id, "#FFFFFF"));

      Assert.AreEqual(color_repo.GetCount(), 1);
    }
 
    [TestMethod]
    public void TestColorsGetAllByProjectIdMethod() {
      int project_id = project_repo.All()[0].ProjectId;
      color_repo.Add(new Color(project_id, "#FFFFFF"));
      color_repo.Add(new Color(project_id, "#000000"));

      var notes = color_repo.GetAllByProjectId(project_id);
      Assert.AreEqual(notes.Count, 2);

      int first_color_id = notes[0].ColorId;
      int second_color_id = notes[1].ColorId;

      Assert.AreEqual("#FFFFFF", color_repo.GetById(first_color_id).Hex);
      Assert.AreEqual("#000000", color_repo.GetById(second_color_id).Hex);
    }

    [TestMethod]
    public void TestColorsGetById() {
      int project_id = project_repo.All()[0].ProjectId;
      color_repo.Add(new Color(project_id,"#FFFFFF"));
      color_repo.Add(new Color(project_id, "#000000"));

      Color First_Color = color_repo.GetAllByProjectId(project_id)[0];

      Assert.AreEqual("#FFFFFF", color_repo.GetById(First_Color.ColorId).Hex);
    }

    [TestMethod]
    public void TestColorClear() {

      List<Project> project_list = project_repo.All();
      var project = project_list[0];
      int project_id = project.ProjectId;
      color_repo.Add(new Color(project_id,"#FFFFFF"));
      color_repo.Add(new Color(project_id, "#000000"));

      color_repo.Clear();

      Assert.AreEqual(0, color_repo.GetCount());
    }

    [TestMethod]
      public void TestColorDelete() {
      List<Project> project_list = project_repo.All();
      var project = project_list[0];
      int project_id = project.ProjectId;

      color_repo.Add(new Color(project_id,"#FFFFFF"));
      color_repo.Add(new Color(project_id, "#000000")); 

      int last_color_id = color_repo.GetAllByProjectId(project_id)[0].ColorId;
      
      Assert.AreEqual(2, color_repo.GetAllByProjectId(project_id).Count);

      color_repo.Delete(last_color_id);

      Assert.AreEqual(1, color_repo.GetAllByProjectId(project_id).Count);
    }
  }
}
