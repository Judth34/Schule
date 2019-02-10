/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package uml_auto;


import pkg_crtl.AutoCrtl;
import pkg_crtl.BesitzerCrtl;
import pkg_data.Auto;
import pkg_data.Besitzer;

/**
 *
 * @author schueler
 */
public class UML_Auto {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        
        Besitzer achim;
        Besitzer gerald;
        
        Auto merc;
        Auto opel;
        
        AutoCrtl ac;
        BesitzerCrtl bc;
        
        try{
            ac = AutoCrtl.getInstance();
            bc = BesitzerCrtl.getInstance();
            
            achim = bc.createBesitzer(1233495, "Achim" , 121834, "def","abc");
            gerald = bc.createBesitzer(3848234, "Gerald" , 1213131, "def","abc");
            
            
            merc = ac.createNewAuto(124412, "mercedes", "benz", gerald);
            opel = ac.createNewAuto(131313, "opel", "corsa", achim);
            
            //bc.removeBesitzer(gerald);
            
            System.out.println(bc.getBesitzerByName("wlörkw"));
            
            System.out.println(gerald);
            System.out.println(achim);
            
        }catch(Exception error){
            System.out.println("an error occured: " + error.toString());
        }
    }
    
}
