using System;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagmentAPI.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(30)]
        public string Position { get; set; }
        public int? ManagerId { get; set; }
    }
}
