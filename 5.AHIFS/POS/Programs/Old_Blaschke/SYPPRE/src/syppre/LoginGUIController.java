/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package syppre;

import java.net.URL;
import java.util.ResourceBundle;
import javafx.event.ActionEvent;
import javafx.fxml.FXML;
import javafx.fxml.FXMLLoader;
import javafx.fxml.Initializable;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;
import javafx.stage.Modality;
import javafx.stage.Stage;

/**
 * FXML Controller class
 *
 * @author schueler
 */
public class LoginGUIController implements Initializable {

    
    @FXML
    private Button btn_submit;
    
    @FXML
    private TextField txt_username;

    @FXML
    void btn_ActionPerformed(ActionEvent event) {
        try{System.out.println(this.txt_username.getText());
            if(event.getSource() == this.btn_submit){
                if(this.txt_username.getText().equals("u")){
                    this.showFrame("syppre/MAINGUI.fxml","userview");
                }else if (this.txt_username.getText().equals("b")){
                    this.showFrame("syppre/BibliothekarGUI.fxml","biblarianview");
                }
            }
        }catch(Exception error){
            
        }
    }
    
    /**
     * Initializes the controller class.
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        // TODO
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
