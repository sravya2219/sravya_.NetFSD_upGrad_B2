using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Json.Serialization;

namespace DAL.Models
{
   public  class Company
    {
        [Key]
        public int CompanyId { get; set; }

        public string? CompanyName { get; set; }

        // 🔁 One Company → Many Contacts

        [JsonIgnore]
        public ICollection<ContactInfo>? Contacts { get; set; }
    }
}
