using CorujasDev.Schedule.Infra.Data.Context;
using CorujasDev.Schedulive.Domain.Entities;
using CorujasDev.Schedulive.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CorujasDev.Schedule.Infra.Data.Repositories
{
    public class LiveRepository : ILiveRepository
    {
        private readonly ScheduliveContext _context;

        public LiveRepository(ScheduliveContext context)
        {
            _context = context;
        }

        public void Add(LiveDomain live)
        {
            _context.Lives.Add(live);
        }

        public void Update(LiveDomain live)
        {
            _context.Lives.Update(live);
        }

        public IQueryable<LiveDomain> FindBy(Expression<Func<LiveDomain, bool>> predicate)
        {
            return _context.Lives.AsNoTracking().Include(x => x.Category).Where(predicate);
        }

        public IQueryable<LiveDomain> GetAll()
        {
            return _context.Lives.AsNoTracking().Include(x => x.Category).AsQueryable();
        }

        public LiveDomain GetById(Guid id)
        {
            return _context.Lives.AsNoTracking().Include(x => x.Category).FirstOrDefault(x => x.Id == id);
        }
    }
}
