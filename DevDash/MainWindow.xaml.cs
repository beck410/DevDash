﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using DevDash.Model;
using DevDash.Repositories;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace DevDash {

  public partial class MainWindow : Window {

    public static ProjectsRepository project_repo = new ProjectsRepository();

    private Project _project_to_display;
    public Project project_to_display {
      get {
        return _project_to_display;
      }
      set {
        _project_to_display = value;
      //  OnPropertyChanged("project_to_display");
      }
    }

    private ObservableCollection<Project> _current_projects = project_repo.AllCurrentProjects();
    //public ObservableCollection<Project> current_projects {
    //  get {
    //    return _current_projects;
    //  }

    //  set {
    //    _current_projects = value;
    //    OnPropertyChanged("current_projects");  
    //  }
    //}

    //add field for notes

    public MainWindow() {
      InitializeComponent();
      //current_projects = project_repo.AllCurrentProjects();
      Current_Projects_Listbox.DataContext = _current_projects; 
      Past_Projects_Listbox.DataContext = project_repo.AllPastProjects();
    }

    private void View_Current_Projects(object sender, RoutedEventArgs e) {
      //_DatabindProjects(Current_Projects_Listbox, "current");
      _show_view(Main_View, false);

      if (project_repo.AllCurrentProjects().Count == 0) {
        _show_view(Current_Projects_List, true);
        _show_list(Current_Projects_Listbox, false);
        _show_error(No_Current_Projects_Message, true);
      }
      else {
        _show_view(Current_Projects_List, true);
        _show_list(Current_Projects_Listbox, true);
      }
    }

    private void View_Past_Projects(object sender, RoutedEventArgs e) {
      //_DatabindProjects(Past_Projects_Listbox, "past");
      _show_view(Main_View, false);

      if (project_repo.AllPastProjects().Count == 0) {
        _show_view(Past_Projects_List, true);
        _show_list(Past_Projects_Listbox, false);
        _show_error(No_Past_Projects_Message,true);
      }
      else {
        _show_view(Past_Projects_List, true);
        _show_list(Past_Projects_Listbox, true);
      }

    }

    private void Create_New_Project(object sender, RoutedEventArgs e) {
      _show_error(New_Project_Error, false);
      string project_name = New_Project_Name.Text;
      string start_date = New_Project_Start_Date.SelectedDate.ToString();
      string end_date = New_Project_End_Date.SelectedDate.ToString();
      string github = New_Project_Github.Text;  

      if(_Valid_Name(project_name) == false){
        _show_error(New_Project_Error, true);
        return;
      }

      project_repo.Add(new Project(project_name, 1, start_date, end_date, github));
      _show_view(Main_View, false);
      _show_view(Current_Projects_List, true);
      //_DatabindProjects(Current_Projects_Listbox, "current"); 
    }

    public void Switch_To_Current_Projects(object sender, RoutedEventArgs e) {
      //_DatabindProjects(Current_Projects_Listbox, "current");
      _show_view(Past_Projects_List, false);
      View_Current_Projects(sender, e);
    }

    public void Switch_To_Past_Projects(object sender, RoutedEventArgs e) {
      //_DatabindProjects(Past_Projects_Listbox, "past");
      _show_view(Current_Projects_List, false);
      View_Past_Projects(sender, e);
    }

    public void Delete_Current_Project(object sender, RoutedEventArgs e) {
      Project project = (Project)Current_Projects_Listbox.SelectedItem;

      if (project == null) {
        _show_error(Delete_Current_Project_Message, true);
        return;
      }

      project_repo.Delete(project.ProjectId);
      //_DatabindProjects(Current_Projects_Listbox, "current");
    }

    public void Delete_Past_Project(object sender, RoutedEventArgs e) {
      Project project = (Project)Past_Projects_Listbox.SelectedItem;

      if (project == null) {
        _show_error(Delete_Past_Project_Message, true);
        return;
      }

      project_repo.Delete(project.ProjectId);
      //_DatabindProjects(Past_Projects_Listbox, "past");
    }

    public void Move_To_Past_Projects(object sender, RoutedEventArgs e) {
      Project project = (Project)Current_Projects_Listbox.SelectedItem;

      if (project == null) {
        _show_error(Delete_Current_Project_Message, true);
        return;
      }

      project_repo.MoveProject(project.ProjectId);

      //_DatabindProjects(Current_Projects_Listbox, "current");
      //_DatabindProjects(Past_Projects_Listbox, "past");
    }

    public void New_Project_Modal(object sender, RoutedEventArgs e) {
      var new_project_modal = new AddProjectModal();
      new_project_modal.ShowDialog();

      if (new_project_modal.DialogResult == true) {
        //_DatabindProjects(Current_Projects_Listbox, "current");
        _show_error(No_Current_Projects_Message, false);
        _show_list(Current_Projects_Listbox,true);
      }
    }

    public void View_Current_Project(object sender, RoutedEventArgs e) {
      Project selected_project = (Project)Current_Projects_Listbox.SelectedItem;
      this.project_to_display = selected_project;
      Single_Project_Container.DataContext = this;

      _show_view(Current_Projects_List,false);
      _show_view(Single_Project_Container,true);

      if (Notes_Listbox.Items.Count == 0) {
        _show_list(Notes_Listbox, false);
      }
    }

    public void Delete_Note(object sender, RoutedEventArgs e) {

    }

    public void Edit_Note(object sender, RoutedEventArgs e) {

    }

    private void _DatabindProjects(ListBox element, string type) {
      element.DataContext = null;

      if (type == "current")
        element.DataContext = project_repo.AllCurrentProjects();

      if (type == "past")
        element.DataContext = project_repo.AllPastProjects();
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

    private void _show_view(StackPanel panel, bool visible) {
      if (visible == false)
        panel.Visibility = Visibility.Collapsed;
      else
        panel.Visibility = Visibility.Visible;
    }

    private void _show_error(TextBlock error, bool visible) {
      if (visible == false)
        error.Visibility = Visibility.Collapsed;
      else
        error.Visibility = Visibility.Visible;
    }

    private void _show_list(ListBox list, bool visible) {
      if (visible == false)
        list.Visibility = Visibility.Collapsed;
      else
        list.Visibility = Visibility.Visible;
    }

    //public event PropertyChangedEventHandler PropertyChanged;
    //private void OnPropertyChanged(string info) {
    //  if (PropertyChanged != null) {
    //    PropertyChanged(this, new PropertyChangedEventArgs(info));
    //  }
    //}
  }
}
