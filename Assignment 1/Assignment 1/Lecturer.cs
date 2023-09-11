using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class Lecturer : Person
    {
        private Position position;
        private Salary salary;
        private Course course;

        public Lecturer(int id, string firstName, string lastName, Position position, Salary salary, Course course) : base(id, firstName, lastName)
            {
            this.position = position;
            this.salary = salary;
            this.course = course;
        }

        public Position Position { get => position; set => position = value; }
        public Salary Salary { get => salary; set => salary = value; }
        public Course Course { get => course; set => course = value; }
    }
}
