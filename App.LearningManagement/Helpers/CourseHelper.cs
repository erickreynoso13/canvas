﻿using App.LearningManagement.Helpers;
using Library.LearningManagement.models;
using Library.LearningManagement.Services;

namespace App.LearningManagement.Helper
{
    public class CourseHelper
    {
        private CourseService courseService;
        private StudentService studentService;

        public CourseHelper()
        {
            studentService= StudentService.Current;
            courseService= CourseService.Current;
        }

        public void CreateCourseRecord(Course? selectedCourse = null)
        {
            Console.WriteLine("What is the code of the course?");
            var code = Console.ReadLine()?? string.Empty;
            Console.WriteLine("What is the name of the course?");
            var name = Console.ReadLine()?? string.Empty;  
            Console.WriteLine("What is the description of the course?");
            var description = Console.ReadLine()?? string.Empty;



            Console.WriteLine("Which students should be enrolled in this course? ('Q' to quit)");
            var roster = new List<Person>();
            bool continueAdding = true;
            while(continueAdding)
            {
                studentService.Students.Where(s => !roster.Any(s2 =>s2.Id == s.Id)).ToList().ForEach(Console.WriteLine);
                var selection = "Q";
                if(studentService.Students.Any(s => !roster.Any(s2 => s2.Id ==s.Id)))
                {
                    selection = Console.ReadLine()?? string.Empty;
                }
                

                if(selection.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
                {
                    continueAdding = false;
                }
                else
                {
                    var selectedId = int.Parse(selection);
                    var selectedStudent = studentService.Students.FirstOrDefault(s => s.Id== selectedId);

                    if(selectedStudent != null)
                    {
                        roster.Add(selectedStudent);

                    }
                }
            }

            Console.WriteLine("would you like to add assigments?(Y/N)");
            var assignResponse = Console.ReadLine() ?? "N";
            var assignments = new List<Assignment>();
            if(assignResponse.Equals("Y",StringComparison.InvariantCultureIgnoreCase))
            {
                continueAdding = true;
                while(continueAdding)
                {
                    //name
                    Console.WriteLine("Name:");
                    var assignmentName = Console.ReadLine()?? string.Empty;
                    //description
                    Console.WriteLine("Description:");
                    var assignmentDescription = Console.ReadLine()?? string.Empty;
                    //totalpoints
                    Console.WriteLine("TotalPoints:");
                    var totalPoints = decimal.Parse(Console.ReadLine()?? "100");
                    //duedate
                    Console.WriteLine("DueDate:");
                    var dueDate = DateTime.Parse(Console.ReadLine()?? "01/01/1900");

                    assignments.Add(new Assignment
                    {
                        Name = assignmentName,
                        Description= assignmentDescription,
                        TotalAvailablePoints = totalPoints,
                        DueDate =dueDate
                    });

                    Console.WriteLine("Add more courses? (Y/N)");
                    assignResponse = Console.ReadLine() ?? "N";
                    if(assignResponse.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                    {
                        continueAdding = false;
                    }


                }
            }



            bool isNewCourse = false;
            if(selectedCourse == null)
            {
                isNewCourse = true;
                selectedCourse = new Course();
            }

            selectedCourse.Code =code;
            selectedCourse.Name = name;
            selectedCourse.Description= description;
            selectedCourse.Roster = new List<Person>();
            selectedCourse.Roster.AddRange(roster);
            selectedCourse.Assignments = new List<Assignment>();
            selectedCourse.Assignments.AddRange(assignments);
            
            if(isNewCourse)
            {
                courseService.Add(selectedCourse);
            }
         
        }

        public void UpdateCourseRecord()
        {
            Console.WriteLine("Enter the code for the course to update");
            SearchCourses();

            var selection= Console.ReadLine();

            var selectedCourse = courseService.Courses.FirstOrDefault(s => s.Code.Equals(selection,StringComparison.InvariantCultureIgnoreCase));
            if (selectedCourse != null)
            {
                CreateCourseRecord(selectedCourse);
            }
        }

        public void SearchCourses(string? query = null)
        {
            if(string.IsNullOrEmpty(query))
            {
                courseService.Courses.ForEach(Console.WriteLine);
            }
            else
            {
                courseService.Search(query).ToList().ForEach(Console.WriteLine);
            }

            Console.WriteLine("select a corus:");
            var code = Console.ReadLine() ?? string.Empty;

            var selectedCourse = courseService
                .Courses
                .FirstOrDefault(c => c.Code.Equals(code, StringComparison.InvariantCultureIgnoreCase));
            if(selectedCourse != null)
            {
                Console.WriteLine(selectedCourse.DetailDisplay);

            }

        }



    }
}
    



