using Library.LearningManagement.models;

namespace Library.LearningManagement.Services;

public class CourseService
{
    private static CourseService? _instance;

    public static CourseService Current
    {
        get
        {
            if(_instance == null)
            {
                _instance = new CourseService();
            }
            return _instance;
        }
    }
    
    private CourseService()
    {

    }

    // public void Add(Course course)
    // {
    //     FakeDatabase.Courses.Add(course);

    // }

    // public List<Course> Courses
    // {
    //     get
    //     {
    //         return FakeDatabase.Courses;
    //     }

    // }

    // public IEnumerable<Course> Search(string query)
    // {
    //     return Courses.Where(s => s.Name.ToUpper().Contains(query.ToUpper())
    //         || s.Description.ToUpper().Contains(query.ToUpper())
    //         || s.Code.ToUpper().Contains(query.ToUpper()));
    // }

}
