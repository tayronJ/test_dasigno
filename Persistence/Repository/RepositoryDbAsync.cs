using Application.Interfaces;
using Ardalis.Specification.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class RepositoryDbAsync<T> : RepositoryBase<T>, IRepositoryAsync<T> where T : class
    {
        private readonly TestDasignoContext dbContext;

        public RepositoryDbAsync(TestDasignoContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
