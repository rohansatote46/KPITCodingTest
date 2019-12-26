using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KPITEmployeeProject.infrastructure.Repo.Impl;
using KPITEmployeeProject.infrastructure.Services.Interface;
using KPITEmployeeProject.Models;
namespace KPITEmployeeProject.infrastructure.Services.Impl
{
    public class StateService : IStateMaster
    {
        private Repository<tblStateMaster> _StateRepository;
        public StateService()
        {
            _StateRepository = new Repository<tblStateMaster>(new EmployeeEntities());
        }

        public IEnumerable<tblStateMaster> GetAll()
        {
            return _StateRepository.GetAll();
        }
    }
}