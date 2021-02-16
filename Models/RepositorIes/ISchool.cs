using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firstPrjAspCore.Models.RepositorIes
{
    public interface ISchool<TEntity>
    {
        //TEntity Get(int id);
        //IEnumerable<TEntity> GetEntitis();
        IList<TEntity> List();

        TEntity find(int id);

        void Add(TEntity eEntity);

        void Update(int id ,TEntity eEntity);

        void Delete(int id);

    }
}
