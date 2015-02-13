using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevDash.Repositories;

namespace TestDevDash.RepoTests {
  [TestClass]
  public class NoteRepoTests {
    
    private static NotesPanelRepository repo;

    [ClassInitialize]
    public static void SetUp(TestContext _context){
      repo = new NotesPanelRepository();
      repo.Clear();
    }

    [ClassCleanup]
    public static void CleanUp() {
      repo.Clear();
    }

    [TestCleanup]
    public void ClearDB() {
      repo.Clear();
    }

    [TestMethod]
    public void TestMethod1() {
    }
  }
}
