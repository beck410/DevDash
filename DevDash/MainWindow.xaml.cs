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
      //project_repo.Add(new Project("angular",1,"03/17/2014"));
      //project_repo.Add(new Project("js",1,"03/17/2014"));
      //project_repo.Add(new Project("penny",0,"03/17/2014"));

      //List<Project> current_projects = new List<Project>();
      //current_projects.Add(new Project("angular",1,"02/03/2014"));
      //current_projects.Add(new Project("js",1,"02/03/2014"));
      //current_projects.Add(new Project("csharp",1,"02/03/2014"));

    }

    private void View_Past_Projects(object sender, RoutedEventArgs e) {

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

    private void Button_Click(object sender, RoutedEventArgs e) {

    }


  }
}
