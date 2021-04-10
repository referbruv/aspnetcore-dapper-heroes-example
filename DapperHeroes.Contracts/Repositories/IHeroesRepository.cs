using DapperHeroes.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DapperHeroes.Contracts.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> All(int page, int maxRecords);
        T Create(T hero);
        void Delete(long id);
        IEnumerable<T> SearchByName(string heroName);
        T Single(long id);
        T Update(long id, T model);
    }

    public interface IHeroesRepository : IRepository<Hero> { }
}
