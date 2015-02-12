using System;
using System.Text;
using System.Threading.Tasks;

namespace Projects {
  public class Project {

    public int ProjectId { get; set; }
    public string ProjectName { get; set; }
    public int ProjectState { get; set; }

    public Project( string name, int state) {
      if (Has_White_Space(name))
        throw new ArgumentException("name contains spaces");
      else
        this.ProjectName = name;
      
      this.ProjectState = state;
    }

    public Project(string name) {

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