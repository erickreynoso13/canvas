using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Library.LearningManagement.models
{
    public class Assignment
    {
        public string? Name { get; set;}
        public string? Description { get; set;}
        public decimal TotalAvailablePoints { get; set;}

        public DateTime DueTime{ get; set;}


    }

    
}


