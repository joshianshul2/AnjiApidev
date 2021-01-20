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
using QRCoder;




namespace BusinessServices
{
    
    public class HospitalTransactionServices: IHospitalTransactionServices
    {
        private readonly UnitOfWork _unitOfWork;
        public HospitalTransactionServices()
        {
            _unitOfWork = new UnitOfWork();
        }

        public BusinessEntities.HospitalTransactionEntity GetTransById(int id)
        {
            BusinessEntities.HospitalTransactionEntity objHspTransMaster = new BusinessEntities.HospitalTransactionEntity();
            if (id == 0)
                return objHspTransMaster;

            var hspTrans = _unitOfWork.HospitalTransactionRepository.GetByID(id);
            if (hspTrans != null)
            {
                Mapper.CreateMap<HospitalTransaction, HospitalTransactionEntity>();
                var cityModel = Mapper.Map<HospitalTransaction, HospitalTransactionEntity>(hspTrans);
                return cityModel;
            }
            return null;
        }

       



        public IEnumerable<BusinessEntities.HospitalTransactionEntity> GetAllTrans()
        {
            var hspTrans = _unitOfWork.HospitalTransactionRepository.GetAll().ToList();
            if (hspTrans.Any())
            {
                Mapper.CreateMap<HospitalTransaction, HospitalTransactionEntity>();
                var hspTransModel = Mapper.Map<List<HospitalTransaction>, List<HospitalTransactionEntity>>(hspTrans);
                return hspTransModel;
            }
            return null;
        }
        public BusinessEntities.HospitalTransactionEntity  CreateHspTransaction(BusinessEntities.HospitalTransactionEntity hspTransEntity)
        {
            using (var scope = new TransactionScope())
            {
                var hspTrans = new HospitalTransaction
                {
                    Address = hspTransEntity.Address,
                    AllImgPath = hspTransEntity.AllImgPath,
                    BlueBag = hspTransEntity.BlueBag,
                    BlueBagNos = Convert.ToInt16(hspTransEntity.BlueBagNos),
                    BlueImgPath = hspTransEntity.BlueImgPath,
                    City = hspTransEntity.City,
                    CodeAll = hspTransEntity.CodeAll,
                    CodeBlue = hspTransEntity.CodeBlue,
                    CodeRed = hspTransEntity.CodeRed,
                    CodeWhite = hspTransEntity.CodeWhite,
                    CodeYellow = hspTransEntity.CodeYellow,
                    District = hspTransEntity.District,
                    HospitalName = hspTransEntity.HospitalName,
                    RedBag = hspTransEntity.RedBag,
                    RedBagNos = Convert.ToInt16(hspTransEntity.RedBagNos),
                    RedImgPath = hspTransEntity.RedImgPath,
                    State = hspTransEntity.State,
                    username = hspTransEntity.username,
                    WasteDate = hspTransEntity.WasteDate,
                    WasteWeight = hspTransEntity.WasteWeight,
                    WhiteBag = hspTransEntity.WhiteBag,
                    WhiteBagNos = Convert.ToInt16(hspTransEntity.WhiteBagNos),
                    WhiteImgPath = hspTransEntity.WhiteImgPath,
                    YellowBag = hspTransEntity.YellowBag,
                    YellowBagNos = Convert.ToInt16(hspTransEntity.YellowBagNos),
                    YellowImgPath = hspTransEntity.YellowImgPath,
                    TotalString = "ALLIN110029DLBH00578",
                    SeqNo1 = hspTransEntity.SeqNo1,
                    SeqNo2 = hspTransEntity.SeqNo2,
                    SeqNo3 = hspTransEntity.SeqNo3,
                    SeqNo4 = hspTransEntity.SeqNo4,
                    IsDeleted = hspTransEntity.IsDeleted,
                    ReportFrom = "mob"



                };
                _unitOfWork.HospitalTransactionRepository.Insert(hspTrans);
                _unitOfWork.Save();
                scope.Complete();

                if (hspTrans != null)
                {
                    Mapper.CreateMap<HospitalTransaction, HospitalTransactionEntity>();
                    var cityModel = Mapper.Map<HospitalTransaction, HospitalTransactionEntity>(hspTrans);
                    return cityModel;
                }

                return null;
            }
        }

