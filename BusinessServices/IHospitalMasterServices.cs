using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessServices
{
    public interface IHospitalMasterServices
    {
        HospitalMasterEntity GetUserById(int id);
       
        IEnumerable<HospitalMasterEntity> GetAllUser();

        HospitalMasterEntity GetUserByNamePaasword(string UserName, string Password);
       
        int CreateUser(HospitalMasterEntity hspMasterEntity);
        bool UpdateUser(int id, HospitalMasterEntity hspMasterEntity);
        bool DeleteUser(int id);
    }
}
