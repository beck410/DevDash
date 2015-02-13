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
    public void TestProjectConstructorWithOnyRequiredParams() {
      Project project = new Project("simpleShapes",0,"02/05/2014");
      Assert.AreEqual("simpleShapes", project.ProjectName);
      Assert.AreEqual(0, project.ProjectState);
      Assert.AreEqual("02/05/2014", project.ProjectStartDate);
      Assert.IsNull(project.ProjectEndDate);
      Assert.IsNull(project.GithubLink);
    }

    [TestMethod]
    public void TestProjectConstructorWithRequiredParamsAndLink() {
      Project project = new Project("simpleShapes",1,"02/06/2015","http://github.com/beck410/simpleShapes");
      Assert.AreEqual("simpleShapes", project.ProjectName);
      Assert.AreEqual(1, project.ProjectState);
      Assert.AreEqual("http://github.com/beck410/simpleShapes", project.GithubLink);
      Assert.AreEqual("02/06/2015", project.ProjectStartDate);
      Assert.IsNull(project.ProjectEndDate);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestProjectConstructorWithNameSpaces() {
      Project project = new Project("simple shapes",0,"05/05/2013");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestProjectConstructorWithNoParams() {
      Project project = new Project();
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestProjectConstructorWithEmptyName() {
      Project project = new Project("",0,"03/05/2012");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestProjectConstructorWithWhiteSpaceForName() {
       Project project = new Project("  ",0,"03/05/2012");
    }


  }
}
