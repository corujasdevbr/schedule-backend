using CorujasDev.Schedulive.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CorujasDev.Schedulive.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        #region Read
        IQueryable<CategoryDomain> GetAll();
        CategoryDomain GetById(Guid id);
        CategoryDomain GetByName(string name);
        IQueryable<CategoryDomain> FindBy(Expression<Func<CategoryDomain, bool>> predicate);
        #endregion

        #region Write
        void Add(CategoryDomain Category);
        void Update(CategoryDomain Category);
        #endregion
    }
}
