using Assignment_1;

namespace Student_management_system_test
{
    [TestClass]
    public class StudentManagementTestClass
    {
        [TestMethod]
        public void TestInstitutionName()
        {
            Institution institution = new Institution("Otago Polytechnic, Otago, New Zealand");
            Assert.AreEqual("Otago Polytechnic", institution.Name);
        }
        public void TestInstitutionRegion()
        {
            Institution institution = new Institution("Otago Polytechnic, Otago, New Zealand");
            Assert.AreEqual("Otago Polytechnic", institution.Region);
        }
        public void TestInstitutionCountry() 
        {
            Institution institution = new Institution("Otago Polytechnic, Otago, New Zealand");
            Assert.AreEqual("Otago Polytechnic", institution.Country);
        }
        public void TestPersonFirstName()
        {
            Person person = new Person(1, "Grayson", "Orr");
            Assert.AreEqual("Grayson", person.FirstName);
        }
        public void TestPersonLastName()
        {
            Person person = new Person(1, "Grayson", "Orr");
            Assert.AreEqual("Grayson", person.LastName);
        }
        public void TestGetAllMarks()
        {
            Institution institution = new Institution("Otago Polytechnic", "Otago", "New Zealand");
            Department department = new Department(institution, "IT");
            Course course = new Course(department, "IT502", "Bachelor of IT", "Programming/Web", 15, 20000);
            CourseAssessmentMark assessmentMarks = new(course, new List<int>()
            {
                10, 20, 30, 40, 50
            });
            Learner learner = new Learner (1, "Grayson", "Ore", assessmentMarks);
            string expected = string.Join(",", assessmentMarks.AssessmentMarks);
            string actual = string.Join(",", learner.CourseAssessmentMark.getAllMarks());
            Assert.AreEqual(expected, actual);
        }
        public void TestInstitutionAfterSeeding()
        {
            List<Institution> institutions = new List<Institution>();
            Assert.AreEqual (0, institutions.Count);
           institutions = Utils.SeedInstitution();
            Assert.AreEqual(3, institutions.Count();
        }
        public void TestLecturerSalary()
        {
            Institution institution = new Institution("Otago Polytechnic", "Otago", "New Zealand");
            Department department = new Department(institution, "IT");
            Course course = new Course(department, "IT502", "Bachelor of IT", "Programming/Web", 15, 20000);
            Lecturer lecturer = new Lecturer(1, "Grayson", "Ore", Position.LECTURER, Salary.LECTURER_SALARY, course);
            Assert.AreEqual(10000, lecturer.Salary); 
        }
    }
}