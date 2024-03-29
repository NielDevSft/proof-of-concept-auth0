﻿using Authentication.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Authentication.Domain.Core.Interfaces
{
    public interface IRepository<TEntity>: IDisposable where TEntity: Entity<TEntity>
    {
        void Add(TEntity obj);

        void Update(TEntity obj);
        TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate, params string[] includes);
        IEnumerable<TEntity> FindAll(params string[] includes);
        IEnumerable<TEntity> FindAllWhere(Expression<Func<TEntity, bool>> predicate, params string[] includes);
        TEntity GetById(int id, params string[] includes);
        void Remove(int id);
        int SaveChanges();
    }
}

