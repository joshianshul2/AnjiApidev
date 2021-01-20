using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class PaymentDetailEntity
    {


        public int  PK_PaymentDetailId {get; set;}
        public int UserId	 {get; set;}
        public string UserName	 {get; set;}
        public string BankName  {get; set;}
         public int RegistrationFee	  {get; set;}

         public DateTime PaymentDate	  {get; set;}
        
        public DateTime ChequeDate	 {get; set;}
         public string ChequeNo	{get; set;}
         public string PaymentMode	{get; set;}
         public string GSTINNo	{get; set;}

         public int  bmwPlusWebsite	{get; set;}

         public decimal bmwAmt	{get; set;}
        
         public decimal WebDev	{get; set;}

         public decimal Domain	{get; set;}

         public decimal Hosting	{get; set;}

         public decimal   Discount	{get; set;}
         public decimal Total	{get; set;}
         public decimal Misc	{get; set;}

         public decimal GTotal	{get; set;}
          public string Owner	{get; set;}
	
    }
}
