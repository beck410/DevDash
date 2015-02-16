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

      var current_projects = project_repo.AllCurrentProjects();
      Main_View.Visibility = Visibility.Collapsed;
      Current_Projects_Listbox.DataContext = current_projects;

      if (current_projects.Count == 0) {
        Current_Projects_List.Visibility = Visibility.Visible;
        Current_Projects_Listbox.Visibility = Visibility.Collapsed;
      }
      else {
        Current_Projects_List.Visibility = Visibility.Visible;
        No_Current_Projects_Message.Visibility = Visibility.Collapsed;
      }
    }

    private void View_Past_Projects(object sender, RoutedEventArgs e) {

      var past_projects = project_repo.AllPastProjects();
      Past_Projects_Listbox.DataContext = past_projects;

      Main_View.Visibility = Visibility.Collapsed;

      if (past_projects.Count == 0) {
        Past_Projects_List.Visibility = Visibility.Visible;
        Past_Projects_Listbox.Visibility = Visibility.Collapsed;
      }
      else {
        Past_Projects_List.Visibility = Visibility.Visible;
        No_Past_Projects_Message.Visibility = Visibility.Collapsed;
      }
      
    }

    private void Button_Click(object sender, RoutedEventArgs e) {

    }


  }
}
