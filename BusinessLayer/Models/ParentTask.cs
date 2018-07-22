using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Models
{
    [ExcludeFromCodeCoverage]
    public class ParentTask
    {
        public int Parent_ID { get; set; }
        public string Parent_Task { get; set; }
    }
}
