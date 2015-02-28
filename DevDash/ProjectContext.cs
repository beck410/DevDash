using DevDash.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace DevDash {
  public class ProjectContext : DbContext {
    public DbSet<Project> Projects { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<Dependency> Dependencies { get; set; }
    public DbSet<Color> Colors { get; set; }
  }
}
