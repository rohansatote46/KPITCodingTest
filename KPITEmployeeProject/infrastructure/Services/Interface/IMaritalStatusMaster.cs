using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KPITEmployeeProject.Models;
namespace KPITEmployeeProject.infrastructure.Services.Interface
{
    public interface IMaritalStatusMaster
    {
        IEnumerable<tblMaritalStatusMaster> GetAll();
    }
}
