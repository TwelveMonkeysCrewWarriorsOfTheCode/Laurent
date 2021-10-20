using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoptDevMVCDAL.Interfaces
{
    public interface ICRUDRequester<TEntity> where TEntity : new()
    {
        TEntity CreateIdReturn(TEntity model);
        void Create(TEntity model);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Update(TEntity model);        
        void Delete(int id);
    }
}
