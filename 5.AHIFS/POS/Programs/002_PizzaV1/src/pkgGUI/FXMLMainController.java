/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgGUI;

import java.awt.Label;
import java.awt.MenuItem;
import java.awt.event.ActionEvent;
import java.net.URL;
import java.util.ResourceBundle;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.image.ImageView;

/**
 * FXML Controller class
 *
 * @author Marcel Judth
 */
public class FXMLMainController implements Initializable {

    @FXML
    private Label txtMessage;

    @FXML
    private MenuItem menueItemCreateImages;

    @FXML
    private MenuItem menuItemStop;

    @FXML
    private MenuItem menuItemStart;
    
    @FXML
    private ImageView imgCook1;

    @FXML
    private ImageView imgCook2;
    
    @FXML
    private ImageView imgCook3;

    @Override
    public void initialize(URL url, ResourceBundle rb) {
        
    }        
    
    @FXML
    void actionPerform(ActionEvent event) {
            
    }
}
