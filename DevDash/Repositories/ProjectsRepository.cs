using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevDash.Model;
using System.Data.Entity;
using System.Collections.ObjectModel;

namespace DevDash.Repositories {
  public class ProjectsRepository : IProjectRepository{

    //set up for db local
    private ProjectContext _dbContext;
    private ObservableCollection<Project> _current_projects; 
    private ObservableCollection<Project> _past_projects; 

    public DbSet<Project> GetDbSet() {
      return _dbContext.Projects;
    }

    public ProjectsRepository(){
      _dbContext = new ProjectContext();
      _dbContext.Projects.Load();

      _current_projects = new ObservableCollection<Project>(_dbContext.Projects.Where(x => x.ProjectState == 1));
      _past_projects = new ObservableCollection<Project>(_dbContext.Projects.Where(x => x.ProjectState == 0));
    }

    public ProjectContext Context() {
      return _dbContext;
    }

   //Project DB Methods
    public List<Project> All() {
      var query = from Project in _dbContext.Projects
                  select Project;
      return query.ToList<Project>();
    }

    public ObservableCollection<Project> AllPastProjects() {
      return _past_projects;
    }

    public ObservableCollection<Project> AllCurrentProjects() {
      return _current_projects; 
    }
 
    public int GetCount(){
      return _dbContext.Projects.Count<Project>();
    }

    public void Add(Project P) {
      _dbContext.Projects.Add(P);
      _dbContext.SaveChanges();
    }

    public void Delete(int id) {
      var project = _dbContext.Projects.Where(x => x.ProjectId == id);
      _dbContext.Projects.RemoveRange(project);
      _dbContext.SaveChanges();
    }

    public void Clear() {
      var projects = this.All();
      _dbContext.Projects.RemoveRange(projects);
      _dbContext.SaveChanges();
    }

    public Project GetById(int id) {
      return _dbContext.Projects.Find(id);
    }

    public void MoveProject(int id) {
      var query = from project in _dbContext.Projects
                  where project.ProjectId == id
                  select project;

      foreach (Project project in query) {
        project.ProjectState = 0;
      }

      _dbContext.SaveChanges();
    }

    public void Edit(int project_id, string name, string start_date, string end_date, string github, string description) {
      var query = _dbContext.Projects.Where(c => c.ProjectId == project_id);

      foreach (Project project in query) {
        project.ProjectName = name;
        project.ProjectStartDate = start_date;
        project.ProjectEndDate = end_date;
        project.GithubLink = github;
        project.Description = description;
      }
      _dbContext.SaveChanges();
    }
  }
}
