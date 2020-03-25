namespace WareHouse.Entity
{
    public class Goods : BaseEntity<int>
    {
        /// <summary>
        /// 货物重量(单位kg)
        /// </summary>
        public float Weight { get; set; }

        /// <summary>
        ///货物种类ID
        /// </summary>
        public int TypeId { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// 货物名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 货物备注
        /// </summary>
        public string Remarks { get; set; }
    }
}