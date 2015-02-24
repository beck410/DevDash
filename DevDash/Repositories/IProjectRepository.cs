using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevDash.Model;
using System.Windows.Documents;
using System.Collections.ObjectModel;

namespace DevDash.Repositories {
  public interface IProjectRepository {

    List<Project> All();
    ObservableCollection<Project> AllPastProjects();
    ObservableCollection<Project> AllCurrentProjects();
    int GetCount();
    void Add(Project P);
    void Delete(int P);
    void Clear();
    Project GetById(int id);
    void Edit(int project_id, string name, string start_date, string end_date, string github, string description);
  }
}
