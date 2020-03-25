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
using WareHouse.Entity;

namespace WareHouse.Service
{
    public class StorageService : IStorageService
    {
        private readonly IRepository<Storage, int> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public StorageService(IServiceProvider serviceProvider)
        {
            _repository = serviceProvider.GetRequiredService<IRepository<Storage, int>>();
            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
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
    }
}