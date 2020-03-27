using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WareHouse.Entity;

namespace WareHouse.Core.Data
{
    public interface IRepository<TEntity, in TKey> where TEntity : BaseEntity<TKey>
    {
        DbSet<TEntity> Entities { get; }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity"></param>
        void Add(TEntity entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        void Delete(TEntity entity);

        /// <summary>
        /// 根据id删除
        /// </summary>
        /// <param name="id"></param>
        void Delete(TKey id);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        void Update(TEntity entity);

        /// <summary>
        /// 根据ID查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TEntity Find(TKey id);

        /// <summary>
        /// 条件查询单条数据
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        TEntity Find(Expression<Func<TEntity, bool>> whereExpression);

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="whereExpression"></param>
        /// <returns></returns>
        List<TEntity> Select(Expression<Func<TEntity, bool>> whereExpression);

        /// <summary>
        /// 条件查询
        /// </summary>
        /// <typeparam name="TOrder"></typeparam>
        /// <param name="whereExpression"></param>
        /// <param name="orderExpression"></param>
        /// <param name="isDesc"></param>
        /// <returns></returns>
        List<TEntity> Select<TOrder>(Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, TOrder>> orderExpression, bool isDesc = true);

        #region 分页查询

        /// <summary>
        /// 分页条件查询
        /// </summary>
        /// <typeparam name="TOrder"></typeparam>
        /// <param name="pager"></param>
        /// <param name="whereExpression"></param>
        /// <param name="orderExpression"></param>
        /// <param name="isDesc"></param>
        /// <returns></returns>
        IPageResult<TEntity> Select<TOrder>(IPager pager, Expression<Func<TEntity, bool>> whereExpression, Expression<Func<TEntity, TOrder>> orderExpression, bool isDesc = true);

        #endregion 分页查询
    }
}