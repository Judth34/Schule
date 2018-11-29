/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Controller;

import Data.Auto;
import Data.Besitzer;
import java.util.ArrayList;
import java.util.HashSet;

/**
 *
 * @author schueler
 */
public class AutoController {
    private HashSet<Auto> colAutos;
    private HashSet<Besitzer> colBesitzer;
    private static AutoController ac;

    private AutoController() {
        colAutos = new HashSet<>();
        colBesitzer = new HashSet<>();
    }
    
    public static AutoController getInstance(){
        if(ac == null){
            ac = new AutoController();
            return ac;
        }
        return ac;
    }
    
    public Besitzer createBesitzer(int svnr, String name, int fgnr, String marke, String type) throws Exception{
        Besitzer b =  new Besitzer(svnr, name, fgnr, marke, type);
        if(this.colBesitzer.contains(b))
            throw new Exception("SVNR already added!");
        this.colBesitzer.add(b);
        return b;
    }
    
    public Auto createAuto(int fgnr, String marke, String type, Besitzer besitzer) throws Exception{
        Auto a = new Auto(fgnr, marke, type, besitzer);
        if(this.colAutos.contains(a))
            throw new Exception("FGNR already added!");
        this.colAutos.add(a);
        return a;
    }
    
    public void updateBesitzer(Besitzer b, int newSvnr) throws Exception{
        this.remove(b);
        b.setSvnr(newSvnr);
        if(this.colBesitzer.contains(b))
            throw new Exception("SVNR already added!");
        this.colBesitzer.add(b);
    }
    
    public void updateAuto(Auto a, int newFgnr) throws Exception{
        this.remove(a);
        a.setFgnr(newFgnr);
        if(this.colAutos.contains(a))
            throw new Exception("FGNR already added!");
        this.colAutos.add(a);
    }
    
    public void remove(Besitzer b) throws Exception{
        if(!this.colBesitzer.contains(b))
            throw new Exception("Besitzer is not in Col!");
        for(Auto a : b.getAllAutos())
            this.remove(a);
        this.colBesitzer.remove(b);
    }
    
    public void remove(Auto a) throws Exception {
        if(!this.colAutos.contains(a))
            throw new Exception("Auto is not in Col!");
        a.getBesitzer().remove(a);
        this.colAutos.remove(a);
    }
    
    public int countBesitzer(){
        return this.colBesitzer.size();
    }
    
    public int countAutos(){
        return this.colAutos.size();
    }
    
    public ArrayList<Besitzer> getBesitzerByName(String name){
        ArrayList<Besitzer> allBesitzer = new ArrayList<>();
        for(Besitzer b : this.colBesitzer)
            if(b.getName().equals(name))
                allBesitzer.add(b);
        return allBesitzer;
    }
    
    public Besitzer get(int Svnr){
        for(Besitzer b : this.colBesitzer)
            if(b.getSvnr() == Svnr)
                return b;
        return null;
    }
}
