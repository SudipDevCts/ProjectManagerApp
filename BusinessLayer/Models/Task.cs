using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    public class TaskModel
    {
        public int Task_ID { get; set; }
        public int Project_ID { get; set; }
        public int User_ID { get; set; }
        public int Parent_ID { get; set; }
        public int Priority { get; set; }
        public string Task { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string TaskStatus { get; set; }
        public string ParentTask { get; set; }
        public bool IsEditable { get; set; }
    }
}
