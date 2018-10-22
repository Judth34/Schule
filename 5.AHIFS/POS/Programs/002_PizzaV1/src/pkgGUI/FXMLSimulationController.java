/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgGUI;

import javafx.scene.input.KeyEvent;
import java.net.URL;
import java.util.ArrayList;
import java.util.ResourceBundle;
import java.util.concurrent.Semaphore;
import java.util.logging.Level;
import java.util.logging.Logger;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.MenuItem;
import javafx.scene.image.ImageView;
import pkgPizza.Bar;
import pkgPizza.Cook;
import pkgPizza.Customer;

/**
 * FXML Controller class
 *
 * @author Marcel Judth
 */
public class FXMLSimulationController implements Initializable {
    
    @FXML
    private ImageView imgCook3;

    @FXML
    private ImageView imgCook1;

    @FXML
    private ImageView imgCook2;

    @FXML
    private MenuItem menuItemCreateImages;
        
    @FXML
    private MenuItem menuItemStart;
        
    @FXML
    private MenuItem menuItemStop;
    
    private ArrayList<ImageView> allImages; 
    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        try {
            // TODOasd
            this.setImages();
            this.simulationMain();
        } catch (InterruptedException ex) {
            Logger.getLogger(FXMLSimulationController.class.getName()).log(Level.SEVERE, null, ex);
        }
    }    
    
    @FXML
    public void actionPerform(KeyEvent event) {
        if(event.getSource() == this.menuItemCreateImages){
            this.createImages();
        }
    }

    private void createImages() {
        this.imgCook2.setVisible(true);
    }

    private void setImages() {
        this.allImages = new ArrayList<>();
        this.allImages.add(imgCook1);
        this.allImages.add(imgCook2);
        this.allImages.add(imgCook3);
//        this.allImages.add(imgCook3);
//        this.allImages.add(imgCook3);
//        this.allImages.add(imgCook3);


    }
    
    
    private void simulationMain() throws InterruptedException {
        System.out.println("*******start simulation");
        Semaphore semaPizzaOnBar = new Semaphore(2);
        Semaphore semBarFree = new Semaphore(1);
        Semaphore semaCustIsHungry = new Semaphore(1);
        semaCustIsHungry.acquire();
        Bar b = new Bar();
        
        Customer c1 = new Customer("Ameise", b, semBarFree, semaPizzaOnBar, semaCustIsHungry);
        Customer c2 = new Customer("Bmeise", b, semBarFree, semaPizzaOnBar, semaCustIsHungry);
        Customer c3 = new Customer("Cmeise", b, semBarFree, semaPizzaOnBar, semaCustIsHungry);

        Cook cook = new Cook("Adam", b, semBarFree, semaPizzaOnBar, semaCustIsHungry);
        Cook cook2 = new Cook("Eva", b, semBarFree, semaPizzaOnBar, semaCustIsHungry);
        Cook cook3 = new Cook("Moses", b, semBarFree, semaPizzaOnBar, semaCustIsHungry);

        this.imgCook1.xProperty().bind(cook.getDoubleProperty());
        this.imgCook2.xProperty().bind(cook2.getDoubleProperty());
        this.imgCook3.xProperty().bind(cook3.getDoubleProperty());

        new Thread(cook).start();
        new Thread(cook2).start();
        new Thread(cook3).start();
        new Thread(c1).start();
        new Thread(c2).start();
        new Thread(c3).start();
    }    
    
}
