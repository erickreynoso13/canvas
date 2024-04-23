using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Library.LearningManagement.models
{
    public class Person
    {
        public int Id {get;set;}
        public string Name {get;set;}

        public Dictionary<int,double> Grades{get;set;}

        public char Classification {get;set;}

        public Person()
        {
            Name = string.Empty;
            Grades = new Dictionary<int, double>(); 
        }

    }
}

