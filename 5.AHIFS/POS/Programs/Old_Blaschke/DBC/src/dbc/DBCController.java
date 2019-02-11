/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dbc;

import java.net.URL;
import java.util.ResourceBundle;
import javafx.event.ActionEvent;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.fxml.FXML;
import javafx.fxml.Initializable;
import javafx.scene.control.ListView;
import Data.Database;
import Data.Employee;
import events.EventDBC;
import java.util.logging.Level;
import java.util.logging.Logger;
import javafx.scene.control.TitledPane;

/**
 *
 * @author org
 */
public class DBCController implements Initializable {

    @Override
    public void initialize(URL location, ResourceBundle resources) {
        try {
            db = new Database(txtConnString.getText());
            this.updatenotifications(new EventDBC("connected",this));
        } catch (Exception ex) {
            this.updatenotifications(new EventDBC("error at initialize : " + ex.toString(),this));
        }
    }
 
    @FXML
    private Label txtMessage;

    @FXML
    private TextField txtConnString;
   
    @FXML
    private Button btnConnect;

    @FXML
    private Button btnSelect;

    @FXML
    private Button btnUpdate;

    @FXML
    private Button btnCommit;

    @FXML
    private Button btnRollback;
    
        @FXML
    private TextField txtEmpNo;

    @FXML
    private TextField txtEmpName;

    @FXML
    private TextField txtEmpSalary;
    
    @FXML
    private ListView<Employee> listEmps;
    
    @FXML
    private TitledPane messagePane;

    Database db;
   


    @FXML
    void btn_actionPerformed(ActionEvent event) {
        try{
            if(event.getSource() == this.btnConnect){
                //connects db
                this.connect();
            }else if(event.getSource() == this.btnSelect){
                //selects from db
                this.select();
            }else if(event.getSource()== this.btnUpdate){
                //updates db if permitted
                this.update();
            }else if(event.getSource() == this.btnRollback){
                //resets to default state
                this.rollback();
            }else if(event.getSource() == this.btnCommit){
                //sets changes
                this.commit();
            }
        }catch(Exception error){
            this.updatenotifications(new EventDBC("Exception happend: " + error.toString(),this,EventDBC.State.ERROR));
        }
    }
    

    
    
    //MYFUNCTIONS
    
    private void connect () throws Exception{
        db = new Database(txtConnString.getText());
        txtMessage.setText("db initialized but not proved");
    }
    
    private void select () throws Exception{
        listEmps.getItems().clear();
        listEmps.getItems().addAll(db.selectEmps());
        txtMessage.setText("emps listed");
    }
    
    private void update() throws Exception{
        int id;
        String name;
        float sal;
        Employee emp;
        try {
            id= Integer.parseInt(this.txtEmpNo.getText());
            name = this.txtEmpName.getText();
            sal = Float.parseFloat(this.txtEmpSalary.getText());
            emp = new Employee(id,name,sal);
        }catch(Exception error){
            throw new Exception("wrong input : "+ error.toString());
        }
        this.db.updateEmps(emp);
        this.updatenotifications(new EventDBC("sucessfully updated",this,EventDBC.State.SUCCESS));
    }
    
    private void commit() throws Exception{
        this.db.commit();
        this.updatenotifications(new EventDBC("sucessfully commited!",this,EventDBC.State.SUCCESS));
    }

    private void rollback() throws Exception{
        this.db.rollback();
        this.updatenotifications(new EventDBC("sucessfully commited!",this,EventDBC.State.SUCCESS));
    }
    
    private void updatenotifications(EventDBC event) {
        this.txtMessage.setText(event.getMessage());
        this.messagePane.getStyleClass().remove(1);
        if(null != event.getState())switch (event.getState()) {
            case ERROR:
                this.messagePane.getStyleClass().add("danger");
                break;
            case SUCCESS:
                this.messagePane.getStyleClass().add("success");
                break;
            case WARNING:
                this.messagePane.getStyleClass().add("warning");
                break;
            default:
                this.messagePane.getStyleClass().add("primary");
                break;
        }
    }
    
}
