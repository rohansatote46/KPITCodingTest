using KPITEmployeeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPITEmployeeProject.infrastructure.services.Interface
{
    public interface IEmployee
    {
        IEnumerable<tblEmployee> GetAll();

        tblEmployee FindById(int Id);

        bool Save(tblEmployee _empObj);
        bool Delete(tblEmployee _empObj);
        bool Update(tblEmployee _empObj);

        IEnumerable<tblEmployee> SearchEmployees(string SearchText);
    }
}
