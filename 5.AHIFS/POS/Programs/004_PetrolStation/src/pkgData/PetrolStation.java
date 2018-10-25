/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgData;

import java.util.ArrayList;

/**
 *
 * @author Marcel Judth
 */
public class PetrolStation {
    private ArrayList<PetrolPump> colPetrolPumps;

    public PetrolStation() {
        this.colPetrolPumps = new ArrayList<>();
    }
    
    public void add(PetrolPump pp){
        this.colPetrolPumps.add(pp);
    }
    
    public PetrolPump getFreePump(){
        for(PetrolPump p : this.colPetrolPumps){
            if(p.isFree())
                return p;
        }
        return null;
    }
}
