using DevDash.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDash.Repositories {
  interface INoteRepository {
    List<Note> GetAllByProjectId(int project_id);
    Note GetById(int note_id);
    void Add(Note note);
    void Delete(int id);
    void Clear();
    void Edit(int id, string note);
    int GetCount();
  }
}
