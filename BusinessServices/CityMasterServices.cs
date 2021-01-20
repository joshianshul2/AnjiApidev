using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using DataModel.UnitOfWork;
using DataModel;
using System.Transactions;
using AutoMapper;


namespace BusinessServices
{
    public class CityMasterServices:ICityMasterServices
    {
        private readonly UnitOfWork _unitOfWork;
        public CityMasterServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        public BusinessEntities.CityMasterEntity GetCityById(int id)
        {
            BusinessEntities.CityMasterEntity objCityMaster = new BusinessEntities.CityMasterEntity();
            if (id == 0)
                return objCityMaster;

            var city = _unitOfWork.CityMasterRepository.GetByID(id);
            if (city != null)
            {
                Mapper.CreateMap<CityMaster, CityMasterEntity>();
                var cityModel = Mapper.Map<CityMaster, CityMasterEntity>(city);
                return cityModel;
            }
            return null;
        }

       



        public IEnumerable<BusinessEntities.CityMasterEntity> GetAllCity()
        {
            var city = _unitOfWork.CityMasterRepository.GetAll().ToList();
            if (city.Any())
            {
                Mapper.CreateMap<CityMaster, CityMasterEntity>();
                var cityModel = Mapper.Map<List<CityMaster>, List<CityMasterEntity>>(city);
                return cityModel;
            }
            return null;
        }
        public int CreateCity(BusinessEntities.CityMasterEntity cityMasterEntity)
        {
            using (var scope = new TransactionScope())
            {
                var city = new CityMaster
                {
                    CityName = cityMasterEntity.CityName,
                    DistrictName = cityMasterEntity.DistrictName,
                    StateName = cityMasterEntity.StateName.ToString() 
                };
                _unitOfWork.CityMasterRepository.Insert(city);
                _unitOfWork.Save();
                scope.Complete();
                return city.PK_ID ;
            }
        }
        public bool UpdateCity(int id, BusinessEntities.CityMasterEntity cityMasterEntity)
        {
            var success = false;
            if (cityMasterEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var city = _unitOfWork.CityMasterRepository.GetByID(id);
                    if (city != null)
                    {
                        city.CityName = cityMasterEntity.CityName;
                        city.DistrictName = cityMasterEntity.DistrictName;
                        city.StateName = cityMasterEntity.StateName.ToString();

                        _unitOfWork.CityMasterRepository.Update(city);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success; 
        }
        public bool DeleteCity(int id)
        {
            var success = false;
            if (id > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var city = _unitOfWork.CityMasterRepository.GetByID(id);
                    if (city != null)
                    {
                        _unitOfWork.CityMasterRepository.Delete(city);
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