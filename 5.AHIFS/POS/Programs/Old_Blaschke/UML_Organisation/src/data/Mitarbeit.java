/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package data;

import java.util.Objects;

/**
 *
 * @author schueler
 */
public class Mitarbeit implements Comparable<Mitarbeit>{
    private Mitarbeiter mitarbeiter;
    private Projekt projekt;
    private int stunden;

    public Mitarbeit(Mitarbeiter mitarbeiter, Projekt projekt, int stunden) {
        this.init(mitarbeiter, projekt, stunden);
    }

    public Mitarbeiter getMitarbeiter() {
        return mitarbeiter;
    }

    public void setMitarbeiter(Mitarbeiter mitarbeiter) {
        this.mitarbeiter = mitarbeiter;
    }

    public Projekt getProjekt() {
        return projekt;
    }

    public void setProjekt(Projekt projekt) {
        this.projekt = projekt;
    }

    public int getStunden() {
        return stunden;
    }

    public void setStunden(int stunden) {
        this.stunden = stunden;
    }

    @Override
    public int hashCode() {
        int hash = 7;
        hash = 23 * hash + Objects.hashCode(this.mitarbeiter);
        hash = 23 * hash + Objects.hashCode(this.projekt);
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
        final Mitarbeit other = (Mitarbeit) obj;
        if (!Objects.equals(this.mitarbeiter, other.mitarbeiter)) {
            return false;
        }
        if (!Objects.equals(this.projekt, other.projekt)) {
            return false;
        }
        return true;
    }
    
    @Override
    public int compareTo(Mitarbeit mitarbeit) {
        if(this.getMitarbeiter().equals(mitarbeit.getMitarbeiter()))
            return this.getProjekt().getKst() - mitarbeit.getProjekt().getKst();
        return this.getMitarbeiter().getSvn() - mitarbeit.getMitarbeiter().getSvn();
    }
    
    
    //**********
    
    private void init(Mitarbeiter mitarbeiter, Projekt projekt, int stunden){
        this.setMitarbeiter(mitarbeiter);
        this.setProjekt(projekt);
        this.setStunden(stunden);
    }


}
