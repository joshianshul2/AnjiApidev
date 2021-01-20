using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class UserMasterEntity
    {

        public int PK_UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string HospitalName { get; set; }
        public string Address { get; set; }
        public int FK_CityId { get; set; }
        public int  FK_StateId { get; set; }

        public bool  IsActive { get; set; }
       
        public int UserType { get; set; }
    }
}
