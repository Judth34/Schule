/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkg_data;

import events.EventChanged;
import java.sql.Connection;
import java.sql.Date;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.EventListener;
import java.util.TreeSet;

/**
 *
 * @author schueler
 */
public class Database {
    private final  String connString; 
    private static String USER  = "d4a03";
    private static String PASSWD = "d4a";
    private Connection conn;
    private ArrayList<Producer> currentProducers;
    private static EventChangedListener listener;
    
    //***** select commands 
    
    private abstract class SQLCommands {

        private final static String select_producers = "select producers.id as id, producers.name as name ,producers.sales as sales, MAX(products.onmarket) as max , MIN(products.onmarket) as min, COUNT(producers.name) as count from producers" +
            " left join products on producers.id = products.id_pc" +
            " Group by producers.id,producers.name,producers.sales";

        private final static String select_products = "select products.id, products.name, products.onStock, products.onMarket, products.price" +
            " from products " + 
            " where id_pc = ?";

        private final static String select_OrderId = "select id " +
            " from dummy";
        
        private final static String select_Orders = "select *  " +
            " from orders inner join products on products.id = id_product ORDER BY orders.id";
        
        private final static String update_product = "UPDATE Products" + 
            " SET name = ?," + 
            " onStock = ?," + 
            " onmarket = ?," +
            " price = ?" +
            " WHERE id = ?";

        private final static String update_OrderId = "update dummy " +
            " set id =  seqOrder.NEXTVAL";
        
        private final static String insert_product = 
            " INSERT INTO Products" + 
            " VALUES ( seqProduct.NEXTVAL, ? , ? , ? , ?)";
        
        private final static String insert_order = 
            " INSERT INTO orders Products" + 
            " VALUES ( ?, ?, ? )";
        
        private final static String update_product_decreaseOnStock = "update products" +
            " set products.onstock = products.onstock- ? " +
            " where products.id = ? ";

    }
        
    
    public Database(String connStringv) throws Exception {
        this.connString = connStringv;
        this.currentProducers = new ArrayList<>();
        this.createConnection(USER,PASSWD);
    }

    public Database(String connString, String USERV, String PASSWORD) throws Exception {
        this.connString = connString;
        this.currentProducers = new ArrayList<>();
        this.createConnection(USERV,PASSWORD);
    }

    public ArrayList<Producer> getCurrentProducers() {
        return currentProducers;
    }
    
    
    //listners
     
    public interface EventChangedListener extends EventListener {
        void handleEvent(EventChanged event);
    }
    
    public void addOnEventChangedListener (EventChangedListener listener){
        Database.listener = listener;
    }
    
    public static void notify(EventChanged event){
        Database.listener.handleEvent(event);
    }
    
    
    //MYFUNCTIONS
    
    private void createConnection(String user,String password) throws Exception{
        if(conn == null){
            DriverManager.registerDriver(new oracle.jdbc.OracleDriver());
            this.conn = DriverManager.getConnection(connString,user,password);
            conn.setAutoCommit(false);
            conn.setTransactionIsolation(Connection.TRANSACTION_READ_COMMITTED);
        }
    }
    
    public void commit() throws Exception{
        this.isConn();
        this.conn.commit();
    }
    
    public void rollback() throws Exception {
        this.isConn();
        this.conn.rollback();
    }
    
    public ArrayList<Producer> selectProducers() throws Exception{
        this.isConn();
        ArrayList<Producer> temp;
        try{
            temp = new ArrayList<>();
            Statement stmnt = conn.createStatement(ResultSet.TYPE_FORWARD_ONLY,ResultSet.CONCUR_READ_ONLY);
            ResultSet rs = stmnt.executeQuery(Database.SQLCommands.select_producers);
            
            while(rs.next()){
                temp.add(new Producer(rs.getInt("id"),rs.getString("name"),rs.getInt("sales"),rs.getInt("count"),rs.getDate("min"),rs.getDate("max")));
            }
        }catch(Exception error){
            throw new Exception ("cant select producers : " + error.toString());
        }
        return this.currentProducers = temp;
    }
    
    public TreeSet<Product> selectProducts(int producerID) throws Exception{
        TreeSet<Product> temp;
        try{
            temp = new TreeSet<>();
                PreparedStatement stmt = conn.prepareStatement(Database.SQLCommands.select_products,
                ResultSet.TYPE_FORWARD_ONLY,ResultSet.CONCUR_READ_ONLY);
                stmt.setInt(1,producerID);
            ResultSet rs = stmt.executeQuery();
            while(rs.next()){
                Product p = new Product(rs.getInt("id"),rs.getString("name"),rs.getInt("onstock"),rs.getDate("onmarket").toLocalDate(),rs.getInt("price"));
                temp.add(p);
            }
        }catch(Exception error){
            throw new Exception ("cant select products ( producer ID : " + producerID + " ) : " + error.toString());
        }
        return temp;
    }
    
