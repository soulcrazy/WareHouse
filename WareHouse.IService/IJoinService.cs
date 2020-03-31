/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：IJoinService.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-03-30 20:35:43
 */

using System.Collections.Generic;
using WareHouse.Core.Data;
using WareHouse.Dto;
using WareHouse.ViewModel;

namespace WareHouse.Service.Interface
{
    public interface IJoinService : IBaseService
    {
        JoinModel GetJoinModel();

        bool Join(GetJoinDto getJoinDto);

        List<GoodsStorageModel> GetAll(int state);
    }
}