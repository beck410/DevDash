using DevDash.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDash.Repositories {
  public class NoteRepository : INoteRepository {

    //private ProjectContext _dbContext;

    //public DbSet<Note> GetDbSet() {
    //  return _dbContext.Notes;
    //}

    //public NoteRepository() {
    //  //_dbContext = new ProjectContext();

    //}

    public List<Note> GetAllByProjectId(int project_id) {
      throw new NotImplementedException();
    }

    public Note GetById(int note_id) {
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

    public void Edit(int id, string note) {
      throw new NotImplementedException();
    }

    public int GetCount() {
      throw new NotImplementedException();
    }

  }
}
