using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KPITEmployeeProject.infrastructure.Repo.Interface
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T FindById(int id);
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);

        IEnumerable<T> Search(string query, params object[] parameters);
    }
}
