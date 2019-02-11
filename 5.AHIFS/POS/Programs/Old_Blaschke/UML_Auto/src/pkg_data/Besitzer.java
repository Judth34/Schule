/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkg_data;

import java.util.TreeSet;
import pkg_crtl.AutoCrtl;

/**
 *
 * @author schueler
 */
public class Besitzer {
    private int SVN;        //unique
    private String name;        
    private TreeSet<Auto> autos;

    public Besitzer(int SVN, String name, TreeSet<Auto> autos) throws Exception {
        if(autos.size() < 1 )
            throw new Exception("no autos given");
        this.init(SVN, name, autos);
    }
    
    public Besitzer(int SVN, String name, Auto auto) throws Exception {
        TreeSet<Auto> temp = new TreeSet<>();
        temp.add(auto);
        this.init(SVN, name, temp);
    }
    
    public Besitzer(int SVN, String name, int FGNr, String Marke, String Type) throws Exception {
        TreeSet<Auto> temp;
        temp = new TreeSet<>();
        this.init(SVN, name,temp);
        
        AutoCrtl ac = AutoCrtl.getInstance();
        Auto a = ac.createNewAuto(FGNr, Marke, Type, this);
        temp.add(a);
        
    }

    public int getSVN() {
        return SVN;
    }

    public void setSVN(int SVN) {
        this.SVN = SVN;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public TreeSet<Auto> getAutos() {
        return autos;
    }

    public void setAutos(TreeSet<Auto> autos) {
        this.autos = autos;
    }

    @Override
    public int hashCode() {
        int hash = 3;
        hash = 97 * hash + this.SVN;
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
        if (this.SVN != other.SVN) {
            return false;
        }
        return true;
    }

    @Override
    public String toString() {
        return "Besitzer{" + "SVN=" + SVN + ", name=" + name + ", autos=" + autos + '}';
    }
    
    public String toStringNoAutos(){
        return "Besitzer{" + "SVN=" + SVN + ", name=" + name +  '}';
    }
    
    
    //**********
    
    public final void init (int SVN, String name, TreeSet<Auto> autos) {
        this.SVN = SVN;
        this.name = name;
        this.autos = autos;
    }

    public void addAuto(Auto auto){
        this.autos.add(auto);
    }
    
}
