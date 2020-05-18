/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：LeaveService.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-04-01 16:50:23
 */

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WareHouse.Core.Data;
using WareHouse.Entity;
using WareHouse.Service.Interface;
using WareHouse.ViewModel;

namespace WareHouse.Service
{
    public class LeaveService : ILeaveService
    {
        private readonly IGoodsStorageService _goodsStorageService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGoodsService _goodsService;
        private readonly IStorageService _storageService;
        private readonly IRegionService _regionService;
        private readonly IGoodsTypeService _goodsTypeService;
        private readonly IUsersService _usersService;
        private readonly IRepository<GoodsLeave, int> _repository;

        public LeaveService(IServiceProvider serviceProvider)
        {
            _goodsStorageService = serviceProvider.GetRequiredService<IGoodsStorageService>();
            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
            _goodsService = serviceProvider.GetRequiredService<IGoodsService>();
            _regionService = serviceProvider.GetRequiredService<IRegionService>();
            _storageService = serviceProvider.GetRequiredService<IStorageService>();
            _goodsTypeService = serviceProvider.GetRequiredService<IGoodsTypeService>();
            _usersService = serviceProvider.GetRequiredService<IUsersService>();
            _repository = serviceProvider.GetRequiredService<IRepository<GoodsLeave, int>>();
        }

        public string Get()
        {
            return Guid.NewGuid().ToString();
        }

        public bool Leave(int id)
        {
            if (id <= 0)
            {
                return false;
            }
            GoodsStorage goodsStorage = _goodsStorageService.Find(id);
            if (goodsStorage == null)
            {
                return false;
            }

            goodsStorage.State = 1;
            _goodsStorageService.Update(goodsStorage);

            GoodsLeave goodsLeave = new GoodsLeave()
            {
                GoodsId = goodsStorage.GoodsId,
                RegionId = goodsStorage.RegionId,
                StorageId = goodsStorage.StorageId
            };

            _repository.Add(goodsLeave);
            return _unitOfWork.Commit() > 0;
        }

        public bool Delete(GoodsLeave goodsLeave)
        {
            _repository.Delete(goodsLeave);
            return _unitOfWork.Commit() > 0;
        }

        public List<GoodsLeave> GetAll(Expression<Func<GoodsLeave, bool>> whereExpression)
        {
            return _repository.Select(whereExpression);
        }

        public List<GoodsStorageModel> GetAll()
        {
            List<GoodsStorageModel> goodsStorageModels = new List<GoodsStorageModel>();
            List<GoodsLeave> goodsStorageList = _repository.Select(c => true);
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

        public GoodsStorageDetailModel Find(int id)
        {
            GoodsLeave goodsLeave = _repository.Find(id);
            Goods goods = _goodsService.Find(goodsLeave.GoodsId);
            GoodsStorageDetailModel goodsStorageDetailModel = new GoodsStorageDetailModel()
            {
                GoodsId = goods.Id,
                GoodsName = goods.Name,
                GoodsRemarks = goods.Remarks,
                Weight = goods.Weight,
                TypeId = goods.TypeId,
                TypeName = _goodsTypeService.Find(goods.TypeId).Name,
                UserId = goods.UserId,
                UserName = _usersService.Find(goods.UserId).Name,
                StorageId = goodsLeave.StorageId,
                StorageName = _storageService.Find(goodsLeave.StorageId).Name,
                RegionId = goodsLeave.RegionId,
                RegionName = _regionService.Find(goodsLeave.RegionId).Name,
            };
            return goodsStorageDetailModel;
        }
    }
}