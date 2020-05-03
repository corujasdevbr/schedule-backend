using CorujasDev.Schedule.Infra.Data.Context;
using CorujasDev.Schedulive.Domain.Entities;
using CorujasDev.Schedulive.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CorujasDev.Schedule.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ScheduliveContext _context;

        public CategoryRepository(ScheduliveContext context)
        {
            _context = context;
        }

        public void Add(CategoryDomain category)
        {
            _context.Categories.Add(category);
        }

        public void Update(CategoryDomain category)
        {
            _context.Categories.Update(category);
        }

        public IQueryable<CategoryDomain> FindBy(Expression<Func<CategoryDomain, bool>> predicate)
        {
            return _context.Categories.AsNoTracking().Where(predicate);
        }

        public IQueryable<CategoryDomain> GetAll()
        {
            return _context.Categories.AsNoTracking().AsQueryable();
        }

        public CategoryDomain GetById(Guid id)
        {
            return _context.Categories.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public CategoryDomain GetByName(string name)
        {
            return _context.Categories.AsNoTracking().FirstOrDefault(x => x.Name == name);
        }
    }
}
