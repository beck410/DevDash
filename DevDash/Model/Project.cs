using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DevDash.Model {
  public class Project {

    public int ProjectId { get; set; }
    public string ProjectName { get; set; } //required
    public int ProjectState { get; set; } //required
    public string ProjectStartDate { get; set; } //required
    public string ProjectEndDate { get; set; }
    public string GithubLink { get; set; }

    public Project(params object[] details) {
      //required params order: name,state, startdate,enddate, link
      int paramCount = details.Count();
      
      switch (paramCount) {
        case 0:
        case 1:
        case 2:
         throw new ArgumentException("All Required details not included");
        case 3:
          _AddRequiredDetails(details[0], details[1], details[2]);
         break;
        case 4:
          _AddRequiredDetails(details[0], details[1], details[2]);
          _AddLinkOrEndDate(details[3]);
          break;
        case 5:
          _AddRequiredDetails(details[0], details[1], details[2]);
          this.ProjectEndDate = details[3].ToString();
          this.GithubLink = details[4].ToString();
          break;
        default:
          throw new ArgumentException("No name,start date or state given for new project");
      }
    }

    private void _AddLinkOrEndDate( object param) {
      if(param.GetType() == "string".GetType())
        this.GithubLink = param.ToString();
      else
        this.ProjectEndDate = param.ToString();
    }

   private void _AddRequiredDetails(object name, object state, object startDate){
    if (Has_White_Space(name.ToString()))
      throw new ArgumentException("name contains spaces");
    else
      this.ProjectName = name.ToString();

    this.ProjectState = (int)state;
    this.ProjectStartDate = startDate.ToString();
  }

    private bool Has_White_Space(string name) {
      for (int i = 0; i < name.Length; i++) {
        if (char.IsWhiteSpace(name[i]))
          return true;
      }
      return false;
    }
  }
}