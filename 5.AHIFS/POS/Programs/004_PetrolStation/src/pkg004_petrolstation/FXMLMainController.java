/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkg004_petrolstation;

import java.net.URL;
import java.util.ResourceBundle;
import javafx.beans.value.ChangeListener;
import javafx.beans.value.ObservableValue;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.ListView;
import javafx.scene.control.TextField;
import pkgData.CarGenerator;

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
    private ListView<String> listLog;    
    private CarGenerator carGenerator;
    
    
    @FXML
    void actionPerform(ActionEvent event) {
        try{
            if(event.getSource() == this.btnStart)
                this.startSimulation();
            else
                if(event.getSource() == this.btnEnd)
                    this.endSimulation();
        }catch(Exception ex){
            this.lblMessage.setText(ex.toString());
            ex.printStackTrace();
        }
    }
    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // TODO
        this.addListener();
    }    

    private void addListener() {
        this.txtTimeCarArr.lengthProperty().addListener(new ChangeListener<Number> (){
            @Override
            public void changed(ObservableValue<? extends Number> observable, Number oldValue, Number newValue) {
                if(newValue.intValue() > oldValue.intValue()){
                    char ch = txtTimeCarArr.getText().charAt(oldValue.intValue());

                    //Check if the new character is the number or other's
                    if(!(ch >= '0' && ch <= '9' )){       

                         //if it's not number then just setText to previous one
                         txtTimeCarArr.setText(txtTimeCarArr.getText().substring(0,txtTimeCarArr.getText().length()-1)); 
                    }
                }
            }
            
        });
        
        this.txtPumpServiceTime.lengthProperty().addListener(new ChangeListener<Number> (){
            @Override
            public void changed(ObservableValue<? extends Number> observable, Number oldValue, Number newValue) {
                if(newValue.intValue() > oldValue.intValue()){
                    char ch = txtPumpServiceTime.getText().charAt(oldValue.intValue());

                    //Check if the new character is the number or other's
                    if(!(ch >= '0' && ch <= '9' )){       

                         //if it's not number then just setText to previous one
                         txtPumpServiceTime.setText(txtPumpServiceTime.getText().substring(0,txtPumpServiceTime.getText().length()-1)); 
                    }
                }
            }
            
        });
        
        this.txtNumberOfPumps.lengthProperty().addListener(new ChangeListener<Number> (){
            @Override
            public void changed(ObservableValue<? extends Number> observable, Number oldValue, Number newValue) {
                if(newValue.intValue() > oldValue.intValue()){
                    char ch = txtNumberOfPumps.getText().charAt(oldValue.intValue());

                    //Check if the new character is the number or other's
                    if(!(ch >= '0' && ch <= '9' )){       

                         //if it's not number then just setText to previous one
                         txtNumberOfPumps.setText(txtNumberOfPumps.getText().substring(0,txtNumberOfPumps.getText().length()-1)); 
                    }
                }
            }
            
        });
    }

    private void startSimulation() {
        ObservableList<String> obs = FXCollections.observableArrayList();
        this.listLog.setItems(obs);
        this.carGenerator = new CarGenerator(4000, 2000, 1, obs);
        new Thread(this.carGenerator).start();
    }

    private void endSimulation() {
        this.carGenerator.setEnd();
    }
}
