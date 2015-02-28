using DevDash.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDash.Repositories {
  public class DependencyRepository : IDependencyRepository {

    private ProjectContext _dbContext;

    public DbSet<Dependency> GetDbSet() {
      return _dbContext.Dependencies;
    }

    public DependencyRepository() {
      _dbContext = new ProjectContext();

    }

    public List<Dependency> GetAllByProjectId(int project_id) {
      var query =  _dbContext.Dependencies.Where(c => c.ProjectId == project_id);
      return new List<Dependency>(query); 
    }

    public Dependency GetById(int dependency_id) {
      return _dbContext.Dependencies.Find(dependency_id);
    }

    public void Delete(int id) {
      var dependency = _dbContext.Dependencies.Where(x => x.DependencyId == id);
      _dbContext.Dependencies.RemoveRange(dependency);
      _dbContext.SaveChanges();
    }

    public void Clear() {
      var query = from d in _dbContext.Dependencies
                  select d;
      List<Dependency> dependencies = query.ToList<Dependency>();
      _dbContext.Dependencies.RemoveRange(dependencies);
      _dbContext.SaveChanges();
    }

    public void Edit(int id, string dependency) {
      var query = from d in _dbContext.Dependencies
                  where d.DependencyId == id
                  select d;

      foreach (Dependency d in query) {
        d.DependencyDetails = dependency;
      }

      _dbContext.SaveChanges();
    }

    public int GetCount() {
      return _dbContext.Dependencies.Count<Dependency>(); 
    }

    public void Add(Dependency dependency) {
      _dbContext.Dependencies.Add(dependency);
      _dbContext.SaveChanges();
    }
  }
}
