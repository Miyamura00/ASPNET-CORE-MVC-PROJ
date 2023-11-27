using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PracticeProjMVC.Models
{
    public class EmployeeModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z]+(\s[a-zA-Z]+)*$", ErrorMessage = "The Name field must contain only letters")]
        [DisplayName("Full Name")]
        public string Fullname { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DisplayName("Job Role")]
        public string JobRole { get; set; }
        [Required]
        [DisplayName("Salary Pay")]
        public int SalaryPay { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}