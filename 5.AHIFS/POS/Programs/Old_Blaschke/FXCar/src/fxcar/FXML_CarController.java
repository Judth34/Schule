/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package fxcar;

import java.net.URL;
import java.util.ResourceBundle;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.scene.layout.AnchorPane;

/**
 *
 * @author schueler
 */
public class FXML_CarController implements Initializable {
    
    @FXML
    private TextField txtName;

    @FXML
    private Button buttonGo;

    @FXML
    private Label lblMessage;

    @FXML
    private TextField txtId;

    @FXML
    void handleButtonAction(ActionEvent event) {
        lblMessage.setText(txtName.getText() + " inserted");
    }
    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // TODO
    }    
    
}
