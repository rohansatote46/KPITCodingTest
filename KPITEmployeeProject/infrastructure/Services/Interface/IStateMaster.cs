using KPITEmployeeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPITEmployeeProject.infrastructure.Services.Interface
{
    public interface IStateMaster
    {
        IEnumerable<tblStateMaster> GetAll();
    }
}
