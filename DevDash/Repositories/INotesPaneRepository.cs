using DevDash.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDash.Repositories {
  interface INotesPaneRepository {    
    NotesPanel GetPanelDescription(int project_id);
    NotesPanel GetById(int id);
    void Add(NotesPanel panel);
    void Delete(int id);
    void Clear();
  }
}
