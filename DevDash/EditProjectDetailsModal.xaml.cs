using DevDash.Model;
using DevDash.Repositories;
using System;
using System.Globalization;
using System.Windows;

namespace DevDash {
  /// <summary>
  /// Interaction logic for EditProjectDetails.xaml
  /// </summary>
  public partial class EditProjectDetailsModal : Window {

    public static ProjectsRepository project_repo = new ProjectsRepository();

    private Project _current_project;
    public void populateModal(Project project) {
      _current_project = project;
      _add_existing_project_details();
    }
    
    public EditProjectDetailsModal() {
      
      InitializeComponent();
    }
    
    private void Edit_New_Project(object sender, RoutedEventArgs e) {

      Modal_Edit_Project_Error.Visibility = Visibility.Collapsed;
     
      string project_name = Modal_Edit_Project_Name.Text;
      string start_date = Modal_Edit_Project_Start_Date.SelectedDate.ToString();
      string end_date = Modal_Edit_Project_End_Date.SelectedDate.ToString();
      string github = Modal_Edit_Project_Github.Text;
      string description = Modal_Edit_Project_Description.Text;

      

     if (_Valid_Name(project_name) == true) {
       project_repo.Edit(_current_project.ProjectId,project_name,start_date,end_date,github,description);
       DialogResult = true;
       this.Close();
     }
     else {
       Modal_Edit_Project_Error.Visibility = Visibility.Visible;
     }
    }

    private void Close_btn(object sender, RoutedEventArgs e) {
      DialogResult = false;
      this.Close();
    }

    private void _add_existing_project_details() {

      if (string.IsNullOrEmpty(_current_project.ProjectStartDate) == false) {
        Modal_Edit_Project_Start_Date.SelectedDate = Convert.ToDateTime(_current_project.ProjectStartDate, CultureInfo.InvariantCulture);
      }

      if (string.IsNullOrEmpty(_current_project.ProjectEndDate) == false) {
        Modal_Edit_Project_End_Date.SelectedDate = Convert.ToDateTime(_current_project.ProjectEndDate, CultureInfo.InvariantCulture);
      }

      Modal_Edit_Project_Description.Text = _current_project.Description;
      Modal_Edit_Project_Name.Text = _current_project.ProjectName;
      Modal_Edit_Project_Github.Text = _current_project.GithubLink;
    }

    private bool _Valid_Name(string name) {
      bool valid = true;
      for (int i = 0; i < name.Length; i++) {
        if (char.IsWhiteSpace(name[i]))
          valid = false;
      }

      if (name == "")
        valid = false;

      return valid;
   }
  }
}
