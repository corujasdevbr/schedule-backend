using CorujasDev.Schedulive.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CorujasDev.Schedulive.Domain.Interfaces.Repositories
{
    public interface ILiveRepository
    {
        #region Read
        IQueryable<LiveDomain> GetAll();
        LiveDomain GetById(Guid id);
        IQueryable<LiveDomain> FindBy(Expression<Func<LiveDomain, bool>> predicate);
        #endregion

        #region Write
        void Add(LiveDomain live);
        void Update(LiveDomain live);
        #endregion
    }
}
