using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class ProjectModel
    {
        public int Project_ID { get; set; }
        public string Project { get; set; }
        public int Priority { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public Boolean SetDate { get; set; }
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public int TaskCount { get; set; }
        public int CompletedTasks { get; set; }
    }
}
