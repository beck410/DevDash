using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevDash.Repositories;
using DevDash.Model;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;

namespace TestDevDash.RepoTests {
  [TestClass]
  public class DescriptionPanelRepoTests {
   
    private static DescriptionPanelRepository repo;

    [ClassInitialize]
    public static void SetUp(TestContext _context){
      repo = new DescriptionPanelRepository();
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
