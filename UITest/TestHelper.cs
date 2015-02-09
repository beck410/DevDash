﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevDash.Model;
using TestStack.White.UIItems.WindowItems;
using TestStack.White;
using System.IO;
using TestStack.White.Factory;
using TestStack.White.UIItems.ListBoxItems;

namespace UITest {
  public class TestHelper {
    private static TestContext test_context;
    private static Window window;
    private static Application application;

    public static void Setup(TestContext _context) {
      test_context = _context;
      var applicationDir = _context.DeploymentDirectory;
      var applicationPath = Path.Combine(applicationDir, "..\\..\\..\\TestWaitForIt\\bin\\Debug\\WaitForIt");
      application = Application.Launch(applicationPath);
      window = application.GetWindow("MainWindow", InitializeOption.NoCache);
    }

    public static void CleanThisUp() {
      window.Close();
      application.Close();
    }

    public void AndIShouldSeeTheProjectInTheProjectList(string p1, string p2) {
      throw new NotImplementedException();
    }

    public void AndIShouldSeeXProjectsInProjectList(string p1, string p2) {
      throw new NotImplementedException();
    }

    public void ThenIShouldSeeProjectList(string p) {
      throw new NotImplementedException();
    }

    public void WhenIClick(string p) {
      throw new NotImplementedException();
    }

    public void GivenIHaveFilledInFormField(string p1, string p2) {
      throw new NotImplementedException();
    }

    public void GivenThereAreNoProjectsInProjectsList(string p) {
      throw new NotImplementedException();
    }

    public void GivenTheNewProjectFormisEmpty() {
      throw new NotImplementedException();
    }

    public void AndIShouldSeeXProjectsInTheProjectList(string p1, string p2) {
      throw new NotImplementedException();
    }

    public void ThenIShouldSeeErrorMessage(string p1, string p2) {
      throw new NotImplementedException();
    }

    public void GivenThereAreXProjectsInProjectsList(string p1, string p2) {
      throw new NotImplementedException();
    }
  }
}
