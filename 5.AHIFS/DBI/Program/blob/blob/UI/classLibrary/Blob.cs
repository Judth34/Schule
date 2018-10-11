using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classLibrary
{
    class Blob
    {
        public byte[] bytes{ get; set; }
        public string name{ get; set; }

        public Blob(byte[] bytes, string name)
        {
            this.bytes = bytes;
            this.name = name;
        }

        #region static
        
        #endregion 

    }
}
