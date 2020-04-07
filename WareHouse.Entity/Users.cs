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
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 角色
        /// </summary>
        public int RoleId { get; set; }

        /// <summary>
        /// 状态，0禁用1启用
        /// </summary>
        public int State { get; set; }
    }
}