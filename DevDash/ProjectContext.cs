using DevDash.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDash {
  public class ProjectContext : DbContext {
    public DbSet<Project> Projects { get; set; }
    public DbSet<Note> Notes { get; set; }
  }
}
