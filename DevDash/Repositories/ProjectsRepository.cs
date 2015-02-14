using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevDash.Model;
using System.Data.Entity;

namespace DevDash.Repositories {
  public class ProjectsRepository : IProjectRepository{

    public ProjectsRepository(){
      _dbContext = new ProjectContext();
      _dbContext.Projects.Load();
    }

    public ProjectContext Context() {
      return _dbContext;
    }

    //set up for db local
    private ProjectContext _dbContext;

   //Project DB Methods
      //return qu.ToList<Project>();
    public List<Project> All() {
      var query = from Project in _dbContext.Projects
                  select Project;
      return query.ToList<Project>();
    }

    public List<Project> AllPastProjects() {
      var query = _dbContext.Projects.Where(x => x.ProjectState == 0);

     return query.ToList();
    }

    public List<Project> AllCurrentProjects() {
     var query = _dbContext.Projects.Where(x => x.ProjectState == 1);

     return query.ToList();
    }
 
    public int GetCount(){
      return _dbContext.Projects.Count<Project>();
    }

    public void Add(Project P) {
      _dbContext.Projects.Add(P);
      _dbContext.SaveChanges();
    }

    public void Delete(Project P) {
      throw new NotImplementedException();
    }

    public void Clear() {
      var projects = this.All();
      _dbContext.Projects.RemoveRange(projects);
      _dbContext.SaveChanges();
    }

    public Project GetById(int id) {
      return _dbContext.Projects.Find(id);
    }
  }
}
