/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkg004_petrolstation;

import java.net.URL;
import java.util.ResourceBundle;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;

/**
 *
 * @author Marcel Judth
 */
public class FXMLMainController implements Initializable {
    
    @FXML
    private Label lblMessage;

    @FXML
    private TextField txtNumberOfPumps;

    @FXML
    private Button btnStart;

    @FXML
    private TextField txtPumpServiceTime;

    @FXML
    private TextField txtTimeCarArr;

    @FXML
    private Button btnEnd;

    @FXML
    void actionPerform(ActionEvent event) {

    }
    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // TODO
    }    
    
}
