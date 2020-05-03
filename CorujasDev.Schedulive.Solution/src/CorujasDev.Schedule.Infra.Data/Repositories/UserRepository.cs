using CorujasDev.Schedule.Infra.Data.Context;
using CorujasDev.Schedulive.Domain.Entities;
using CorujasDev.Schedulive.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CorujasDev.Schedule.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ScheduliveContext _context;

        public UserRepository(ScheduliveContext context)
        {
            _context = context;
        }

        public void Add(UserDomain user)
        {
            _context.Users.Add(user);
        }

        public void Update(UserDomain user)
        {
            _context.Users.Update(user);
        }

        public IQueryable<UserDomain> FindBy(Expression<Func<UserDomain, bool>> predicate)
        {
            return _context.Users.AsNoTracking().Where(predicate);
        }

        public IQueryable<UserDomain> GetAll()
        {
            return _context.Users.AsNoTracking().AsQueryable();
        }

        public UserDomain GetByEmail(string email)
        {
            return _context.Users.AsNoTracking().FirstOrDefault(x => x.Email == email);
        }

        public UserDomain GetById(Guid id)
        {
            return _context.Users.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
    }
}
