using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White.UIItems.WindowItems;
using TestStack.White;
using System.IO;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.Finders;

namespace TestDevDash.UserTests {
  [TestClass]
  public class ZeroStateUserTest : TestHelper {
    
    [ClassInitialize]
    public static void SetUpTests(TestContext _context) {
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
    public void TestZeroStateWithNoProjectsInDB() {
      
    }
    
    [TestMethod]
    public void TestZeroStateWithOnlyCurrentProjectsInDB() {
    }

    [TestMethod]
    public void TestZeroStateWithOnlyPastProjectsInDB() {
    }

    [TestMethod]
    public void TestZeroStateWithCurrentAndPastProjectsInDB() {
    }
  }
}
