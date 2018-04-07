using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SmartPOS.App.Models
{
    public class ProductVm
    {
        public int? Id { get; set; }
        [DisplayName("Items")]
        public string ItemId { get; set; }
        [DisplayName("Brand")]
        public string BrandId { get; set; }
        [DisplayName("Front Image")]
        [NotMapped]

        [ValidateFile]

        public HttpPostedFileBase Image1 { get; set; }

        public class ValidateFileAttribute : ValidationAttribute
        {
            public override bool IsValid(object value)

            {

                int maxContent = 102400 * 10240; //1 MB

                string[] sAllowedExt = new string[] { ".jpg", ".gif", ".png" };





                var file = value as HttpPostedFileBase;



                if (file == null)

                    return false;

                else if (!sAllowedExt.Contains(file.FileName.Substring(file.FileName.LastIndexOf('.'))))

                {

                    ErrorMessage = "Please upload Your Photo of type: " + string.Join(", ", sAllowedExt);

                    return false;

                }

                else if (file.ContentLength > maxContent)

                {

                    ErrorMessage = "Your Photo is too large, maximum allowed size is : " + (maxContent / 1024).ToString() + "MB";

                    return false;

                }

                else

                    return true;

            }

        }

        [DisplayName("Front Image")]
        public byte[] Image2 { get; set; }
        [DisplayName("Category")]
        public string CategoryId { get; set; }
        [DisplayName("Code No")]
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$",ErrorMessage = "Enter only Number")]
        public string Price { get; set; }
      
    }
}