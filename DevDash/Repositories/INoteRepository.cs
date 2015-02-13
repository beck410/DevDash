using DevDash.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDash.Repositories {
  interface INoteRepository {
    List<Note> GetAllNotes(int project_id);
    Note GetNoteById(int note_id);
    void Add(Note note);
    void Delete(int id);
    void Clear();
    void EditNote(int id, string note);
  }
}
