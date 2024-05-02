﻿using App.LearningManagement.Helper;
using App.LearningManagement.Helpers;
using Library.LearningManagement.models;
using Library.LearningManagement.Services;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var studentHelper = new StudentHelper();
            var courseHelper = new CourseHelper();

            bool cont = true;
            
            while(cont)
            {
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1. Add a student enrollment");
                Console.WriteLine("2. Update a student enrollment");
                Console.WriteLine("3. List all student enrollment");
                Console.WriteLine("4. Search For a student");
                Console.WriteLine("5. Add a new course");
                Console.WriteLine("6. Update a course");
                Console.WriteLine("7. List all course");
                Console.WriteLine("8. Search for a course");
                Console.WriteLine("9. Exit");
                var input = Console.ReadLine();
                if(int.TryParse(input, out int result))
                {
                    if(result == 1)
                    {
                        studentHelper.CreateStudnetRecord();
                    }
                    else if (result == 2)
                    {
                        studentHelper.UpdateStudentRecord();
                    }
                    else if (result == 3)
                    {
                        studentHelper.ListStudents();
                    }
                    else if (result == 4)
                    {
                        studentHelper.SearchStudent();
                    }
                    else if (result == 5)
                    {
                        courseHelper.CreateCourseRecord();
                    }
                    else if (result == 6)
                    {
                        courseHelper.UpdateCourseRecord();
                    }
                    else if (result == 7)
                    {
                        //courseHelper.ListCourses();
                        courseHelper.SearchCourses();
                    }
                    else if (result == 8)
                    {
                        Console.WriteLine("Enter a query:");
                        var query = Console.ReadLine()?? string.Empty;
                        courseHelper.SearchCourses(query);
                    }
                    else if (result == 9)
                    {
                        cont = false;
                    }
                }

            }        
        }
    }
}