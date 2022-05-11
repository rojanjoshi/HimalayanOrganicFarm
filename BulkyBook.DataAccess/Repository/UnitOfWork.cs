using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
     
            ApplicationUser = new ApplicationUserRepository(_db);
            Department = new DepartmentRepository(_db);
            Designation = new DesignationRepository(_db);

            Employee = new EmployeeRepository(_db);

            Salary = new SalaryRepository(_db);
            Leave = new LeaveRepository(_db);

            CreateLeave = new CreateLeaveRepository(_db);
            Vaccancy = new VaccancyRepository(_db);

        }
        public IDepartmentRepository Department { get; private set; }
        public IDesignationRepository Designation { get; private set; }

        public IEmployeeRepository Employee { get; private set; }

        public ISalaryRepository Salary { get; private set; }

        public ILeaveRepository Leave { get; private set; }

        public ICreateLeaveRepository CreateLeave { get; private set; }

        public IVaccancyRepository Vaccancy { get; private set; }




        public IApplicationUserRepository ApplicationUser {  get; private set; }


               public void Save()
        {
            _db.SaveChanges();
        }
    }
}
