using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLoader
{
    public abstract class FileLoader
    {
        public string Path;
        public FileLoader(string Path)
        {
            this.Path = Path;
        }
    }
}
