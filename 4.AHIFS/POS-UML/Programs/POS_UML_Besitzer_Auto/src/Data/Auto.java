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
public class Auto implements Comparable<Auto>{
    private int fgnr;
    private String marke;
    private String type;
    private Besitzer besitzer;

    public Auto(int fgnr, String marke, String type, Besitzer b) throws Exception {
        this.fgnr = fgnr;
        this.marke = marke;
        this.type = type;
        this.besitzer = b;
        b.addAuto(this);
    }

    public int getFgnr() {
        return fgnr;
    }

    public void setFgnr(int fgnr) {
        this.fgnr = fgnr;
    }

    public String getMarke() {
        return marke;
    }

    public void setMarke(String marke) {
        this.marke = marke;
    }

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }

    public Besitzer getBesitzer() {
        return besitzer;
    }

    public void setBesitzer(Besitzer besitzer) {
        this.besitzer = besitzer;
    }

    @Override
    public int hashCode() {
        int hash = 3;
        hash = 41 * hash + this.fgnr;
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
        final Auto other = (Auto) obj;
        if (this.fgnr != other.fgnr) {
            return false;
        }
        return true;
    }
    
    @Override
    public String toString() {
        return "Auto{" + "fgnr=" + fgnr + ", marke=" + marke + ", type=" + type + ", besitzer={" + besitzer.getSvnr() + ", " + besitzer.getName() + "}}";
    }

    @Override
    public int compareTo(Auto o) {
        return this.fgnr - o.fgnr;
    }
    
}
