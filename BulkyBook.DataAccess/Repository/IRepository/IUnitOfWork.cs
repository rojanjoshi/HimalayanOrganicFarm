using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
       
        IApplicationUserRepository ApplicationUser {  get; }

       
        IDepartmentRepository Department { get; }
        IDesignationRepository Designation { get; }

        IEmployeeRepository Employee { get; }

        ISalaryRepository Salary { get; }

        ILeaveRepository Leave { get; }

        ICreateLeaveRepository CreateLeave { get; }

        IVaccancyRepository Vaccancy { get; }


        void Save();
    }
}
