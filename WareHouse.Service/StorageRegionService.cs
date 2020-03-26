/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：StorageRegionService.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-03-26 13:15:20
 */

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using WareHouse.Core.Data;
using WareHouse.Entity;

namespace WareHouse.Service
{
    public class StorageRegionService : IStorageRegionService
    {
        private readonly IRepository<StorageRegion, int> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public StorageRegionService(IServiceProvider serviceProvider)
        {
            _repository = serviceProvider.GetRequiredService<IRepository<StorageRegion, int>>();
            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
        }

        public string Get()
        {
            return Guid.NewGuid().ToString();
        }

        public List<StorageRegion> GetAllByStorageId(int id)
        {
            return _repository.Select(c => c.StorageId == id);
        }

        public IPageResult<StorageRegion> GetPageResultByStorageId(IPager pager, int id)
        {
            return _repository.Select(pager, c => c.StorageId == id, c => c.Id);
        }

        public StorageRegion Find(int id)
        {
            return _repository.Find(id);
        }

        public bool Add(StorageRegion storageRegion)
        {
            if (_repository.Select(c => c.RegionId == storageRegion.RegionId && c.StorageId == storageRegion.StorageId).Count > 0)
            {
                return false;
            }
            _repository.Add(storageRegion);
            return _unitOfWork.Commit() > 0;
        }

        public bool Delete(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            StorageRegion storageRegion = Find(id);
            if (storageRegion == null)
            {
                return false;
            }
            _repository.Delete(storageRegion);
            return _unitOfWork.Commit() > 0;
        }

        public bool Update(StorageRegion storageRegion)
        {
            if (storageRegion.Id <= 0)
            {
                return false;
            }

            StorageRegion tempStorageRegion = Find(storageRegion.Id);

            tempStorageRegion.RegionId = storageRegion.RegionId;
            tempStorageRegion.StorageId = storageRegion.StorageId;

            _repository.Update(tempStorageRegion);
            return _unitOfWork.Commit() > 0;
        }
    }
}