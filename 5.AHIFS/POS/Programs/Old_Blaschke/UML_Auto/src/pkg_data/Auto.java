/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkg_data;

/**
 *
 * @author schueler
 */
public class Auto implements Comparable<Auto> {
    private int FGNr;       //unique
    private String Marke;
    private String Type;
    private Besitzer besitzer;
    
    public Auto(int FGNr, String Marke, String Type, Besitzer besitzer) throws Exception {
        this.init(FGNr, Marke, Type, besitzer);
    }
    
    public Auto(int FGNr, String Marke, String Type, int SVN, String name) throws Exception {
        this.init(FGNr, Marke, Type, new Besitzer(SVN , name , this ));
    }
    
    
    

    public int getFGNr() {
        return FGNr;
    }

    public void setFGNr(int FGNr) {
        this.FGNr = FGNr;
    }

    public String getMarke() {
        return Marke;
    }

    public void setMarke(String Marke) {
        this.Marke = Marke;
    }

    public String getType() {
        return Type;
    }

    public void setType(String Type) {
        this.Type = Type;
    }

    public Besitzer getBesitzer() {
        return besitzer;
    }

    public void setBesitzer(Besitzer besitzer) {
        this.besitzer = besitzer;
    }

    @Override
    public int hashCode() {
        int hash = 7;
        hash = 53 * hash + this.FGNr;
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
        if (this.FGNr != other.FGNr) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "Auto{" + "FGNr=" + FGNr + ", Marke=" + Marke + ", Type=" + Type + ", besitzer=" + besitzer.toStringNoAutos() + '}';
    }
    
//    public String toStringNoBesitzer() {
//        return "Auto{" + "FGNr=" + FGNr + ", Marke=" + Marke + ", Type=" + Type + '}';
//    }
    
    
    
    //**********

    private void init (int FGNr, String Marke, String Type, Besitzer besitzer) throws Exception {
        this.setFGNr(FGNr);
        this.setMarke(Marke);
        this.setType(Type);
        this.setBesitzer(besitzer);
    }

    @Override
    public int compareTo(Auto auto) {
        if(this.equals(auto))
            return 0;
        return -1;
    }


    
   
    
}
