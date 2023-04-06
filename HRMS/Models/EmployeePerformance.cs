using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMS.Models
{
    public class EmployeePerformance
    {
        [Key]
        public int EmpPerformanceId { get; set; }
        public int? EmpId { get; set; }
        [ForeignKey("EmpId")]
        public Employee? Employee { get; set; }
        [Required]
        [MinLength(10)]
        [DisplayName("Performance Review")]
        public string PerformanceReview { get; set; }

        public EmployeePerformance() { }

        public EmployeePerformance(int empPerformanceId, int empId, string performanceReview)
        {
            EmpPerformanceId = empPerformanceId;
            EmpId = empId;
            PerformanceReview = performanceReview;

        }
    }
}
