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
using System.Linq;
using System.Linq.Expressions;
using WareHouse.Core.Data;
using WareHouse.Entity;
using WareHouse.Service.Interface;

namespace WareHouse.Service
{
    public class RegionService : IRegionService
    {
        private readonly IRepository<Region, int> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStorageRegionService _storageRegionService;

        public RegionService(IServiceProvider serviceProvider)
        {
            _repository = serviceProvider.GetRequiredService<IRepository<Region, int>>();
            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
            _storageRegionService = serviceProvider.GetRequiredService<IStorageRegionService>();
        }

        public string Get()
        {
            return Guid.NewGuid().ToString();
        }

        public List<Region> GetAll()
        {
            return _repository.Select(c => true);
        }

        public List<Region> GetAllNotAdd(int id)
        {
            List<StorageRegion> storageRegions = _storageRegionService.GetAll(c => c.StorageId == id);
            int[] storageRegionArray = new int[storageRegions.Count];
            int i = 0;
            foreach (var storageRegion in storageRegions)
            {
                storageRegionArray[i] = storageRegion.RegionId;
                i++;
            }

            List<Region> regions = GetAll();
            int[] regionArray = new int[regions.Count];
            int j = 0;
            foreach (var region in regions)
            {
                regionArray[j] = region.Id;
                j++;
            }

            int[] notAddArray = regionArray.Except(storageRegionArray).ToArray();

            List<Region> allNotAddRegion = new List<Region>();

            foreach (var t in notAddArray)
            {
                foreach (var t1 in regions)
                {
                    if (t == t1.Id)
                    {
                        allNotAddRegion.Add(t1);
                        break;
                    }
                }
            }

            return allNotAddRegion;
        }

        public IPageResult<Region> GetPageResult(IPager pager)
        {
            return _repository.Select(pager, c => true, c => c.Id);
        }

        public Region Find(int id)
        {
            return _repository.Find(id);
        }

        public Region Find(Expression<Func<Region, bool>> whereExpression)
        {
            return _repository.Find(whereExpression);
        }

        /// <summary>
        /// 0成功，1失败，2已存在，3信息未填写
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int Add(string name)
        {
            if (name == null)
            {
                return 3;
            }
            if (_repository.Select(c => c.Name == name).Count > 0)
            {
                return 2;
            }
            Region region = new Region()
            {
                Name = name
            };
            _repository.Add(region);
            if (_unitOfWork.Commit() > 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        public bool Delete(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            List<StorageRegion> storageRegions = _storageRegionService.GetAll(c => c.RegionId == id);
            foreach (var storageRegion in storageRegions)
            {
                _storageRegionService.Delete(storageRegion);
            }

            _repository.Delete(id);
            return _unitOfWork.Commit() > 0;
        }

        public int Update(Region region)
        {
            if (region.Name == null)
            {
                return 3;
            }
            if (_repository.Select(c => c.Name == region.Name).Count > 0)
            {
                return 2;
            }
            Region tempRegion = _repository.Find(region.Id);
            tempRegion.Name = region.Name;
            _repository.Update(tempRegion);
            if (_unitOfWork.Commit() > 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}