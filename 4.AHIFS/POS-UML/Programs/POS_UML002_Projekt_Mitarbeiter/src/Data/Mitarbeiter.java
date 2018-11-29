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
public class Mitarbeiter {
    private int SvNr;
    private String name;

    public Mitarbeiter(int SvNr, String name) {
        this.setSvNr(SvNr);
        this.setName(name);
    }

    public int getSvNr() {
        return SvNr;
    }

    public void setSvNr(int SvNr) {
        this.SvNr = SvNr;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    @Override
    public int hashCode() {
        int hash = 7;
        hash = 19 * hash + this.SvNr;
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
        if (this.SvNr != other.SvNr) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "Mitarbeiter{" + "SvNr=" + SvNr + ", name=" + name + '}';
    }
}
