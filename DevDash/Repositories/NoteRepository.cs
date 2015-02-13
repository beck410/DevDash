using DevDash.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDash.Repositories {
  public class NoteRepository : INoteRepository {

    public List<Note> GetAllNotes(int project_id) {
      throw new NotImplementedException();
    }

    public Note GetNoteById(int note_id) {
      throw new NotImplementedException();
    }

    public void Add(Note note) {
      throw new NotImplementedException();
    }

    public void Delete(int id) {
      throw new NotImplementedException();
    }

    public void Clear() {
      throw new NotImplementedException();
    }

    public void EditNote(int id, string note) {
      throw new NotImplementedException();
    }
  }
}
