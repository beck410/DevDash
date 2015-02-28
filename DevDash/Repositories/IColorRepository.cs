using DevDash.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDash.Repositories {
  interface IColorRepository {
    List<Color> GetAllByProjectId(int project_id);
    Color GetById(int color_id);
    void Add(Color color);
    void Delete(int id);
    void Clear();
    int GetCount();
  }
}
