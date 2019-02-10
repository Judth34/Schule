/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkg_Controllers;

import java.net.URL;
import java.util.ResourceBundle;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;
import javafx.stage.Stage;
import pkg_Data.Database;
import pkg_Data.Drink;
import pkg_events.EventDrinkChanged;

/**
 * FXML Controller class
 *
 * @author schueler
 */
public class DrinkController implements Initializable {

    /**
     * Initializes the controller class.
     * @param url
     * @param rb
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        db = Database.getNewInstance();
    }   
    
    @FXML
    private TextField txt_name;

    @FXML
    private TextField txt_alcohol;

    @FXML
    private Button btn_cancel;

    @FXML
    private Button btn_add;
    
    private Database db ;

    @FXML
    void btnActionPerformed(ActionEvent event) {
        try{
            if(event.getSource() == this.btn_cancel ){
                //close Frame
                this.Close();
            }else if(event.getSource() == this.btn_add){
                //store drink in col
                this.Add();
                this.Close();
            } 
        }catch(Exception err){
            Database.notify(new EventDrinkChanged(err.getMessage(), this));
        }
        
    }
 
    
        //MYFUNCTIONS 
    
    private void Close () throws Exception{
        Stage stage = (Stage) this.btn_cancel.getScene().getWindow();
        stage.close();   
    }
    
    private void Add() throws Exception{
        String name;
        long alcohol;
        Drink drink;
            //trying to set values
                try{
                    name = this.txt_name.getText();
                    alcohol = Long.parseLong(this.txt_alcohol.getText());
                    
            //checking
                if("".equals(name))
                    throw new Exception("input 'name' not valid");
                if(alcohol < 0)
                    throw new Exception("input 'alcohol' not valid");
                drink = new Drink(name,alcohol);
                
            // adding into database
                this.db.add(drink);
                
        }catch (Exception err){
            throw new Exception ("Error at adding new Profile: " + err.getMessage());
        }
    }
    
}
