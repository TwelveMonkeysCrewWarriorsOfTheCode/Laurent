using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoptDevDAL.Interfaces
{
    public interface ICRUDService<TEntity> where TEntity : new()
    {
        TEntity CreateIdReturn(TEntity model);
        void Create(TEntity model);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity model);
        void Delete(int id);
        TEntity GetById(int id);
    }
}
