using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SmartPOS.Entity.EntityModels
{
   public class Attachment
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public byte[] FileData { get; set; }
        public string contentType { get; set; }

        public Attachment(string fileName, string filePath)
        {
            this.FileName = fileName;
            this.FilePath = filePath + @"\" + fileName;
            this.FileData = System.IO.File.ReadAllBytes(FilePath);
            this.contentType = MimeMapping.GetMimeMapping(FilePath);
        }
    }
}
