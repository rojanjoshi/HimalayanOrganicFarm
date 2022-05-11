using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class SalaryRepository : Repository<Salary>, ISalaryRepository
    {
        private ApplicationDbContext _db;

        public SalaryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Salary obj)
        {
            var objFromDb = _db.Salarys.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.DesignationId = obj.DesignationId;
                objFromDb.TSalary = obj.TSalary;
               
            }
        }
    }
}
