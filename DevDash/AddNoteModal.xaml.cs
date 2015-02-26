using DevDash.Model;
using DevDash.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DevDash {
  /// <summary>
  /// Interaction logic for AddNoteModal.xaml
  /// </summary>
  public partial class AddNoteModal : Window {
    public int projectId;
    public NoteRepository note_repo = new NoteRepository();

    public AddNoteModal() {
      InitializeComponent();
    }

    private void Add_New_Note(object sender, RoutedEventArgs e) {
      string note = Modal_Note.Text;

      note_repo.Add(new Note(note, projectId));
      DialogResult = true;
      return;
    }

    private void Close_btn(object sender, RoutedEventArgs e) {
      DialogResult = false;
      this.Close();
    }
  }
}
