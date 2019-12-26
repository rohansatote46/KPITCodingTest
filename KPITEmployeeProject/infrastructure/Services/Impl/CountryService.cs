using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KPITEmployeeProject.infrastructure.Repo.Impl;
using KPITEmployeeProject.infrastructure.Services.Interface;
using KPITEmployeeProject.Models;
namespace KPITEmployeeProject.infrastructure.Services.Impl
{
    public class CountryService : ICountryMaster
    {
        private Repository<tblCountryMaster> _CountryRepository;
        public CountryService()
        {
            _CountryRepository = new Repository<tblCountryMaster>(new EmployeeEntities());
        }

        public IEnumerable<tblCountryMaster> GetAll()
        {
            return _CountryRepository.GetAll();
        }
    }
}