/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package basti;

/**
 *
 * @author schueler
 */
public class Basti {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
       
        int idfortlaufend = 0;
        printStar(2,4);
        
        Person basti = new Person();
        basti.setName("basti");

        Person julian = new Person();
        julian.setName("julian");
        
        
        System.out.println(julian);
        
    }

    private static void printStar(int op1, int op2) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }
    
}
