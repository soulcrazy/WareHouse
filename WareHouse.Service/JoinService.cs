/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：JoinService.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-03-30 20:36:52
 */

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using WareHouse.Core.Data;
using WareHouse.Entity;
using WareHouse.IService;
using WareHouse.ViewModel;

namespace WareHouse.Service
{
    public class JoinService : IJoinService
    {
        private readonly IStorageService _storageService;
        private readonly IGoodsTypeService _goodsTypeService;
        private readonly IRepository<StorageRegion, int> _repository;

        public JoinService(IServiceProvider serviceProvider)
        {
            _storageService = serviceProvider.GetRequiredService<IStorageService>();
            _goodsTypeService = serviceProvider.GetRequiredService<IGoodsTypeService>();
            _repository = serviceProvider.GetRequiredService<IRepository<StorageRegion, int>>();
        }

        public string Get()
        {
            return Guid.NewGuid().ToString();
        }

        public JoinModel GetJoinModel()
        {
            JoinModel joinModel = new JoinModel()
            {
                GoodsTypeList = _goodsTypeService.GetAll(),
                StorageList = _storageService.GetAll()
            };
            return joinModel;
        }

        public List<Region> GetRegion()
        {
            string sql = "select RegionId from storageRegion";
            return _repository.SqlQuery<Region>(sql, null).ToList();
        }
    }
}