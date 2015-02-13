using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevDash.Model;

namespace TestDevDash.UnitTests {
  [TestClass]
  public class TestNote {
    [TestMethod]
    public void TestNoteConstructorWithValidParams() {
      Note note = new Note("this is a new note about the project", 1);
      Assert.AreEqual("this is a new note about the project", note.NoteDetails);
      Assert.AreEqual(1, note.NotesPanelId);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestNoteConstructorWithEmptyNoteDetail() { 
      Note note = new Note("", 1);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void TestNoteConstructorWithWhiteSpaceForNoteDetail() {
      Note note = new Note("        ", 1);
    }
  }
}
