using DevDash.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDash.Repositories {
  public class ColorRepository : IColorRepository {

    private ProjectContext _dbContext;

    public DbSet<Color> GetDbSet() {
      return _dbContext.Colors;
    }

    public ColorRepository() {
      _dbContext = new ProjectContext();

    }

    public List<Model.Color> GetAllByProjectId(int project_id) {
      var query =  _dbContext.Colors.Where(c => c.ProjectId == project_id);
      return new List<Color>(query); 
    }

    public Model.Color GetById(int color_id) {
      return _dbContext.Colors.Find(color_id);
    }

    public void Add(Model.Color color) {
      _dbContext.Colors.Add(color);
      _dbContext.SaveChanges();
    }

    public void Delete(int id) {
      var color = _dbContext.Colors.Where(x => x.ColorId == id);
      _dbContext.Colors.RemoveRange(color);
      _dbContext.SaveChanges();
    }

    public void Clear() {
    var query = from n in _dbContext.Colors
                  select n;
      List<Color> colors = query.ToList<Color>();
      _dbContext.Colors.RemoveRange(colors);
      _dbContext.SaveChanges();
    }

    public int GetCount() {
      return _dbContext.Colors.Count<Color>(); 
    }
  }
}
