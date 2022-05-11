using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private ApplicationDbContext _db;

        public EmployeeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Employee obj)
        {
            var objFromDb = _db.Employees.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = obj.Name;
                objFromDb.Email = obj.Email;
                objFromDb.Phone = obj.Phone;
                objFromDb.Address = obj.Address;
                
                objFromDb.DesignationId = obj.DesignationId;
                
                objFromDb.DepartmentId = obj.DepartmentId;
                objFromDb.Salary = obj.Salary;
              
            }
        }
    }
}
