/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controller;

import data.Mitarbeit;
import data.Mitarbeiter;
import data.Projekt;
import java.util.HashMap;
import java.util.TreeSet;

/**
 *
 * @author schueler
 */
public class Ctrl_Mitarbeit {
    private static Ctrl_Mitarbeit ctrl_mitarbeit;
    private HashMap<Integer,Mitarbeiter> mitarbeiter;
    private HashMap<Integer,Projekt> projekte;
    private TreeSet<Mitarbeit> mitarbeiten;

    private Ctrl_Mitarbeit() {
        this.init();
    }
    
    //**********
    
    private void init(){
        this.mitarbeiter = new HashMap<>();
        this.projekte = new HashMap<>();
        this.mitarbeiten = new TreeSet<>();
    }
    
    public static Ctrl_Mitarbeit getInstance(){
        if(Ctrl_Mitarbeit.ctrl_mitarbeit == null)
            Ctrl_Mitarbeit.ctrl_mitarbeit = new Ctrl_Mitarbeit();
        return Ctrl_Mitarbeit.ctrl_mitarbeit;
    }
    
    public Mitarbeiter createMitarbeiter(int svn, String name,int kst, String bezeichnung, int stunden) throws Exception{
        Mitarbeiter m;
        Mitarbeit ma;
        try{
            if(this.mitarbeiter.containsKey(svn))
                throw new Exception("this svn already belongs to an existing Mitarbeiter");
            if(this.projekte.containsKey(kst))
                throw new Exception("this kst already belongs to an existing Projekt");
            m = new Mitarbeiter(svn,name,kst,bezeichnung);
            ma = new Mitarbeit(m,m.getProjekt(),stunden);
            
            this.mitarbeiter.put(svn, m);
            this.projekte.put(kst, m.getProjekt());
            
            if(!this.mitarbeiten.add(ma))
                throw new Exception("cant add Mitarbeit to collection");
            
            return m;
        }catch(Exception error){
            throw new Exception("cant create Mitarbeiter : " + error.getMessage());
        }
    }
    
    public Mitarbeiter createMitarbeiter(int svn, String name,Projekt projekt, int stunden) throws Exception{
        Mitarbeiter m;
        Mitarbeit ma;
        try{
            if(this.mitarbeiter.containsKey(svn))
                throw new Exception("this svn already belongs to an existing Mitarbeiter");
            if(!this.projekte.containsKey(projekt.getKst()))
                throw new Exception("this projekt is not in col");
            m = new Mitarbeiter(svn,name,projekt);
            ma = new Mitarbeit(m,m.getProjekt(),stunden);
            
            this.mitarbeiter.put(svn, m);
            
            if(!this.mitarbeiten.add(ma))
                throw new Exception("cant add Mitarbeit to collection");
            
            return m;
        }catch(Exception error){
            throw new Exception("cant create Mitarbeiter : " + error.getMessage());
        }
    }
    
    
    
    
    
}
