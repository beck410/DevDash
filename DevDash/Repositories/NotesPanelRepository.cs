using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevDash.Model;
using System.Data.Entity;

namespace DevDash.Repositories {
  public class NotesPanelRepository : INotesPaneRepository {

    private ProjectContext _dbContext;
    public NotesPanelRepository() {
      _dbContext = new ProjectContext();
      _dbContext.Projects.Load();
    }

    public NotesPanel GetPanelDescription(int project_id) {
      throw new NotImplementedException();
    }

    public NotesPanel GetById(int id) {
      throw new NotImplementedException();
    }

    public void Add(NotesPanel panel) {
      throw new NotImplementedException();
    }

    public void Delete(int id) {
      throw new NotImplementedException();
    }

    public void Clear() {
      throw new NotImplementedException();
    }
  }
}
