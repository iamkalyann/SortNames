using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using SortNames;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class NamesUnitTests
    {
        [TestMethod]
        //reader test
        public void FilePathCheck()
        {
            // Arrange
            var filename = "./unsorted-names-list.txt";
            Program p = new Program();

            // Act 
            p.FileReader(filename);

            // Assert
            Assert.IsTrue(true);
        }
        //reader test

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void FilePathInvalid()
        {
            // Arrange
            var p = new Program();
            var filename = "./sample.txt";

            // Act 
            p.FileReader(filename);

            // Assert
            Assert.Fail();
        }
        //Writer test
        [TestMethod]
        public void FileCreated()
        {
            // Arrange
            var p = new Program();
            var filename = "sampleOutput.txt";
            var list = new List<PersonName>();

            // Act 
            p.FileWriter(list, filename);
            var isExist = File.Exists(Directory.GetCurrentDirectory() + "\\" + filename);

            // Assert
            Assert.IsTrue(isExist);
        }
        //Sorter test
        [TestMethod]
        public void LnameSorting()
        {
            var p = new Program();
            var list = new List<PersonName>();
            list.Add(new PersonName("two", "K"));
            list.Add(new PersonName("one", "A"));
            list.Add(new PersonName("four", "L"));
            list.Add(new PersonName("three", "Y"));
            list.Add(new PersonName("five", "G"));
            list.Add(new PersonName("six", "N"));

            var sortedList = p.FileSorter(list);

            Assert.AreEqual("A", sortedList.First().LastName);
        }
        //Sorter test
        [TestMethod]
        public void ReturnName()
        {
            var p = new Program();
            var list = new List<PersonName>();
            list.Add(new PersonName("one", "A"));

            var sortedList = p.FileSorter(list);

            Assert.AreEqual("A", sortedList.First().LastName);
        }

    }
}
