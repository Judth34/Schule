package Data;

import Controller.AutoController;
import java.util.TreeSet;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author schueler
 */
public class Besitzer {
    private int svnr;
    private String name;
    private TreeSet<Auto> colAuto;
    private AutoController ac;

    public Besitzer(int svnr, String name, int fgnr, String marke, String type) throws Exception {
        this.colAuto = new TreeSet<>();
        this.ac = AutoController.getInstance();
        this.svnr = svnr;
        this.name = name;
        this.colAuto.add(ac.createAuto(fgnr, marke, type, this));
    }

    public int getSvnr() {
        return svnr;
    }
    
    public void setSvnr(int newSvnr){
        this.svnr = newSvnr;
    }

    public String getName() {
        return name;
    }
    
    public TreeSet<Auto> getAllAutos(){
        return (TreeSet<Auto>) colAuto.clone();
    }

    public void setName(String name) {
        this.name = name;
    }
    
    public void addAuto(Auto a) throws Exception{
        if(colAuto.contains(a)){
            throw new Exception("Auto already added!");
        }
        this.colAuto.add(a);
    }
    
    public void remove(Auto a) throws Exception{
        if(!this.colAuto.contains(a))
            throw new Exception("Auto is not in Col");
        this.colAuto.remove(a);
    }

    @Override
    public int hashCode() {
        int hash = 7;
        hash = 89 * hash + this.svnr;
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
        final Besitzer other = (Besitzer) obj;
        if (this.svnr != other.svnr) {
            return false;
        }
        return true;
    }
    
    
    
    @Override
    public String toString() {
        String autos = "";
        for(Auto a : this.colAuto)
            autos += "{fgnr=" + a.getFgnr() + ", marke=" + a.getMarke() + ", type=" + a.getType() + "},";
        return "Besitzer{" + "svnr=" + svnr + ", name=" + name + ", " + "Autos:[" + autos + "]" + '}';
    }
}
