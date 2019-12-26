using KPITEmployeeProject.infrastructure.Repo.Interface;
using KPITEmployeeProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace KPITEmployeeProject.infrastructure.Repo.Impl
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly EmployeeEntities DBcontext;
        public Repository(EmployeeEntities context)
        {
            DBcontext = context;
        }

        public bool Delete(T entity)
        {
            DBcontext.DatabaseSet<T>().Remove(entity);
            try
            {
                DBcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public T FindById(int id)
        {
            return DBcontext.DatabaseSet<T>().Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return DBcontext.DatabaseSet<T>().AsEnumerable();
        }

        public bool Insert(T entity)
        {
            DBcontext.DatabaseSet<T>().Add(entity);
            try
            {
                DBcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public IEnumerable<T> Search(string query, params object[] parameters)
        {
            return DBcontext.Database.SqlQuery<T>(query, parameters);
        }

        public bool Update(T entity)
        {
            DBcontext.Entry<T>(entity).State = EntityState.Modified;
            try
            {
                DBcontext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}