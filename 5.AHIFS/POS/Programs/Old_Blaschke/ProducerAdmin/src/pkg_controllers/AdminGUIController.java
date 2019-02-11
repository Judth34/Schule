/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkg_controllers;

import pkg_misc.IntegerConverter;
import events.EventChanged;
import java.net.URL;
import java.time.LocalDate;
import java.util.ArrayList; 
import java.util.ResourceBundle;
import java.util.TreeSet;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.event.ActionEvent;
import javafx.fxml.Initializable;
import javafx.fxml.FXML;
import javafx.scene.control.ComboBox;
import javafx.scene.control.Label;
import javafx.scene.control.ListView;
import javafx.scene.control.MenuItem;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TableColumn;
import javafx.scene.control.TableColumn.CellEditEvent;
import javafx.scene.control.TableView;
import javafx.scene.control.TextField;
import javafx.scene.control.TitledPane;
import javafx.scene.control.cell.PropertyValueFactory;
import javafx.scene.control.cell.TextFieldTableCell;
import pkg_data.Database;
import pkg_data.Order;
import pkg_data.Producer;
import pkg_data.Product;
import pkg_misc.DateConverter;
/**
 * FXML Controller class
 *
 * @author schueler
 */
public class AdminGUIController implements Initializable,Database.EventChangedListener {

    /**
     * Initializes the controller class.
     * @param url
     * @param rb
     */
    @Override
    public void initialize(URL url, ResourceBundle rb) {
        String connString;
        String USER;
        String PASSWORD;
        try {
            connString = this.txt_connString.getText();
            USER = this.txt_user.getText();
            PASSWORD = this.txt_pass.getText();
            db = new Database(connString,USER,PASSWORD);
            this.updateNot(new EventChanged("Connected" ,this,EventChanged.State.SUCCESS));
        } catch (Exception ex) {
            this.updateNot(new EventChanged("could not instance Database : " + ex.toString(),this,EventChanged.State.ERROR));
        }
    }    
    
    @FXML
    private TextField txt_connString;

    @FXML
    private TextField txt_user;

    @FXML
    private PasswordField txt_pass;

    @FXML
    private TableView<Product> table_product;

    @FXML
    private ComboBox<Producer> cb_proc;

    @FXML
    private Label lbl_Message;

    @FXML
    private MenuItem mntm_loadproc;

    @FXML
    private MenuItem mntm_update;

    @FXML
    private MenuItem mntm_addProduct;
    
    @FXML
    private MenuItem mntm_decOnStock;

    @FXML
    private MenuItem mntm_commit;
    
    @FXML
    private TableColumn<Product, Integer> tc_id;

    @FXML
    private TableColumn<Product, String> tc_name;

    @FXML
    private TableColumn<Product, Integer> tc_decOnStock;
        
    @FXML
    private TableColumn<Product, Integer> tc_onStock;

    @FXML
    private TableColumn<Product, Integer> tc_price;
    
    @FXML
    private TableColumn<Product, LocalDate> tc_onmarket;

    @FXML
    private TitledPane tp_not;
    
    private Database db;
    
    @FXML
    private ListView<Order> lv_orders;
    
    
    //actionPerformed Methods

    @FXML
    void mntm_actionPerformed(ActionEvent event) {
        try{
           if(event.getSource() == this.mntm_loadproc){
                //loades procedures from db
                this.loadProcedures();
            }else if(event.getSource() == this.mntm_update){
                // updates and committs changed values to db
                this.updateAndCommit();
            }else if(event.getSource() == this.mntm_addProduct){
                //adds Product 
                this.addProduct();
            }else if(event.getSource() == this.mntm_decOnStock){
                //decreases onStock 
                this.decreaseOnStock();
            }else if(event.getSource() == this.mntm_commit){
                //commits changes to database
                this.commit();
            }
        }catch(Exception error){
            this.updateNot(new EventChanged(error.toString(),this,EventChanged.State.ERROR));
        }
    }
    
    @FXML
    void cbox_actionPerformed(ActionEvent event) {
        try{
            if(event.getSource() == this.cb_proc){
                //updates list and loads products from db
                this.db.updateProducer(this.cb_proc.getSelectionModel().getSelectedItem());
                this.updateProducerList();
            }
        }catch(Exception error){
            this.updateNot(new EventChanged(error.toString(),this,EventChanged.State.ERROR));
        }
    }
    
    @FXML
    void tableColoumn_onEditPerformed(CellEditEvent <Product,?> event) {
        try{
            if (event.getSource() == this.tc_name){
                //updates name of selected product
                this.OnEditName(event);
            }else if (event.getSource() == this.tc_onStock){
                //updates onStock of selected product
                this.OnEditOnStock(event);
            }else if (event.getSource() == this.tc_onmarket){
                //updates onMarket of selected product
                this.onEditOnMarket(event);
            }else if(event.getSource() == this.tc_decOnStock){
                this.OnEditDecOnstock(event);
            }else if(event.getSource() == this.tc_price){
                //updates value of cell price
                this.OnEditPrice(event);
            }
            Product product = this.table_product.getSelectionModel().getSelectedItem();
            product.setState(Product.State.MODIFIED);
      
        }catch(Exception error){
            this.updateNot(new EventChanged(error.toString(), this,EventChanged.State.ERROR));
        }
    }
    
    
    //MYFUNCTIONS
    
