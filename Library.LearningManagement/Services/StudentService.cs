using Library.LearningManagement.Database;
using Library.LearningManagement.models;

namespace Library.LearningManagement.Services;

public class StudentService
{

    private static StudentService? _instance;

    public IEnumerable<Person?>Students 
    {
        get
        {
            return FakeDatabase.People.Where(p => p is Person).Select(p =>p as Person);
        }
    }

    private StudentService()
    {

    }

    public static StudentService Current
    {
        get
        {
            if(_instance == null)
            {
                _instance = new StudentService();
            }

        return _instance;
            
        }
    }

    public void Add(Person student)
    {
        FakeDatabase.People.Add(student);
    }
    
    public IEnumerable<Person?> Search(string query)
    {
        return Students.Where(s => (s != null) && s.Name.ToUpper().Contains(query.ToUpper()));  
    }

}
