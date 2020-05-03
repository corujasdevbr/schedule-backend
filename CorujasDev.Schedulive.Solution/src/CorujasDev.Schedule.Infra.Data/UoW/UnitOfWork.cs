using CorujasDev.Schedule.Infra.Data.Context;
using CorujasDev.Schedulive.Core.Data;
using System;

namespace CorujasDev.Schedule.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ScheduliveContext _context;

        public UnitOfWork(ScheduliveContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public bool RollBack()
        {
            throw new NotImplementedException();
        }
    }
}
