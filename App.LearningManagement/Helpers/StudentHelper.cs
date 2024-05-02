using System.Diagnostics.Contracts;
using Library.LearningManagement.models;
using Library.LearningManagement.Services;


namespace App.LearningManagement.Helpers;

internal class StudentHelper
{
    private StudentService studentService;
    private CourseService courseService;
    public StudentHelper()
    {
        studentService= StudentService.Current;
        courseService = CourseService.Current;
    }

    public void CreateStudnetRecord(Person? selectStudent = null)
    {

            Console.WriteLine("What is the ID of the student?");
            var id = Console.ReadLine();
            Console.WriteLine("What is the name of the student?");
            var name = Console.ReadLine();  
            Console.WriteLine("What is the classificaiton of the studnet?[(F)reshman, S(O)phmore, (J)unior, (S)enior]");
            var classification = Console.ReadLine()?? string.Empty;
            PersonClassification classEnum= PersonClassification.Freshman;
            if(classification.Equals("O",StringComparison.InvariantCultureIgnoreCase))
            {
                classEnum = PersonClassification.Sophmore;  
            }
            else if(classification.Equals("J",StringComparison.InvariantCultureIgnoreCase))
            {
                classEnum=  PersonClassification.Junior;
            }
            else if (classification.Equals("S",StringComparison.InvariantCultureIgnoreCase))
            {
                classEnum = PersonClassification.Senior;
            }
            bool isCreate = false;
            if(selectStudent == null)
            {
                isCreate=true;
                selectStudent = new Person();
            }
              
                selectStudent.Id= int.Parse(id?? "0");
                selectStudent.Name = name?? string.Empty;
                selectStudent.Classification =  classEnum;

                if(isCreate)
                {
                    studentService.Add(selectStudent);
                }

    }

    public void UpdateStudentRecord()
    {
        Console.WriteLine("Select a student to update");
        ListStudents();

        var selectionStr = Console.ReadLine();

        if(int.TryParse(selectionStr, out int selectionInt))
        {
            var selectStudent= studentService.Students.FirstOrDefault(s =>s.Id == selectionInt);
            if (selectStudent != null)
            {
                CreateStudnetRecord(selectStudent);
            }
        }
    }

    public void ListStudents()
    {
        studentService.Students.ForEach(Console.WriteLine);

        Console.WriteLine("Select a student");
        var selectionStr = Console.ReadLine();
        var selectionInt = int.Parse(selectionStr ?? "0");

        Console.WriteLine("Student Course List:");
        courseService.Courses.Where(c => c.Roster.Any(s => s.Id == selectionInt)).ToList().ForEach(Console.WriteLine);
        {
            
        }

    }

    public void SearchStudent()
    {
        Console.WriteLine("Enter a query");
        var query = Console.ReadLine() ?? string.Empty;
    
        studentService.Search(query).ToList().ForEach(Console.WriteLine);

        var selectionStr = Console.ReadLine();
        var selectionInt = int.Parse(selectionStr ?? "0");


        Console.WriteLine("Student Course List:");
        courseService.Courses.Where(c => c.Roster.Any(s => s.Id == selectionInt)).ToList().ForEach(Console.WriteLine);
    }

}
