﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;
using DevDash.Model;
using DevDash.Repositories;
using DevDash;

namespace DevDash {

  public partial class MainWindow : Window {

    public static ProjectsRepository project_repo = new ProjectsRepository();

    public MainWindow() {
      InitializeComponent();
    }

    private void View_Current_Projects(object sender, RoutedEventArgs e) {
      Main_View.Visibility = Visibility.Collapsed;
      List<Project> current_projects = project_repo.AllCurrentProjects();

      Current_Projects_Listbox.DataContext = current_projects; 

      if (current_projects.Count == 0) {
        No_Current_Projects_Message.Visibility = Visibility.Visible;
        Current_Projects_List.Visibility = Visibility.Visible;
        Current_Projects_Listbox.Visibility = Visibility.Collapsed;
      }
      else {
        Current_Projects_List.Visibility = Visibility.Visible;
      }
    }

    private void View_Past_Projects(object sender, RoutedEventArgs e) {

      var past_projects = project_repo.AllPastProjects();
      Past_Projects_Listbox.DataContext = past_projects;

      Main_View.Visibility = Visibility.Collapsed;

      if (past_projects.Count == 0) {
        No_Past_Projects_Message.Visibility = Visibility.Visible;
        Past_Projects_List.Visibility = Visibility.Visible;
        Past_Projects_Listbox.Visibility = Visibility.Collapsed;
      }
      else {
        Past_Projects_List.Visibility = Visibility.Visible;
        No_Past_Projects_Message.Visibility = Visibility.Collapsed;
      }
      
    }

    private void Create_New_Project(object sender, RoutedEventArgs e) {

      New_Project_Error.Visibility = Visibility.Collapsed;
      string project_name = New_Project_Name.Text;
      string start_date = New_Project_Start_Date.SelectedDate.ToString();
      string end_date = New_Project_End_Date.SelectedDate.ToString();
      string github = New_Project_Github.Text;

      if (Has_Spaces(project_name)) {
        New_Project_Error.Visibility = Visibility.Visible;
        New_Project_Error.Text = "Please Put In Valid Project Name - no spaces";
        return;
      }  

      if (project_name == "") {
        New_Project_Error.Visibility = Visibility.Visible;
        New_Project_Error.Text = "Name is Required To Add A Project";
        return;
      }

      project_repo.Add(new Project(project_name, 1, start_date, end_date, github));
      Current_Projects_Listbox.DataContext = project_repo.AllCurrentProjects();
      Main_View.Visibility = Visibility.Collapsed;
      Current_Projects_List.Visibility = Visibility.Visible;
    }

    public void Switch_To_Current_Projects(object sender, RoutedEventArgs e) {
      Past_Projects_List.Visibility = Visibility.Collapsed;
      View_Current_Projects(sender,e);
    }

    public void Switch_To_Past_Projects(object sender, RoutedEventArgs e){
      Current_Projects_List.Visibility = Visibility.Collapsed;
      View_Past_Projects(sender, e);
    }

    public void Delete_Current_Project(object sender, RoutedEventArgs e) {
      Project project = (Project)Current_Projects_Listbox.SelectedItem;

      if (project == null) {
        Delete_Current_Project_Message.Visibility = Visibility.Visible;
        return;
      }

      project_repo.Delete(project.ProjectId);
      Current_Projects_Listbox.DataContext = null;
      Current_Projects_Listbox.DataContext = project_repo.AllCurrentProjects();
    }

    public void Delete_Past_Project(object sender, RoutedEventArgs e) {
      Project project = (Project)Past_Projects_Listbox.SelectedItem;

      if (project == null) {
        Delete_Past_Project_Message.Visibility = Visibility.Visible;
        return;
      }

      project_repo.Delete(project.ProjectId);
      Past_Projects_Listbox.DataContext = null;
      Past_Projects_Listbox.DataContext = project_repo.AllPastProjects();
    }

    public void Move_To_Past_Projects(object sender, RoutedEventArgs e) { 
      Project project = (Project)Current_Projects_Listbox.SelectedItem;

      if (project == null) {
        Delete_Current_Project_Message.Visibility = Visibility.Visible;
        return;
      }

      project_repo.MoveProject(project.ProjectId);
      Current_Projects_Listbox.DataContext = null;
      Current_Projects_Listbox.DataContext = project_repo.AllCurrentProjects();
      Past_Projects_Listbox.DataContext = null;
      Past_Projects_Listbox.DataContext = project_repo.AllPastProjects();
    }

    private bool Has_Spaces(string name) {
     for (int i = 0; i < name.Length; i++) {
       if (char.IsWhiteSpace(name[i]))
         return true;
     }
     return false;
   }
  }
}
