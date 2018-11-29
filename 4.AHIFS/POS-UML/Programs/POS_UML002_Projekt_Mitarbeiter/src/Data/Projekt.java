/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Data;

/**
 *
 * @author schueler
 */
public class Projekt {
    private int kst;
    private String bezeichnung;

    public Projekt(int kst, String bezeichnung) {
        this.setKst(kst);
        this.setBezeichnung(bezeichnung);
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

    @Override
    public int hashCode() {
        int hash = 3;
        hash = 79 * hash + this.kst;
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
        return "Projekt{" + "kst=" + kst + ", bezeichnung=" + bezeichnung + '}';
    }
}
