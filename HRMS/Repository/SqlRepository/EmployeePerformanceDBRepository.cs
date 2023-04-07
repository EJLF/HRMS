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

        public EmployeePerformance DeleteEmployeePerformance(string EmployeePerformanceId)
        {
            throw new NotImplementedException();
        }

        public List<SelectListItem> GetEmployeeList()
        {
            throw new NotImplementedException();
        }

        public EmployeePerformance GetEmployeePerformanceById(int Id)
        {
            return _dbcontext.EmployeePerformances.AsNoTracking().ToList().FirstOrDefault(x => x.No == Id);
        }

        public List<EmployeePerformance> ListEmployeePerformance(string value)
        {
            throw new NotImplementedException();
        }

        public List<EmployeePerformance> ListOfEmployeePerformance()
        {
            return _dbcontext.EmployeePerformances.AsNoTracking().ToList();
        }

        public EmployeePerformance UpdateEmployeePerformance(string EmployeePerformanceId, EmployeePerformance newEmployeePerformance)
        {
            throw new NotImplementedException();
        }
    }
}
