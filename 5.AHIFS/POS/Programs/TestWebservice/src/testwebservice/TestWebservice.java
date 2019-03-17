/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package testwebservice;

import java.io.IOException;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Marcel Judth
 */
public class TestWebservice {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        try {
            Database db = new Database();
//            Database.call_me();
            // TODO code application logic here
            Database.getUsers();
        } catch (Exception ex) {
            Logger.getLogger(TestWebservice.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
}
