/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Controllers;

import java.net.URL;
import java.util.ResourceBundle;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Label;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.Label;

/**
 *
 * @author schueler
 */
public class FXMLDocumentController implements Initializable {
    
    @FXML
    private Button btn_nextCar;

    @FXML
    private Button btn_lastCar;

    @FXML
    private Label lbl_message;

    @FXML
    void onSelectBtnLastCar(ActionEvent event) {
        lbl_message.setText("last pressed " + event.getSource());
    }

    @FXML
    void onSelectBtnNextCar(ActionEvent event) {
        lbl_message.setText("last pressed " + event.getSource());
    }

    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // TODO
    }    
    
}
