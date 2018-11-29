/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Data;

import java.util.Objects;

/**
 *
 * @author schueler
 */
public class Mitarbeit {
    private Projekt projekt;
    private Mitarbeiter mitarbeiter;
    private int Stunden;

    public Mitarbeit(Mitarbeiter mitarbeiter, Projekt projekt, int Stunden) {
        this.setMitarbeiter(mitarbeiter);
        this.setProjekt(projekt);
        this.setStunden(Stunden);
    }

    public Projekt getProjekt() {
        return projekt;
    }

    public void setProjekt(Projekt projekt) {
        this.projekt = projekt;
    }

    public int getStunden() {
        return Stunden;
    }

    public void setStunden(int Stunden) {
        this.Stunden = Stunden;
    }
    
    public Mitarbeiter getMitarbeiter() {
        return mitarbeiter;
    }

    public void setMitarbeiter(Mitarbeiter mitarbeiter) {
        this.mitarbeiter = mitarbeiter;
    }

    @Override
    public int hashCode() {
        int hash = 5;
        hash = 79 * hash + Objects.hashCode(this.projekt);
        hash = 79 * hash + Objects.hashCode(this.mitarbeiter);
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
        if (!Objects.equals(this.projekt, other.projekt)) {
            return false;
        }
        if (!Objects.equals(this.mitarbeiter, other.mitarbeiter)) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "Mitarbeit{" + "projekt=" + projekt + ", mitarbeiter=" + mitarbeiter + ", Stunden=" + Stunden + '}';
    }
}
