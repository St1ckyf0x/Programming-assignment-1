using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public static class Utils
    {
        private static List<Institution> institutions = new List<Institution>();
        private static List<Department> departments = new List<Department>();
        private static List<Course> courses = new List<Course>();
        public static List<Institution> SeedInstitution()
        {
            institutions.Add(new Institution("Otago Polytechnic", "Otago", "New Zealand"));
            institutions.Add(new Institution("Otago Polytechnic", "Otago", "New Zealand"));
            institutions.Add(new Institution("Otago Polytechnic", "Otago", "New Zealand"));
            return institutions; 
        }
        public static List<Department> SeedDepartment()
        {
            departments.Add(new Department(institutions[0], "IT"));
            departments.Add(new Department(institutions[1], "Fashion"));
            departments.Add(new Department(institutions[2], "Culinary"));
            return departments; 
        }
        public static List<Course> SeedCoures()
        {
            courses.Add(new Course(departments[0], "IT502", "Bachelor of IT", "Programming/Web", 15, 20000));
            courses.Add(new Course(departments[1], "IT503", "Bachelor of Fashion", "Fabrics/Design", 15, 10000));
            courses.Add(new Course(departments[2], "IT504", "Diploma of Gastronomy", "Cooking/Baking", 15, 15000));
            return courses;
        }
        public static void ReadLearnersFromFile(string filePath, List<Learner> learners)
        {
            using (StreamReader  reader = new StreamReader(filePath)) 
            {
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    CourseAssessmentMark courseAssessmentMark = new CourseAssessmentMark(courses[Convert.ToInt32(data[3])], new List<int>()
                    {
                        Convert.ToInt32(data[4]),
                        Convert.ToInt32(data[5]),
                        Convert.ToInt32(data[6]),
                        Convert.ToInt32(data[7]),
                        Convert.ToInt32(data[8]),
                    });
                    Learner learner = new Learner(Convert.ToInt32(data[0]), data[1], data[2], courseAssessmentMark);
                    learners.Add(learner);
                }
            }
        }
        public static void ReadLecturersFromFile(string filePath, List<Lecturer> lecturers)
        {
            using (StreamReader reader = new StreamReader(filePath)) 
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[]data = line.Split(",");
                    Lecturer lecturer = new Lecturer(
                        Convert.ToInt32(data[0]),
                        data[1],
                        data[2],
                        (Position)Convert.ToInt32(data[3]),
                        (Salary)Convert.ToInt32(data[4]),
                        courses[Convert.ToInt32(data[5])]);
                    lecturers.Add(lecturer);
                }
            }
        }
    }
}
