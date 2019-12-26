using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KPITEmployeeProject.infrastructure.Repo.Impl;
using KPITEmployeeProject.infrastructure.Services.Interface;
using KPITEmployeeProject.Models;
namespace KPITEmployeeProject.infrastructure.Services.Impl
{
    public class GenderService:IGenderMaster
    {
        private Repository<tblGenderMaster> _GenderRepository;
        public GenderService()
        {
            _GenderRepository = new Repository<tblGenderMaster>(new EmployeeEntities());
        }
        public IEnumerable<tblGenderMaster> GetAll()
        {
            return _GenderRepository.GetAll();
        }
    }
}