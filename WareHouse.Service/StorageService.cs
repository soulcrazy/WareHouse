/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：StorageService.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-03-25 18:03:07
 */

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using WareHouse.Core.Data;
using WareHouse.Dto;
using WareHouse.Entity;
using WareHouse.Service.Interface;

namespace WareHouse.Service
{
    public class StorageService : IStorageService
    {
        private readonly IRepository<Storage, int> _repository;
        private readonly IRepository<Region, int> _regionRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRegionService _regionService;
        private readonly IStorageRegionService _storageRegionService;

        public StorageService(IServiceProvider serviceProvider)
        {
            _repository = serviceProvider.GetRequiredService<IRepository<Storage, int>>();
            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
            _regionService = serviceProvider.GetRequiredService<IRegionService>();
            _regionRepository = serviceProvider.GetRequiredService<IRepository<Region, int>>();
            _storageRegionService = serviceProvider.GetRequiredService<IStorageRegionService>();
        }

        public string Get()
        {
            return Guid.NewGuid().ToString();
        }

        public List<Storage> GetAll()
        {
            return _repository.Select(c => true);
        }

        public IPageResult<Storage> GetPageResult(IPager pager)
        {
            return _repository.Select(pager, c => true, c => c.Id);
        }

        public Storage Find(int id)
        {
            return _repository.Find(id);
        }

        public bool Add(Storage storage)
        {
            if (_repository.Select(c => c.Name == storage.Name).Count == 1)
            {
                return false;
            }
            _repository.Add(storage);
            return _unitOfWork.Commit() > 0;
        }

        public bool Delete(int id)
        {
            Storage storage = Find(id);
            if (storage == null)
            {
                return false;
            }

            List<StorageRegion> storageRegions = _storageRegionService.GetAll(c => c.StorageId == id);
            foreach (var storageRegion in storageRegions)
            {
                _storageRegionService.Delete(storageRegion);
            }

            _repository.Delete(storage);
            return _unitOfWork.Commit() > 0;
        }

        public bool Update(Storage storage)
        {
            if (storage.Id <= 0)
            {
                return false;
            }

            if (_repository.Select(c => c.Name == storage.Name).Count > 0)
            {
                return false;
            }

            Storage tempStorage = _repository.Find(storage.Id);
            if (tempStorage == null)
            {
                return false;
            }

            tempStorage.Name = storage.Name;
            tempStorage.Address = storage.Address;
            tempStorage.Capacity = storage.Capacity;
            _repository.Update(tempStorage);
            return _unitOfWork.Commit() > 0;
        }

        public bool AddNewRegion(GetRegionDto getRegionDto)
        {
            Region region = new Region()
            {
                Name = getRegionDto.RegionName,
                Capacity = getRegionDto.RegionCapacity
            };

            if (!_regionService.Add(region))
            {
                return false;
            }

            region = _regionRepository.Find(c =>
                c.Name == getRegionDto.RegionName && c.Capacity == getRegionDto.RegionCapacity);

            StorageRegion storageRegion = new StorageRegion()
            {
                StorageId = getRegionDto.StorageId,
                RegionId = region.Id
            };

            return _storageRegionService.Add(storageRegion);
        }
    }
}