/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package data;

/**
 *
 * @author schueler
 */
public class Mitarbeiter {
    private int svn;
    private String name;
    private Projekt projekt;

    public Mitarbeiter(int svn, String name,Projekt projekt) {
        this.init(svn, name,projekt);
    }

    public Mitarbeiter(int svn, String name, int kst, String bezeichnung) {
        this.init(svn, name, new Projekt(kst,bezeichnung,this));
    }
    
    

    public int getSvn() {
        return svn;
    }

    public void setSvn(int svn) {
        this.svn = svn;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Projekt getProjekt() {
        return projekt;
    }

    public void setProjekt(Projekt projekt) {
        this.projekt = projekt;
    }
    
    @Override
    public int hashCode() {
        int hash = 7;
        hash = 17 * hash + this.svn;
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
        final Mitarbeiter other = (Mitarbeiter) obj;
        if (this.svn != other.svn) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "Mitarbeiter{" + "svn=" + svn + ", name=" + name + ", projekt.kst =" + projekt.getKst() + ", projekt.bezeichnung =" + projekt.getBezeichnung() + '}';
    }
    
    
    //**********
    
    private void init(int svn, String name,Projekt projekt) {
        this.setSvn(svn);
        this.setName(name);
        this.setProjekt(projekt);
    }
    
}
