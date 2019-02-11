/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkg_Controllers;

import java.io.File;
import java.net.URL;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import static java.time.temporal.ChronoUnit.DAYS;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.Observable;
import java.util.Observer;
import java.util.ResourceBundle;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.ComboBox;
import javafx.scene.control.DatePicker;
import javafx.scene.control.Label;
import javafx.scene.control.ListView;
import javafx.scene.control.TextField;
import javafx.scene.layout.AnchorPane;
import javafx.stage.FileChooser;
import javafx.stage.Stage;
import javafx.util.StringConverter;
import pkg_Data.AlcoholReduction;
import pkg_Data.Calculation;
import pkg_Data.Database;
import pkg_Data.Drink;
import pkg_Data.Profile;
import pkg_events.EventCalculationChanged;

/**
 * FXML Controller class
 *
 * @author schueler
 */
public class CalculationController implements Initializable {

    public CalculationController() {
        
    }

    /**
     * Initializes the controller class.
     * @param url
     * @param rb
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        
        db = Database.getNewInstance();
        try {
            this.fillComboxProfile();
            this.fillComboxdDrink();
            this.datePickerSetConverter();
        } catch (Exception ex) {
            System.out.println(ex.getMessage());
            Database.notify(new EventCalculationChanged("couldnt initialize : " + ex.getMessage(),this));
        }
    } 
        
    @FXML
    private TextField txt_quantity;

    @FXML
    private ComboBox<Profile> cb_profile;

    @FXML
    private ComboBox<Drink> cb_drink;

    @FXML
    private Button btn_cancel;
    
    @FXML
    private Button btn_save;

    
    @FXML
    private DatePicker dp_date;
    
    @FXML
    private ListView<AlcoholReduction> list_calc;

    @FXML
    private Button btn_calculate;
    
    @FXML
    private Label lbl_Message;
    
    private Database db;
    
    private Calculation currentCalculation = null;
    
    @FXML
    private AnchorPane content_pane;
    
    //action Performed methods
    @FXML
    void btnActionPerformed(ActionEvent event) {
        try{
            if(event.getSource()== this.btn_cancel){
                //closes Frame 
                this.Close();
            }else if (event.getSource() == this.btn_calculate){
                //calculates the right 
                this.calculate();
            }else if (event.getSource() == this.btn_save){
                //Saves the Calculation as xml file
                this.saveCalc();
            }
        }catch(Exception err){
            this.updateNotifications(err.toString());
        }
    }

    @FXML
    void cboxActionPerformed(ActionEvent event) {

    }
    
    @FXML
    void datePickerActionPerformed(ActionEvent event) {
        try{
            if(event.getSource() == this.dp_date){
                //check if date is valid
                this.validateDate();
            }
        }catch(Exception error){
            this.updateNotifications("date error : " + error.toString());
        }
    }
    
    
    //eventhandlers 
 
    //MY FUNCTIONS 
   
    private void fillComboxProfile() throws Exception{
        try {
           ObservableList<Profile> tmplist = FXCollections.observableArrayList(this.db.getProfiles());
           this.cb_profile.setItems(tmplist);
           if(tmplist.size() > 0)
            this.cb_profile.setValue(tmplist.get(0));
        }catch(Exception error){
            throw new Exception("Error in fillComboxProfile: " + error.getMessage() );
        }
    }
   
    private void fillComboxdDrink() throws Exception{
        try {
           ObservableList<Drink> tmplist = FXCollections.observableArrayList(this.db.getDrinks());
           this.cb_drink.setItems(tmplist);
           if(tmplist.size() > 0)
           this.cb_drink.setValue(tmplist.get(0));
        }catch(Exception error){
            throw new Exception("Error in fillComboxDrink: " + error.getMessage() );
        }
    }
   
    private void Close () throws Exception{
            Stage stage = (Stage) this.btn_cancel.getScene().getWindow();
            stage.close();   
    }
    
    private void calculate() throws Exception{
        try{
            Profile profile = this.cb_profile.getValue();
            Drink drink = this.cb_drink.getValue();
            double quantity = Double.parseDouble(this.txt_quantity.getText());
            LocalDate date = this.dp_date.getValue();
            
            this.checkdate();
            ArrayList<AlcoholReduction> tempList = Database.calculate(profile,drink,quantity);
            ObservableList<AlcoholReduction> list = FXCollections.observableArrayList(tempList);
            this.setCurrentCalculation(tempList,profile,drink,date);
            this.list_calc.setItems(list);
        }catch(Exception error){
            throw new Exception("Error at calculation : " + error.getMessage());
        }
    }

    private void updateNotifications(String notification){
        this.lbl_Message.setText(notification);
        Database.notify(new EventCalculationChanged(notification,this));
    }
    
    private void saveCalc() throws Exception{
        if(this.currentCalculation == null)
            throw new Exception("no calculation");
        FileChooser chooser = new FileChooser();
        chooser.setTitle("Open Resource File");
        File file;
        file = chooser.showSaveDialog((Stage)this.content_pane.getScene().getWindow());
        this.currentCalculation.save(file.getAbsolutePath());
        this.updateNotifications("--> sucessfully saved to " + file.getName());
    }
    
    private void setCurrentCalculation(ArrayList<AlcoholReduction> list,Profile profile,Drink drink,LocalDate date)throws Exception{
        this.currentCalculation = new Calculation(profile,drink,date,list);
    }
    
    private void datePickerSetConverter() {
        String pattern = "dd-MMM-yyyy";

        dp_date.setPromptText(pattern.toLowerCase());

        dp_date.setConverter(new StringConverter<LocalDate>() {
             DateTimeFormatter dateFormatter = DateTimeFormatter.ofPattern(pattern);

             @Override 
             public String toString(LocalDate date) {
                 if (date != null) {
                     return dateFormatter.format(date);
                 } else {
                     return "";
                 }
             }

             @Override 
             public LocalDate fromString(String string) {
                 if (string != null && !string.isEmpty()) {
                     return LocalDate.parse(string, dateFormatter);
                 } else {
                     return null;
                 }
             }
         });
    }
    
    private boolean checkdate() throws Exception{
        Calendar cal = Calendar.getInstance();
        LocalDate date = this.dp_date.getValue();
       
        if(date == null)
            throw new Exception("please enter a date");
        if(LocalDate.now().compareTo(date) < 0)
            throw new Exception("your date cant be in future!");
        if(DAYS.between(date, LocalDate.now()) > 7)
            throw new Exception("your date cant be more than 7 days in the past");
        return true;
        
        
    }
    
    private void validateDate() throws Exception{
        if(this.checkdate())
            this.updateNotifications("date is valid");
    }
    
}
