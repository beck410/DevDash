using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevDash.Model;
using System.Windows.Documents;

namespace DevDash.Repositories {
  public interface IProjectRepository {

    List<Project> All();
    List<Project> AllPastProjects();
    List<Project> AllCurrentProjects();
    int GetCount();
    void Add(Project P);
    void Delete(int P);
    void Clear();
    Project GetById(int id);
  }
}
