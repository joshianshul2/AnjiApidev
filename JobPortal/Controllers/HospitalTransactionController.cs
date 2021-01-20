using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessEntities;
using BusinessServices;
using QRCoder;
using System.Drawing;
using System.IO;
using System.Web;

namespace WebApiIms.Controllers
{
    public class HospitalTransactionController : ApiController
    {
        private readonly IHospitalTransactionServices _hspTransServices;

        public HospitalTransactionController()
        {
            _hspTransServices = new HospitalTransactionServices();
        }
        //public void GenerateAll(string TransDate, string Company, Decimal Red, Decimal Yellow, Decimal Blue, Decimal White)
        //{
        //    String codeAll = "";
        //    DateTime dtDate = Convert.ToDateTime(TransDate);
        //    //   dtDate.Replace(@"/", string.Empty);
        //    //string st = string.Format

        //    Int32 strCount = 0;

        //    string testDate = string.Format("{0:yyyyMMdd}", dtDate);

        //    codeAll = Company + "_" + "R" + "_" + Red + "_" + "Y" + "_" + Red + "_" + "B" + "_" + Blue + "_" + "W" + "_" + White + "_" + testDate + "_" + "!";





        //    //           strCount =DataKey 
        //    //          codeAll=strCount
        //    QRCodeGenerator qrGenerator = new QRCodeGenerator();
        //    QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(codeAll, QRCodeGenerator.ECCLevel.Q);
        //    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
        //    imgBarCode.Height = 150;
        //    imgBarCode.Width = 150;
        //    using (Bitmap bitMap = qrCode.GetGraphic(20))
        //    {
        //        using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
        //        {
        //            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        //            byte[] byteImage = ms.ToArray();
        //            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);

        //            var fs = new BinaryWriter(new FileStream("Hospital/QRCode/" + codeAll + ".jpeg"), FileMode.Append, FileAccess.Write));
        //         //   Session["codeAllImg"] = "http://bmwbarcode.com/Hospital/QRCode/" + codeAll + ".jpeg";
        //            fs.Write(byteImage);
        //            fs.Close();
        //        }
        //        //plBarCode.Controls.Add(imgBarCode);
        //        //
        //        //codA = codeAll;
        //    }
        //}

