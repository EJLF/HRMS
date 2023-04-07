using HRMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRMS.Repository
{
    public interface IEmployeePerformanceDBRepository
    {
        // Add Employee
        EmployeePerformance AddEmployeePerformance(EmployeePerformance newEmployeePerformance);
        // GetAllEmployeePerformance
        List<EmployeePerformance> ListOfEmployeePerformance();
        // GetId
        EmployeePerformance GetEmployeePerformanceById(int Id);
        // Update
        EmployeePerformance UpdateEmployeePerformance(string EmployeePerformanceId, EmployeePerformance newEmployeePerformance);
        // Delete
        EmployeePerformance DeleteEmployeePerformance(string EmployeePerformanceId);
        List<EmployeePerformance> ListEmployeePerformance(string value);
        List<SelectListItem> GetEmployeeList();
    }
}
