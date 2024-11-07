using System.ComponentModel.DataAnnotations;

namespace RazorPagesLessons.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }
        
        public string? PhotoPath { get; set; }
        public Dept? Department { get; set; }
    }
}
