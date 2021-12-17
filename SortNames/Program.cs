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
                var sorting = p.FileSorter(persons);
                foreach (var name in sorting)
                {
                    System.Console.WriteLine(name.ToString());
                }
                var writer = p.FileWriter(sorting, outputFilename);
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
            var data = "";
            using (StreamReader sr = new StreamReader(inputFilename))
            {
                data = sr.ReadToEnd();
            }
            return data;

        }
        //File parsing method, in this method we will parse file till end of the file.
        public List<PersonName> FileParsing(String data, string delimiter)
        {
            List<PersonName> personsName = new List<PersonName>();
            string[] lines = data.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string line in lines)
            {
                var givenName = "";
                var lastName = "";

                if (line.IndexOf(delimiter) > 0)
                {
                    givenName = line.Substring(0, line.LastIndexOf(delimiter));
                    lastName = line.Substring(line.LastIndexOf(delimiter) + 1);
                }
                else
                {
                    givenName = line;
                }
                var name = new PersonName(givenName, lastName);
                personsName.Add(name);
            }
            return personsName;
        }
        //Names sorting by last name
        public List<PersonName> FileSorter(List<PersonName> personsName)
        {
            var list= personsName.ToList();
            list.Sort((firstPerson, secondPerson) => string.Compare(firstPerson.LastName, secondPerson.LastName));
            return list;
        }
        //File writer- write sorted names in the outputfile
        public List<PersonName> FileWriter(List<PersonName> personsName, string outputFilename)
        {
            using (StreamWriter sw = new StreamWriter(Directory.GetCurrentDirectory()+"\\" + outputFilename))
            {
                foreach (var name in personsName)
                {
                    sw.WriteLine(name.ToString());
                }
            }
            return personsName;
        }
    }
}
