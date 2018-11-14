/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkg004_petrolstation;

import java.net.URL;
import java.util.ArrayList;
import java.util.ResourceBundle;
import java.util.logging.Level;
import javafx.animation.PathTransition;
import javafx.application.Platform;
import javafx.beans.value.ChangeListener;
import javafx.beans.value.ObservableValue;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Parent;
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
import pkgData.TimeGenerator;

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
    private final static String IMAGE_CAR_PATH = "/res/car.png";



    private CarGenerator carGenerator;
    private ArrayList<ImageView> collImages;

    @FXML
    void actionPerform(ActionEvent event) {
        try {
            if (event.getSource() == this.btnStart) {
                this.startSimulation();
            } else if (event.getSource() == this.btnEnd) {
                this.endSimulation();
            }
        } catch (Exception ex) {
            this.lblMessage.setText(ex.toString());
            java.util.logging.Logger.getLogger(this.getClass().getName()).log(Level.SEVERE, null, ex);
        }
    }

    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // TODO
        this.addListener();
        CarDriver.setController(this);
    }

    private void addListener() {
        this.txtTimeCarArr.lengthProperty().addListener(new ChangeListener<Number>() {
            @Override
            public void changed(ObservableValue<? extends Number> observable, Number oldValue, Number newValue) {
                if (newValue.intValue() > oldValue.intValue()) {
                    char ch = txtTimeCarArr.getText().charAt(oldValue.intValue());

                    //Check if the new character is the number or other's
                    if (!(ch >= '0' && ch <= '9')) {
                        txtTimeCarArr.setText(txtTimeCarArr.getText().substring(0, txtTimeCarArr.getText().length() - 1));
                    }
                }
            }

        });

        this.txtPumpServiceTime.lengthProperty().addListener(new ChangeListener<Number>() {
            @Override
            public void changed(ObservableValue<? extends Number> observable, Number oldValue, Number newValue) {
                if (newValue.intValue() > oldValue.intValue()) {
                    char ch = txtPumpServiceTime.getText().charAt(oldValue.intValue());

                    //Check if the new character is the number or other's
                    if (!(ch >= '0' && ch <= '9')) {

                        //if it's not number then just setText to previous one
                        txtPumpServiceTime.setText(txtPumpServiceTime.getText().substring(0, txtPumpServiceTime.getText().length() - 1));
                    }
                }
            }

        });

        this.txtNumberOfPumps.lengthProperty().addListener(new ChangeListener<Number>() {
            @Override
            public void changed(ObservableValue<? extends Number> observable, Number oldValue, Number newValue) {
                if (newValue.intValue() > oldValue.intValue()) {
                    char ch = txtNumberOfPumps.getText().charAt(oldValue.intValue());

                    //Check if the new character is the number or other's
                    if (!(ch >= '0' && ch <= '9')) {
                        //if it's not number then just setText to previous one
                        txtNumberOfPumps.setText(txtNumberOfPumps.getText().substring(0, txtNumberOfPumps.getText().length() - 1));
                    }
                }
            }

        });
    }

    private void startSimulation() throws Exception {
        if (this.txtNumberOfPumps.getText().equals("") || this.txtPumpServiceTime.getText().equals("") || this.txtTimeCarArr.getText().equals("")) {
            throw new Exception("Please enter all textfields!!");
        }
        this.collImages = new ArrayList<>();
        int timeBetweenArrival = Integer.parseInt(this.txtTimeCarArr.getText());
        int servicetime = Integer.parseInt(this.txtPumpServiceTime.getText());
        int numberOfPP = Integer.parseInt(this.txtNumberOfPumps.getText());
        ObservableList<String> obs = FXCollections.synchronizedObservableList(FXCollections.observableArrayList());
        this.listLog.setItems(obs);
        this.carGenerator = new CarGenerator(timeBetweenArrival, servicetime, numberOfPP, obs);
        new Thread(this.carGenerator).start();
    }

    private void endSimulation() {
        this.carGenerator.setEnd();
    }

    public void doAnimationMoving(CarDriver cd) {
        ImageView iv = this.collImages.get(cd.getId());
        Path path = new Path();
        path.getElements().add(new MoveTo(cd.getOldCooX(), START_Y + LANE_WIDTH * cd.getId()));
        path.getElements().add(new HLineTo(cd.getCurrentCooX()));
        PathTransition pathTransition = new PathTransition();
        pathTransition.setDuration(Duration.millis(ANIMATION_DURATION));
        pathTransition.setPath(path);
        pathTransition.setNode(iv);
        pathTransition.setAutoReverse(false);
        pathTransition.play();
    }

    public void addNewCarImage(int id) {
        try{
            ImageView imageView = new ImageView();
            imageView.setImage(new Image(getClass().getResource(IMAGE_CAR_PATH).toExternalForm()));
            imageView.setFitWidth(40);
            imageView.setFitHeight(20);
            imageView.setX(AnimCoordinates.XCOO_START);
            imageView.setY(AnimCoordinates.START_Y + AnimCoordinates.LANE_WIDTH * id);
            this.collImages.add(imageView);
            Platform.runLater(()->{anchorPane.getChildren().add(imageView);});
        }catch(Exception ex){
                java.util.logging.Logger.getLogger(FXMLMainController.class.getName()).log(Level.SEVERE, null, ex);
        } 
    }

}
