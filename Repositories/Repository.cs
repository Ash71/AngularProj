using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AngularProj.Entities;
using AngularProj.Mongo;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace AngularProj.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected IMongoDatabase _db;

        protected IMongoCollection<T> _collection;

        public Repository(IDbProvider dbProvider)
        {
            _db = dbProvider.Database;
        }

        protected async Task<List<T>> Find(FilterDefinition<T> filter)
        {
            return await _collection.Find(filter).ToListAsync();
        }

        protected virtual IMongoQueryable<T> Where(Expression<Func<T, bool>> predicate = null)
        {
            var query = _collection.AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }
            return query;
        }

        protected virtual IMongoQueryable<T> Page(IMongoQueryable<T> query, int page, int size)
        {
            return query.Skip((page - 1) * size).Take(size);
        }


        protected async Task<T> FindByIdAsync(string id)
        {
            var item = await this.Where(d => d.Id == id).FirstOrDefaultAsync();
            return item;
        }

        protected async Task<T> CreateAsync(T item)
        {
            item.Created = DateTime.UtcNow;
            item.Modified= DateTime.UtcNow;
            await _collection.InsertOneAsync(item);
            return item;
        }

        protected async Task<bool> UpdateAsync(string id, T item)
        {
            item.Modified = DateTime.UtcNow;
            var result = await _collection.ReplaceOneAsync(d => d.Id == id, item);
            return result.IsAcknowledged;
        }

        protected async Task<bool> DeleteByIdAsync(string id)
        {
            var result = await _collection.DeleteOneAsync(d => d.Id == id);
            return result.IsAcknowledged;
        }

    }
}