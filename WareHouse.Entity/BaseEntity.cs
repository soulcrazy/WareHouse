using System;
using System.ComponentModel.DataAnnotations;

namespace WareHouse.Entity
{
    public class BaseEntity<TKey>
    {
        /// <summary>
        /// 主键
        /// </summary>
        public TKey Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreatedTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime ModifyTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 行版本（实现乐观锁，控制并发）
        /// </summary>
        [Timestamp, ConcurrencyCheck]
        public byte[] RowVersion { get; set; }
    }
}