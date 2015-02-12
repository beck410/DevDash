using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDash.Model {
  class NotesPanel {

    public int NotesPanelId { get; set; }
    public int ProjectId { get; set; }

    public NotesPanel(int projectId) {
      this.ProjectId = projectId;
    }

  }
}
