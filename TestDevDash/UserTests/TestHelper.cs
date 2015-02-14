﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevDash.Model;
using TestStack.White.UIItems.WindowItems;
using TestStack.White;
using System.IO;
using System.Reflection;
using TestStack.White.Factory;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems;
using DevDash.Repositories;
using DevDash;

namespace TestDevDash.UserTests {
  class TestHelper {

    private static TestContext test_context;
    protected static Window window;
    private static Application application;
    private static ProjectsRepository repo = new ProjectsRepository();
    private static ProjectContext context;
    private static String applicationPath;

    public static void SetUpClass(TestContext _context) {
      var applicationDir = _context.DeploymentDirectory;
      applicationPath = Path.Combine(applicationDir, "..\\..\\..\\TestWaitForIt\\bin\\Debug\\DevDash");
    }

    public static void TestPrep() {
      application = Application.Launch(applicationPath);
      window = application.GetWindow("MainWindow", InitializeOption.NoCache);
      context = repo.Context(); 
    }

    public static void CleanThisUp() {
      window.Close();
      application.Close();
      repo.Clear();
    }
  }
}
