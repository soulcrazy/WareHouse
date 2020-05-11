/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：HomeService.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-05-11 15:26:45
 */

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using WareHouse.Entity;
using WareHouse.Service.Interface;
using WareHouse.ViewModel;

namespace WareHouse.Service
{
    public class HomeService : IHomeService
    {
        private readonly IUsersService _usersService;
        private readonly IStorageService _storageService;
        private readonly IRegionService _regionService;
        private readonly IGoodsService _goodsService;
        private readonly IGoodsStorageService _goodsStorageService;
        private readonly IStorageRegionService _storageRegionService;

        public HomeService(IServiceProvider serviceProvider)
        {
            _goodsService = serviceProvider.GetRequiredService<IGoodsService>();
            _regionService = serviceProvider.GetRequiredService<IRegionService>();
            _storageService = serviceProvider.GetRequiredService<IStorageService>();
            _usersService = serviceProvider.GetRequiredService<IUsersService>();
            _goodsStorageService = serviceProvider.GetRequiredService<IGoodsStorageService>();
            _storageRegionService = serviceProvider.GetRequiredService<IStorageRegionService>();
        }

        public string Get()
        {
            return Guid.NewGuid().ToString();
        }

        public HomeModel GetHomeModel()
        {
            List<Storage> storageList = _storageService.GetAll();
            HomeModel homeModel = new HomeModel()
            {
                UserTotal = _usersService.GetUsers().Count,
                GoodsTotal = _goodsService.GetAll().Count,
                StorageTotal = storageList.Count,
                RegionTotal = _regionService.GetAll().Count
            };

            var storageInfoList = new List<ViewModel.StorageInfo>();
            foreach (var storage in storageList)
            {
                ViewModel.StorageInfo temp = new StorageInfo()
                {
                    JoinTotal = _goodsStorageService.GetAll(c => c.StorageId == storage.Id && c.State == 0).Count,
                    StorageName = storage.Name
                };
                List<StorageRegion> storageRegions = _storageRegionService.GetAll(c => c.StorageId == storage.Id);
                int total = 0;
                foreach (var storageRegion in storageRegions)
                {
                    total += storageRegion.Capacity;
                }

                temp.Capacity = total - temp.JoinTotal;
                storageInfoList.Add(temp);
            }

            homeModel.StorageInfos = storageInfoList;
            return homeModel;
        }
    }
}