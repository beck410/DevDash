using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDash {
  public class Dependency {

    public int DependencyId { get; set; }
    public int ProjectId { get; set; }
    public string DependencyDetails { get; set; }

    public Dependency(string dependencyDetails, int projectId) {

      _isEmpty(dependencyDetails);

      this.DependencyDetails = dependencyDetails;
      this.ProjectId = projectId;
    }

    public Dependency() {

    }

    private void _isEmpty(string note) {
      if (string.IsNullOrWhiteSpace(note))
        throw new ArgumentException("no description provided"); 
    }
  }
}
