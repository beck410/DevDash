using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevDash.Model;

namespace TestDevDash.UnitTests {
  [TestClass]
  public class TestProjectDescriptionPanel {
    [TestMethod]
    public void TestProjectDescriptionConstructorPanelWithValidParams() {
      DescriptionPanel panel = new DescriptionPanel("this project is an angular app", 2);
      Assert.AreEqual("this project is an angular app", panel.Description);
      Assert.AreEqual(2, panel.ProjectId);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestProjectDescriptionConstructorWithEmptyDescription() { 
      DescriptionPanel panel = new DescriptionPanel("",1);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestProjectDescriptionConstructorWithDoulbeEmptyDescription() { 
      DescriptionPanel panel = new DescriptionPanel(" ",1);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestProjectDescriptionConstructorWhiteSpaceForDescription() {
      DescriptionPanel panel = new DescriptionPanel("     ",1);
    }
  }
}
