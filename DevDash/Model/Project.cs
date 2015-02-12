using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DevDash {
  public class Project {

    public int ProjectId { get; set; }
    public string ProjectName { get; set; }
    public int ProjectState { get; set; }
    public DateTime ProjectStartDate { get; set; }
    public DateTime ProjectEndDate { get; set; }

    public Project( string name, int state, DateTime start, DateTime end) {
      if (Has_White_Space(name))
        throw new ArgumentException("name contains spaces");
      else
        this.ProjectName = name;
      
      this.ProjectState = state;
      this.ProjectStartDate = start;
      this.ProjectEndDate = end;
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