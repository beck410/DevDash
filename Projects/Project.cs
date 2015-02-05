using System;
using System.Text;
using System.Threading.Tasks;

namespace Projects {
  public class Project {

    public Project(string name) {
      if (Has_White_Space(name))
        throw new ArgumentException("name contains spaces");
      else
        this.name = name;
    }

    private string name;
    public string Name {
      get { return this.name; }
    }
    private bool Has_White_Space(string name) {
      for (int i = 0; i < name.Length; i++) {
        if (char.IsWhiteSpace(name[i]))
          return true;
      }
      return false;
    }
  }
}
