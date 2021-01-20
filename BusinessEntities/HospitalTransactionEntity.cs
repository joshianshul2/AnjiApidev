using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class HospitalTransactionEntity
    {

        public int PK_UserId { get; set; }
        public string username	{ get; set; }
        public string HospitalName	{ get; set; }
        public string Address	{ get; set; }
        public string City	{ get; set; }
        public string District	{ get; set; }
        public string State	{ get; set; }
        public decimal  WasteWeight	{ get; set; }
        public DateTime WasteDate	{ get; set; }

        public decimal RedBag	{ get; set; }
         public decimal YellowBag { get; set; } 
         public 	decimal BlueBag { get; set; } 
         public decimal WhiteBag { get; set; } 
         public string CodeAll	 { get; set; } 
         public string CodeRed	 { get; set; } 
         public string CodeYellow { get; set; } 
         public string CodeBlue { get; set; } 
         public string CodeWhite	{ get; set; } 
         public int RedBagNos	{ get; set; } 
         public int BlueBagNos	{ get; set; }
         public int YellowBagNos	{ get; set; }
         public int WhiteBagNos	{ get; set; }
        public string AllImgPath { get; set; }
         public string RedImgPath { get; set; }
         public string BlueImgPath { get; set; }
        public string YellowImgPath { get; set; }
        public string WhiteImgPath { get; set; }
        public string TotalString { get; set; }
        public string SeqNo1 { get; set; }
        public string SeqNo2 { get; set; }
        public string SeqNo3 { get; set; }
        public string SeqNo4 { get; set; }
        public bool IsDeleted { get; set; }
        public string ReportFrom { get; set; }
    }
}