        ////public int CreateHspTransaction(BusinessEntities.HospitalTransactionEntity hspTransEntity)
        ////{
        ////    using (var scope = new TransactionScope())
        ////    {
        ////        var hspTrans = new HospitalTransaction
        ////        {
        ////            Address = hspTransEntity.Address,
        ////            AllImgPath = hspTransEntity.AllImgPath,
        ////            BlueBag = hspTransEntity.BlueBag,
        ////            BlueBagNos = Convert.ToInt16(hspTransEntity.BlueBagNos),
        ////            BlueImgPath = hspTransEntity.BlueImgPath,
        ////            City = hspTransEntity.City,
        ////            CodeAll = hspTransEntity.CodeAll,
        ////            CodeBlue = hspTransEntity.CodeBlue,
        ////            CodeRed = hspTransEntity.CodeRed,
        ////            CodeWhite = hspTransEntity.CodeWhite,
        ////            CodeYellow = hspTransEntity.CodeYellow,
        ////            District = hspTransEntity.District,
        ////            HospitalName = hspTransEntity.HospitalName,
        ////            RedBag = hspTransEntity.RedBag,
        ////            RedBagNos = Convert.ToInt16(hspTransEntity.RedBagNos),
        ////            RedImgPath = hspTransEntity.RedImgPath,
        ////            State = hspTransEntity.State,
        ////            username = hspTransEntity.username,
        ////            WasteDate = hspTransEntity.WasteDate,
        ////            WasteWeight = hspTransEntity.WasteWeight,
        ////            WhiteBag = hspTransEntity.WhiteBag,
        ////            WhiteBagNos = Convert.ToInt16(hspTransEntity.WhiteBagNos),
        ////            WhiteImgPath = hspTransEntity.WhiteImgPath,
        ////            YellowBag = hspTransEntity.YellowBag,
        ////            YellowBagNos = Convert.ToInt16(hspTransEntity.YellowBagNos),
        ////            YellowImgPath = hspTransEntity.YellowImgPath

        ////        };
        ////        _unitOfWork.HospitalTransactionRepository.Insert(hspTrans);
        ////        _unitOfWork.Save();
        ////        scope.Complete();
        ////        return hspTrans.PK_UserId;
        ////    }
        ////}
        public bool UpdateHspTransaction(int id, BusinessEntities.HospitalTransactionEntity hspTransEntity)
        {
            var success = false;
            if (hspTransEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var hspTrans = _unitOfWork.HospitalTransactionRepository.GetByID(id);
                    if (hspTrans != null)
                    {
                        
                        string HspName = hspTransEntity.HospitalName.Replace(" ", "");
                        string strHsp = HspName.Substring(0, 5);

                        hspTrans.Address = hspTransEntity.Address;
                        hspTrans.AllImgPath = hspTransEntity.AllImgPath;
                        hspTrans.BlueBag = hspTransEntity.BlueBag;
                        hspTrans.BlueBagNos = Convert.ToInt16(hspTransEntity.BlueBagNos);
                        hspTrans.BlueImgPath = hspTransEntity.BlueImgPath;
                        hspTrans.City = hspTransEntity.City;
                        hspTrans.CodeAll = hspTransEntity.CodeAll;
                        hspTrans.CodeBlue = hspTransEntity.CodeBlue;
                        hspTrans.CodeRed = hspTransEntity.CodeRed;
                        hspTrans.CodeWhite = hspTransEntity.CodeWhite;
                        hspTrans.CodeYellow = hspTransEntity.CodeYellow;
                        hspTrans.District = hspTransEntity.District;
                        hspTrans.HospitalName = hspTransEntity.HospitalName;
                        hspTrans.RedBag = hspTransEntity.RedBag;
                        hspTrans.RedBagNos = Convert.ToInt16(hspTransEntity.RedBagNos);
                        hspTrans.RedImgPath = hspTransEntity.RedImgPath;
                        hspTrans.State = hspTransEntity.State;
                        hspTrans.username = hspTransEntity.username;
                        hspTrans.WasteDate = hspTransEntity.WasteDate;
                        hspTrans.WasteWeight = hspTransEntity.WasteWeight;
                        hspTrans.WhiteBag = hspTransEntity.WhiteBag;
                        hspTrans.WhiteBagNos = Convert.ToInt16(hspTransEntity.WhiteBagNos);
                        hspTrans.WhiteImgPath = hspTransEntity.WhiteImgPath;
                        hspTrans.YellowBag = hspTransEntity.YellowBag;
                        hspTrans.YellowBagNos = Convert.ToInt16(hspTransEntity.YellowBagNos);
                        hspTrans.YellowImgPath = hspTransEntity.YellowImgPath;
                        hspTrans.TotalString = "ALLIN110029DLBH00578";
                        hspTrans.SeqNo1 = hspTransEntity.SeqNo1;
                        hspTrans.SeqNo2 = hspTransEntity.SeqNo2;
                        hspTrans.SeqNo3 = hspTransEntity.SeqNo3;
                        hspTrans.SeqNo4 = hspTransEntity.SeqNo4;
                        hspTrans.IsDeleted = hspTransEntity.IsDeleted;
                        hspTrans.ReportFrom = "mob";

                        _unitOfWork.HospitalTransactionRepository.Update(hspTrans);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success; 
        }
        public bool DeleteTrans(int id)
        {
            var success = false;
            if (id > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var hsp = _unitOfWork.HospitalTransactionRepository.GetByID(id);
                    if (hsp != null)
                    {
                        _unitOfWork.HospitalTransactionRepository.Delete(hsp);
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