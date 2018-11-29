/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Ctrl;

import Data.Mitarbeit;
import java.util.ArrayList;
import java.util.TreeSet;

/**
 *
 * @author Marcel Judth
 */
public class MitarbeitCtrl {
    private TreeSet<Mitarbeit> colMitarbeiten = new TreeSet<>();

    public MitarbeitCtrl() {
    }
    
    public void addMitarbeit(int Svnr, String name, int kst, String bez, int Stunden) throws Exception{
        for(Mitarbeit m : this.colMitarbeiten)
            if(m.getProjekt().getKst() == kst || m.getMitarbeiter().getSvNr() == Svnr)
                throw new Exception("Keys are not unique!");
        this.colMitarbeiten.add(new Mitarbeit(Svnr, name, kst, bez, Stunden));
    }
    
    public void remove(Mitarbeit m) throws Exception{
        if(!colMitarbeiten.remove(m))
            throw new Exception("The Mitarbeit is not in List!");
    }
    
    public ArrayList<Mitarbeit.Projekt> getProjekteBySvnr(int svnr){
        ArrayList<Mitarbeit.Projekt> allProjects = new ArrayList<>();
        for(Mitarbeit m : colMitarbeiten)
            if(m.getMitarbeiter().getSvNr() == svnr)
                allProjects.add(m.getProjekt());
        return allProjects;        
    }
    
    public TreeSet<Mitarbeit> getAllMitarbeiten(){
        return (TreeSet<Mitarbeit>) colMitarbeiten.clone();
    }
}
