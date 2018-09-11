/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkg99jdbc;

import java.net.URL;
import java.util.ResourceBundle;
import javafx.event.ActionEvent;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.ListView;
import pkgData.Database;
import pkgData.Employee;

/**
 *
 * @author org
 */
public class FXMLDocumentController implements Initializable {

    @FXML
    private Label txtMessage;

    @FXML
    private TextField txtConnString;

    @FXML
    private Button btnConnect;

    @FXML
    private Button btnSelect;

    @FXML
    void onClickBtnConnect(ActionEvent event) {
        try {
            db = new Database(txtConnString.getText());
            txtMessage.setText("db initialized but not proved");
        } catch (Exception ex) {
            txtMessage.setText(ex.getMessage());
        }
    }

    @FXML
    void onClickBtnSelect(ActionEvent event) {
        try {
            listEmps.getItems().clear();
            listEmps.getItems().addAll(db.selectEmps());
            txtMessage.setText("emps listed");
        } catch (Exception ex) {
            txtMessage.setText(ex.getMessage());
        }

    }

    @FXML
    private ListView<Employee> listEmps;

    @Override
    public void initialize(URL location, ResourceBundle resources) {
    }

    /**
     * other attributes
     */
    Database db;
}
