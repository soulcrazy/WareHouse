using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using WareHouse.Core.Data;
using WareHouse.Entity;

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

        public bool Add(Goods goods)
        {
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
    }
}