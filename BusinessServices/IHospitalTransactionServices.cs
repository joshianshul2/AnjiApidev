using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessServices
{
    public interface IHospitalTransactionServices
    {
        HospitalTransactionEntity  GetTransById(int id);
       
        IEnumerable<HospitalTransactionEntity> GetAllTrans();
        HospitalTransactionEntity CreateHspTransaction(HospitalTransactionEntity hspTransEntity);
        bool UpdateHspTransaction(int id, HospitalTransactionEntity hspTransEntity);
        bool DeleteTrans(int id);
    }
}
