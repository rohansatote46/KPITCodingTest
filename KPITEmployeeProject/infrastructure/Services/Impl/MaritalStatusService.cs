using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KPITEmployeeProject.infrastructure.Repo.Impl;
using KPITEmployeeProject.infrastructure.Services.Base;
using KPITEmployeeProject.infrastructure.Services.Interface;
using KPITEmployeeProject.Models;
namespace KPITEmployeeProject.infrastructure.Services.Impl
{
    public class MaritalStatusService : IMaritalStatusMaster
    {
        EmployeeEntities _db = BaseClass.Instance();
        private Repository<tblMaritalStatusMaster> _MaritalStatusRepository;
        public MaritalStatusService()
        {
            _MaritalStatusRepository = new Repository<tblMaritalStatusMaster>(_db);
        }
        public IEnumerable<tblMaritalStatusMaster> GetAll()
        {
            return _MaritalStatusRepository.GetAll();
        }
    }
}