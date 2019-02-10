/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package syppre;

import java.io.IOException;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.stage.Stage;

/**
 *
 * @author schueler
 */
public class SYPPRE extends Application{

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        launch(args);
    }

    @Override
    public void start(Stage stage) throws Exception {
        //this.startMainGUI(stage);
        //this.startBibliothekarGUI(stage);
        this.startLoginGUI(stage);
    }

    private void startMainGUI(Stage stage) throws IOException{
        Parent root = FXMLLoader.load(getClass().getResource("MAINGUI.fxml"));
        Scene scene = new Scene(root);
        
        stage.setScene(scene);
        stage.show();
    }
    
    private void startBibliothekarGUI(Stage stage) throws IOException{
         Parent root = FXMLLoader.load(getClass().getResource("BibliothekarGUI.fxml"));
         Scene scene = new Scene(root);

         stage.setScene(scene);
         stage.show();
     }
 
    private void startLoginGUI(Stage stage) throws IOException{
         Parent root = FXMLLoader.load(getClass().getResource("LoginGUI.fxml"));
         Scene scene = new Scene(root);

         stage.setScene(scene);
         stage.show();
     }
    
}
