using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;

namespace BusinessLayer.Models
{
    [ExcludeFromCodeCoverage]
    public class UserModel
    {
        public int User_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmployeeId { get; set; }
    }
}