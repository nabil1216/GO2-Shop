using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using SmartPOS.Entity.EntityModels;
using SmartPOS.Gateway;

namespace SmartPOS.Manager
{
  public  class ProductManager
    {
        ProductGateway productGateway=new ProductGateway();
        private const int MaxImgSize = 524288;
        public List<Brand> FillCategory(int id)
        {
            return productGateway.FillCategory(id);
        }

        public String Save(Product product)
        {
            using (var scope = new TransactionScope())
            {
                int rowAffected = productGateway.Save(product);

               // MemoryStream tmpStream = new MemoryStream();
                //barcode.Save(tmpStream, ImageFormat.Png); // change to other format
                //tmpStream.Seek(0, SeekOrigin.Begin);
                //product.Barcode = new byte[Int32.MaxValue];
                //tmpStream.Read(product.Barcode, 0, Int32.MaxValue);
                if ( rowAffected > 0)
                {
                    scope.Complete();
                    scope.Dispose();
                    return "Saved successfully";
                }

                scope.Dispose();
                return "Save Failed";
            }
        }

        public string Update(Product product)
        {
            int rowAfftected = productGateway.Update(product);
            if (rowAfftected > 0)
            {
                return "Item Updated";
            }

            return "Update Failed";
        }

        public List<Product> GetAllProduct()
        {
            return productGateway.GetAllProduct();
        }

        public Product GetById(int id)
        {
            return productGateway.GetById(id);
        }

        //private byte[] GenerateBarcode(int productId)
        //{
        //    string image;
        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        //The Image is drawn based on length of Barcode text.
        //        using (Bitmap bitMap = new Bitmap(image))
        //        {
        //            //The Graphics library object is generated for the Image.
        //            //using (Graphics graphics = Graphics.FromImage(bitMap))
        //            //{
        //            //    //The installed Barcode font.
        //            //    Font oFont = new Font("IDAutomationHC39M", 16);
        //            //    PointF point = new PointF(2f, 2f);

        //            //    //White Brush is used to fill the Image with white color.
        //            //    SolidBrush whiteBrush = new SolidBrush(Color.White);
        //            //    graphics.FillRectangle(whiteBrush, 0, 0, bitMap.Width, bitMap.Height);

        //            //    //Black Brush is used to draw the Barcode over the Image.
        //            //    SolidBrush blackBrush = new SolidBrush(Color.Black);
        //            //    graphics.DrawString("*" + barcode + "*", oFont, blackBrush, point);
        //            //}

        //            //The Bitmap is saved to Memory Stream.
        //            bitMap.Save(ms, ImageFormat.Png);
        //            //bitMap.Save(@"E:\test\123.png");
        //            byte[] imageBytes = new byte[MaxImgSize];
        //            ms.Read(imageBytes, 0, MaxImgSize);
        //            return imageBytes;
        //        }
        //    }
        //}
    }
}
