using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models {
    public class Employee {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public Int64 IdentificationNumber { get; set; }

        public Employee(string id, string firstName, string lastName, DateTime birthday, Int64 identificationNumber)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
            IdentificationNumber = identificationNumber;
        }
    }
}
