/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：GoodsStorageService.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-03-27 17:41:26
 */

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using WareHouse.Core.Data;
using WareHouse.Entity;
using WareHouse.IService;

namespace WareHouse.Service
{
    public class GoodsStorageService : IGoodsStorageService
    {
        private readonly IRepository<GoodsStorage, int> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public GoodsStorageService(IServiceProvider serviceProvider)
        {
            _repository = serviceProvider.GetRequiredService<IRepository<GoodsStorage, int>>();
            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
        }

        public string Get()
        {
            return Guid.NewGuid().ToString();
        }

        public bool Add(GoodsStorage goodsStorage)
        {
            if (goodsStorage.GoodsId == 0 || goodsStorage.StorageId == 0 || goodsStorage.RegionId == 0)
            {
                return false;
            }
            _repository.Add(goodsStorage);
            return _unitOfWork.Commit() > 0;
        }

        public bool Delete(int id)
        {
            if (id <= 0)
            {
                return false;
            }
            _repository.Delete(id);
            return _unitOfWork.Commit() > 0;
        }

        public bool Update(GoodsStorage goodsStorage)
        {
            if (goodsStorage.Id <= 0)
            {
                return false;
            }

            GoodsStorage tempGoodsStorage = _repository.Find(goodsStorage.Id);
            if (tempGoodsStorage == null)
            {
                return false;
            }

            tempGoodsStorage.GoodsId = goodsStorage.GoodsId;
            tempGoodsStorage.RegionId = goodsStorage.RegionId;
            tempGoodsStorage.StorageId = goodsStorage.StorageId;

            _repository.Update(tempGoodsStorage);
            return _unitOfWork.Commit() > 0;
        }

        public GoodsStorage Find(int id)
        {
            return _repository.Find(id);
        }

        public List<GoodsStorage> GetAll()
        {
            return _repository.Select(c => true);
        }

        public IPageResult<GoodsStorage> GetPages(IPager pager)
        {
            return _repository.Select(pager, c => true, c => c.Id);
        }
    }
}