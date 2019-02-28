using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Data
{
    public class File
    {
        public ObjectId _id { get; set; }
        public String filename { get; set; }
        public String fileContent { get; set; }

        public File(String filename, String fileContent)
        {
            this.filename = filename;
            this.fileContent = fileContent;
        }

        public override string ToString()
        {
            return filename;
        }
    }
}
