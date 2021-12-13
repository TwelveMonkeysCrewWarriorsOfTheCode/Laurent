using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KravMagaAPI_DAL.Interfaces_DAL
{
    public interface ICRUDServiceDAL<TEntity> where TEntity : new()
    {
        void Create(TEntity member);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity model);
        void Delete(int id);
        TEntity GetById(int id);
    }
}
