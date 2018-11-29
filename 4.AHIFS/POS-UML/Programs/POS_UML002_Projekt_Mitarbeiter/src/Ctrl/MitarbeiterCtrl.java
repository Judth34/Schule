/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Ctrl;

import Data.Mitarbeiter;
import java.util.HashMap;

/**
 *
 * @author schueler
 */
public class MitarbeiterCtrl {
    private HashMap<Integer, Mitarbeiter> colMitarbeiter;

    public MitarbeiterCtrl() {
        this.colMitarbeiter = new HashMap<>();
    }
    
    public void add(int Svnr, String name, int Kst, String Bez) throws Exception{
//        if(this.colMitarbeiter.containsKey(newMitarbeiter.getSvNr()))
//            throw new Exception("SVNR already exsits!");
        if(this.colMitarbeiter.containsKey(Svnr))
            throw new Exception("SVNR already exsits!");
    }
}
