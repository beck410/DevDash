using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDash {
  class Project {
    public Project(string name) {
      this.name = name;
    }

    private string name;
    public string Name {
      get { return this.name; }
    } 

  }
}
