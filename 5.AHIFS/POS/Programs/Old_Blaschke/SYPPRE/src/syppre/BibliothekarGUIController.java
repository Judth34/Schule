/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package syppre;


import java.net.URL;
import java.util.ResourceBundle;
import java.util.logging.Level;
import java.util.logging.Logger;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Modality;
import javafx.stage.Stage;

/**
 * FXML Controller class
 *
 * @author schueler
 */
public class BibliothekarGUIController implements Initializable {

    /**
     * Initializes the controller class.
     */


    
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // TODO
    }  
    
    
    //action Performed Methods
    
    @FXML
    void btn_actionPerformed(ActionEvent event) {
        try {
            this.showFrame("syppre/Auleihgegenstand_UserGUI.fxml","Ausleihgegenstände");
        } catch (Exception ex) {
           System.out.println(ex.toString());
        }
    }
  
    
    
    //MUFUNCTIONS
    
        private void showFrame(String path,String title) throws Exception{
        Stage stage = new Stage();
        Parent root = FXMLLoader.load(getClass().getClassLoader().getResource(path));
        Scene scene = new Scene(root);
        stage.setScene(scene);
        stage.setTitle(title);
        stage.initModality(Modality.APPLICATION_MODAL);
        stage.showAndWait();
        //this.lbl_message.setText(title + "was sucessfully loaded");
    }
}
