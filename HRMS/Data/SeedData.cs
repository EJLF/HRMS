using HRMS.Models;
using HRMS.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace HRMS.Data
{
    public static class SeedData
    {
        public static void SeedDefaultData(this ModelBuilder modelBuilder)
        { 

            modelBuilder.Entity<Department>().HasData(
                new Department(1, "Human Resource"),
                new Department(2, "Information Technology")
                ) ;
            modelBuilder.Entity<Position>().HasData(
                new Position(1, "Manager"),
                new Position(2, "Team Leader"),
                new Position(3, "Associate")
                );

            var roleid = Guid.NewGuid().ToString();
            var mroleid = Guid.NewGuid().ToString();
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole {Id = roleid, Name = "Administrator",NormalizedName = "ADMINISTRATOR"},

                new IdentityRole{Id = Guid.NewGuid().ToString(),Name = "Employee",NormalizedName = "EMPLOYEE"},

                new IdentityRole{Id = mroleid, Name = "Manager",NormalizedName = "MANAGER"}
                );

            var userId= Guid.NewGuid().ToString();
            var managerId= Guid.NewGuid().ToString();

                  modelBuilder.Entity<ApplicationUser>().HasData(
                 new ApplicationUser
                 {
                     Id = userId,
                     FirstName = "Admin",
                     MiddleName = "Admin",
                     LastName = "Admin",
                     FullName = "Administrator",
                     DepartmentId=1,
                     PositionId=1,
                     Gender = "Male",
                     DateOfBirth = DateTime.Now,
                     Email = "admin@admin.com",
                     NormalizedEmail = "ADMIN@ADMIN.COM",
                     EmailConfirmed = true,
                     UserName = "admin@admin.com",
                     NormalizedUserName = "ADMIN@ADMIN.COM",
                     Phone = "09111111111",
                     Street = "Admin",
                     Barangay = "Admin",
                     City = "Admin",
                     State = "Admin",
                     PostalCode = 123,
                     ActiveStatus=true,

                     PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "admin"),
                     SecurityStamp = String.Empty,
                 }
                 );
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                    new IdentityUserRole<string> { UserId = userId, RoleId = roleid }                  
                );
           
        }
    }
}
