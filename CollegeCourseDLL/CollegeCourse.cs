using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;


namespace CollegeCourseDLL
{

    public class CollegeCourse
    {

        public string CourseId { get; private set; }
        public string Name { get; private set; }
        public int Hours { get; private set; }
        public string Days { get; private set; }
        public string Time { get; private set; }
        public string StudentId { get; set; }


        public static Dictionary<string, CollegeCourse> CollegeInfo = new Dictionary<string, CollegeCourse>();


        public CollegeCourse(string courseId, string name, int hours, string days, string time, string studentId)
        {
            CourseId = courseId;
            Name = name;
            Hours = hours;
            Days = days;
            Time = time;
            StudentId = studentId;

            if (!CollegeInfo.ContainsKey(courseId))
            {
                CollegeInfo[courseId] = this;
               
            }
            else
            {
                throw new ArgumentException("A course with this ID already exists.");
            }
        }


        public static CollegeCourse CourseInfo(string courseId)
        {
            if (CollegeInfo.TryGetValue(courseId, out var course))
            {
                return course;
            }
            else
            {
                throw new KeyNotFoundException("Course ID not found.");
            }
        }

        public static void DisplayCoursesForStudent(string studentId)
        {
            if (CollegeInfo == null || string.IsNullOrEmpty(studentId))
            {

                MessageBox.Show("Invalid input or no courses found.");
                return;
            }

            var courses = CollegeInfo.Values.Where(course => course.StudentId == studentId).ToList();

            if (courses.Count == 0)
            {
                MessageBox.Show("No courses found for the given student ID.");
                return;
            }

            foreach (var course in courses)
            {
                MessageBox.Show($"Course ID: {course.CourseId}\nName: {course.Name}\nHours: {course.Hours}\nDays: {course.Days}\nTime: {course.Time}\n");
            }
        }


        public static void DeleteCourse(string courseId)
        {
            if (CollegeInfo.ContainsKey(courseId))
            {
                CollegeInfo.Remove(courseId);



            }

        }

    }
}


