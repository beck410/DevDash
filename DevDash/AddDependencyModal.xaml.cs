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
  /// Interaction logic for AddDependencyModal.xaml
  /// </summary>
  public partial class AddDependencyModal : Window {
    public int projectid;
    public DependencyRepository repo = new DependencyRepository();

    public AddDependencyModal() {
      InitializeComponent();
    }

    private void Add_New_Dependency(object sender, RoutedEventArgs e) {
      string dependency = Modal_Dependency.Text;

      repo.Add(new Dependency(dependency, projectid));
      DialogResult = true;
      return;
    }

    private void Close_btn(object sender, RoutedEventArgs e) {
      DialogResult = false;
      this.Close();
    }
  }
}
