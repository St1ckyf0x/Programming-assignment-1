using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class Person
    {
        private int id;
        private string firstName;
        private string lastName;

        protected int Id { get => id; set => id = value; }
        protected string FirstName { get => firstName; set => firstName = value; }
        protected string LastName { get => lastName; set => lastName = value; }

        public Person(int id, string firstName, string lastName)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}
