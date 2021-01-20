using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
   public class HospitalMasterEntity
    {
     
      public int  PK_HospitalId	{ get; set; }
     public string HospitalName	{ get; set; }
     public string NameOfOwner	{ get; set; }
     public string Address1	{ get; set; }
     public string Address2	{ get; set; }
     public string City	{ get; set; }
     public string  District { get; set; }
     public string State { get; set; }
     public string ContactPerson { get; set; }
     public string MobileNo { get; set; }
     public string EmailId	{ get; set; }
     public string BedNos	{ get; set; }
     public DateTime RegDate { get; set; }
     public string UserName	{ get; set; }
     public string Password	{ get; set; }
     public string ConfirmPassword	{ get; set; }
     public bool  IsActive	{get; set;}
     public DateTime ActiveDate {get; set;}
     public string UserType {get; set;}
     public string GSTINNo	{get; set;}
     public string OWNER {get; set;}
	 public int PlantId { get; set; }
     public int Pincode { get; set; }
    }
}
