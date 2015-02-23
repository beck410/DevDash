using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DevDash.Model {
  public class Project : INotifyPropertyChanged {

    public int ProjectId { get; set; }
    public string ProjectName { get; set; } //required
    public int ProjectState { get; set; } //required
    public string ProjectStartDate { get; set; } //required
    public string ProjectEndDate { get; set; }
    public string GithubLink { get; set; }
    public string Description { get; set; }
    public event PropertyChangedEventHandler PropertyChanged;
    public Project() {

    }

    public Project(string name, int project_type, string start_date, string end_date, string link) {
      //required params order: name,state, startdate,enddate, link
      
     if (Has_Spaces(name) || String.IsNullOrWhiteSpace(name))
       throw new ArgumentException("name contains spaces");
     else
       this.ProjectName = name;

     this.ProjectState = project_type;
     this.ProjectStartDate = start_date;
     this.ProjectEndDate = end_date;
     this.GithubLink = link;
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