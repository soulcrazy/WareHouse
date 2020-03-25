/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：Service.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建时间：2020-03-23 11:09:33
 */

using System;

namespace WareHouse.Core.Data
{
    public class Service : IService
    {
        public string Get()
        {
            return Guid.NewGuid().ToString();
        }
    }
}