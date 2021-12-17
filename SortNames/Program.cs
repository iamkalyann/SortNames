using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SortNames
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string inputFilename = "unsorted-names-list.txt";
            SortNames(inputFilename);
            System.Console.Read();
        }
        // main sorting method, where we are calling reader,writer, and sorter methods.
        public static void SortNames(string inputFilename)
        {
            try
            {
                var p = new Program();
                var outputFilename = "sorted-names-list.txt";
                var delimiter = " ";
                var reader = p.FileReader(inputFilename);
                var persons = p.FileParsing(reader, delimiter);
                var sortedList = p.FileSorter(persons);
                foreach (var person in sortedList)
                {
                    System.Console.WriteLine(person.ToString());
                }
                var writer = p.FileWriter(sortedList, outputFilename);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
        //File reader method.
        public string FileReader(string inputFilename)
        {
            //Console.WriteLine(Directory.GetCurrentDirectory());
            if (!File.Exists(Directory.GetCurrentDirectory() +"\\"+ inputFilename))
            {
                throw new FileNotFoundException("File not found at path:" + inputFilename);
            }
            var result = "";
            using (StreamReader sr = new StreamReader(inputFilename))
            {
                result = sr.ReadToEnd();
            }
            return result;

        }
        //File parsing method, in this method we will parse file till end of the file.
        public List<PersonName> FileParsing(String result, string delimiter)
        {
            List<PersonName> persons = new List<PersonName>();
            string[] lines = result.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                var GivenName = "";
                var lastName = "";

                if (line.IndexOf(delimiter) > 0)
                {
                    GivenName = line.Substring(0, line.LastIndexOf(delimiter));
                    lastName = line.Substring(line.LastIndexOf(delimiter) + 1);
                }
                else
                {
                    GivenName = line;
                }
                var person = new PersonName(GivenName, lastName);
                persons.Add(person);
            }
            return persons;
        }
        //Names sorting by last name
        public List<PersonName> FileSorter(List<PersonName> persons  )
        {
            var list= persons.ToList();
            list.Sort((firstPerson, secondPerson) => string.Compare(firstPerson.LastName, secondPerson.LastName));
            return list;
        }
        //File writer- write sorted names in the outputfile
        public List<PersonName> FileWriter(List<PersonName> persons, string outputFilename)
        {
            using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory()+"\\" + outputFilename))
            {
                foreach (var person in persons)
                {
                    sw.WriteLine(person.ToString());
                }
            }
            return persons;
        }
    }
}
