﻿using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.BDDfy;

namespace UITest {
  [TestClass]
  public class MainWindowAddProjectStory {

    private static Window window;
    private static Application application;
    private static Button New_Project_Button;

    [ClassInitialize]
    public static void Setup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _context){
      var applicationDir = _context.DeploymentDirectory;
      var applicationPath = Path.Combine(applicationDir, "..\\..\\..\\DevDash\\bin\\Debug\\DevDash");
      application = Application.Launch(applicationPath);
      window = application.GetWindow("MainWindow", InitializeOption.NoCache);
      New_Project_Button = window.Get<Button>("Main_New_Project_Button");
    }

    void WhenTheNewProjectButtonIsClicked() {
      New_Project_Button.Click();
    }

    void GivenTheMainWindowIsOpen() {
      Assert.IsTrue(window.IsFocussed);
    }

    void ThenTheNewProjectWindowShouldOpen() {
      //New Window
    }

    void AndThenNewProjectcreateButtonIsDisabled() {
      Assert.IsFalse(New_Project_Button.Enabled);
    } 

    [TestMethod]
    public void MainPageAddNewProjectButtonTest(){
      this.BDDfy();
    }

    [ClassCleanup]
    public static void TearDown()
    {
        window.Close();
        application.Close();
    }
  }
}
