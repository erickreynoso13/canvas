using System;
using System.Collections.Generic;  
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Library.LearningManagement.models
{
    public class Courses
    {
        public string Code{ get; set; }
        public string Name{ get; set; }
        public string Description { get; set; }

        public List<Person> Roster{ get; set; }

        public List <Assignment> Assignment{ get; set; }    
        public List <Modules> Moduels { get; set; }

        public Courses()
        {
            Code = string.Empty;
            Name = string.Empty;
            Description = string.Empty;
            Roster= new List<Person>();
            Assignment = new List<Assignment>();
            Moduels = new List < Modules >();
            

        }
    }
}