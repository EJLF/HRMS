using HRMS.Data;
using HRMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HRMS.Repository.SqlRepository
{
    public class EmployeePerformanceDBRepository: IEmployeePerformanceDBRepository
    {
        HRMSDBContext _dbcontext;

        public EmployeePerformanceDBRepository(HRMSDBContext dbContext)
        {
            _dbcontext = dbContext;
        }


        public EmployeePerformance AddEmployeePerformance(EmployeePerformance newEmployeePerformance)
            {
                _dbcontext.Add(newEmployeePerformance);
                _dbcontext.SaveChanges();
                return newEmployeePerformance;
            }

            public EmployeePerformance DeleteEmployeePerformance(int EmployeePerformanceId)
            {
                var EP = GetEmployeePerformanceById(EmployeePerformanceId);
                if (EP != null)
                {
                    _dbcontext.EmployeePerformances.Remove(EP);
                    _dbcontext.SaveChanges();
                }
                return EP;
            }

            public EmployeePerformance GetEmployeePerformanceById(int Id)
            {
                return _dbcontext.EmployeePerformances.Include(e=> e.Employee).AsNoTracking().ToList().FirstOrDefault(x => x.EmpPerformanceId == Id);
            }

            public List<EmployeePerformance> ListOfEmployeePerformance()
            {
                return _dbcontext.EmployeePerformances.AsNoTracking().ToList();
            }

            public EmployeePerformance UpdateEmployeePerformance(int EmployeePerformanceId, EmployeePerformance newEmployeePerformance)
            {
                _dbcontext.EmployeePerformances.Update(newEmployeePerformance);
                _dbcontext.SaveChanges();
                return newEmployeePerformance;
            }

        public List<SelectListItem> GetEmployeeList()
        {

            var listEmp = new List<SelectListItem>();
            List<Employee> employees = _dbcontext.Employees.ToList();
            listEmp = employees.Select(emp => new SelectListItem
            {
                Value = (emp.EmpId).ToString(),
                Text = emp.FirstName
            }).ToList();

            var defItem = new SelectListItem()
            {
                Value = "",
                Text = "---Select Employee---"
            };
            listEmp.Insert(0, defItem);
            return listEmp;
        }

        public List<EmployeePerformance> ListEmployeePerformance(string searchValue)
        {
            if (!string.IsNullOrEmpty(searchValue))
            {
                List<EmployeePerformance> employeePerformances = _dbcontext.EmployeePerformances
                    .Include(d => d.Employee)
                    .Where(e => e.EmpPerformanceId.ToString().Contains(searchValue))
                    .ToList();
                foreach (EmployeePerformance empPerformance in employeePerformances)
                {
                    int empPerformanceId = empPerformance.EmpPerformanceId;
                    
                }
                return employeePerformances;
            }
            List<EmployeePerformance> EmployeePerformances = _dbcontext.EmployeePerformances
                .Include(d => d.Employee)
                .ToList();
            return EmployeePerformances;
        }
    }
}
