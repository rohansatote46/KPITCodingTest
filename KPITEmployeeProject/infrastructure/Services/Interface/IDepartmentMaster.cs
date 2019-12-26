using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KPITEmployeeProject.Models;
namespace KPITEmployeeProject.infrastructure.Services.Interface
{
    public interface IDepartmentMaster
    {
        IEnumerable<tblDepartmentMaster> GetAll();
    }
}