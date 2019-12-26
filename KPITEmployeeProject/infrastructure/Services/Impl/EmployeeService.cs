using KPITEmployeeProject.infrastructure.Repo.Impl;
using KPITEmployeeProject.infrastructure.services.Interface;
using KPITEmployeeProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KPITEmployeeProject.infrastructure.Services.Impl
{
    public class EmployeeService : IEmployee
    {
        private Repository<tblEmployee> _EmpRepository;
        public EmployeeService()
        {
            _EmpRepository = new Repository<tblEmployee>(new EmployeeEntities());
        }
        public bool Delete(tblEmployee _empObj)
        {
            return _EmpRepository.Delete(_empObj);
        }

        public tblEmployee FindById(int Id)
        {
            return _EmpRepository.FindById(Id);
        }

        public IEnumerable<tblEmployee> GetAll()
        {
            return _EmpRepository.GetAll();
        }

        public bool Save(tblEmployee _empObj)
        {
            return _EmpRepository.Insert(_empObj);
        }

        public IEnumerable<tblEmployee> SearchEmployees(string SearchText)
        {
            return _EmpRepository.Search("sp_SearchEmployee @SearchText", new SqlParameter("SearchText", SqlDbType.NVarChar) { Value = SearchText });
        }

        public bool Update(tblEmployee _empObj)
        {
            return _EmpRepository.Update(_empObj);
        }
    }
}