/*
 * Copyright (c) 2020
 * All rights reserved.
 *
 * 文件名称：GoodsTypeService.cs
 /* 摘   要：
 *
 * 当前版本：1.0
 * 作   者：SoulCrazy
 * 创建时间：2020-03-23 21:21:40
 */

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using WareHouse.Core.Data;
using WareHouse.Entity;
using WareHouse.Service.Interface;

namespace WareHouse.Service
{
    public class GoodsTypeService : IGoodsTypeService
    {
        private readonly IRepository<GoodsType, int> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public GoodsTypeService(IServiceProvider serviceProvider)
        {
            _repository = serviceProvider.GetRequiredService<IRepository<GoodsType, int>>();
            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
        }

        public string Get()
        {
            return Guid.NewGuid().ToString();
        }

        public List<GoodsType> GetAll()
        {
            return _repository.Select(c => true);
        }

        public IPageResult<GoodsType> GetPageResult(IPager pager)
        {
            return _repository.Select(pager, c => true, c => c.Id);
        }

        public GoodsType Find(int id)
        {
            return _repository.Find(id);
        }

        public bool Add(GoodsType goodsType)
        {
            if (_repository.Select(c => c.Name == goodsType.Name).Count > 0)
            {
                return false;
            }
            if (string.IsNullOrEmpty(goodsType.Name))
            {
                return false;
            }
            _repository.Add(goodsType);
            return _unitOfWork.Commit() > 0;
        }

        public bool Delete(int id)
        {
            if (id <= 0)
            {
                return false;
            }
            GoodsType goodsType = _repository.Find(id);
            if (goodsType == null)
            {
                return false;
            }
            _repository.Delete(goodsType);
            return _unitOfWork.Commit() > 0;
        }

        public bool Update(GoodsType goodsType)
        {
            if (goodsType.Id <= 0)
            {
                return false;
            }

            GoodsType tempGoodsType = _repository.Find(goodsType.Id);
            if (tempGoodsType == null)
            {
                return false;
            }

            tempGoodsType.Name = goodsType.Name;

            _repository.Update(tempGoodsType);
            return _unitOfWork.Commit() > 0;
        }
    }
}