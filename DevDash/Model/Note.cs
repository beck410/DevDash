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
    public int ProjectId { get; set; }
    public string NoteDetails { get; set; }

    public Note() { }

    public Note(string noteDetails, int projectId) {

      _isEmpty(noteDetails);

      this.ProjectId = projectId;
      this.NoteDetails = noteDetails;
    }

    private void _isEmpty(string note) {
    if (string.IsNullOrWhiteSpace(note))
      throw new ArgumentException("no description provided"); 
    }
  }
}
