﻿using SozluKalem.Data.Context;
using SozluKalem.Data.Repositories.Absractions;
using SozluKalem.Data.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozluKalem.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly AppDbContext dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async ValueTask DisposeAsync()
        {
            await dbContext.DisposeAsync();
        }

        public int Save()
        {
            return dbContext.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
           return await dbContext.SaveChangesAsync();   
        }

        IRepository<T> IUnitOfWork.GetRepository<T>()
        {
            return new Repository<T>(dbContext);
        }

    }
}
