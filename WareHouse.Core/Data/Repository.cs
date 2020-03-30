using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WareHouse.Entity;

namespace WareHouse.Core.Data
{
    public class Repository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        private readonly WareHouseDbContext _dbContext;

        public Repository(WareHouseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DbSet<TEntity> Entities => _dbContext.Set<TEntity>();

        public void Add(TEntity entity)
        {
            Entities.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }

        public void Delete(TKey id)
        {
            var entity = Find(id);
            Delete(entity);
        }

        public void Update(TEntity entity)
        {
            Entities.Update(entity);
        }

        public TEntity Find(TKey id)
        {
            return Entities.Find(id);
        }

        public TEntity Find(Expression<Func<TEntity, bool>> whereExpression)
        {
            return Entities.Where(whereExpression).FirstOrDefault();
        }

        public List<TEntity> Select(Expression<Func<TEntity, bool>> whereExpression)
        {
            return Entities.Where(whereExpression).ToList();
        }

        public List<TEntity> Select<TOrder>(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, TOrder>> orderExpression, bool isDesc = true)
        {
            if (isDesc)
            {
                return Entities.Where(whereExpression).OrderByDescending(orderExpression).ToList();
            }
            return Entities.Where(whereExpression).OrderBy(orderExpression).ToList();
        }

        public IPageResult<TEntity> Select<TOrder>(IPager pager, Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, TOrder>> orderExpression, bool isDesc = true)
        {
            var pageResult = new PageResult<TEntity>(pager)
            {
                Total = Entities.Where(whereExpression).Count()
            };
            if (isDesc)
            {
                //降序
                pageResult.Rows = Entities.Where(whereExpression).OrderByDescending(orderExpression)
                    .Skip((pager.PageIndex - 1) * pager.PageSize).Take(pager.PageSize).AsNoTracking().ToList();
                //return Entities.Where(whereExpression).OrderByDescending(orderExpression).ToList();
            }
            else
            {
                //升序
                pageResult.Rows = Entities.Where(whereExpression).OrderBy(orderExpression)
                    .Skip((pager.PageIndex - 1) * pager.PageSize).Take(pager.PageSize).AsNoTracking().ToList();
            }
            //return Entities.Where(whereExpression).OrderBy(orderExpression).ToList();
            return pageResult;
        }

        public List<TResult> SqlQuery<TResult>(string sql, object param)
        {
            return _dbContext.Database.GetDbConnection().Query<TResult>(sql, param).ToList();
        }
    }
}