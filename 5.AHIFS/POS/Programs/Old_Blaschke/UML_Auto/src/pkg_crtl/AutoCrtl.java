/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkg_crtl;

import java.util.HashSet;
import pkg_data.Auto;
import pkg_data.Besitzer;

/**
 * Singleton implementation
 * @author schueler
 */
public class AutoCrtl {
    private static AutoCrtl autoCrtl = null;
    private final HashSet<Integer> all_fgnr;
    private HashSet<Auto> all_autos = null;
    
    private AutoCrtl() {
        this.all_autos = new HashSet<>();
        this.all_fgnr = new HashSet<>();
    }
    
    
    //*********
    
    public static AutoCrtl getInstance(){
        if(AutoCrtl.autoCrtl == null)
            AutoCrtl.autoCrtl = new AutoCrtl();
        return AutoCrtl.autoCrtl;
    }
    
    public Auto createNewAuto(int FGNr, String Marke, String Type, Besitzer besitzer) throws Exception{
       Auto auto;
       try{
           if(this.all_fgnr.contains(FGNr))
               throw new Exception("this FGNr already exists!");
           if(this.all_fgnr.add(FGNr) == false)
               throw new Exception("cant add this FGNr to HashSet");
           auto = new Auto(FGNr,Marke,Type,besitzer);
           if(!besitzer.getAutos().contains(auto))
               besitzer.addAuto(auto);
           if(this.all_autos.add(auto) == false)
               throw new Exception("cannot add this Auto to HashSet");  
           return auto;
       }catch(Exception error){
           throw new Exception("cant create Auto : " + error.toString());
       }
    }
    
    public Auto createNewAuto(int FGNr, String Marke, String Type, int SVN, String name) throws Exception{
       Auto auto;
       try{
           if(this.all_fgnr.contains(FGNr))
               throw new Exception("this FGNr already exists!");
           if(this.all_fgnr.add(FGNr) == false)
               throw new Exception("cant add this FGNr to HashSet");
           auto = new Auto(FGNr,Marke,Type, SVN, name);
           if(!auto.getBesitzer().getAutos().contains(auto))
               auto.getBesitzer().addAuto(auto);
           if(this.all_autos.add(auto) == false)
               throw new Exception("cannot add this Auto to HashSet");  
           return auto;
       }catch(Exception error){
           throw new Exception("cant create Auto : " + error.toString());
       }
    }
    
    
    public void updateAuto (Auto auto , int FGNr) throws Exception{
        try{
            if(AutoCrtl.autoCrtl.all_autos.contains(FGNr))
                throw new Exception("this SVN already exists");
            if(!AutoCrtl.autoCrtl.all_autos.contains(auto))
                throw new Exception("this Besitzer does not exist");
            auto.setFGNr(FGNr);
        }catch(Exception error){
            throw new Exception("error in update Besitzer : " + error.toString());
        }
    }
    
    
    public void removeAuto (Auto auto) throws Exception{
        if(!AutoCrtl.autoCrtl.all_autos.contains(auto))
            throw new Exception("this Auto does not exist");
        if(!auto.getBesitzer().getAutos().remove(auto))
            throw new Exception("error at deleting Auto from Besitzer");
        AutoCrtl.autoCrtl.all_autos.remove(auto);
    }
    
    
    public int countAutos(){
        return AutoCrtl.autoCrtl.all_autos.size();
    }
}
