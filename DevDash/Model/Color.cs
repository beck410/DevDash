using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevDash.Model {
  public class Color {

    public int ColorId { get; set; }
    public int ProjectId { get; set; }
    public string Hex { get; set; }
    public string Name { get; set; }

    public Color(int projectId, string hex, string name) {
      _isEmpty(hex);
      _isEmpty(name);

      this.ProjectId = projectId;
      this.Hex = hex;
      this.Name = name;
    }

    public Color(){

    }

    private void _isEmpty(string hex) {
      if (string.IsNullOrWhiteSpace(hex))
        throw new ArgumentException("no hex provided");
    }
  }
}
