using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DevDash.Model {
  public class DescriptionPanel {

    public int DescriptionId { get; set; }
    public int ProjectId { get; set; }
    public string Description { get; set; }


    public DescriptionPanel(string description, int projectId) {
      _IsEmptyDescription(description);

      this.ProjectId = projectId;
      this.Description = description;
    }

    private void _IsEmptyDescription(string description){
      if (string.IsNullOrWhiteSpace(description))
        throw new ArgumentException("no description provided");
    }
  }
}
