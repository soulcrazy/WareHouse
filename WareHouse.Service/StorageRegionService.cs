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
using System.Linq.Expressions;
using WareHouse.Core.Data;
using WareHouse.Core.Exceptions;
using WareHouse.Dto;
using WareHouse.Entity;
using WareHouse.Service.Interface;
using WareHouse.ViewModel;

namespace WareHouse.Service
{
    public class StorageRegionService : IStorageRegionService
    {
        private readonly IRepository<StorageRegion, int> _repository;
        private readonly IRepository<Region, int> _regionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public StorageRegionService(IServiceProvider serviceProvider)
        {
            _repository = serviceProvider.GetRequiredService<IRepository<StorageRegion, int>>();
            _regionRepository = serviceProvider.GetRequiredService<IRepository<Region, int>>();
            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
        }

        public string Get()
        {
            return Guid.NewGuid().ToString();
        }

        public RegionModel GetAllByStorageId(int id)
        {
            RegionModel regionModel = new RegionModel();
            try
            {
                List<StorageRegion> storageRegionList = _repository.Select(c => c.StorageId == id);

                var regionList = new List<ViewModel.RegionModel.Regions>();

                foreach (var storageRegion in storageRegionList)
                {
                    ViewModel.RegionModel.Regions tempRegions = new RegionModel.Regions();
                    int storageRegionId = storageRegion.Id;
                    Region region = _regionRepository.Find(storageRegion.RegionId);
                    tempRegions.StorageRegionId = storageRegionId;
                    tempRegions.Id = region.Id;
                    tempRegions.Name = region.Name;
                    tempRegions.Capacity = storageRegion.Capacity;
                    regionList.Add(tempRegions);
                }

                regionModel.Region = regionList;
            }
            catch (Exception e)
            {
                throw new BusinessException(e.ToString());
            }

            return regionModel;
        }

        public IPageResult<StorageRegion> GetPageResultByStorageId(IPager pager, int id)
        {
            return _repository.Select(pager, c => c.StorageId == id, c => c.Id);
        }

        public StorageRegion Find(int id)
        {
            return _repository.Find(id);
        }

        public StorageRegionModel FindStorageRegionModel(int id)
        {
            StorageRegion storageRegion = _repository.Find(id);
            StorageRegionModel storageRegionModel = new StorageRegionModel()
            {
                RegionId = storageRegion.RegionId,
                RegionName = _regionRepository.Find(storageRegion.RegionId).Name,
                Capacity = storageRegion.Capacity
            };
            return storageRegionModel;
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

        public bool Delete(StorageRegion storageRegion)
        {
            _repository.Delete(storageRegion);
            return _unitOfWork.Commit() > 0;
        }

        public bool Update(GetStorageRegionDto getStorageRegionDto)
        {
            if (getStorageRegionDto.Id <= 0)
            {
                return false;
            }

            Region tempRegion = _regionRepository.Find(getStorageRegionDto.RegionId);
            if (!tempRegion.Name.Equals(getStorageRegionDto.RegionName))
            {
                tempRegion.Name = getStorageRegionDto.RegionName;
                _regionRepository.Update(tempRegion);
                _unitOfWork.Commit();
            }

            StorageRegion tempStorageRegion = Find(getStorageRegionDto.Id);
            tempStorageRegion.Capacity = getStorageRegionDto.Capacity;

            _repository.Update(tempStorageRegion);
            return _unitOfWork.Commit() > 0;
        }

        public List<StorageRegion> GetAll(Expression<Func<StorageRegion, bool>> whereExpression)
        {
            return _repository.Select(whereExpression);
        }
    }
}