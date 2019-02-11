/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package data;

import java.util.TreeSet;

/**
 *
 * @author schueler
 */
public class Projekt {
    private int kst;
    private String bezeichnung;
    private TreeSet<Mitarbeiter> mitarbeiter;

    public Projekt(int kst, String bezeichnung,Mitarbeiter mitarbeiter) {
        this.init(kst, bezeichnung,mitarbeiter);
    }

    public Projekt(int kst, String bezeichnung, int svn, String name ) {
        this.init(kst, bezeichnung, new Mitarbeiter(svn,name,this));
    }

    public int getKst() {
        return kst;
    }

    public void setKst(int kst) {
        this.kst = kst;
    }

    public String getBezeichnung() {
        return bezeichnung;
    }

    public void setBezeichnung(String bezeichnung) {
        this.bezeichnung = bezeichnung;
    }

    public Mitarbeiter getMitarbeiter() {
        return mitarbeiter;
    }

    public void setMitarbeiter(Mitarbeiter mitarbeiter) {
        this.mitarbeiter = mitarbeiter;
    }

    @Override
    public int hashCode() {
        int hash = 7;
        hash = 13 * hash + this.kst;
        return hash;
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (obj == null) {
            return false;
        }
        if (getClass() != obj.getClass()) {
            return false;
        }
        final Projekt other = (Projekt) obj;
        if (this.kst != other.kst) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "Projekt{" + "kst=" + kst + ", bezeichnung=" + bezeichnung + ",mitarbeiter.svn=" + this.mitarbeiter.getSvn() + ",mitarbeiter.svn=" + this.mitarbeiter.getName() + '}';
    }
    
    
    //**********
    
    private void init(int kst, String bezeichnung,Mitarbeiter mitarbeiter){
        this.setKst(kst);
        this.setBezeichnung(bezeichnung);
        this.setMitarbeiter(mitarbeiter);
    }
    
}
