/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：IHomeService.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-05-11 15:23:50
 */

using WareHouse.Core.Data;
using WareHouse.ViewModel;

namespace WareHouse.Service.Interface
{
    public interface IHomeService : IBaseService
    {
        HomeModel GetHomeModel();
    }
}