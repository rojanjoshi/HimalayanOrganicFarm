using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class DesignationRepository : Repository<Designation>, IDesignationRepository
    {
        private ApplicationDbContext _db;

        public DesignationRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Designation obj)
        {
            _db.Designations.Update(obj);
        }
    }
}
