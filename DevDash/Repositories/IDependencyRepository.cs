using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDash.Repositories {
  public interface IDependencyRepository {

    List<Dependency> GetAllByProjectId(int project_id);
    Dependency GetById(int dependency_id);
    void Delete(int id);
    void Clear();
    void Edit(int id, string note);
    int GetCount();
    void Add(Dependency dependency);
  }
}
