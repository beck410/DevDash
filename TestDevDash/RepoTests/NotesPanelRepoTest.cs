using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevDash.Repositories;
using DevDash.Model;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;



namespace TestDevDash.RepoTests {
  [TestClass]
  public class NotesPanelRepoTest {
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
