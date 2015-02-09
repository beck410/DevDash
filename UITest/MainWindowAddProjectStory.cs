﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UITest {
  [TestClass]
  public class MainWindowAddProjectStory : TestHelper {

    [ClassInitialize]
    public static void Setup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _context) {
      TestHelper.Setup(_context);
    }

    [TestMethod]
      public void TestNewProjectFormWithOnlyValidProjectName()
      {
      GivenTheNewProjectFormisEmpty();
      GivenThereAreNoProjectsInProjectsList("projects list");
      GivenIHaveFilledInFormField("pass in textbox name","pass in name");
      WhenIClick("button name");
      ThenIShouldSeeProjectList("project list");
      AndIShouldSeeXProjectsInProjectList("count","project list");
      AndIShouldSeeTheProjectInTheProjectList("project name", "project list");
      }



    [TestMethod]
    public void TestNewProjectFormWithAllValidFields() {
      GivenTheNewProjectFormisEmpty();
      GivenThereAreNoProjectsInProjectsList("projects list");
      GivenIHaveFilledInFormField("pass in textbox name","pass in name");
      GivenIHaveFilledInFormField("pass in textbox name","pass in github link");
      GivenIHaveFilledInFormField("pass in textbox name","pass in project desciption");
      WhenIClick("button name");
      ThenIShouldSeeProjectList("project list");
      AndIShouldSeeXProjectsInProjectList("count","project list");
      AndIShouldSeeTheProjectInTheProjectList("project name", "project list");
    }

    [TestMethod]
    public void TestNewProjectFormWithInvalidProjectName() {
      GivenTheNewProjectFormisEmpty();
      GivenThereAreNoProjectsInProjectsList("projects list");
      GivenIHaveFilledInFormField("pass in textbox name","pass in invalid name");
      WhenIClick("button name");
      ThenIShouldSeeErrorMessage("error message", "textblock name");
      AndIShouldSeeXProjectsInTheProjectList("error message", "textblock name");
    }



    [TestMethod]
    public void TestNewProjectFormWithInvalidGitHubLink() {
      GivenTheNewProjectFormisEmpty();
      GivenThereAreNoProjectsInProjectsList("projects list");
      GivenIHaveFilledInFormField("pass in textbox name","pass in valid name");
      GivenIHaveFilledInFormField("pass in textbox name","pass in invalid github link");
      WhenIClick("button name");
      ThenIShouldSeeErrorMessage("error message", "textblock name");
      AndIShouldSeeXProjectsInTheProjectList("project list", "0");
    }
    
    [TestMethod]
    public void TestNewProjectWithInvalidDescription() {
      GivenTheNewProjectFormisEmpty();
      GivenThereAreNoProjectsInProjectsList("projects list");
      GivenIHaveFilledInFormField("pass in textbox name","pass in valid name");
      GivenIHaveFilledInFormField("pass in textbox name","pass in description longer than 500 characters");
      WhenIClick("button name");
      ThenIShouldSeeErrorMessage("error message", "textblock name");
      AndIShouldSeeXProjectsInTheProjectList("project list", "0");
    }

    [TestMethod]
    public void TestNewProjectWithExistingProjectsInProjectList() {
      GivenTheNewProjectFormisEmpty();
      GivenThereAreXProjectsInProjectsList("projects list","2");
      GivenIHaveFilledInFormField("pass in textbox name","pass in name");
      WhenIClick("button name");
      ThenIShouldSeeProjectList("project list");
      AndIShouldSeeXProjectsInProjectList("count","project list");
      AndIShouldSeeTheProjectInTheProjectList("project name", "3");
    }



    [TestMethod]
    public void TestNewProjectWithNoInformationEntered() { 
      GivenTheNewProjectFormisEmpty();
      WhenIClick("button name"); 
      ThenIShouldSeeErrorMessage("error message", "textblock name");
      AndIShouldSeeXProjectsInTheProjectList("project list", "0");
    }

    [ClassCleanup]
    public static void CleanUp() {
      TestHelper.CleanThisUp();
    }
  }
}
