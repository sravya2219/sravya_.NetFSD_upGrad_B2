using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace DAL.Models
{
    public class ContactInfo
    {

        [Key] // ✅ Primary Key
        public int ContactId { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailId { get; set; }
        public long MobileNo { get; set; }
        public string? Designation { get; set; }

        // 🔗 Foreign Keys
        public int CompanyId { get; set; }
        public int DepartmentId { get; set; }

        // 🔁 Navigation Properties
        public Company? Company { get; set; }
        public Department? Department { get; set; }
    }
}
