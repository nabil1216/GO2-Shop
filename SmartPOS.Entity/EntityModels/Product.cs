using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SmartPOS.Entity.EntityModels
{
   public class Product
    {
        public int Id { get; set; }
        public string ItemId { get; set; }
        public string BrandId { get; set; }
        public string CategoryId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }

        public string Price { get; set; }
        public byte[] file { get; set; }
        public byte[] Image2 { get; set; }
        public HttpPostedFileBase File1 { get; set; }
        public HttpPostedFileBase File2 { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
