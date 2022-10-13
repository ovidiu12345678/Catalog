using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog
{
    internal class Student
    {
        private static UInt16 idGenerator = 1;

        private UInt16 id=0;
        private string firstName;
        private string lastName;
        private UInt16 age;
        private Address address;
        private List<Mark> marks;

        public Student(string firstName, string lastName, UInt16 age, Address address, List<Mark> marks)
        {
            this.id = idGenerator++;
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.address = address;
            this.marks = marks;
        }

        public UInt16 Id { get => id; set => id = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public UInt16 Age { get => age; set => age = value; }
        public Address Address { get => address; set => address = value; }
        public List<Mark> Marks { get => marks; set => marks = value; }

        public override string ToString()
        {
            String studentAsString=String.Format("Id : {0}\nFirstName : {1}\nLastName : {2}\nAge : {3}\nAddress : {4}\nMarks : ",
                id, firstName, lastName, Age, address);

            marks.ForEach((mark) => studentAsString = String.Concat(studentAsString,mark));

            return String.Concat(studentAsString,"\n");
        }
    }
}
