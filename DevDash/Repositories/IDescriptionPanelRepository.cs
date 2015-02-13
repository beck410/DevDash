using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevDash.Model;

namespace DevDash.Repositories {
  interface IDescriptionPanelRepository {

    DescriptionPanel GetPanelDescription(int project_id);
    DescriptionPanel GetById(int id);
    void Add(DescriptionPanel description);
    void Delete(int id);
    void Clear();
  }
}
