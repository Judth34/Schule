/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pos_uml_besitzer_auto;

import Controller.AutoController;
import Data.Auto;
import Data.Besitzer;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author schueler
 */
public class Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        try {
            AutoController ac = AutoController.getInstance();
            Besitzer b = ac.createBesitzer(4034, "Julian Blaschke", 5000, "Audi", "A3");
            Auto ab = ac.createAuto(2100, "VW", "Golf", b);
            Besitzer c = ac.createBesitzer(5034, "Marcel Judth", 4000, "Peugeot", "600");
            ac.createAuto(2200, "Auto", "Typ", c);
            for(Auto a : b.getAllAutos()){
                System.out.println(a.toString());
            }
            System.out.println(b.toString());
        } catch (Exception ex) {
            Logger.getLogger(Main.class.getName()).log(Level.SEVERE, null, ex);
        }   
    }
    
}
