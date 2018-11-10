/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkg004_petrolstation;

import java.net.URL;
import java.util.ArrayList;
import java.util.ResourceBundle;
import javafx.animation.PathTransition;
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
import javafx.scene.image.Image;
import javafx.scene.image.ImageView;
import javafx.scene.layout.AnchorPane;
import javafx.scene.shape.HLineTo;
import javafx.scene.shape.MoveTo;
import javafx.scene.shape.Path;
import javafx.util.Duration;
import pkgData.AnimCoordinates;
import pkgData.CarDriver;
import pkgData.CarGenerator;

/**
 *
 * @author Marcel Judth
 */
public class FXMLMainController implements Initializable, AnimCoordinates {
    
    @FXML
    private AnchorPane anchorPane;
    
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
    
    private final static int ANIMATION_DURATION = 1000;
    private final static int MAX_CARS = 20;
    private final static String IMAGE_CAR_PATH = "..\\res\\car.png";
    
    private CarGenerator carGenerator;
    private ArrayList<ImageView> collImages;
    
    
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
        }
    }
    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // TODO
        this.addListener();
        CarDriver.setController(this);
    }    

    private void addListener() {
        this.txtTimeCarArr.lengthProperty().addListener(new ChangeListener<Number> (){
            @Override
            public void changed(ObservableValue<? extends Number> observable, Number oldValue, Number newValue) {
                if(newValue.intValue() > oldValue.intValue()){
                    char ch = txtTimeCarArr.getText().charAt(oldValue.intValue());

                    //Check if the new character is the number or other's
                    if(!(ch >= '0' && ch <= '9' )){       
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

    private void startSimulation() throws Exception {
        if(this.txtNumberOfPumps.getText().equals("") || this.txtPumpServiceTime.getText().equals("") || this.txtTimeCarArr.getText().equals(""))
            throw new Exception("Please enter all textfields!!");
        this.initOtherStuff();
        int timeBetweenArrival = Integer.parseInt(this.txtTimeCarArr.getText()) * 1000;
        int servicetime = Integer.parseInt(this.txtPumpServiceTime.getText()) * 1000;
        int numberOfPP = Integer.parseInt(this.txtNumberOfPumps.getText());
        ObservableList<String> obs = FXCollections.synchronizedObservableList(FXCollections.observableArrayList());
        this.listLog.setItems(obs);
        this.carGenerator = new CarGenerator(timeBetweenArrival, servicetime, numberOfPP, obs);
        new Thread(this.carGenerator).start();
    }

    private void endSimulation() {
        this.carGenerator.setEnd();
    }
    
    public void doAnimationMoving(CarDriver cd){
        ImageView iv = this.collImages.get(cd.getId());
        Path path = new Path();
        
        path.getElements().add(new MoveTo(cd.getCurrentCooX(), START_Y + cd.getId() * LANE_WIDTH));
        path.getElements().add(new HLineTo(cd.getCurrentCooX()));
        PathTransition pathTransition = new PathTransition();
        pathTransition.setDuration(Duration.millis(ANIMATION_DURATION));
        pathTransition.setPath(path);
        pathTransition.setNode(this.anchorPane);
        pathTransition.setAutoReverse(false);
        pathTransition.play();
    }

    private void initOtherStuff() {
        this.collImages = new ArrayList<>();
        for(int i = 0; i < MAX_CARS; i++){
            ImageView imageView = new ImageView();
            imageView.setFitWidth(1000);
            imageView.setFitHeight(1000);
            imageView.setImage(new Image("file:/car.png"));
            this.collImages.add(imageView);
            imageView.setX(100);
            imageView.setY(100);
            imageView.setVisible(true);
            this.anchorPane.getChildren().add(imageView);
        }
    }
    
}
