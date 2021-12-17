using System;
using System.Collections.Generic;
using System.Text;

namespace SortNames
{
    public class PersonName
    {

        public string GivenName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", GivenName, LastName);
            }
        }

        public PersonName(string givenName, string lastName)
        {
            GivenName = givenName;
            LastName = lastName;
        }
        public override string ToString()
        {
            return FullName;
        }
    }
}

