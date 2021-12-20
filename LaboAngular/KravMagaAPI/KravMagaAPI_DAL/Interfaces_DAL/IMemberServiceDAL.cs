using KravMagaAPI_DAL.Models_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KravMagaAPI_DAL.Interfaces_DAL
{
    public interface IMemberServiceDAL<TEntity> where TEntity : new()
    {
        BeLoggedModelDAL Create(TEntity member);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity model);
        void Delete(int id);
        TEntity GetById(int id);
    }
}
