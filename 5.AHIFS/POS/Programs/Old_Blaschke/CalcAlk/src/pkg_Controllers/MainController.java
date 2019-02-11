/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkg_Controllers;
import pkg_Data.Database;
import java.io.File;
import java.net.URL;
import java.util.EventObject;
import java.util.Observable;
import java.util.Observer;
import java.util.ResourceBundle;
import javafx.collections.ListChangeListener;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.image.ImageView;
import javafx.scene.layout.VBox;
import javafx.stage.FileChooser;
import javafx.stage.Modality;
import javafx.stage.Stage;
import pkg_Data.Drink;
import pkg_Data.Profile;
import pkg_Data.ProfileType;
import pkg_events.EventCalcAlkChanged;
import pkg_events.EventCalculationChanged;
import pkg_events.EventDrinkChanged;
import pkg_events.EventListDrinksChanged;
import pkg_events.EventProfileChanged;

/**
 *
 * @author schueler
 */
public class MainController implements Initializable,Database.OnExceptionControllerListener,ListChangeListener {
    
    public MainController () throws Exception{
        if(instanceCounter == 0){
            instanceCounter = -1;
            mc = this;
        }else{
            throw new Exception("singleton instance error");
        }
    }
    
    public static MainController getInstance() throws Exception{
        if(mc == null)
            mc = new MainController();
        return mc;
    }
    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        //MainGui listens for other GUIs to pass EventObjects along
        this.db.addOnExceptionControllerListener(this);
    }

    @FXML
    private VBox pane_content;

    @FXML
    private Button btn_addProfile;

    @FXML
    private Button btn_addDrinks;

    @FXML
    private Button btn_calculation;

    @FXML
    private Button btn_save;

    @FXML
    private Button btn_load;
    
    @FXML
    private Button btn_loadSql;
    
    @FXML
    private Button btn_saveSql;
    
    @FXML
    private Button btn_ListDrinks;

    @FXML
    private Label lbl_Message;

    @FXML
    private ImageView img_beer;

    @FXML
    private Label lbl_title;
    
    private Database db = Database.getNewInstance();
    
    private static MainController mc = null;
    
    private static int instanceCounter = 0;
    
    private static String connString = "jdbc:oracle:thin:@192.168.128.152:1521:ora11g";
    
    //action listeners
    
    @FXML
    void onMenuSelection(ActionEvent event) {
        try{
            if(event.getSource() == this.btn_addProfile){
                //creates new Frame Profile
                this.showFrame("pkg_resource/FXMLProfile.fxml","Profile");
            }else if(event.getSource() == this.btn_addDrinks){
                //creates new Frame Drink
                this.showFrame("pkg_resource/FXMLDrink.fxml","Drink");
            }else if(event.getSource() == this.btn_calculation){
                //creates new Frame Calculation
                this.showFrame("pkg_resource/FXMLCalculation.fxml","Calculation");
            }else if(event.getSource() == this.btn_ListDrinks){
                //creates new Frame Calculation
                this.showFrame("pkg_resource/FXMLListDrinks.fxml","List Drinks");
            }else if(event.getSource() == this.btn_load){
                //loades binary file into db (options: CONCAT / OVERRIDE)
                this.load();
            }else if(event.getSource() == this.btn_save){
                //saves current db to binary file
                this.save();
            }else if(event.getSource() == this.btn_loadSql){
                //loads the data from database
                this.loadSql();
            }else if(event.getSource() == this.btn_saveSql){
                //saves the data into database /wheater appends or overrides the current state
                this.saveSql();
            }
        }catch (Exception ex){
            this.handleEvent(new EventCalcAlkChanged(ex.getMessage(),this));
        }
        
        
    }
   
    
    //MYFUNCTIONS 
    
    private void showFrame(String path,String title) throws Exception{
        Stage stage = new Stage();
        Parent root = FXMLLoader.load(getClass().getClassLoader().getResource(path));
        Scene scene = new Scene(root);
        stage.setScene(scene);
        stage.setTitle(title);
        stage.initModality(Modality.APPLICATION_MODAL);
        
        this.updateNotification("-->    Frame '" + title + "' sucessfully generated");
        stage.showAndWait();
        //this.lbl_message.setText(title + "was sucessfully loaded");
    }

    private void updateNotification(String notification){
        this.lbl_Message.setText(notification);
    }
    
    private void updateNotification(String notification,String classname){
        this.lbl_Message.setText("Message from " + classname + ": " + notification);
    }
    
    private void save() throws Exception{
        FileChooser chooser = new FileChooser();
        chooser.setTitle("Open Resource File");
        File file;
        file = chooser.showSaveDialog((Stage)this.pane_content.getScene().getWindow());
        db.save(file.getAbsolutePath());
        
    }
    
    private void load() throws Exception{
        FileChooser chooser = new FileChooser();
        chooser.setTitle("Open File to load");
        File file;
        file = chooser.showOpenDialog((Stage)this.pane_content.getScene().getWindow());
        //OVERRIDE  -->     Delete current cols in db and replace with data from file
        //CONCAT    -->     Append data from file to current cols in db
        db.load(file.getAbsolutePath(),Database.LoadType.OVERRIDE); 
    }
    
    private void loadSql() throws Exception{
        //Connect to database
        db.connect(connString);
        //Saves both col drink and col profile into db from sql db
        //OVERRIDE  -->     Delete current cols in db and replace with data from file
        //CONCAT    -->     Append data from file to current cols in db
        db.loadSql(Database.LoadType.CONCAT);
    }
    
    private void saveSql() throws Exception{
        //Connect to database
        db.connect(connString);
        db.saveSql();
    }
    
    
    //eventhandlers
   

    @Override
    public void handleEvent(EventObject event) {
        if(event.getClass().equals(EventDrinkChanged.class)){
            //Something has happend in GUI Drink
            this.updateNotification(((EventDrinkChanged)event).getMessage(),EventDrinkChanged.class.toString());
        }else if(event.getClass().equals(EventProfileChanged.class)){
            //Something has happend in GUI Profile
            this.updateNotification(((EventProfileChanged)event).getMessage(),EventProfileChanged.class.toString());
        }else if(event.getClass().equals(EventCalculationChanged.class)){
            //Something has happend in GUI Calculation
            this.updateNotification(((EventCalculationChanged)event).getMessage(),EventCalculationChanged.class.toString());
        }else if(event.getClass().equals(EventCalcAlkChanged.class)){
            //Something has happend in GUI Calc Alk
            this.updateNotification(((EventCalcAlkChanged)event).getMessage(),EventCalcAlkChanged.class.toString());
        }else if(event.getClass().equals(EventListDrinksChanged.class)){
            //Something has happend in GUI Calc Alk
            this.updateNotification(((EventListDrinksChanged)event).getMessage(),EventListDrinksChanged.class.toString());
        }
    }

    @Override
    public void onChanged(Change c) {
        this.updateNotification(c.toString(), c.getClass().toString());
    }
    

}
