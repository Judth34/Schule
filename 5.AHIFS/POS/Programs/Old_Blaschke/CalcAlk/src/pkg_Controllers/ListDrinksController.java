/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkg_Controllers;

import java.net.URL;
import java.util.ResourceBundle;
import java.util.logging.Level;
import java.util.logging.Logger;
import javafx.beans.InvalidationListener;
import javafx.collections.ListChangeListener;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableColumn.CellEditEvent;
import javafx.scene.control.TableView;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.scene.control.cell.TextFieldTableCell;
import pkg_Data.Database;
import pkg_Data.Drink;
import pkg_events.EventListDrinksChanged;
import pkg_misc.DoubleConverter;

/**
 * FXML Controller class
 *
 * @author schueler
 */
public class ListDrinksController implements Initializable {

    @FXML
    private Button btn_LoadDrinks;

    @FXML
    private Button btn_AddDrink;

    @FXML
    private Button btn_Delete;
    
    @FXML
    private Label lbl_Message;

    @FXML
    private TableView<Drink> table_Drinks;

    @FXML
    private TableColumn<Drink, String> col_name;

    @FXML
    private TableColumn<Drink, Double> col_alcohol;

    private Database db;
    
    /**
     * Initializes the controller class.
     * @param url
     * @param rb
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        this.db = Database.getNewInstance();
        //load drinks into col
    }    
    
    

    // action performed Methods
    @FXML
    void btn_ActionPerformed(ActionEvent event) {
        try{
            if(event.getSource() == this.btn_LoadDrinks){
                //Loads Drinks from file
                this.LoadDrinks();
            }else if(event.getSource() == this.btn_AddDrink){
                //Adds a new Drink to col
                this.AddDrink();
            }else if(event.getSource() == this.btn_Delete){
                //Deletes Drink from Collection
                this.DeleteDrink();
            }
        }catch(Exception error){
            this.updateNotifications(error.toString());
        }
    }
    
    @FXML
    void onEditName(CellEditEvent <Drink,String> ev) {
        try{
            ((Drink)ev.getTableView().getItems().get(
            ev.getTablePosition().getRow())).setName(ev.getNewValue());
            this.updateNotifications("name changed");
        }catch(Exception error){
            this.updateNotifications(error.toString());
        }
    }

    @FXML
    void onEditAlcohol(CellEditEvent <Drink,Double> ev) {
       try{
            ((Drink)ev.getTableView().getItems().get(
            ev.getTablePosition().getRow())).setAlcohol(ev.getNewValue());
            this.updateNotifications("% vol changed");
        }catch(Exception error){
            this.updateNotifications(error.toString());
        }
    }
    
    
    
    //MY FUNCTIONS
    private void LoadDrinks(){
        try{
            this.updateList();
            this.updateNotifications("drinks loaded.");
        }catch(Exception error){
            this.updateNotifications(error.toString());
        }
    }
    
    private void AddDrink(){
        Drink drink;
        try {
            drink = new Drink("---",0.0);
            this.db.add(drink);
            this.updateList();
            this.updateNotifications("Drink " + drink.toString() + " added");
        } catch (Exception ex) {
            this.updateNotifications(ex.toString());
        }
    }
    
    private void DeleteDrink(){
        Drink drink;
        try{
            drink = this.table_Drinks.getSelectionModel().getSelectedItem();
            db.remove(drink);
            this.updateList();
            this.updateNotifications("Drink " + drink.toString() + " deleted");
        }catch(Exception error){
            this.updateNotifications(error.toString());
        }
    }

    private void updateList() throws Exception{
        this.table_Drinks.getItems().clear();
        this.table_Drinks.getItems().addAll(db.getDrinks());

        this.col_name.setCellValueFactory(
            new PropertyValueFactory<>("name"));
        this.col_alcohol.setCellValueFactory(
            new PropertyValueFactory<>("alcohol"));
        this.col_name.setStyle("-fx-aligment: CENTER");
        
        this.col_name.setCellFactory(TextFieldTableCell.forTableColumn());
        this.col_alcohol.setCellFactory(TextFieldTableCell.forTableColumn(new DoubleConverter()));
        
    }
    
    private void updateNotifications(String notification) {
       this.lbl_Message.setText(notification);
       Database.notify(new EventListDrinksChanged(notification,this));
    }
    
}
