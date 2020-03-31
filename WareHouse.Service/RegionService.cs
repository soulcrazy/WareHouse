/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：RegionService.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建日期：2020-03-26 11:17:13
 */

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using WareHouse.Core.Data;
using WareHouse.Entity;
using WareHouse.Service.Interface;

namespace WareHouse.Service
{
    public class RegionService : IRegionService
    {
        private readonly IRepository<Region, int> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public RegionService(IServiceProvider serviceProvider)
        {
            _repository = serviceProvider.GetRequiredService<IRepository<Region, int>>();
            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
        }

        public string Get()
        {
            return Guid.NewGuid().ToString();
        }

        public List<Region> GetAll()
        {
            return _repository.Select(c => true);
        }

        public IPageResult<Region> GetPageResult(IPager pager)
        {
            return _repository.Select(pager, c => true, c => c.Id);
        }

        public Region Find(int id)
        {
            return _repository.Find(id);
        }

        public bool Add(Region region)
        {
            if (region.Name == null)
            {
                return false;
            }
            if (_repository.Select(c => c.Name == region.Name).Count > 0)
            {
                return false;
            }
            _repository.Add(region);
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

        public bool Update(Region region)
        {
            if (_repository.Select(c => c.Name == region.Name).Count > 0)
            {
                return false;
            }

            Region tempRegion = _repository.Find(region.Id);

            if (tempRegion == null)
            {
                return false;
            }

            tempRegion.Name = region.Name;
            tempRegion.Capacity = region.Capacity;

            _repository.Update(tempRegion);
            return _unitOfWork.Commit() > 0;
        }
    }
}