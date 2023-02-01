using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVCLayers.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCLayers.ViewModels
{
    public class EmployeeVM
    {
        public int SSN { get; set; }
        [Display(Name ="First Name")]
        public string? Fname { get; set; }
        [Display(Name = "Last Name")]

        public string? LName { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }
        [Display(Name = "Birth Date")]

        public DateTime? BDate { get; set; }

        public double? Salary { get; set; }
        [Display(Name = "Department")]

        public int? Dept_id { get; set; }
        [Display(Name = "Supervisor")]

        public int? Super_SSN { get; set; }
    }
}
