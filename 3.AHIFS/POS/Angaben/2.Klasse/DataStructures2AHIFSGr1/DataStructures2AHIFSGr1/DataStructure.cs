using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures2AHIFSGr1
{
    abstract class DataStructure
    {
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
        public DataStructure (string Name)
        {
            // fortlaufende ID vergeben 
            // Namen setzen 
        }

        public DataStructure(string Name, int Capacity)
        {
            // 1. Capacity - Parameter auf Gültigkeit überprüfen 
            // uint.MaxValue; 

            // 2. // fortlaufende ID vergeben 
                  // Namen setzen
                  // >> Codeduplizierung aber vermeiden !
        }

        public abstract bool IsEmpty();
        public abstract bool IsFull();
        public abstract void Add(string NewElement);
        public abstract string Remove();
        public abstract void Clear();
        public abstract bool Contains(string Element);
        // IsEmpty 
        // IsFull 

        // Add (ein Element dazuhängen)
        // Remove (ein Element rausnehmen - lt. Datenstruktur)
        // Clear (alle Element löschen)

        // Contains (prüft, ob Element mit diesem Wert enhalten ist)
    }
}
