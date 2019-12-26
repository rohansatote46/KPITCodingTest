using KPITEmployeeProject.infrastructure.Repo.Impl;
using KPITEmployeeProject.infrastructure.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KPITEmployeeProject.Models;
namespace KPITEmployeeProject.infrastructure.Services.Impl
{
    public class DepartmentService : IDepartmentMaster
    {
        private Repository<tblDepartmentMaster> _DepartmentRepository;
        public DepartmentService()
        {
            _DepartmentRepository = new Repository<tblDepartmentMaster>(new EmployeeEntities());
        }

        public IEnumerable<tblDepartmentMaster> GetAll()
        {
            return _DepartmentRepository.GetAll();
        }
    }
}