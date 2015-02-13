using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DevDash.Model {
  class Note {

    public int NoteId { get; set; }
    public int NotesPanelId { get; set; }
    public string NoteDetails { get; set; }

    public Note(int notePanelId, string noteDetails) {
      this.NotesPanelId = notePanelId;
      this.NoteDetails = noteDetails;
    }
  }
}
