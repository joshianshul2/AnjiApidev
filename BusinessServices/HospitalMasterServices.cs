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
    public class HospitalMasterServices:IHospitalMasterServices
    {
        private readonly UnitOfWork _unitOfWork;
        public HospitalMasterServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        public BusinessEntities.HospitalMasterEntity  GetUserById(int id)
        {
            BusinessEntities.HospitalMasterEntity objHospitalMaster = new BusinessEntities.HospitalMasterEntity();
            if (id == 0)
                return objHospitalMaster;

            var city = _unitOfWork.HospitalMasterRepository.GetByID(id);
            if (city != null)
            {
                Mapper.CreateMap<HospitalMaster, HospitalMasterEntity>();
                var cityModel = Mapper.Map<HospitalMaster, HospitalMasterEntity>(city);
                return cityModel;
            }
            return null;
        }

        public BusinessEntities.HospitalMasterEntity GetUserByNamePaasword(string UserName, string Password)
        {
            BusinessEntities.HospitalMasterEntity objHospitalMaster = new BusinessEntities.HospitalMasterEntity();
           // if (UserName.Length  > 0)
              //  return objHospitalMaster;

            var city = _unitOfWork.HospitalMasterRepository.Get(o => o.UserName == UserName && o.Password == Password);
            if (city != null)
            {
                Mapper.CreateMap<HospitalMaster, HospitalMasterEntity>();
                var cityModel = Mapper.Map<HospitalMaster, HospitalMasterEntity>(city);
                return cityModel;
            }
            return null;
        }



        public IEnumerable<BusinessEntities.HospitalMasterEntity> GetAllUser()
        {
            var city = _unitOfWork.HospitalMasterRepository.GetAll().ToList();
            if (city.Any())
            {
                Mapper.CreateMap<HospitalMaster, HospitalMasterEntity>();
                var cityModel = Mapper.Map<List<HospitalMaster>, List<HospitalMasterEntity>>(city);
                return cityModel;
            }
            return null;
        }
        public int CreateUser(BusinessEntities.HospitalMasterEntity hspMasterEntity)
        {
            using (var scope = new TransactionScope())
            {
                var hsp = new HospitalMaster
                {
                    ActiveDate = hspMasterEntity.ActiveDate,
                    Address1 = hspMasterEntity.Address1 ,
                    Address2 = hspMasterEntity.Address2 ,
                    BedNos =Convert.ToInt32(hspMasterEntity.BedNos) ,
                    City =hspMasterEntity.City,
                    ConfirmPassword =hspMasterEntity.ConfirmPassword ,
                    ContactPerson = hspMasterEntity.ContactPerson ,
                    District =hspMasterEntity.District ,
                    EmailId =hspMasterEntity.EmailId ,
                    GSTINNo = hspMasterEntity.GSTINNo  ,
                    HospitalName = hspMasterEntity.HospitalName ,
                    IsActive = hspMasterEntity.IsActive ,
                    MobileNo = hspMasterEntity.MobileNo ,
                    NameOfOwner = hspMasterEntity.NameOfOwner ,
                    OWNER = hspMasterEntity.OWNER,
                    Password= hspMasterEntity.Password ,
                    RegDate = hspMasterEntity.RegDate,
                    State =hspMasterEntity.State ,
                    UserName = hspMasterEntity.UserName,
                    UserType = Convert.ToInt32(hspMasterEntity.UserType),
                    Pincode = hspMasterEntity.Pincode,
                    PlantId = hspMasterEntity.PlantId,
                    UnitType = hspMasterEntity.UserType, 

                };
                _unitOfWork.HospitalMasterRepository.Insert(hsp);
                _unitOfWork.Save();
                scope.Complete();
                return hsp.PK_HospitalId ;
            }
        }
        public bool UpdateUser(int id, BusinessEntities.HospitalMasterEntity hspMasterEntity)
        {
            var success = false;
            if (hspMasterEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var hsp = _unitOfWork.HospitalMasterRepository.GetByID(id);
                    if (hsp != null)
                    {
                        //city.CityName = cityMasterEntity.CityName;
                        //city.DistrictName = cityMasterEntity.DistrictName;
                        //city.StateName = cityMasterEntity.StateName.ToString();

                        hsp.ActiveDate = hspMasterEntity.ActiveDate;
                        hsp.Address1 = hspMasterEntity.Address1;
                        hsp.Address2 = hspMasterEntity.Address2;
                        hsp.BedNos = Convert.ToInt32(hspMasterEntity.BedNos);
                        hsp.City = hspMasterEntity.City;
                        hsp.ConfirmPassword = hspMasterEntity.ConfirmPassword;
                        hsp.ContactPerson = hspMasterEntity.ContactPerson;
                        hsp.District = hspMasterEntity.District;
                        hsp.EmailId = hspMasterEntity.EmailId;
                        hsp.GSTINNo = hspMasterEntity.GSTINNo;
                        hsp.HospitalName = hspMasterEntity.HospitalName;
                        hsp.IsActive = hspMasterEntity.IsActive;
                        hsp.MobileNo = hspMasterEntity.MobileNo;
                        hsp.NameOfOwner = hspMasterEntity.NameOfOwner;
                        hsp.OWNER = hspMasterEntity.OWNER;
                        hsp.Password = hspMasterEntity.Password;
                        hsp.RegDate = hspMasterEntity.RegDate;
                        hsp.State = hspMasterEntity.State;
                        hsp.UserName = hspMasterEntity.UserName;
                        hsp.UserType = Convert.ToInt32(hspMasterEntity.UserType);
                        hsp.Pincode = hspMasterEntity.Pincode;
                        hsp.PlantId = hspMasterEntity.PlantId;
                        hsp.UnitType = hspMasterEntity.UserType; 

                        _unitOfWork.HospitalMasterRepository.Update(hsp);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success; 
        }
        public bool DeleteUser(int id)
        {
            var success = false;
            if (id > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var city = _unitOfWork.HospitalMasterRepository.GetByID(id);
                    if (city != null)
                    {
                        _unitOfWork.HospitalMasterRepository.Delete(city);
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