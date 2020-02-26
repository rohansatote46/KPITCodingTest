using KPITEmployeeProject.infrastructure.Repo.Impl;
using KPITEmployeeProject.infrastructure.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KPITEmployeeProject.Models;
using KPITEmployeeProject.infrastructure.Services.Base;

namespace KPITEmployeeProject.infrastructure.Services.Impl
{
    public class DepartmentService : IDepartmentMaster
    {
        EmployeeEntities _db = BaseClass.Instance();
        private Repository<tblDepartmentMaster> _DepartmentRepository;
        public DepartmentService()
        {
            _DepartmentRepository = new Repository<tblDepartmentMaster>(_db);
        }

        public IEnumerable<tblDepartmentMaster> GetAll()
        {
            return _DepartmentRepository.GetAll();
        }
    }
}