    private void loadProcedures() throws Exception{
        this.fillComboxdProducers(this.db.selectProducers());
        this.updateNot(new EventChanged("successfully loaded",this,EventChanged.State.SUCCESS));
    }

    private void updateAndCommit() throws Exception {
        try{
            this.db.updateProducer(this.cb_proc.getSelectionModel().getSelectedItem());
            this.db.commit();
            this.updateNot(new EventChanged("sucessfully updated producers.",this,EventChanged.State.SUCCESS));
        }catch(Exception error){
            this.updateList();
            throw new Exception(error);
        }
    }

    private void addProduct() throws Exception{
        Product temp = new Product(Integer.MAX_VALUE,"---",0,LocalDate.now(),Integer.MAX_VALUE);
        this.cb_proc.getSelectionModel().getSelectedItem().add(temp);
        this.db.insertProduct(temp,this.cb_proc.getSelectionModel().getSelectedItem().getId());
        this.updateTableProduct();
        this.updateNot(new EventChanged("sucessfulyy added Product.",this,EventChanged.State.SUCCESS));
    }

    private void updateNot(EventChanged event) {
        this.lbl_Message.setText(event.getMessage());
        this.tp_not.getStyleClass().remove(1);
        
        if(null != event.getState())switch (event.getState()) {
            case ERROR:
                this.tp_not.getStyleClass().add("danger");
                this.tp_not.setText("error");
                break;
            case SUCCESS:
                this.tp_not.getStyleClass().add("success");
                this.tp_not.setText("success");
                break;
            case WARNING:
                this.tp_not.getStyleClass().add("warning");
                    this.tp_not.setText("warning");
                break;
            default:
                this.tp_not.getStyleClass().add("primary");
                this.tp_not.setText("message");
                break;
        }
            
    }
    
    private void fillComboxdProducers(ArrayList<Producer> temp) throws Exception{
        try {
           ObservableList<Producer> tmplist = FXCollections.observableArrayList(temp);
           this.cb_proc.setItems(tmplist);
           if(tmplist.size() > 0)
            this.cb_proc.setValue(tmplist.get(0));
        }catch(Exception error){
            throw new Exception("Error in fillComboxProducer: " + error.getMessage() );
        }
    }
    
    private void updateTableProduct() throws Exception {
        TreeSet<Product> temp = this.cb_proc.getSelectionModel().getSelectedItem().getProducts();
        this.table_product.getItems().clear();
        this.table_product.getItems().addAll(temp);

        this.tc_id.setCellValueFactory(
            new PropertyValueFactory<>("id"));
        this.tc_name.setCellValueFactory(
            new PropertyValueFactory<>("name"));
        this.tc_decOnStock.setCellValueFactory(
            new PropertyValueFactory<>("decOnStock"));
        this.tc_onStock.setCellValueFactory(
            new PropertyValueFactory<>("onStock"));
        this.tc_price.setCellValueFactory(
            new PropertyValueFactory<>("price"));
        this.tc_onmarket.setCellValueFactory(
            new PropertyValueFactory<>("onMarket"));
        
        this.tc_id.setCellFactory(TextFieldTableCell.forTableColumn(new IntegerConverter()));
        this.tc_name.setCellFactory(TextFieldTableCell.forTableColumn());
        this.tc_decOnStock.setCellFactory(TextFieldTableCell.forTableColumn(new IntegerConverter()));
        this.tc_onStock.setCellFactory(TextFieldTableCell.forTableColumn(new IntegerConverter()));
        this.tc_price.setCellFactory(TextFieldTableCell.forTableColumn(new IntegerConverter()));
        this.tc_onmarket.setCellFactory(TextFieldTableCell.forTableColumn(new DateConverter()));
        
    }
    
    private void updateList() throws Exception{
        this.updateTableProduct();
        this.updateNot(new EventChanged("Products of " + cb_proc.getSelectionModel().getSelectedItem().getName() + " displayed",this,EventChanged.State.DEFAULT));
          
    }
    
    private void updateProducerList() throws Exception{
        Producer producer = this.cb_proc.getSelectionModel().getSelectedItem();
        producer.setProducts(this.db.selectProducts(producer.getId()));
        this.updateList();
    }
    
    private void commit() throws Exception{
        this.db.commit();
        this.setListItems();
        Order.first = true;
        this.updateNot(new EventChanged("sucessfully commited.",this,EventChanged.State.SUCCESS));
    }
    
    private void decreaseOnStock() throws Exception{
        Producer producer = this.cb_proc.getSelectionModel().getSelectedItem();
        this.db.decreaseOnStock(producer);
        this.updateProducerList();
        this.updateNot(new EventChanged("sucessfully decreased on Stock",this,EventChanged.State.SUCCESS));
    }
    
