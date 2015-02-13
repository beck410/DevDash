using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DevDash.Model {
  public class NotesPanel {

    public int NotesPanelId { get; set; }
    public int ProjectId { get; set; }

    public NotesPanel(int projectId) {
      this.ProjectId = projectId;
    }

  }
}
