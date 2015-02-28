﻿using System.Windows;
using System.Windows.Controls;
using DevDash.Model;
using DevDash.Repositories;
using System.ComponentModel;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace DevDash {

  public partial class MainWindow : Window, INotifyPropertyChanged {

    public static ProjectsRepository project_repo = new ProjectsRepository();
    public static NoteRepository note_repo = new NoteRepository();
    public static DependencyRepository dependency_repo = new DependencyRepository();

    private Project _project_to_display;
    public Project project_to_display {
      get {
        return _project_to_display;
      }
      set {
        _project_to_display = value;
        OnPropertyChanged("project_to_display");
      }
    }

    private ObservableCollection<Note> _notes;
    public ObservableCollection<Note> Notes {
      get {
        return _notes;
      }
      set {
        _notes = value;
      }
    }

    public MainWindow() {
      InitializeComponent();
      Current_Projects_Listbox.DataContext = project_repo.AllCurrentProjects();
      Past_Projects_Listbox.DataContext = project_repo.AllPastProjects();
    }

    private void View_Current_Projects(object sender, RoutedEventArgs e) {
      _DatabindProjects(Current_Projects_Listbox, "current");
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
      Current_Projects_Listbox.Items.Refresh();
    }

    private void View_Past_Projects(object sender, RoutedEventArgs e) {
      _DatabindProjects(Past_Projects_Listbox, "past");
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
      _DatabindProjects(Current_Projects_Listbox, "current"); 
    }

    public void Switch_To_Current_Projects(object sender, RoutedEventArgs e) {
      _DatabindProjects(Current_Projects_Listbox, "current");
      _show_view(Past_Projects_List, false);
      View_Current_Projects(sender, e);
    }

    public void Switch_To_Past_Projects(object sender, RoutedEventArgs e) {
      _DatabindProjects(Past_Projects_Listbox, "past");
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
      Current_Projects_Listbox.Items.Refresh();
      _DatabindProjects(Current_Projects_Listbox, "current");
    }
    
    public void Delete_Past_Project(object sender, RoutedEventArgs e) {
      Project project = (Project)Past_Projects_Listbox.SelectedItem;

      if (project == null) {
        _show_error(Delete_Past_Project_Message, true);
        return;
      }

      project_repo.Delete(project.ProjectId);
      _DatabindProjects(Past_Projects_Listbox, "past");
    }

    public void Move_To_Past_Projects(object sender, RoutedEventArgs e) {
      Project project = (Project)Current_Projects_Listbox.SelectedItem;

      if (project == null) {
        _show_error(Delete_Current_Project_Message, true);
        return;
      }

      project_repo.MoveProject(project.ProjectId);

      _DatabindProjects(Current_Projects_Listbox, "current");
      _DatabindProjects(Past_Projects_Listbox, "past");
    }

    public void New_Project_Modal(object sender, RoutedEventArgs e) {
      var new_project_modal = new AddProjectModal();
      new_project_modal.ShowDialog();

      if (new_project_modal.DialogResult == true) {
        _DatabindProjects(Current_Projects_Listbox, "current");
        _show_error(No_Current_Projects_Message, false);
        _show_list(Current_Projects_Listbox,true);
      }
    }

    public void View_Past_Project(object sender, RoutedEventArgs e) {
      Project selected_project = (Project)Past_Projects_Listbox.SelectedItem;
      this.project_to_display = selected_project;
      Single_Project_Container.DataContext = this;

      int project_to_display_id = this.project_to_display.ProjectId;

      Notes = note_repo.GetAllByProjectId(project_to_display_id);
      Notes_Listbox.DataContext = Notes;

      Dependency_Listbox.DataContext = dependency_repo.GetAllByProjectId(project_to_display_id);

      _show_view(Past_Projects_List, false);
      _show_view(Single_Project_Container, true);

      if (Notes_Listbox.Items.Count == 0) {
        _show_list(Notes_Listbox, false);
      }

      if (Dependency_Listbox.Items.Count == 0) {
        _show_list(Dependency_Listbox, false);
      }
    }

    public void View_Current_Project(object sender, RoutedEventArgs e) {
      Project selected_project = (Project)Current_Projects_Listbox.SelectedItem;
      this.project_to_display = selected_project;
      Single_Project_Container.DataContext = this;

      int project_to_display_id = this.project_to_display.ProjectId;

      Dependency_Listbox.DataContext = dependency_repo.GetAllByProjectId(project_to_display_id);
      Notes = note_repo.GetAllByProjectId(project_to_display_id);

      Notes_Listbox.DataContext = Notes;
      _show_view(Current_Projects_List, false);
      _show_view(Single_Project_Container, true);

      if (Notes_Listbox.Items.Count == 0) {
        _show_list(Notes_Listbox, false);
      }

      if (Dependency_Listbox.Items.Count == 0) {
        _show_list(Dependency_Listbox, false);
      }
    }

    public void Edit_Project_Details(object sender, RoutedEventArgs  e) {
      var edit_project_modal = new EditProjectDetailsModal();
      edit_project_modal.populateModal(_project_to_display);
      edit_project_modal.ShowDialog();

      if (edit_project_modal.DialogResult == true){

        DateTime? start_date = edit_project_modal.Modal_Edit_Project_Start_Date.SelectedDate;
        DateTime? end_date = edit_project_modal.Modal_Edit_Project_End_Date.SelectedDate;

        Single_Project_Name.Text = edit_project_modal.Modal_Edit_Project_Name.Text;
        Github.Text = "Github Link: " + edit_project_modal.Modal_Edit_Project_Github.Text;
        Description.Text = "Description: " + edit_project_modal.Modal_Edit_Project_Description.Text;
        _add_formatted_date(start_date, Start_Date, "Start Date: ");
        _add_formatted_date(end_date, End_Date, "End Date: ");


        project_to_display.ProjectName = edit_project_modal.Modal_Edit_Project_Name.Text;
        project_to_display.GithubLink = edit_project_modal.Modal_Edit_Project_Github.Text;
        project_to_display.ProjectStartDate = edit_project_modal.Modal_Edit_Project_Start_Date.SelectedDate.ToString();
        project_to_display.ProjectEndDate = edit_project_modal.Modal_Edit_Project_End_Date.SelectedDate.ToString();
        project_to_display.Description = edit_project_modal.Modal_Edit_Project_Description.Text;
      }
    }

    public void Add_Note(object sender, RoutedEventArgs e) {
      AddNoteModal new_note = new AddNoteModal();
      new_note.projectId = _project_to_display.ProjectId;
      new_note.ShowDialog();

      if (new_note.DialogResult == true) {
        _show_list(Notes_Listbox, true);
        _DataBindNotes(Notes_Listbox);
      }
    }
    
    public void Delete_Note(object sender, RoutedEventArgs e) {
      Note note = (Note)Notes_Listbox.SelectedItem;
      _show_error(Delete_Note_Error_Message, false);

      if (note == null) {
        _show_error(Delete_Note_Error_Message, true);
        return;
      }
      note_repo.Delete(note.NoteId);
      _DataBindNotes(Notes_Listbox);
    }

    public void Show_Edit_Note_Textbox(object sender, RoutedEventArgs e) {
      Note note_item = (Note)Notes_Listbox.SelectedItem;
      Edit_Note_Container.Visibility = Visibility.Visible;

      Edit_Note_textbox.Text = note_item.NoteDetails;
    }

    public void Edit_Note(object sender, RoutedEventArgs e) {
      Edit_Note_Container.Visibility = Visibility.Collapsed;
      Note note_item = (Note)Notes_Listbox.SelectedItem;
      note_repo.Edit(note_item.NoteId, Edit_Note_textbox.Text);
      _DataBindNotes(Notes_Listbox);
    }

    public void Back_To_Projects(object sender, RoutedEventArgs e) {
      _show_view(Main_View, true);
      _show_view(Single_Project_Container, false);
    }

    public void Open_Dependency_Modal(object sender, RoutedEventArgs e) {
      AddDependencyModal modal = new AddDependencyModal();
      modal.projectid = _project_to_display.ProjectId;
      modal.ShowDialog();

      if (modal.DialogResult == true) {
        _DataBindDependencies(Dependency_Listbox);
        _show_list(Dependency_Listbox, true);
      }
    }

    public void Edit_Dependency(object sender, RoutedEventArgs e) {

    }

    public void Show_Edit_Dependency_Textbox(object sender, RoutedEventArgs e) {

    }

    private void _DataBindDependencies(ListBox element) {
      element.DataContext = dependency_repo.GetAllByProjectId(_project_to_display.ProjectId);
    }

    private void _DataBindNotes(ListBox element) {
      element.DataContext = note_repo.GetAllByProjectId(_project_to_display.ProjectId);
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

    public event PropertyChangedEventHandler PropertyChanged;
    private void OnPropertyChanged(string info) {
      if (PropertyChanged != null) {
        PropertyChanged(this, new PropertyChangedEventArgs(info));
      }
    }

    private void _add_formatted_date(DateTime? date, TextBlock element, string date_text) {
      if (date == null)
        element.Text = date_text;
      else
        element.Text = date_text + date.Value.ToString("MM/dd/yyyy");
    }
  }
}
