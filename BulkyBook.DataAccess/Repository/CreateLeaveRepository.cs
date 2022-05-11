using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class CreateLeaveRepository : Repository<CreateLeave>, ICreateLeaveRepository
    {
        private ApplicationDbContext _db;

        public CreateLeaveRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(CreateLeave obj)
        {
            var objFromDb = _db.CreateLeaves.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.EmployeeId = obj.EmployeeId;
                objFromDb.LeaveId = obj.LeaveId;
                objFromDb.Fromdate = obj.Fromdate;
                objFromDb.Todate = obj.Todate;
           
              
            }
        }
    }
}
