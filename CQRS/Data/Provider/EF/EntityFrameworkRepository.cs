﻿namespace Incoding.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Incoding.Extensions;
    using Microsoft.EntityFrameworkCore;
    public class EntityFrameworkRepository : IRepository
    {
        readonly DbContext session;
        public EntityFrameworkRepository(DbContext session)
        {
            this.session = session;
        }

        public EntityFrameworkRepository() { }


        public void ExecuteSql(string sql)
        {
            session.Database.ExecuteSqlCommand(sql);
        }

        public TProvider GetProvider<TProvider>() where TProvider : class
        {
            return session as TProvider;
        }

        public void Save<TEntity>(TEntity entity) where TEntity : class, IEntity, new()
        {
            session.Set<TEntity>().Add(entity);
        }

        public void Saves<TEntity>(IEnumerable<TEntity> entities) where TEntity : class, IEntity, new()
        {
            foreach (var entity in entities)
                Save(entity);
        }

        public void Flush()
        {
            session.SaveChanges();
        }

        public void SaveOrUpdate<TEntity>(TEntity entity) where TEntity : class, IEntity, new()
        {
            if (session.Entry(entity).State == EntityState.Detached)
                session.Set<TEntity>().Add(entity);
        }

        public void Delete<TEntity>(int id) where TEntity : class, IEntity, new()
        {
            Delete(GetById<TEntity>(id));
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class, IEntity, new()
        {
            session.Set<TEntity>().Remove(entity);
        }

     

        public TEntity GetById<TEntity>(int id) where TEntity : class, IEntity, new()
        {
            return session.Set<TEntity>().FirstOrDefault(r => r.Id == id);
        }

        public TEntity LoadById<TEntity>(int id) where TEntity : class, IEntity, new()
        {
            return session.Set<TEntity>().Find(id);
        }

        public IQueryable<TEntity> Query<TEntity>(OrderSpecification<TEntity> orderSpecification = null, Specification<TEntity> whereSpecification = null, FetchSpecification<TEntity> fetchSpecification = null, PaginatedSpecification paginatedSpecification = null) where TEntity : class, IEntity, new()
        {
            return session.Set<TEntity>().AsQueryable().Query(orderSpecification, whereSpecification, fetchSpecification, paginatedSpecification);
        }

        public IncPaginatedResult<TEntity> Paginated<TEntity>(PaginatedSpecification paginatedSpecification, OrderSpecification<TEntity> orderSpecification = null, Specification<TEntity> whereSpecification = null, FetchSpecification<TEntity> fetchSpecification = null) where TEntity : class, IEntity, new()
        {
            return session.Set<TEntity>().AsQueryable().Paginated(orderSpecification, whereSpecification, fetchSpecification, paginatedSpecification);
        }

        public void Clear() { }


    }
}