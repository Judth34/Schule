/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Ctrl;

import Data.Mitarbeit;
import Data.Mitarbeiter;
import Data.Projekt;
import java.util.HashMap;
import java.util.TreeSet;

/**
 *
 * @author schueler
 */
public class MitarbeitCtrl {
    private static MitarbeitCtrl ctrl = new MitarbeitCtrl();
    private TreeSet <Mitarbeit> colMitarbeiten;

    private MitarbeitCtrl() {
        this.colMitarbeiten = new TreeSet<>();
    }    
    
    private static MitarbeitCtrl getInsance(){
        return ctrl;
    }
    
    private void addMitarbeit(int Svnr, String bezM, int kst, String bezP, int Stunden) throws Exception{
        for(Mitarbeit m : this.colMitarbeiten)
            if(m.getMitarbeiter().getSvNr() == Svnr || m.getProjekt().getKst() == kst)
                throw new Exception("SVNR or KST is not unique!");
        Projekt p = new Projekt(kst, bezP);
        Mitarbeiter m = new Mitarbeiter(Svnr, bezM);
        Mitarbeit newMitarbeit = new Mitarbeit(m, p, Stunden);
    }
}
