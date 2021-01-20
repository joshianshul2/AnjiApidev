using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using DataModel.UnitOfWork;
using BusinessEntities;
using DataModel;
using AutoMapper;

namespace BusinessServices
{
    public class CounterServices
    {
        private readonly UnitOfWork _unitOfWork;
        public CounterServices()
        {
            _unitOfWork = new UnitOfWork();
        }

 
        public IEnumerable<BusinessEntities.CounterEntity> GetAllCounter()
        {
            var client = _unitOfWork.CounterRepository.GetAll().ToList();
            if (client.Any())
            {
                Mapper.CreateMap<Counter , CounterEntity>();
                var clientModel = Mapper.Map<List<Counter>, List<CounterEntity>>(client);
                return clientModel;
            }
            return null;
        }
        public decimal CreateCounter(BusinessEntities.CounterEntity counterEntity)
        {
            using (var scope = new TransactionScope())
            {
                var client = new Counter 
                {
                    createDate = counterEntity.createDate,
                    counts = counterEntity.counts 
             
                };
                _unitOfWork.CounterRepository.Insert(client);
                _unitOfWork.Save();
                scope.Complete();
                return Convert.ToDecimal(client.sno);
            }
        }
        public bool UpdateCounter(int id, BusinessEntities.CounterEntity clientCounterEntity)
        {
            var success = false;
            if (clientCounterEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var client = _unitOfWork.CounterRepository.GetByID(id);
                    if (client != null)
                    {
                        client.counts  = clientCounterEntity.counts;
                        client.createDate = clientCounterEntity.createDate;
                       
                        _unitOfWork.CounterRepository.Update(client);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
        public bool DeleteCounter(int id)
        {
            var success = false;
            if (id > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var client = _unitOfWork.CounterRepository.GetByID(id);
                    if (client != null)
                    {
                        _unitOfWork.CounterRepository.Delete(client);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }
    }
}
