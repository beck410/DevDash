using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projects;

namespace UnitTest {
  [TestClass]
  public class ProjectTests {
    [TestMethod]
    public void TestProjectConstructor() {
      Project project = new Project("simpleShapes");
      Assert.AreEqual("simpleShapes",project.Name);
    }
    
    [TestMethod]
    [ExpectedException (typeof(ArgumentException))]
    public void TestProjectConstructorWithSpaces() {
      Project project = new Project("simple shapes");
    }
  }
}

