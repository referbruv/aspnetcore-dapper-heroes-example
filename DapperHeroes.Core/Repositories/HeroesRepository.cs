using DapperHeroes.Contracts;
using DapperHeroes.Contracts.Entities;
using DapperHeroes.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DapperHeroes.Core.Repositories
{
    public class HeroesRepository : IHeroesRepository
    {
        private readonly HeroesContext _context;

        public HeroesRepository(HeroesContext context)
        {
            _context = context;
        }

        public IEnumerable<Hero> All(int page, int maxRecords)
        {
            return _context.Heroes.AsNoTracking().OrderByDescending(x => x.Created).Skip((page - 1) * maxRecords).Take(maxRecords);
        }

        public Hero Create(Hero hero)
        {
            hero.Created = DateTime.Now;
            _context.Heroes.Add(hero);
            _context.SaveChanges();
            return hero;
        }

        public void Delete(long id)
        {
            Hero index = _context.Heroes.Find(id);
            if (index != null)
            {
                _context.Heroes.Remove(index);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Hero> SearchByName(string heroName)
        {
            return _context.Heroes.AsNoTracking().Where(x => x.Name.Contains(heroName) || heroName.Contains(x.Name));
        }

        public Hero Single(long id)
        {
            return _context.Heroes.AsNoTracking().Single(x => x.Id == id);
        }

        public Hero Update(long id, Hero model)
        {
            model.Id = id;
            _context.Heroes.Attach(model);
            _context.SaveChanges();

            return model;
        }
    }
}
