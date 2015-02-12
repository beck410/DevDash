using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDash.Model {
  public class GithubPanel {
     
    public int GithubId { get; set; }
    public string link { get; set; }
    public int ProjectId { get; set; }

    public GithubPanel(string link, int projectId) {
      this.link = link;
      this.ProjectId = projectId;
    }
  }
}
