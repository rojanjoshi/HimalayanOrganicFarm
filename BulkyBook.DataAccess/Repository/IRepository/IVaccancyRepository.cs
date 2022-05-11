using BulkyBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IVaccancyRepository : IRepository<Vaccancy>
    {
        void Update(Vaccancy obj);
    }
}
