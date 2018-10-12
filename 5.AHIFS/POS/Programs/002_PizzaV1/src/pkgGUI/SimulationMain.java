/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgGUI;

import java.util.concurrent.Semaphore;
import java.util.logging.Level;
import java.util.logging.Logger;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;
import pkgPizza.Bar;
import pkgPizza.Cook;
import pkgPizza.Customer;

/**
 *
 * @author Marcel Judth
 */
public class SimulationMain extends Application{

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        launch(args);
//        try {
//            simulationMain();
//        } catch (InterruptedException ex) {
//            Logger.getLogger(SimulationMain.class.getName()).log(Level.SEVERE, null, ex);
//        }
    }
    
    private static void simulationMain() throws InterruptedException {
        System.out.println("*******start simulation");
        Semaphore semaPizzaOnBar = new Semaphore(2);
        Semaphore semBarFree = new Semaphore(1);
        Semaphore semaCustIsHungry = new Semaphore(1);
        semaCustIsHungry.acquire();
        Bar b = new Bar();       
        
        Customer c1 = new Customer("Ameise", b, semBarFree, semaPizzaOnBar, semaCustIsHungry);
        Customer c2 = new Customer("Bmeise", b, semBarFree, semaPizzaOnBar, semaCustIsHungry);
//        Customer c3 = new Customer("Cmeise", b, semBarFree, semaPizzaOnBar, semaCustIsHungry);
//
        Cook c = new Cook("Arnold", b, semBarFree, semaPizzaOnBar, semaCustIsHungry);
        c.start();
        c1.start();
        c2.start();
//        c3.start();
//
        Thread.sleep(10000);
//        c1.setEnd();
//        c2.setEnd();
//        c3.setEnd();
//        
        c1.join();
        c2.join();
//        c3.join();
//        
        System.out.println("Waiting for end!");
        Thread.sleep(10000);
        c.setEnd();
        System.out.println("*******end simulation");
    }    

    @Override
    public void start(Stage primaryStage) throws Exception {
        Parent root = FXMLLoader.load(getClass().getResource("FXMLMain.fxml"));
    
        Scene scene = new Scene(root, 300, 275);
    
        primaryStage.setTitle("FXML Welcome");
        primaryStage.setScene(scene);
        primaryStage.show();
    }
}