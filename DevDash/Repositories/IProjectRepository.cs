using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevDash.Model;

namespace DevDash.Repositories {
  public interface IProjectRepository {

    int GetCount();
    void Add(Project P);
    void Delete(Project P);
    void Clear();
    Project GetById(int id);
  }
}
