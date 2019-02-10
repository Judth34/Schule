/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkg_crtl;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.TreeSet;
import pkg_data.Auto;
import pkg_data.Besitzer;

/**
 *Singleton implementation
 * @author schueler
 */
public class BesitzerCrtl {
    private static BesitzerCrtl besitzerCrtl = null;
    private HashSet<Besitzer> all_besitzer = null;
    private HashSet<Integer> all_SVN;
    
    
    private BesitzerCrtl() {
    }
    
    

    //**********
    
    public static BesitzerCrtl getInstance(){
        if(BesitzerCrtl.besitzerCrtl == null)
            BesitzerCrtl.besitzerCrtl = new BesitzerCrtl();
        BesitzerCrtl.besitzerCrtl.all_besitzer = new HashSet<>();
        BesitzerCrtl.besitzerCrtl.all_SVN = new HashSet<>();
        
        return BesitzerCrtl.besitzerCrtl;
    }
    
    public Besitzer createBesitzer(int SVN, String name, TreeSet<Auto> autos) throws Exception{
        Besitzer besitzer;
        try{
            if(this.all_SVN.contains(SVN))
                throw new Exception("this SVN already exists!");
            if(this.all_SVN.add(SVN) == false)
                throw new Exception("cant add this SVN to HashSet");
            besitzer = new Besitzer(SVN, name, autos);
            if(this.all_besitzer.add(besitzer) == false)
                throw new Exception("cannot add this Auto to HashSet");  
            return besitzer;
        }catch(Exception error){
            throw new Exception("cant create Auto : " + error.toString());
        }
    }
    
    public Besitzer createBesitzer(int SVN, String name, Auto auto) throws Exception{
        Besitzer besitzer;
        try{
            if(this.all_SVN.contains(SVN))
                throw new Exception("this SVN already exists!");
            if(this.all_SVN.add(SVN) == false)
                throw new Exception("cant add this SVN to HashSet");
            besitzer = new Besitzer(SVN, name, auto);
            if(this.all_besitzer.add(besitzer) == false)
                throw new Exception("cannot add this Auto to HashSet");  
            return besitzer;
        }catch(Exception error){
            throw new Exception("cant create Auto : " + error.toString());
        }
    }
    
    public Besitzer createBesitzer(int SVN, String name, int FGNr, String Marke, String Type) throws Exception{
        Besitzer besitzer;
        try{
            if(this.all_SVN.contains(SVN))
                throw new Exception("this SVN already exists!");
            if(this.all_SVN.add(SVN) == false)
                throw new Exception("cant add this SVN to HashSet");
            besitzer = new Besitzer(SVN, name, FGNr, Marke, Type);
            if(this.all_besitzer.add(besitzer) == false)
                throw new Exception("cannot add this Auto to HashSet");  
            return besitzer;
        }catch(Exception error){
            throw new Exception("cant create Auto : " + error.toString());
        }
    }
    
    
    public void updateBesitzer (Besitzer besitzer , int SVN) throws Exception{
        try{
            if(BesitzerCrtl.besitzerCrtl.all_SVN.contains(SVN))
                throw new Exception("this SVN already exists");
            if(!BesitzerCrtl.besitzerCrtl.all_besitzer.contains(besitzer))
                throw new Exception("this Besitzer does not exist");
            besitzer.setSVN(SVN);
        }catch(Exception error){
            throw new Exception("error in update Besitzer : " + error.toString());
        }
    }
    
    
    public void removeBesitzer (Besitzer besitzer) throws Exception{
        if(!BesitzerCrtl.besitzerCrtl.all_besitzer.contains(besitzer))
            throw new Exception("this Besitzer does not exist");
       
        BesitzerCrtl.besitzerCrtl.all_besitzer.remove(besitzer);
    }
    
    
    public int countBesitzer (){
        return BesitzerCrtl.besitzerCrtl.all_besitzer.size();
    }
    
    public ArrayList<Besitzer> getBesitzerByName(String name) throws Exception{
        ArrayList<Besitzer> besitzer;
        try{
            besitzer = new ArrayList<>();
            for(Besitzer b : BesitzerCrtl.besitzerCrtl.all_besitzer)
                if(b.getName().compareTo(name) == 0 )
                    besitzer.add(b);
            if(besitzer.size() == 0)
                throw new Exception("no such Besitzer in col");
            return besitzer;
        }catch(Exception error){
            throw new Exception("error in getBesitzerByName : " + error.toString());
        }
        
    }
    
}
