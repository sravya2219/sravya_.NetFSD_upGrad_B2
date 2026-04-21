using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DAL.Models
{
    public class ContactInfo
    {
        [Key]
        public int ContactId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string EmailId { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string MobileNo { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Designation { get; set; } = string.Empty;

        // 🔗 Foreign Keys
        public int CompanyId { get; set; }
        public int DepartmentId { get; set; }

        // 🔁 Navigation Properties (nullable to avoid unnecessary object creation)

        [JsonIgnore]
        public Company? Company { get; set; }
        public Department? Department { get; set; }
    }
}