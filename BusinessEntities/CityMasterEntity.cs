using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class CityMasterEntity
    {
       
        public int PK_ID { get; set; }
        public string CityName { get; set; }
        public string DistrictName { get; set; }
        public string StateName { get; set; }
    }
}
