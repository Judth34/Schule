using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures2AHifsGr2
{
    abstract class Datastructure
    {
        public string Name { get; private set; }
        // ID ; wird automatisch fortlaufend 
        // aufsteigend vergeben (beginnend mit 1) 
        // - kann nur gelesen werden 

        // Name, der bei der Anlage des Objekts vergeben werden muss 
        // und danach nicht mehr geändert werden darf. 
        // Dieser Name steht den Verwendern der Klasse lesend zur Verfügung 

        // Kapazität
        // Kann durch den Konstruktor vorgegeben werden; darf in Folge gelesen werden 
        // kann nur über die Methode Resize verändert werden (verkleinern der Kapazität 
        // ist nur erlaubt, wenn es zu keinem Datenverlust in der Datenstruktur kommt) 
        public Datastructure(string Name, int Capacity)
        {
            if ((Capacity < 1) || (Capacity > int.MaxValue))
            {
                throw new Exception("invalid capacity in Datastructure.create");
            }
            this.Name = Name;
        }

        public abstract void Add(string NewElement);
        public abstract string Remove();
        public abstract bool IsEmpty();
        public abstract bool IsFull();
        public abstract void Clear();
        public abstract int Count { get;}
        public abstract bool Contains(string Element);
    }
}
