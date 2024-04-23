using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Library.LearningManagement.models
{
    public class Modules
    {
        public string? Name{get;set;}

        public string? Description{get;set;} 
        public List<ContentItem> Content{get;set;}

        public Modules()
        {
            Content = new List<ContentItem>();
        }

    }
}