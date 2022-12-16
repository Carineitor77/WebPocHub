using System.ComponentModel.DataAnnotations;

namespace WebPocHub.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [MaxLength(100)]
        [Required(ErrorMessage = "Employee name is a required field!")]
        public string EmployeeName { get; set; } = string.Empty;

        [MaxLength(300)]
        public string Address { get; set; } = string.Empty;

        [MaxLength(50)]
        [Required(ErrorMessage = "Employee city is a required field!")]
        public string City { get; set; } = string.Empty;

        [MaxLength(10)]
        public string Zipcode { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Country { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Skillsets { get; set; } = string.Empty;

        [MaxLength(15)]
        [Required(ErrorMessage = "Employee phone is a required field!")]
        [Phone]
        public string Phone { get; set; } = string.Empty;

        [MaxLength(100)]
        [Required(ErrorMessage = "Employee email is a required field!")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Avatar { get; set; } = string.Empty;
    }
}
