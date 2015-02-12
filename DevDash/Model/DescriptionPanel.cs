using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDash.Model {
  class DescriptionPanel {

    public int DescriptionId { get; set; }
    public int ProjectId { get; set; }
    public string Description { get; set; }


    public DescriptionPanel(string description, int projectId) {
      this.ProjectId = projectId;
      this.Description = description;
    }
  }
}
