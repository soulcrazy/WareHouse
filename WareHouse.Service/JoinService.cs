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
using WareHouse.Core.Exceptions;
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
        private readonly IRegionService _regionService;
        private readonly IGoodsStorageService _goodsStorageService;
        private readonly IStorageRegionService _storageRegionService;

        public JoinService(IServiceProvider serviceProvider)
        {
            _storageService = serviceProvider.GetRequiredService<IStorageService>();
            _goodsService = serviceProvider.GetRequiredService<IGoodsService>();
            _goodsTypeService = serviceProvider.GetRequiredService<IGoodsTypeService>();
            _usersService = serviceProvider.GetRequiredService<IUsersService>();
            _regionService = serviceProvider.GetRequiredService<IRegionService>();
            _goodsStorageService = serviceProvider.GetRequiredService<IGoodsStorageService>();
            _storageRegionService = serviceProvider.GetRequiredService<IStorageRegionService>();
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

        public int Join(GetJoinDto getJoinDto)
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

            if (_goodsStorageService.Find(c => c.GoodsId == goodsId && c.RegionId == getJoinDto.RegionId && c.StorageId == getJoinDto.StorageId && c.State == 0) != null)
            {
                return 3;
            }

            StorageRegion storageRegion = new StorageRegion()
            {
                StorageId = getJoinDto.StorageId,
                RegionId = getJoinDto.RegionId
            };

            //判断仓库中的货物数量是否超出最大容量
            if (_goodsStorageService.GetCountByStorageRegion(storageRegion) >= _storageRegionService.Find(c => c.StorageId == getJoinDto.StorageId && c.RegionId == getJoinDto.RegionId).Capacity)
            {
                return 2;
            }

            GoodsStorage goodsStorage = new GoodsStorage()
            {
                GoodsId = goodsId,
                StorageId = getJoinDto.StorageId,
                RegionId = getJoinDto.RegionId,
                State = 0
            };

            return _goodsStorageService.Add(goodsStorage) ? 0 : 1;
        }

        public List<GoodsStorageModel> GetAll(int state)
        {
            List<GoodsStorageModel> goodsStorageModels = new List<GoodsStorageModel>();
            List<GoodsStorage> goodsStorageList = _goodsStorageService.GetAll(c => c.State == state);
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

        public List<GoodsStorageModel> GetAll()
        {
            List<GoodsStorageModel> goodsStorageModels = new List<GoodsStorageModel>();
            List<GoodsStorage> goodsStorageList = _goodsStorageService.GetAll();
            foreach (var goodsStorage in goodsStorageList)
            {
                GoodsStorageModel tempGoodsStorageModel = new GoodsStorageModel
                {
                    Id = goodsStorage.Id,
                    GoodsName = _goodsService.Find(goodsStorage.GoodsId).Name,
                    StorageName = _storageService.Find(goodsStorage.StorageId).Name,
                    RegionName = _regionService.Find(goodsStorage.RegionId).Name,
                    CreatedTime = goodsStorage.CreatedTime.ToString("F"),
                    State = goodsStorage.State
                };
                goodsStorageModels.Add(tempGoodsStorageModel);
            }

            return goodsStorageModels;
        }

        public GoodsStorageDetailModel Find(int id)
        {
            GoodsStorage goodsStorage = _goodsStorageService.Find(id);
            Goods goods = _goodsService.Find(goodsStorage.GoodsId);
            GoodsStorageDetailModel goodsStorageDetailModel = new GoodsStorageDetailModel()
            {
                GoodsStorageId = goodsStorage.Id,
                GoodsId = goods.Id,
                GoodsName = goods.Name,
                GoodsRemarks = goods.Remarks,
                Weight = goods.Weight,
                TypeId = goods.TypeId,
                TypeName = _goodsTypeService.Find(goods.TypeId).Name,
                UserId = goods.UserId,
                UserName = _usersService.Find(goods.UserId).Name,
                StorageId = goodsStorage.StorageId,
                StorageName = _storageService.Find(goodsStorage.StorageId).Name,
                RegionId = goodsStorage.RegionId,
                RegionName = _regionService.Find(goodsStorage.RegionId).Name,
            };
            return goodsStorageDetailModel;
        }

        public int Update(GetGoodsStorageDetailDto getGoodsStorageDetailDto)
        {
            Goods goods = new Goods()
            {
                Id = getGoodsStorageDetailDto.GoodsId,
                Weight = getGoodsStorageDetailDto.Weight,
                TypeId = getGoodsStorageDetailDto.TypeId,
                UserId = getGoodsStorageDetailDto.UserId,
                Name = getGoodsStorageDetailDto.GoodsName,
                Remarks = getGoodsStorageDetailDto.GoodsRemarks,
                IsWarehousing = 1
            };
            if (!_goodsService.Update(goods))
            {
                throw new BusinessException("修改货物信息失败");
            }

            StorageRegion storageRegion = new StorageRegion()
            {
                StorageId = getGoodsStorageDetailDto.StorageId,
                RegionId = getGoodsStorageDetailDto.RegionId
            };
            if (_goodsStorageService.GetCountByStorageRegion(storageRegion) >= _storageRegionService.Find(c => c.StorageId == getGoodsStorageDetailDto.StorageId && c.RegionId == getGoodsStorageDetailDto.RegionId).Capacity)
            {
                return 2;
            }
            GoodsStorage goodsStorage = _goodsStorageService.Find(getGoodsStorageDetailDto.GoodsStorageId);
            goodsStorage.GoodsId = getGoodsStorageDetailDto.GoodsId;
            goodsStorage.StorageId = getGoodsStorageDetailDto.StorageId;
            goodsStorage.RegionId = getGoodsStorageDetailDto.RegionId;
            return _goodsStorageService.Update(goodsStorage) ? 0 : 1;
        }

        //public List<Region> GetRegion()
        //{
        //    string sql = "select RegionId from storageRegion";
        //    return _repository.SqlQuery<Region>(sql, null).ToList();
        //}
    }
}