using System;

namespace CorujasDev.Schedulive.Core.Data
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();

        bool RollBack();
    }
}
