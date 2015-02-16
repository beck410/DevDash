using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDevDash.UserTests {
  [TestClass]
  public class AddNewProjectFromMainWindow : TestHelper {

    [ClassInitialize]
    public static void Setup(TestContext _context) {
      TestHelper.SetUpClass(_context);
    }

    [TestInitialize]
    public void SetUpTests() {
      TestHelper.TestPrep();
    }

    [TestCleanup]
    public void CleanUp() {
      TestHelper.CleanThisUp();
    }

    [TestMethod]
    public void AddFirstProjectToDB() {
      throw new NotImplementedException();
    }

    [TestMethod]
    public void AddProjectToDBWithExistingProjects() { 
      throw new NotImplementedException();
    }

    [TestMethod]
    public void AddProjectWithValidData() { 
      throw new NotImplementedException();
    }

    [TestMethod]
    public void AddProjectWithNoName() { 
      throw new NotImplementedException();
    }

    [TestMethod]
    public void AddProjectWithInvalidArguments() { 
      throw new NotImplementedException();
    }
  }
}
