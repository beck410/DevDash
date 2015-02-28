using DevDash.Model;
using DevDash.Repositories;
using System.Windows;

namespace DevDash {
  /// <summary>
  /// Interaction logic for AddColorModal.xaml
  /// </summary>
  public partial class AddColorModal : Window {
    public int projectId;
    public ColorRepository repo = new ColorRepository();
 
    public AddColorModal() {
      InitializeComponent();
    }

    private void Add_Color(object sender, RoutedEventArgs e) {
      string name = Modal_Color_Name.Text;
      string color = Modal_Color_Hex.Text;

      repo.Add(new Color(projectId,color,name));
      DialogResult = true;
      return;
    }

    private void Close_Btn(object sender, RoutedEventArgs e) {
      DialogResult = false;
      this.Close();
    }
  }
}
