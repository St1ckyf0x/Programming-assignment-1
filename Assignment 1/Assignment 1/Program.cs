using System.Security.Cryptography.X509Certificates;

namespace Assignment_1
{
    public class Program
    {
        private static List<Learner> learners = new List<Learner>();
        private static List<Lecturer> lecturers = new List<Lecturer>();
        private static List<Course> courses = new List<Course>();
        private static List<Institution> institutions = new List<Institution>();
        private static List<Department> departments = new List<Department>();
        private static List<CourseAssessmentMark> courseAssessmentMarks = new List<CourseAssessmentMark>();
        static void Main(string[] args)
        {
            Utils.SeedInstitution();
            Utils.SeedDepartment();
            courses = Utils.SeedCoures();

            Utils.ReadLearnersFromFile("learners.txt", learners);
            Utils.ReadLecturersFromFile("lecturers.txt", lecturers);
            int userInput;
            Console.Clear();
            Console.WriteLine("1  Course Details* \n2  Marks* \n3  All Grades* \n4  Highest Marks* \n5 Lowest Marks \n6 Fail Marks \n 7 Average Marks \n 8 Average Grade \n 9 Add Learner \n0  Exit menu system*");
            userInput = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (userInput)
            {
                case 1:
                    courseDetails();
                    break;
                case 2:
                    marks();
                    break;
                case 3:
                    allGrades();
                    break;
                case 4:
                    highestMarks();
                    break;
                case 5:
                    lowestMarks();
                    break;
                case 6:
                    failMarks();
                    break;
                case 7:
                    averageMarks();
                    break;
                case 8:
                    averageGrades();
                    break;
                case 9:
                    addLearner();
                    break;
                default:
                    exit();
                    break;
            }
        }
        public static void courseDetails()
        {
            Console.WriteLine("/COURSE DETAILS/");
            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Code}: {course.Name}");
                Institution institution = course.Department.Institution;
                Console.WriteLine($"Description: {course.Description}, Credits: {course.Credits}, Fee: {course.Fees}, Institution: {institution.Name}, {institution.Region}, {institution.Country}, {course.Department.Name} department\n");
            }
            Console.ReadLine();
        }
        public static void marks()
        {
            Console.WriteLine("/ALL MARKS/");
            foreach (var learner in learners)
            {
                Console.WriteLine($"{learner.Id}, {learner.FirstName}, {learner.LastName}, {string.Join(", ",learner.CourseAssessmentMark.getAllMarks())}");
            }
            Console.ReadLine();
        }
        public static void allGrades()
        {
            Console.WriteLine("/ALL GRADES/");
            foreach (var learner in learners)
            {
                Console.WriteLine(string.Join(",", learner.CourseAssessmentMark.GetAllGrades()));
            }
            Console.ReadLine();
        }
        public static void highestMarks()
        {
            Console.WriteLine("Highest marks");
            foreach (var learner in learners)
            {
                Console.WriteLine(string.Join(",", learner.CourseAssessmentMark.GetHighestMarks()));
            }
            Console.ReadLine();
        }
        public static void lowestMarks()
        {
            Console.WriteLine("Lowest marks");
            foreach (var learner in learners)
            {
                Console.WriteLine(string.Join(",", learner.CourseAssessmentMark.GetLowestMarks()));
            }
            Console.ReadLine();
        }
        public static void failMarks()
        {
            Console.WriteLine("Fail marks");
            foreach (var learner in learners)
            {
                Console.WriteLine(string.Join(",", learner.CourseAssessmentMark.GetFailMarks()));
            }
            Console.ReadLine();
        }
        public static void averageMarks()
        {
            Console.WriteLine("Average marks");
            foreach (var learner in learners)
            {
                Console.WriteLine(string.Join(",", learner.CourseAssessmentMark.GetAverageMarks()));
            }
            Console.ReadLine();
        }
        public static void averageGrades()
        {
            Console.WriteLine("Average grades");
            foreach (var learner in learners)
            {
                Console.WriteLine(string.Join(",", learner.CourseAssessmentMark.GetAverageGrades()));
            }
            Console.ReadLine();
        }
        public static void addLearner()
        {
            Console.WriteLine("Enter ");
            Console.ReadLine();
        }
        public static void exit()
        {
            Console.WriteLine("Cya!");
            Console.ReadLine();
        }
    }
}