using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessServices
{
    public interface ICityMasterServices
    {
        CityMasterEntity GetCityById(int id);
       
        IEnumerable<CityMasterEntity> GetAllCity();
        int CreateCity(CityMasterEntity cityMasterEntity);
        bool UpdateCity(int id, CityMasterEntity cityMasterEntity);
        bool DeleteCity(int id);
    }
}