    private void setListItems() throws Exception{
        this.lv_orders.getItems().setAll(this.db.selectOrders());
    }
    
        //ONEDIT 

        private void OnEditName(CellEditEvent<Product, ? > event) throws Exception{
            try {
                CellEditEvent <Product , String > ev = (CellEditEvent <Product , String >) event;
                if(event.getOldValue().equals(ev.getNewValue())){
                    this.updateNot(new EventChanged("value did not change",this,EventChanged.State.WARNING));
                    return;   
                }
                ((Product)event.getTableView().getItems().get(
                ev.getTablePosition().getRow())).setName(event.getNewValue().toString());
                this.updateNot(new EventChanged("sucessfully changed name to '" + event.getNewValue().toString() + "' ." , this, EventChanged.State.SUCCESS ));
            }catch (Exception error){
                throw new Exception("wrong input for name: " + error.toString());
            }
        }

        private void OnEditOnStock(CellEditEvent<Product, ? > event) throws Exception{
            try{
                IntegerConverter intconv = new IntegerConverter();
                
                if(event.getNewValue() == null){
                    event.getTableView().getItems().set(event.getTablePosition().getRow(),event.getTableView().getSelectionModel().getSelectedItem());
                    throw new Exception("cant cast onStock");
                }
                if(event.getOldValue().equals(event.getNewValue())){
                    this.updateNot(new EventChanged("value did not change",this,EventChanged.State.WARNING));
                    return;   
                }
                CellEditEvent <Product , Integer > ev = (CellEditEvent <Product , Integer >) event;
                ((Product)event.getTableView().getItems().get(
                ev.getTablePosition().getRow())).setOnStock(intconv.fromString(event.getNewValue().toString()));            

                this.updateNot(new EventChanged("sucessfully changed onStock to '" + event.getNewValue() + "' . ",this,EventChanged.State.SUCCESS));
        
            }catch(Exception error){
                throw new Exception ("wrong input for OnStock: " + error.toString());
            }
        }
        
        private void onEditOnMarket(CellEditEvent<Product, ? > event) throws Exception {
            
            if(event.getOldValue().equals(event.getNewValue())){
                this.updateNot(new EventChanged("value did not change",this,EventChanged.State.WARNING));
                return;   
            }if(event.getNewValue() == null){
                event.getTableView().getItems().set(event.getTablePosition().getRow(),event.getTableView().getSelectionModel().getSelectedItem());
                throw new Exception("date not valid");
            }
            
            CellEditEvent <Product , LocalDate > ev = (CellEditEvent <Product , LocalDate >) event;
            ((Product)event.getTableView().getItems().get(
            ev.getTablePosition().getRow())).setOnMarket((LocalDate) event.getNewValue());            
            
            this.updateNot(new EventChanged("sucessfully changed onMarket to '" + event.getNewValue() + "' . ",this,EventChanged.State.SUCCESS));
        }
        
        private void OnEditPrice(CellEditEvent<Product, ? > event) throws Exception{
            try{
                IntegerConverter intconv = new IntegerConverter();
                
                if(event.getNewValue() == null){
                    event.getTableView().getItems().set(event.getTablePosition().getRow(),event.getTableView().getSelectionModel().getSelectedItem());
                    throw new Exception("cant cast Price");
                }
                if(event.getNewValue().equals(event.getOldValue())){
                    this.updateNot(new EventChanged("value did not change",this,EventChanged.State.WARNING));
                    return;   
                }
                CellEditEvent <Product , Integer > ev = (CellEditEvent <Product , Integer >) event;
                ((Product)event.getTableView().getItems().get(
                ev.getTablePosition().getRow())).setPrice(intconv.fromString(event.getNewValue().toString()));            

                this.updateNot(new EventChanged("sucessfully changed price to '" + event.getNewValue() + "' . ",this,EventChanged.State.SUCCESS));
        
            }catch(Exception error){
                throw new Exception ("wrong input for price: " + error.toString());
            }
        }
        
        private void OnEditDecOnstock(CellEditEvent<Product, ?> event) throws Exception {
            try{
                IntegerConverter intconv = new IntegerConverter();

                if(event.getNewValue() == null){
                    event.getTableView().getItems().set(event.getTablePosition().getRow(),event.getTableView().getSelectionModel().getSelectedItem());
                    throw new Exception("cant cast dec On Stock");
                }
                if(event.getNewValue().equals(event.getOldValue())){
                    this.updateNot(new EventChanged("value did not change",this,EventChanged.State.WARNING));
                    return;   
                }
                CellEditEvent <Product , Integer > ev = (CellEditEvent <Product , Integer >) event;
                ((Product)event.getTableView().getItems().get(
                ev.getTablePosition().getRow())).setDecOnStock(intconv.fromString(event.getNewValue().toString()));            

                this.updateNot(new EventChanged("update to decrease.",this,EventChanged.State.SUCCESS));

            }catch(Exception error){
                throw new Exception ("wrong input for OnStock: " + error.toString());
            }
        }

        
    @Override
    public void handleEvent(EventChanged event) {
        this.updateNot(event);
    }

  
}
