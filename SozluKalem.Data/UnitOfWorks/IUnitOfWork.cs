﻿using SozluKalem.Core.Entities;
using SozluKalem.Data.Repositories.Absractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SozluKalem.Data.UnitOfWorks
{
    public interface IUnitOfWork :IAsyncDisposable
    {
        IRepository<T> GetRepository<T>() where T : class, IEntityBase, new();

        Task<int> SaveAsync();
        int Save();

    }
}
