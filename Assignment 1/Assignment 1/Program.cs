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
            do
            {
            Console.Clear();
                Console.WriteLine("STUDENT MANAGEMENT TOOL\n1: Course Details \n2: Marks \n3: All Grades \n4: Highest Marks \n5: Lowest Marks \n6: Fail Marks \n7: Average Marks \n8: Average Grade \n9: Add/Remove Learner \n10: Add Lecturer \n0: Exit Management System");
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
                        addRemoveLearner();
                        break;
                    case 10:
                        //addLecturer();
                        break;
                    default:
                        userInput = 0;
                        break;
                }
            } while (userInput != 0);
        }
        public static void courseDetails()
        {
            Console.WriteLine("/COURSE DETAILS/");
            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Code}: {course.Name}");
                Institution institution = course.Department.Institution;
                Console.WriteLine($"Description: {course.Description}," +
                    $" Credits: {course.Credits}," +
                    $" Fee: ${course.Fees}," +
                    $" Institution: {institution.Name}," +
                    $" {institution.Region}," +
                    $" {institution.Country}," +
                    $" {course.Department.Name} department\n");
            }
            Console.ReadLine();
        }
        public static void marks()
        {
            Console.WriteLine("ALL MARKS");
            foreach (var learner in learners)
            {
                Console.WriteLine($"{learner.Id}: {learner.FirstName}," +
                    $" {learner.LastName}, " +
                    $"{learner.CourseAssessmentMark.Course.Code}:" +
                    $" {learner.CourseAssessmentMark.Course.Name}:" +
                    $"  {string.Join(", ", learner.CourseAssessmentMark.getAllMarks())}");
            }
            Console.ReadLine();
        }
        public static void allGrades()
        {
            Console.WriteLine("ALL GRADES");
            foreach (var learner in learners)
            {
                Console.WriteLine($"{learner.Id}:" +
                    $" {learner.FirstName}," +
                    $" {learner.LastName}," +
                    $" {learner.CourseAssessmentMark.Course.Code}:" +
                    $" {learner.CourseAssessmentMark.Course.Name}:" +
                    $" {string.Join(", ", learner.CourseAssessmentMark.GetAllGrades())}");
            }
            Console.ReadLine();
        }
        public static void highestMarks()
        {
            Console.WriteLine("HIGHEST MARKS");
            foreach (var learner in learners)
            {
                Console.WriteLine($"{learner.Id}:" +
                    $" {learner.FirstName}," +
                    $" {learner.LastName}," +
                    $" {learner.CourseAssessmentMark.Course.Code}:" +
                    $" {learner.CourseAssessmentMark.Course.Name}:" +
                    $" {string.Join(", ", learner.CourseAssessmentMark.GetHighestMarks())}");
            }
            Console.ReadLine();
        }
        public static void lowestMarks()
        {
            Console.WriteLine("LOWEST MARKS");
            foreach (var learner in learners)
            {
                Console.WriteLine($"{learner.Id}:" +
                    $" {learner.FirstName}," +
                    $" {learner.LastName}," +
                    $" {learner.CourseAssessmentMark.Course.Code}:" +
                    $" {learner.CourseAssessmentMark.Course.Name}:" +
                    $" {string.Join(", ", learner.CourseAssessmentMark.GetLowestMarks())}");
            }
            Console.ReadLine();
        }
        public static void failMarks()
        {
            Console.WriteLine("FAIL MARKS");
            foreach (var learner in learners)
            {
                Console.WriteLine($"{learner.Id}: " +
                    $"{learner.FirstName}," +
                    $" {learner.LastName}," +
                    $" {learner.CourseAssessmentMark.Course.Code}:" +
                    $" {learner.CourseAssessmentMark.Course.Name}:" +
                    $" {string.Join(", ", learner.CourseAssessmentMark.GetFailMarks())}");
            }
            Console.ReadLine();
        }
        public static void averageMarks()
        {
            Console.WriteLine("AVERAGE MARKS");
            foreach (var learner in learners)
            {
                Console.WriteLine($"{learner.Id}:" +
                    $" {learner.FirstName}," +
                    $" {learner.LastName}," +
                    $" {learner.CourseAssessmentMark.Course.Code}:" +
                    $" {learner.CourseAssessmentMark.Course.Name}:" +
                    $" {string.Join(", ", learner.CourseAssessmentMark.GetAverageMarks())}");
            }
            Console.ReadLine();
        }
        public static void averageGrades()
        {
            Console.WriteLine("AVERAGE GRADES");
            foreach (var learner in learners)
            {
                Console.WriteLine($"{learner.Id}:" +
                    $" {learner.FirstName}," +
                    $" {learner.LastName}," +
                    $" {learner.CourseAssessmentMark.Course.Code}:" +
                    $" {learner.CourseAssessmentMark.Course.Name}: {string.Join(", ", learner.CourseAssessmentMark.GetAverageGrades())}");
            }
            Console.ReadLine();
        }
        public static void addRemoveLearner()
        {
            int userInput;
            Console.WriteLine("Add/Remove Learner\n1: Add Learner \n2: Remove Learner ");
            userInput = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            switch (userInput)
            {
                case 1:
                    addLearner();
                    break;
                case 2:
                    //removeLearner();
                    break;
            }
        }
        public static void addLearner()
        {
            Console.WriteLine();

            // get first name => check if first name contains numbers/spec chars
            // get last name
            // get course = 0, 1, 2 => make sure that the value is either 0, 1 or 2
            // get you marks => make sure that mark is >= 1 and <= 100

            // create a new Learner
            // add new Learner to learners list

            // write to file
            Console.WriteLine("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Last Name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Course:");
            int course = int.Parse(Console.ReadLine());



            Console.WriteLine("Enter Mark 1: ");
            int assessementMark1 = int.Parse(Console.ReadLine());
            if (assessementMark1 < 0 && assessementMark1 > 100)
            {
                Console.WriteLine("Please enter a vaild mark: ");
                assessementMark1 = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Enter Mark 2: ");
            int assessementMark2 = int.Parse(Console.ReadLine());
            if (assessementMark2 < 0 && assessementMark2 > 100)
            {
                Console.WriteLine("Please enter a vaild mark: ");
                assessementMark2 = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Enter Mark 3: ");
            int assessementMark3 = int.Parse(Console.ReadLine());
            if (assessementMark3 < 0 && assessementMark3 > 100)
            {
                Console.WriteLine("Please enter a vaild mark: ");
                assessementMark3 = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Enter Mark 4: ");
            int assessementMark4 = int.Parse(Console.ReadLine());
            if (assessementMark4 < 0 && assessementMark4 > 100)
            {
                Console.WriteLine("Please enter a vaild mark: ");
                assessementMark4 = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Enter Mark 5: ");
            int assessementMark5 = int.Parse(Console.ReadLine());
            if (assessementMark5 < 0 && assessementMark5 > 100)
            {
                Console.WriteLine("Please enter a vaild mark: ");
                assessementMark5 = int.Parse(Console.ReadLine());
            }


            int ID = learners[learners.Count - 1].Id + 1;
            CourseAssessmentMark courseAssessmentMark = new CourseAssessmentMark(courses[course], new List<int>()
            {
                assessementMark1, assessementMark2, assessementMark3, assessementMark4, assessementMark5
            });
            Learner learner = new Learner(ID, firstName, lastName, courseAssessmentMark);
            learners.Add(learner);
            using (StreamWriter SW = new StreamWriter(@"learners.txt", true))
            {
                SW.WriteLine($"{ID},{firstName},{lastName},{course},{assessementMark1},{assessementMark2},{assessementMark3},{assessementMark4},{assessementMark5}");
            }


      //  public static void removeLearner()
        {
            Console.WriteLine();
        }
       // public static void addLecturer()
        {
            Console.WriteLine();
        }
        }
    }
}