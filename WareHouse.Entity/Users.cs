using System;

namespace WareHouse.Entity
{
    public class Users : BaseEntity<int>
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string CorporateName { get; set; }

        /// <summary>
        /// 邮编
        /// </summary>
        public string PostCode { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public int Role { get; set; }
    }
}