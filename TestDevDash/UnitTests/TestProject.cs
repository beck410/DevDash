using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevDash.Model;

namespace TestDevDash.UnitTests {
  [TestClass]
  public class ProjectTests {
    [TestMethod]
    public void TestProjectConstructorWithAllValidParams() {
      Project project = new Project("simpleShapes",1,"02/02/2015","03/02/2015","http://github.com/beck410/simpleShapes");
      Assert.AreEqual("simpleShapes", project.ProjectName);
      Assert.AreEqual(1, project.ProjectState);
      Assert.AreEqual("02/02/2015", project.ProjectStartDate);
      Assert.AreEqual("03/02/2015", project.ProjectEndDate);
      Assert.AreEqual("http://github.com/beck410/simpleShapes", project.GithubLink);
    } 

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestProjectConstructorWithNameSpaces() {
      Project project = new Project("simple shapes",0,"05/05/2013","05/20/2013","http://github.com/simple_shapes");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestProjectConstructorWithEmptyName() {
      Project project = new Project("",0,"03/05/2012","05/20/2013","http://github.com/simple_shapes");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestProjectConstructorWithWhiteSpaceForName() {
       Project project = new Project("  ",0,"03/05/2012","05/20/2013","http://github.com/simple_shapes");
    }
  }
}
