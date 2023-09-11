using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_1
{
    public class CourseAssessmentMark
    {
        private Course course;
        private List<int> assessmentMarks;

        public CourseAssessmentMark(Course course, List<int> assessmentMarks)
        {
            this.course = course;
            this.assessmentMarks = assessmentMarks;
        }

        public List<int> getAllMarks()
        {
            return assessmentMarks;
        }
        public List<string> GetAllGrades()
        {
            List<string> temp = new List<string>();
            for (int i = 0; i < assessmentMarks.Count; i++) //grades method below
            {
                if (assessmentMarks[i] >= 90)
                {
                    temp.Add("A+");
                }
            else if (assessmentMarks[i] <= 89 && assessmentMarks[i] >= 85)
                {
                    temp.Add("A");
                }
            else if (assessmentMarks[i] >= 80 && assessmentMarks[i] <= 84)
                {
                    temp.Add("A-");
                }
            else if (assessmentMarks[i] >=75 && assessmentMarks[i] <= 79)
                {
                    temp.Add("B+");
                }
                else if (assessmentMarks[i] >= 70 && assessmentMarks[i] <= 74)
                {
                    temp.Add("B");
                }
                else if (assessmentMarks[i] >= 65 && assessmentMarks[i] <= 69)
                {
                    temp.Add("B-");
                }
                else if (assessmentMarks[i] >= 60 && assessmentMarks[i] <= 65)
                {
                    temp.Add("C+");
                }
                else if (assessmentMarks[i] >= 55 && assessmentMarks[i] <= 59)
                {
                    temp.Add("C");
                }
                else if (assessmentMarks[i] >= 50 && assessmentMarks[i] <= 54)
                {
                    temp.Add("C-");
                }
                else
                {
                    temp.Add("D");
                }

                return temp;

            }
            return new List<string> { };
        }
        public List<int> GetHighestMarks()  //Highest marks method
        {
            List<int> highest = new List<int>();
            for(int i = 0; i < assessmentMarks.Count; i++)
            {
                if (assessmentMarks[i] == assessmentMarks.Max()) 
                {
                    highest.Add(assessmentMarks[i]);
                }
            }
          return highest;
        }
        public List <int> GetLowestMarks() 
        {
            List<int> lowest = new List<int>();
            for (int i = 0; i < assessmentMarks.Count; i++)
            {
                if (assessmentMarks[i] == assessmentMarks.Min())
                {
                    lowest.Add(assessmentMarks[i]);
                }
            }
            return lowest ;
        }
        public List <int> GetFailMarks()  //Fail marks method - if the mark <50 its a fail
        {
            List<int> fail = new List<int>();

            for (int i = 0; i < assessmentMarks.Count; i++)
            {
                if (assessmentMarks[i] < 50)
                {
                    fail.Add(assessmentMarks[i]);
                }
            }
            return fail;
        }
        public double GetAverageMarks()
        {
            return assessmentMarks.Sum() / assessmentMarks.Count;
        }
        public string GetAverageGrades() 
        {
            double average = GetAverageMarks();

         if (average >= 90)
                {
                    return "A+";
                }
            else if (average <= 89 && average >= 85)
                {
                    return "A";
                }
            else if (average >= 80 && average <= 84)
                {
                    return "A-";
                }   
            else if (average >=75 && average <= 79)
                {
                    return "B+";
                }
                else if (average >= 70 && average <= 74)
                {
                    return "B";
                }
                else if (average >= 65 && average <= 69)
                {
                    return "B-";
                }
                else if (average >= 60 && average <= 65)
                {
                    return "C+";
                }
                else if (average >= 55 && average <= 59)
                {
                    return "C";
                }
                else if (average >= 50 && average <= 54)
                {
                    return "C-";
                }
            return "D";
        }
    }
}
