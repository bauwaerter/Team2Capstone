using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Team2Capstone.Core
{
    public class Repository : IRepository
    {

        private readonly DbContext _dbContext;
        
        public DbContext Context { get; private set; }
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            Context = _dbContext;
        }

        public Repository()
        {
        }
        //public void GetSomething<TEntity, TEntity2>(Expression<Func<TEntity, TEntity2, bool>> predicate) where TEntity : TEntity2 : class
        //{

        //}

        // get a entity (expression) id == eventid
        public TEntity Get<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return _dbContext.Set<TEntity>().Where(predicate).FirstOrDefault();
        }

        public async Task<TEntity> GetAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return await _dbContext.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();
        }
        // get all rows up <TEntity> table
        public IEnumerable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return _dbContext.Set<TEntity>();
        }
        // get all rows up <TEntity> table where (userType == 'admin')
        public IEnumerable<TEntity> GetAll<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            return _dbContext.Set<TEntity>().Where(predicate);
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public async Task UpdateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public TEntity Add<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Set<TEntity>().Add(entity);
            try
            {
                _dbContext.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException e)
            {
                foreach (var validationErrors in e.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
            return entity;
        }

        public async Task AddAsync<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Set<TEntity>().Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void Delete<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            _dbContext.Set<TEntity>().Remove(_dbContext.Set<TEntity>().Find(predicate));
            _dbContext.SaveChanges();
        }

        public async Task DeleteAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            _dbContext.Set<TEntity>().Remove(_dbContext.Set<TEntity>().Find(predicate));
            await _dbContext.SaveChangesAsync();
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public async Task DeleteAsync<TEntity>(TEntity entity) where TEntity : class
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

    }

}