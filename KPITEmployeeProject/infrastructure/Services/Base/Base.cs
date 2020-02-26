using KPITEmployeeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KPITEmployeeProject.infrastructure.Services.Base
{
    public class BaseClass
    {
        public static EmployeeEntities db;

        protected BaseClass()
        {

        }
        public static EmployeeEntities Instance()
        {
            if (db == null)
            {
                db = new EmployeeEntities();
            }

            return db;
        }
    }
}