using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessServices
{
    public interface ICounterServices
    {
     
       
        IEnumerable<CounterEntity> GetAllCounter();
        int CreateCounter(CounterEntity counterEntity);
        bool UpdateCounter(int id, CounterEntity counterEntity);
        bool DeleteCounter(int id);
    }
}
