using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevDash.Repositories;
using DevDash.Model;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace TestDevDash.RepoTests {
  [TestClass]
  public class NoteRepoTests {
    
    private static NoteRepository note_repo;
    private static ProjectsRepository project_repo;

    [ClassInitialize]
    public static void SetUp(TestContext _context){
      note_repo = new NoteRepository();
      project_repo = new ProjectsRepository();
      project_repo.Add(new Project("Angular",1,"03/02/2013","03/04/2014","www.github.com/angular"));
      project_repo.Add(new Project("js",1,"03/02/2013","03/04/2014","www.github.com/js"));
      note_repo.Clear();
    }

    [TestInitialize]
    public void TestSetUp() {
      
    }

    [ClassCleanup]
    public static void CleanUp() {
      note_repo.Clear();
      project_repo.Clear();
    }

    [TestCleanup]
    public void ClearDB() {
      note_repo.Clear();
    }
    [TestMethod]
    public void TestAddNoteMethod() {
      var projects = project_repo.All();
      Assert.AreEqual(projects.Count, 2);
      int project_id = projects[0].ProjectId;
      note_repo.Add(new Note("this is a test note", project_id));

      Assert.AreEqual(note_repo.GetCount(), 1);
    }
 
    [TestMethod]
    public void TestNotesGetAllByProjectIdMethod() {
      int project_id = project_repo.All()[0].ProjectId;
      note_repo.Add(new Note("this is a test note", project_id));
      note_repo.Add(new Note("this is a note 2", project_id));

      var notes = note_repo.GetAllByProjectId(project_id);
      Assert.AreEqual(notes.Count, 2);

      int first_note_id = notes[0].NoteId;
      int second_note_id = notes[1].NoteId;

      Assert.AreEqual("this is a test note", note_repo.GetById(first_note_id).NoteDetails);
      Assert.AreEqual("this is a note 2", note_repo.GetById(second_note_id).NoteDetails);
    }

    [TestMethod]
    public void TestNotesGetById() {
      int project_id = project_repo.All()[0].ProjectId;
      note_repo.Add(new Note("this is a test note", project_id));
      note_repo.Add(new Note("this is note 2", project_id));
    }

    [TestMethod]
    public void TestNoteClear() {

      List<Project> project_list = project_repo.All();
      var project = project_list[0];
      int project_id = project.ProjectId;
      note_repo.Add(new Note("this is a test note", project_id));
      note_repo.Add(new Note("this is note 2", project_id));

      note_repo.Clear();

      Assert.AreEqual(0, note_repo.GetCount());
    }

    [TestMethod]
    public void TestNoteEdit() {
      int project_id = project_repo.All()[0].ProjectId;
      note_repo.Add(new Note("this is a test note", project_id));
      note_repo.Add(new Note("this is note 2", project_id));

      Note note = note_repo.GetAllByProjectId(project_id)[1];

      Assert.AreEqual(note.NoteDetails, "this is note 2");

      note_repo.Edit(note.NoteId,"this is note 2 - edited");

      Note note_edited = note_repo.GetAllByProjectId(project_id)[1];

      Assert.AreEqual("this is note 2 - edited", note_edited.NoteDetails);

    }

    [TestMethod]
      public void TestNoteDelete() {
      List<Project> project_list = project_repo.All();
      var project = project_list[0];
      int project_id = project.ProjectId;

      note_repo.Add(new Note("this is a test note", project_id));
      note_repo.Add(new Note("this is note 2", project_id));

      int last_note_id = note_repo.GetAllByProjectId(project_id)[0].NoteId;
      
      Assert.AreEqual(2, note_repo.GetAllByProjectId(project_id).Count);
      note_repo.Delete(last_note_id);
      Assert.AreEqual(1, note_repo.GetAllByProjectId(project_id).Count);
      }
    
  }
}
