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
using WareHouse.Core.Data;
using WareHouse.Dto;
using WareHouse.Entity;
using WareHouse.Service.Interface;
using WareHouse.ViewModel;

namespace WareHouse.Service
{
    public class JoinService : IJoinService
    {
        private readonly IStorageService _storageService;
        private readonly IGoodsService _goodsService;
        private readonly IGoodsTypeService _goodsTypeService;
        private readonly IUsersService _usersService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRegionService _regionService;
        private readonly IRepository<GoodsStorage, int> _goodsStorage;

        public JoinService(IServiceProvider serviceProvider)
        {
            _storageService = serviceProvider.GetRequiredService<IStorageService>();
            _goodsService = serviceProvider.GetRequiredService<IGoodsService>();
            _goodsTypeService = serviceProvider.GetRequiredService<IGoodsTypeService>();
            _usersService = serviceProvider.GetRequiredService<IUsersService>();
            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
            _regionService = serviceProvider.GetRequiredService<IRegionService>();
            _goodsStorage = serviceProvider.GetRequiredService<IRepository<GoodsStorage, int>>();
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
                StorageList = _storageService.GetAll(),
                UsersList = _usersService.GetUsers()
            };
            return joinModel;
        }

        public bool Join(GetJoinDto getJoinDto)
        {
            Goods goods = new Goods()
            {
                Weight = getJoinDto.Weight,
                TypeId = getJoinDto.TypeId,
                UserId = getJoinDto.UserId,
                Name = getJoinDto.Name,
                Remarks = getJoinDto.Remarks,
                IsWarehousing = 1
            };
            _goodsService.Add(goods);
            int goodsId = _goodsService.GetId(goods);

            if (_goodsStorage.Find(c => c.GoodsId == goodsId && c.RegionId == getJoinDto.RegionId && c.StorageId == getJoinDto.StorageId && c.State == 0) != null)
            {
                return false;
            }

            GoodsStorage goodsStorage = new GoodsStorage()
            {
                GoodsId = goodsId,
                StorageId = getJoinDto.StorageId,
                RegionId = getJoinDto.RegionId,
                State = 0
            };

            _goodsStorage.Add(goodsStorage);
            return _unitOfWork.Commit() > 0;
        }

        public List<GoodsStorageModel> GetAll(int state)
        {
            List<GoodsStorageModel> goodsStorageModels = new List<GoodsStorageModel>();
            List<GoodsStorage> goodsStorageList = _goodsStorage.Select(c => c.State == state);
            foreach (var goodsStorage in goodsStorageList)
            {
                GoodsStorageModel tempGoodsStorageModel = new GoodsStorageModel
                {
                    Id = goodsStorage.Id,
                    GoodsName = _goodsService.Find(goodsStorage.GoodsId).Name,
                    StorageName = _storageService.Find(goodsStorage.StorageId).Name,
                    RegionName = _regionService.Find(goodsStorage.RegionId).Name,
                    CreatedTime = goodsStorage.CreatedTime.ToString("F")
                };
                goodsStorageModels.Add(tempGoodsStorageModel);
            }

            return goodsStorageModels;
        }

        //public List<Region> GetRegion()
        //{
        //    string sql = "select RegionId from storageRegion";
        //    return _repository.SqlQuery<Region>(sql, null).ToList();
        //}
    }
}