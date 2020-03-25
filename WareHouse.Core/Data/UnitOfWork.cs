using Microsoft.EntityFrameworkCore;
using System;

namespace WareHouse.Core.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WareHouseDbContext _dbContext;

        public UnitOfWork(WareHouseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 保存到数据库
        /// </summary>
        /// <returns></returns>
        public int Commit()
        {
            try
            {
                return _dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                return 0;
            }
        }

        public string Get()
        {
            return Guid.NewGuid().ToString();
        }
    }
}