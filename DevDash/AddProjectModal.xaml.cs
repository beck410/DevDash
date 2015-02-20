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
  /// Interaction logic for AddProjectModal.xaml
  /// </summary>
  /// 
  public partial class AddProjectModal : Window {

public static ProjectsRepository project_repo = new ProjectsRepository();

    public AddProjectModal() {
      InitializeComponent();
    }

    public void Add_New_Project(object sender, RoutedEventArgs e) {
      Modal_New_Project_Error.Visibility = Visibility.Collapsed;
      string project_name = Modal_New_Project_Name.Text;
      string start_date = Modal_New_Project_Start_Date.SelectedDate.ToString();
      string end_date = Modal_New_Project_End_Date.SelectedDate.ToString();
      string github = Modal_New_Project_Github.Text;

      if (_Has_Spaces(project_name)) {
        Modal_New_Project_Error.Visibility = Visibility.Visible;
        Modal_New_Project_Error.Text = "Please Put In Valid Project Name - no spaces";
        return;
      }  

      if (project_name == "") {
        Modal_New_Project_Error.Visibility = Visibility.Visible;
        Modal_New_Project_Error.Text = "Name is Required To Add A Project";
        return;
      }

      project_repo.Add(new Project(project_name, 1, start_date, end_date, github));

      DialogResult = true;
    }

    private void Close_btn(object sender, RoutedEventArgs e) {
      DialogResult = false;
      this.Close();
    }

    public bool _Has_Spaces(string name) {
      for (int i = 0; i < name.Length; i++) {
       if (char.IsWhiteSpace(name[i]))
         return true;
      }
      return false;
   }
  }
}
