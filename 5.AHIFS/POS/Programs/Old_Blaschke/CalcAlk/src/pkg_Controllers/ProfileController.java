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
import javafx.scene.control.RadioButton;
import javafx.scene.control.TextField;
import javafx.stage.Stage;
import pkg_Data.Database;
import pkg_Data.Profile;
import pkg_Data.ProfileType;
import pkg_events.EventProfileChanged;

/**
 * FXML Controller class
 *
 * @author schueler
 */
public class ProfileController implements Initializable {

    
    
    
    /**
     * Initializes the controller class.
     * @param url
     * @param rb
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        
    }
    
    public ProfileController(){
        
    }

    @FXML
    private TextField txt_name;

    @FXML
    private TextField txt_weight;

    @FXML
    private RadioButton rbtn_female;

    @FXML
    private RadioButton rbtn_youth;

    @FXML
    private RadioButton rbtn_male;    
    
    @FXML
    private Button btn_cancel;

    @FXML
    private Button btn_add;
    
    private Database db = Database.getNewInstance();
    
    //Actionperfomed Methods
    
        //Radiobuttons
        @FXML
        void rbtnActionPerformed(ActionEvent event) {
            if(event.getSource() == this.rbtn_male){

            }else if(event.getSource() == this.rbtn_female){

            }else if(event.getSource() == this.rbtn_youth){

            }
        }

        //Buttons 
        @FXML
        void btnActionPerformed(ActionEvent event) throws Exception {
            try{
                if(event.getSource() == this.btn_cancel){
                    //Close Frame Profile
                    this.Close();
                }else if(event.getSource() == this.btn_add){
                    //Add Profile entry
                    this.Add();
                    this.Close();
                }
            }catch(Exception err){
                Database.notify(new EventProfileChanged(err.getMessage(),this));
            }


        }

    
    
    //MYFUNCTIONS 
        
    private void Close () throws Exception{
            Stage stage = (Stage) this.btn_cancel.getScene().getWindow();
            stage.close();   
    }
    
    private void Add() throws Exception{
        String name;
        int weight;
        ProfileType type = ProfileType.UNSET;
        Profile profile;
        
        //trying to set values

            try{
                    name = this.txt_name.getText();
                    weight = Integer.parseInt(this.txt_weight.getText());
                    if(this.rbtn_male.isSelected()){
                        type = ProfileType.valueOf(this.rbtn_male.getText().toUpperCase());
                    }else if(this.rbtn_female.isSelected()){
                        type = ProfileType.valueOf(this.rbtn_female.getText().toUpperCase());
                    }else if(this.rbtn_youth.isSelected()){
                        type = ProfileType.valueOf(this.rbtn_youth.getText().toUpperCase());
                    }
            
                //checking
                    if(type == ProfileType.UNSET)
                        throw new Exception("No Radio Button selected");
                    if("".equals(name))
                        throw new Exception("input 'name' not valid");
                    if(weight <= 0)
                        throw new Exception("input 'weight' not valid");

                    profile = new Profile(name,type,weight);

                // adding into database
                    this.db.add(profile);
                
            }catch (Exception err){
                throw new Exception ("Error at adding new Profile: " + err.getMessage());
            }
    }
    

    
    //LISTENERS

    
}
