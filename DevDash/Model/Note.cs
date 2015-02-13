using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DevDash.Model {
  public class Note {

    public int NoteId { get; set; }
    public int NotesPanelId { get; set; }
    public string NoteDetails { get; set; }

    public Note(string noteDetails, int notePanelId) {

      _isEmpty(noteDetails);

      this.NotesPanelId = notePanelId;
      this.NoteDetails = noteDetails;
    }

    private void _isEmpty(string note) {
    if (string.IsNullOrWhiteSpace(note))
      throw new ArgumentException("no description provided"); 
    }
  }
}
