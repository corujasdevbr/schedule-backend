using CorujasDev.Schedule.Infra.Data.Context;
using CorujasDev.Schedule.Infra.Data.Repositories;
using CorujasDev.Schedulive.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Xunit;
using Xunit.Priority;

namespace CorujasDev.Schedulive.Tests.Repositories
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class UserRepositoryTest
    {
        private readonly ScheduliveContext _context;

        public UserRepositoryTest()
        {
            DbContextOptions<ScheduliveContext> options = new DbContextOptionsBuilder<ScheduliveContext>()
              .UseInMemoryDatabase(databaseName: "DataBase")
              .Options;

            _context = new ScheduliveContext(options);
        }

        [Fact, Priority(0)]
        public void ValidUserEmpty()
        {
            UserDomain user = new UserDomain("", "", "", "");

            Assert.True(user.Invalid);
        }


        [Fact, Priority(1)]
        public void ValidUserNotEmpty()
        {
            UserDomain user = new UserDomain("Fernando Henrique", "fernando.guerra@tagpet.com.br", "123456789", "Admin");

            Assert.True(user.Valid);
        }


        [Fact, Priority(2)]
        public void ValidAddUser()
        {
            var repo = new UserRepository(_context);
            repo.Add(new UserDomain("Fernando Henrique", "fernando.guerra@tagpet.com.br", "123456789", "Admin"));
            bool retorno = _context.SaveChanges() > 0;

            Assert.True(retorno);
        }

        [Fact, Priority(3)]
        public void ValidListUser()
        {
            var repo = new UserRepository(_context);
            var list = repo.GetAll();

            Assert.True(list.ToList().Count > 0);
        }


    }
}
