using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevDash.Model;
using System.Data.Entity;

namespace DevDash.Repositories {
  class ProjectsRepository : IProjectRepository{

    public ProjectsRepository(){
      _dbContext = new ProjectContext();
      _dbContext.Projects.Load();
    }

    //set up for db local
    private ProjectContext _dbContext;



    //Project DB Methods
    public int GetCount(){
      throw new NotImplementedException();
    }

    public void Add(Project P) {
      throw new NotImplementedException();
    }

    public void Delete(Project P) {
      throw new NotImplementedException();
    }

    public void Clear() {
      throw new NotImplementedException();
    }

    public Project GetById(int id) {
      throw new NotImplementedException();
    }
  }
}
