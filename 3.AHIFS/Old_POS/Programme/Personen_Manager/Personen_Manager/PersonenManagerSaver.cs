using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personen_Manager
{
    abstract class PersonenManagerSaver
    {
        #region Properties
        public string Filename { get; set; }
        #endregion

        public abstract PersonenManager Load();

        abstract public void Save(PersonenManager pm);
    }
}
