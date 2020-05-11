/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：UserModel.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-05-11 17:22:30
 */

namespace WareHouse.ViewModel
{
    public class UserModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string RoleName { get; set; }

        public string State { get; set; }
    }
}