using DevDash.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDash.Repositories {
  public class NoteRepository : INoteRepository {

    private ProjectContext _dbContext;

    public DbSet<Note> GetDbSet() {
      return _dbContext.Notes;
    }

    public NoteRepository() {
      _dbContext = new ProjectContext();

    }

    public ObservableCollection<Note> GetAllByProjectId(int project_id) {
      var query =  _dbContext.Notes.Where(c => c.ProjectId == project_id);
      return new ObservableCollection<Note>(query); 
    }

    public Note GetById(int note_id) {
      return _dbContext.Notes.Find(note_id);
    }

    public void Add(Note note) {
      _dbContext.Notes.Add(note);
      _dbContext.SaveChanges();
    }

    public void Delete(int id) {
      var note = _dbContext.Notes.Where(x => x.NoteId == id);
      _dbContext.Notes.RemoveRange(note);
      _dbContext.SaveChanges();
    }

    public void Clear() {
      var query = from n in _dbContext.Notes
                  select n;
      List<Note> notes = query.ToList<Note>();
      _dbContext.Notes.RemoveRange(notes);
      _dbContext.SaveChanges();
    }

    public void Edit(int note_id, string edited_note) {
      var query = from note in _dbContext.Notes
                  where note.NoteId == note_id
                  select note;

      foreach (Note note in query) {
        note.NoteDetails = edited_note;
      }

      _dbContext.SaveChanges();
    }

    public int GetCount() {
      return _dbContext.Notes.Count<Note>(); 
    }

  }
}
