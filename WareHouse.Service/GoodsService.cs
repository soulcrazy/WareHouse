using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using WareHouse.Core.Data;
using WareHouse.Entity;
using WareHouse.Service.Interface;

namespace WareHouse.Service
{
    public class GoodsService : IGoodsService
    {
        private readonly IRepository<Goods, int> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public GoodsService(IServiceProvider serviceProvider)
        {
            _repository = serviceProvider.GetRequiredService<IRepository<Goods, int>>();
            _unitOfWork = serviceProvider.GetRequiredService<IUnitOfWork>();
        }

        public string Get()
        {
            return Guid.NewGuid().ToString();
        }

        public IPageResult<Goods> GetPageResult(IPager pager)
        {
            return _repository.Select(pager, c => true, c => c.Id);
        }

        public List<Goods> GetAll()
        {
            return _repository.Select(c => true);
        }

        public Goods Find(int id)
        {
            return _repository.Find(id);
        }

        public int GetId(Goods goods)
        {
            return _repository.Find(c => c.UserId == goods.UserId && c.Name == goods.Name && c.Remarks == goods.Remarks).Id;
        }

        public bool Add(Goods goods)
        {
            goods.IsWarehousing = 0;
            _repository.Add(goods);
            return _unitOfWork.Commit() > 0;
        }

        public bool Delete(int id)
        {
            if (id <= 0)
            {
                return false;
            }
            Goods goods = _repository.Find(id);
            if (goods == null)
            {
                return false;
            }
            _repository.Delete(goods);
            return _unitOfWork.Commit() > 0;
        }

        public bool Update(Goods goods)
        {
            if (goods.Id <= 0)
            {
                return false;
            }
            Goods tempGoods = _repository.Find(goods.Id);
            if (tempGoods == null)
            {
                return false;
            }

            tempGoods.Name = goods.Name;
            tempGoods.TypeId = goods.TypeId;
            tempGoods.UserId = goods.UserId;
            tempGoods.Weight = goods.Weight;
            tempGoods.Remarks = goods.Remarks;

            _repository.Update(tempGoods);
            return _unitOfWork.Commit() > 0;
        }

        public bool Out(int id)
        {
            if (id <= 0)
            {
                return false;
            }
            Goods goods = Find(id);
            if (goods == null)
            {
                return false;
            }

            goods.IsWarehousing = 0;

            _repository.Update(goods);
            return _unitOfWork.Commit() > 0;
        }

        public List<Goods> Inside()
        {
            return _repository.Select(c => c.IsWarehousing == 1);
        }

        public IPageResult<Goods> InsidePage(IPager pager)
        {
            return _repository.Select(pager, c => c.IsWarehousing == 1, c => c.Id);
        }

        public List<Goods> Outside()
        {
            return _repository.Select(c => c.IsWarehousing == 0);
        }

        public IPageResult<Goods> OutsidePage(IPager pager)
        {
            return _repository.Select(pager, c => c.IsWarehousing == 0, c => c.Id);
        }
    }
}