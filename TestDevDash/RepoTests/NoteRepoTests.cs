using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevDash.Repositories;
using DevDash.Model;

namespace TestDevDash.RepoTests {
  [TestClass]
  public class NoteRepoTests {
    
    private static NoteRepository note_repo;
    private static ProjectsRepository project_repo;

    [ClassInitialize]
    public static void SetUp(TestContext _context){
      note_repo = new NoteRepository();
      project_repo = new ProjectsRepository();
      project_repo.Add(new Project("Simple_Project",1, "02/31/2015","04/01/2015","wwww.github.com/beck410/Simple_Project"));
      project_repo.Add(new Project("Angular_Project",1,"02/14/2015","02/20/2015","http://www.github.com"));
      note_repo.Clear();
    }

    [ClassCleanup]
    public static void CleanUp() {
      note_repo.Clear();
      project_repo.Clear();
    }

    [TestCleanup]
    public void ClearDB() {
      note_repo.Clear();
      project_repo.Clear();
    }
    [TestMethod]
    public void TestAddNoteMethod() {
      var projects = project_repo.AllCurrentProjects();
      Assert.AreEqual(projects.Count, 2);
      int project_id = projects[0].ProjectId;
      note_repo.Add(new Note("this is a test note", project_id));

      Assert.AreEqual(note_repo.GetCount(), 1);
    }

    [TestMethod]
    public void TestNotesGetAllByProjectIdMethod() {
      int project_id = project_repo.AllCurrentProjects()[0].ProjectId;
      note_repo.Add(new Note("this is a test note", project_id));
      note_repo.Add(new Note("this is note 2", project_id));

      var notes = note_repo.GetAllByProjectId(project_id);
      Assert.AreEqual(notes.Count, 2);

      int first_note_id = notes[0].NoteId;
      int second_note_id = notes[1].NoteId;

      Assert.AreEqual("this is a test note", note_repo.GetById(first_note_id).NoteDetails);
      Assert.AreEqual("this is a note 2", note_repo.GetById(second_note_id).NoteDetails);
    }

    [TestMethod]
    public void TestNotesGetById() {
      int project_id = project_repo.AllCurrentProjects()[0].ProjectId;
      note_repo.Add(new Note("this is a test note", project_id));
      note_repo.Add(new Note("this is note 2", project_id));
    }

    [TestMethod]
    public void TestNoteClear() {
      int project_id = project_repo.AllCurrentProjects()[0].ProjectId;
      note_repo.Add(new Note("this is a test note", project_id));
      note_repo.Add(new Note("this is note 2", project_id));

      note_repo.Clear();

      Assert.AreEqual(0, note_repo.GetCount());
    }

    [TestMethod]
    public void TestNoteEdit() {
      int project_id = project_repo.AllCurrentProjects()[0].ProjectId;
      note_repo.Add(new Note("this is a test note", project_id));
      note_repo.Add(new Note("this is note 2", project_id));
      
      int last_note_id = note_repo.GetAllByProjectId(project_id).Find(c => c.NoteDetails == "this is note 2").NoteId;

      Assert.AreEqual(note_repo.GetById(last_note_id).NoteDetails, "this is note 2");

      note_repo.Edit(last_note_id,"this is note 2 - edited");

      Assert.AreEqual(note_repo.GetById(last_note_id), "this is note 2 - edited");

    }

    [TestMethod]
      public void TestNoteDelete() {
      int project_id = project_repo.AllCurrentProjects()[0].ProjectId;
      note_repo.Add(new Note("this is a test note", project_id));
      note_repo.Add(new Note("this is note 2", project_id));

      int last_note_id = note_repo.GetAllByProjectId(project_id).Find(c => c.NoteDetails == "this is note 2").NoteId;
      
      Assert.AreEqual(2, note_repo.GetAllByProjectId(project_id).Count);
      note_repo.Delete(last_note_id);
      Assert.AreEqual(1, note_repo.GetAllByProjectId(project_id).Count);
      }
    
  }
}
