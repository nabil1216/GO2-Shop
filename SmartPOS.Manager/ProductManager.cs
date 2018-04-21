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
using System.IO;
using System.Configuration;
using System.Web;

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
                int id = productGateway.Save(product);

                //MemoryStream tmpStream = new MemoryStream();
                //barcode.Save(tmpStream, ImageFormat.Png); // change to other format
                //tmpStream.Seek(0, SeekOrigin.Begin);
                //product.Barcode = new byte[Int32.MaxValue];
                //tmpStream.Read(product.Barcode, 0, Int32.MaxValue);
               // int rowAffected = productGateway.(product);
                if (id > 0)
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

        private byte[] PostImage(int productId, HttpPostedFileBase postedFile)
        {
            byte[] bytes;

            using (BinaryReader br = new BinaryReader(postedFile.InputStream))
            {
                bytes = br.ReadBytes(postedFile.ContentLength);
            }
            byte[] imageBytes = new byte[MaxImgSize];
            return imageBytes;
            
            
        }
    }
}
