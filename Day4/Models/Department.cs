using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        public string? DepartmentName { get; set; }

        // 🔁 One Department → Many Contacts
        public ICollection<ContactInfo>? Contacts { get; set; }
    }
    }
