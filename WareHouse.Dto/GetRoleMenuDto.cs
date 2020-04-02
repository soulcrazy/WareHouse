/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：GetRoleMenuDto.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-04-02 20:24:07
 */

namespace WareHouse.Dto
{
    public class GetRoleMenuDto
    {
        public int RoleId { get; set; }

        public int[] MenuArray { get; set; }
    }
}