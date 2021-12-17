using System;
using Xunit.Sdk;

namespace UnitTests
{
    [TestClass]
    public class PersonFileReaderTest
    {
        [TestMethod]
        public void Is_Valid_File_Path()
        {
            // Arrange
            var filename = "./unsorted-names-list.txt";
            var pr = new PersonFileReader(filename);

            // Act 
            pr.Read();

            // Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void Is_Invalid_File_Path()
        {
            // Arrange
            var filename = "./123.txt";
            var pr = new PersonFileReader(filename);

            // Act 
            pr.Read();

            // Assert
            Assert.Fail();
        }
    }
}