    public void updateProducer(Producer producer) throws Exception{
        this.isConn();
        try{
            for(Product product : producer.getProducts()){
                    this.updateProduct(product);
            }
        }catch(Exception error){
            this.rollback();
            throw new Exception(error.toString() + " --> rollback");
        }
    }
    
    public void updateProduct(Product product) throws SQLException, Exception{
        this.isConn();
        PreparedStatement stmt = conn.prepareStatement(Database.SQLCommands.update_product,
                ResultSet.TYPE_FORWARD_ONLY,ResultSet.CONCUR_READ_ONLY);
        stmt.setString(1,product.getName());
        stmt.setFloat(2,product.getOnStock());
        stmt.setDate(3,Date.valueOf(product.getOnMarket()));
        stmt.setInt(4, product.getPrice());
        stmt.setInt(5,product.getId());
        stmt.executeUpdate();
    }
    
    public void updateProductDecreaseOnStock(Product product) throws SQLException, Exception{
        this.isConn();
        PreparedStatement stmt = conn.prepareStatement(Database.SQLCommands.update_product_decreaseOnStock,
                ResultSet.TYPE_FORWARD_ONLY,ResultSet.CONCUR_READ_ONLY);
        stmt.setInt(1,product.getDecOnStock());
        stmt.setInt(2,product.getId());
        stmt.executeUpdate();
    }
    
    public void insertProduct(Product product,int pr_id) throws Exception{
        this.isConn();

        PreparedStatement stmt = conn.prepareStatement(Database.SQLCommands.insert_product,
                ResultSet.TYPE_FORWARD_ONLY,ResultSet.CONCUR_READ_ONLY);
        stmt.setString(1,product.getName());
        stmt.setInt(2,pr_id);
        stmt.setInt(3,product.getOnStock());
        stmt.setDate(4, Date.valueOf(product.getOnMarket()));
        stmt.executeUpdate();
    }
    
    public void decreaseOnStock(Producer producer) throws Exception{
        for(Product product : producer.getProducts()){
            if(product.getState() == Product.State.MODIFIED && product.getDecOnStock() != 0 ){
                this.updateProductDecreaseOnStock(product);
                this.insertOrder(product);
            }
        }
    }
    
    public void insertOrder(Product product) throws Exception{
        this.isConn();

        PreparedStatement stmt = conn.prepareStatement(Database.SQLCommands.insert_order,
                ResultSet.TYPE_FORWARD_ONLY,ResultSet.CONCUR_READ_ONLY);
        stmt.setInt(1,this.selectOrderId());
        stmt.setInt(2,product.getId());
        stmt.setInt(3,product.getDecOnStock());
        stmt.executeUpdate();
    }
    
    public int selectOrderId() throws Exception{
        PreparedStatement stmt = null;
        if(Order.first){
            stmt = conn.prepareStatement(Database.SQLCommands.update_OrderId,
            ResultSet.TYPE_FORWARD_ONLY,ResultSet.CONCUR_READ_ONLY);
            stmt.executeQuery();
            Order.first = false;
        }
        
            stmt = conn.prepareStatement(Database.SQLCommands.select_OrderId,
                ResultSet.TYPE_FORWARD_ONLY,ResultSet.CONCUR_READ_ONLY);
        
        ResultSet rs = stmt.executeQuery();
        if(rs.next())
            return rs.getInt("id");
        return 0;
    }
    
    public TreeSet<Order> selectOrders () throws Exception{
        TreeSet<Order> temp;
        try{
            temp = new TreeSet<>();
                PreparedStatement stmt = conn.prepareStatement(Database.SQLCommands.select_Orders,
                ResultSet.TYPE_FORWARD_ONLY,ResultSet.CONCUR_READ_ONLY);
            ResultSet rs = stmt.executeQuery();
            while(rs.next()){
                Order order = new Order(rs.getInt("id"),rs.getInt("id_product"),rs.getInt("qty"),rs.getString("name"),rs.getInt("onstock"),rs.getDate("onmarket").toLocalDate(),rs.getInt("price"));
                temp.add(order);
            }
        }catch(Exception error){
            throw new Exception ("cant select orders: " + error.toString());
        }
        return temp;
    }
    
    public boolean isConn() throws Exception{
        if(this.conn == null || this.conn.isClosed())
            throw new Exception("not connected");
        return true;
    }

}
