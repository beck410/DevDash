using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevDash.Model;

namespace TestDevDash.UnitTests {
  [TestClass]
  public class TestNotesPanel {
    [TestMethod]
    public void TestNotesPanelConstructorWithValidParams() {
      NotesPanel panel = new NotesPanel(2);
      Assert.AreEqual(2,panel.ProjectId);
    }
  }
}