            protected void getQRCodeAll(HospitalTransactionEntity hspTransEntity)
        {
            DateTime WasteDate;
            string strYear;
            string strMonth;
            string strDays;
            string strDate;
            strYear = hspTransEntity.WasteDate.Year.ToString();
            strMonth = hspTransEntity.WasteDate.Month.ToString();
            strDays= hspTransEntity.WasteDate.Day.ToString();

            strDate = strYear + "-" + strMonth + "-" + strDays;
            //codeAll = Company + "_" + "R" + "_" + Red + "_" + "Y" + "_" + Red + "_" + "B" + "_" + Blue + "_" + "W" + "_" + White + "_" + testDate + "_" + "!";
            // string qrcode = hspTransEntity.HospitalName + "_" + "R_" + hspTransEntity.RedBag + "_" + "Y" + "_" + hspTransEntity.YellowBag + "_" + "B" + "_" + hspTransEntity.BlueBag  + "_" + "W" + "_" + hspTransEntity.WhiteBag  + "_" + hspTransEntity.WasteDate  + "_" + "!";
            string qrcode = hspTransEntity.HospitalName.Trim() + "_" + "R_" + hspTransEntity.RedBag + "_" + "Y" + "_" + hspTransEntity.YellowBag + "_" + "B" + "_" + hspTransEntity.BlueBag + "_" + "W" + "_" + hspTransEntity.WhiteBag+"_"+strDate+"_"+"!";
           
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(qrcode, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap bitMap = qrCode.GetGraphic(20))
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                    System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                    //                   string pad = img.Save(HttpContext.Current.Server.MapPath("Hospital/QrCode/" + "Test.Jpeg", System.Drawing.Imaging.ImageFormat.Jpeg));
                    //img.Save(HttpContext.Current.Server.MapPath("~/Hospital/QrCode/" + qrcode+".Jpeg"));

                    System.Drawing.Image imgs = ResizeByWidth(img, 150);
                    System.Drawing.Image imgss = ResizeByHeight(imgs, 150);

                    imgss.Save(HttpContext.Current.Server.MapPath("~/Hospital/QrCode/"+ qrcode + ".Jpeg"));
                    //img.Save(HttpContext.Current.Server.MapPath("Hospital/QrCode/" + qrcode + ".Jpeg"));

                    //  ViewBag.QRCodeImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());

                    //  var fs = new BinaryWriter(new FileStream("Hospital/QRCode/" + qrcode + ".jpeg"), FileMode.Append, FileAccess.Write));
                }
            }

        }
        protected void getQRCodeRed(HospitalTransactionEntity hspTransEntity)
        {
            DateTime WasteDate;
            string strYear;
            string strMonth;
            string strDays;
            string strDate;
            strYear = hspTransEntity.WasteDate.Year.ToString();
            strMonth = hspTransEntity.WasteDate.Month.ToString();
            strDays = hspTransEntity.WasteDate.Day.ToString();

            strDate = strYear + "-" + strMonth + "-" + strDays;
            //codeAll = Company + "_" + "R" + "_" + Red + "_" + "Y" + "_" + Red + "_" + "B" + "_" + Blue + "_" + "W" + "_" + White + "_" + testDate + "_" + "!";
            // string qrcode = hspTransEntity.HospitalName + "_" + "R_" + hspTransEntity.RedBag + "_" + "Y" + "_" + hspTransEntity.YellowBag + "_" + "B" + "_" + hspTransEntity.BlueBag  + "_" + "W" + "_" + hspTransEntity.WhiteBag  + "_" + hspTransEntity.WasteDate  + "_" + "!";
            string qrcode = hspTransEntity.HospitalName.Trim() + "_" + "R_" + hspTransEntity.RedBag + "_" + strDate + "_" + "!";

            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(qrcode, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap bitMap = qrCode.GetGraphic(20))
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                    System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                    //                   string pad = img.Save(HttpContext.Current.Server.MapPath("Hospital/QrCode/" + "Test.Jpeg", System.Drawing.Imaging.ImageFormat.Jpeg));
                    //img.Save(HttpContext.Current.Server.MapPath("~/Hospital/QrCode/" + qrcode+".Jpeg"));

                    System.Drawing.Image imgs = ResizeByWidth(img, 150);
                    System.Drawing.Image imgss = ResizeByHeight(imgs, 150);

                    imgss.Save(HttpContext.Current.Server.MapPath("~/Hospital/QrCode/" + qrcode + ".Jpeg"));
                    //img.Save(HttpContext.Current.Server.MapPath("Hospital/QrCode/" + qrcode + ".Jpeg"));

                    //  ViewBag.QRCodeImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());

                    //  var fs = new BinaryWriter(new FileStream("Hospital/QRCode/" + qrcode + ".jpeg"), FileMode.Append, FileAccess.Write));
                }
            }

        }

        protected void getQRCodeYellow(HospitalTransactionEntity hspTransEntity)
        {
            DateTime WasteDate;
            string strYear;
            string strMonth;
            string strDays;
            string strDate;
            strYear = hspTransEntity.WasteDate.Year.ToString();
            strMonth = hspTransEntity.WasteDate.Month.ToString();
            strDays = hspTransEntity.WasteDate.Day.ToString();

            strDate = strYear + "-" + strMonth + "-" + strDays;
            //codeAll = Company + "_" + "R" + "_" + Red + "_" + "Y" + "_" + Red + "_" + "B" + "_" + Blue + "_" + "W" + "_" + White + "_" + testDate + "_" + "!";
            // string qrcode = hspTransEntity.HospitalName + "_" + "R_" + hspTransEntity.RedBag + "_" + "Y" + "_" + hspTransEntity.YellowBag + "_" + "B" + "_" + hspTransEntity.BlueBag  + "_" + "W" + "_" + hspTransEntity.WhiteBag  + "_" + hspTransEntity.WasteDate  + "_" + "!";
            string qrcode = hspTransEntity.HospitalName.Trim() + "_" + "Y_" + hspTransEntity.YellowBag+ "_" + strDate + "_" + "!";

            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(qrcode, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap bitMap = qrCode.GetGraphic(20))
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                    System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                    //                   string pad = img.Save(HttpContext.Current.Server.MapPath("Hospital/QrCode/" + "Test.Jpeg", System.Drawing.Imaging.ImageFormat.Jpeg));
                    //img.Save(HttpContext.Current.Server.MapPath("~/Hospital/QrCode/" + qrcode+".Jpeg"));

                    System.Drawing.Image imgs = ResizeByWidth(img, 150);
                    System.Drawing.Image imgss = ResizeByHeight(imgs, 150);


                    imgss.Save(HttpContext.Current.Server.MapPath("~/Hospital/QrCode/" + qrcode + ".Jpeg"));
                    //img.Save(HttpContext.Current.Server.MapPath("Hospital/QrCode/" + qrcode + ".Jpeg"));

                    //  ViewBag.QRCodeImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());

                    //  var fs = new BinaryWriter(new FileStream("Hospital/QRCode/" + qrcode + ".jpeg"), FileMode.Append, FileAccess.Write));
                }
            }

        }

        protected void getQRCodeBlue(HospitalTransactionEntity hspTransEntity)
        {
            DateTime WasteDate;
            string strYear;
            string strMonth;
            string strDays;
            string strDate;
            strYear = hspTransEntity.WasteDate.Year.ToString();
            strMonth = hspTransEntity.WasteDate.Month.ToString();
            strDays = hspTransEntity.WasteDate.Day.ToString();

            strDate = strYear + "-" + strMonth + "-" + strDays;
            //codeAll = Company + "_" + "R" + "_" + Red + "_" + "Y" + "_" + Red + "_" + "B" + "_" + Blue + "_" + "W" + "_" + White + "_" + testDate + "_" + "!";
            // string qrcode = hspTransEntity.HospitalName + "_" + "R_" + hspTransEntity.RedBag + "_" + "Y" + "_" + hspTransEntity.YellowBag + "_" + "B" + "_" + hspTransEntity.BlueBag  + "_" + "W" + "_" + hspTransEntity.WhiteBag  + "_" + hspTransEntity.WasteDate  + "_" + "!";
            string qrcode = hspTransEntity.HospitalName.Trim() + "_" + "B_" + hspTransEntity.BlueBag + "_" + strDate + "_" + "!";

            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(qrcode, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap bitMap = qrCode.GetGraphic(20))
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                    System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                    //                   string pad = img.Save(HttpContext.Current.Server.MapPath("Hospital/QrCode/" + "Test.Jpeg", System.Drawing.Imaging.ImageFormat.Jpeg));
                    //img.Save(HttpContext.Current.Server.MapPath("~/Hospital/QrCode/" + qrcode+".Jpeg"));
                    System.Drawing.Image imgs = ResizeByWidth(img, 150);
                    System.Drawing.Image imgss = ResizeByHeight(imgs, 150);


                    imgss.Save(HttpContext.Current.Server.MapPath("~/Hospital/QrCode/" + qrcode + ".Jpeg"));
                    //img.Save(HttpContext.Current.Server.MapPath("Hospital/QrCode/" + qrcode + ".Jpeg"));

                    //  ViewBag.QRCodeImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());

                    //  var fs = new BinaryWriter(new FileStream("Hospital/QRCode/" + qrcode + ".jpeg"), FileMode.Append, FileAccess.Write));
                }
            }

        }

        protected void getQRCodeWhite(HospitalTransactionEntity hspTransEntity)
        {
            DateTime WasteDate;
            string strYear;
            string strMonth;
            string strDays;
            string strDate;
            strYear = hspTransEntity.WasteDate.Year.ToString();
            strMonth = hspTransEntity.WasteDate.Month.ToString();
            strDays = hspTransEntity.WasteDate.Day.ToString();

            strDate = strYear + "-" + strMonth + "-" + strDays;
            //codeAll = Company + "_" + "R" + "_" + Red + "_" + "Y" + "_" + Red + "_" + "B" + "_" + Blue + "_" + "W" + "_" + White + "_" + testDate + "_" + "!";
            // string qrcode = hspTransEntity.HospitalName + "_" + "R_" + hspTransEntity.RedBag + "_" + "Y" + "_" + hspTransEntity.YellowBag + "_" + "B" + "_" + hspTransEntity.BlueBag  + "_" + "W" + "_" + hspTransEntity.WhiteBag  + "_" + hspTransEntity.WasteDate  + "_" + "!";
            string qrcode = hspTransEntity.HospitalName.Trim() + "_" + "W_" + hspTransEntity.WhiteBag  + "_" + strDate + "_" + "!";

            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator qrGenerator = new QRCodeGenerator();
                QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(qrcode, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap bitMap = qrCode.GetGraphic(20))
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    
                    System.Drawing.Image img = System.Drawing.Image.FromStream(ms);

                    System.Drawing.Image imgs = ResizeByWidth(img, 150);
                    System.Drawing.Image imgss = ResizeByHeight(imgs, 150);
                    //                   string pad = img.Save(HttpContext.Current.Server.MapPath("Hospital/QrCode/" + "Test.Jpeg", System.Drawing.Imaging.ImageFormat.Jpeg));
                    //img.Save(HttpContext.Current.Server.MapPath("~/Hospital/QrCode/" + qrcode+".Jpeg"));
                    // img.Save(HttpContext.Current.Server.MapPath("~/Hospital/QrCode/" + qrcode + ".Jpeg"));
                    imgss.Save(HttpContext.Current.Server.MapPath("~/Hospital/QrCode/" + qrcode + ".Jpeg"));

                    //img.Save(HttpContext.Current.Server.MapPath("Hospital/QrCode/" + qrcode + ".Jpeg"));

                    //  ViewBag.QRCodeImage = "data:image/png;base64," + Convert.ToBase64String(ms.ToArray());

                    //  var fs = new BinaryWriter(new FileStream("Hospital/QRCode/" + qrcode + ".jpeg"), FileMode.Append, FileAccess.Write));
                }
            }

        }
        public static Image ResizeByHeight(Image Img, int NewHeight)
        {
            float PercentH = ((float)Img.Height / (float)NewHeight);

            Bitmap bmp = new Bitmap((int)(Img.Width / PercentH), NewHeight);
            Graphics g = Graphics.FromImage(bmp);

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(Img, 0, 0, bmp.Width, bmp.Height);
            g.Dispose();

            return bmp;
        }
        public static Image ResizeByWidth(Image Img, int NewWidth)
        {
            float PercentW = ((float)Img.Width / (float)NewWidth);

            Bitmap bmp = new Bitmap(NewWidth, (int)(Img.Height / PercentW));
            Graphics g = Graphics.FromImage(bmp);

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(Img, 0, 0, bmp.Width, bmp.Height);
            g.Dispose();

            return bmp;
        }
        public HttpResponseMessage Get()
        {
            var hsp = _hspTransServices.GetAllTrans();
            if (hsp == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Transaction not found");
            }
            var hspEntities = hsp as List<HospitalTransactionEntity> ?? hsp.ToList();
            if (hspEntities.Any())
                return Request.CreateResponse(HttpStatusCode.OK, hspEntities);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Transaction not found");
        }

        public HttpResponseMessage Get(int id)
        {
            var hsp =  _hspTransServices.GetTransById(id);
          
            if (hsp != null)
                return Request.CreateResponse(HttpStatusCode.OK, hsp);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Transaction found for this id");
        }

        public HttpResponseMessage Post([FromBody] HospitalTransactionEntity hspTransEntity)
        {
            Int32 intTranId;
            string strYear;
            string strMonth;
            string strDays;
            string strDate;
            strYear = hspTransEntity.WasteDate.Year.ToString();
            strMonth = hspTransEntity.WasteDate.Month.ToString();
            strDays = hspTransEntity.WasteDate.Day.ToString();

            strDate = strYear + "-" + strMonth + "-" + strDays;

            string strAllImagePath;
            string strRedImagePath;
            string strYellowImagePath;
            string strBlueImagePath;
            string strWhiteImagePath;


            strAllImagePath = "http://app.bmwbarcode.com/Hospital/QrCode/" + hspTransEntity.HospitalName.Trim() + "_" + "R_" + hspTransEntity.RedBag + "_" + "Y" + "_" + hspTransEntity.YellowBag + "_" + "B" + "_" + hspTransEntity.BlueBag + "_" + "W" + "_" + hspTransEntity.WhiteBag + "_" + strDate + "_" + "!" + ".jpeg";
            strRedImagePath = "http://app.bmwbarcode.com/Hospital/QrCode/" + hspTransEntity.HospitalName.Trim() + "_" + "R_" + hspTransEntity.RedBag +"_" + strDate + "_" + "!" + ".jpeg";
            strYellowImagePath = "http://app.bmwbarcode.com/Hospital/QrCode/" + hspTransEntity.HospitalName.Trim() + "_" + "Y_" + hspTransEntity.YellowBag  + "_" + strDate + "_" + "!" + ".jpeg";
            strBlueImagePath = "http://app.bmwbarcode.com/Hospital/QrCode/" + hspTransEntity.HospitalName.Trim() + "_" + "B_" + hspTransEntity.BlueBag  + "_" + strDate + "_" + "!" + ".jpeg";
            strWhiteImagePath = "http://app.bmwbarcode.com/Hospital/QrCode/" + hspTransEntity.HospitalName.Trim() + "_" + "W_" + hspTransEntity.WhiteBag  + "_" + strDate + "_" + "!" + ".jpeg";

            hspTransEntity.BlueImgPath = strBlueImagePath;
            hspTransEntity.RedImgPath = strRedImagePath;
            hspTransEntity.YellowImgPath = strYellowImagePath;
            hspTransEntity.WhiteImgPath = strWhiteImagePath;
            hspTransEntity.AllImgPath = strAllImagePath;


          var hsps = _hspTransServices.CreateHspTransaction(hspTransEntity);
            // return _hspTransServices.CreateHspTransaction(hspTransEntity);

            getQRCodeAll(hspTransEntity);
            getQRCodeRed(hspTransEntity);
            getQRCodeYellow(hspTransEntity);
            getQRCodeBlue(hspTransEntity);
            getQRCodeWhite(hspTransEntity);


            if (hsps != null)
                return Request.CreateResponse(HttpStatusCode.OK, hsps);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Transaction found for this id");

            //  return Request.CreateResponse(HttpStatusCode.OK, hspTransEntity);


        }

        public bool Put(int id, [FromBody] HospitalTransactionEntity hspTransEntity)
        {
            if (id > 0)
            {
                return _hspTransServices.UpdateHspTransaction(id, hspTransEntity);
            }
            return false;
        }
        public bool Delete(int id)
        {
            if (id > 0)
                return _hspTransServices.DeleteTrans(id);
            return false;
        }

       

    }
}