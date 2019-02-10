/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package uml_organisation;

import controller.Ctrl_Mitarbeit;
import data.Mitarbeiter;

/**
 *
 * @author schueler
 */
public class UML_Organisation {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        
        Mitarbeiter mitarbeiter;
        Ctrl_Mitarbeit ctrl;
        try{
           ctrl = Ctrl_Mitarbeit.getInstance();
           mitarbeiter = ctrl.createMitarbeiter(446251099, "Julian Blaschke", 99283, "Java Entwicklung", 0);
           System.out.println(mitarbeiter);
        }catch(Exception error){
            System.out.println(error.getMessage().toString());
        }
        
        
    }
    
}
