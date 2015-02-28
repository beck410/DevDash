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

    public Color(int projectId, string hex) {
      _isEmpty(hex);

      this.ProjectId = projectId;
      this.Hex = hex;
    }

    public Color(){

    }

    private void _isEmpty(string hex) {
      if (string.IsNullOrWhiteSpace(hex))
        throw new ArgumentException("no hex provided");
    }
  }
}
