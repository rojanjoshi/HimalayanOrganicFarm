using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class VaccancyRepository : Repository<Vaccancy>, IVaccancyRepository
    {
        private ApplicationDbContext _db;

        public VaccancyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Vaccancy obj)
        {
            var objFromDb = _db.Vaccancys.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.DesignationId = obj.DesignationId;
                objFromDb.Nposition = obj.Nposition;
                objFromDb.Startdate = obj.Startdate;
                objFromDb.Deadline = obj.Deadline;
         
              
            }
        }
    }
}
