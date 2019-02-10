/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgData;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.Collection;

/**
 *
 * @author Gerald
 */
public class Database {

//    private static final String CONNECTSTRING = "jdbc:oracle:thin:@localhost:1521:orcl";
    private static final String CONNECTSTRING = "jdbc:oracle:thin:@192.168.191.26:1521:ora11g";
    private static final String USER = "mak";
    private static final String PASSWD = "mak";
    private Connection conn = null;

    /**
     * Singleton
     */
    private static Database database = null;

    public static Database newInstance() throws Exception {
        if (database == null) {
            database = new Database();
        }

        return database;
    }

    private Database() throws Exception {
    }

    private Connection createConnection() throws Exception {
        DriverManager.registerDriver(new oracle.jdbc.driver.OracleDriver());
        return DriverManager.getConnection(CONNECTSTRING, USER, PASSWD);
    }

    public Producer getProducer(int id) throws Exception {
        Producer producer = null;
        conn = createConnection();
        String select = "SELECT id, name, sales FROM producers WHERE id = ? ";
        PreparedStatement stmt = conn.prepareStatement(select);
        stmt.setInt(1, id);
        ResultSet rs = stmt.executeQuery();
        if (rs.next()) {
            producer = new Producer(rs.getInt("id"), rs.getString("name"), rs.getBigDecimal("sales"));
        } else {
            throw new Exception("producer with id '" + id + "' not found");
        }
        conn.close();
        return producer;
    }
    public void addProducer(Producer p) throws Exception {
        conn = createConnection();
        String select = "INSERT INTO producers VALUES(seqProducer.NEXTVAL,?,?)";
        PreparedStatement stmt = conn.prepareStatement(select);
        stmt.setString(1, p.getName());
        stmt.setBigDecimal(2, p.getSales());
        stmt.executeUpdate();
        conn.close();
    }
    public void updateProducer(Producer p) throws Exception {
        conn = createConnection();
        String select = "UPDATE producers SET name = ?, sales = ?";
        PreparedStatement stmt = conn.prepareStatement(select);
        stmt.setString(1, p.getName());
        stmt.setBigDecimal(2, p.getSales());
        stmt.executeUpdate();
        conn.close();
    }
    public Product getProduct(int id) throws Exception {
        Product product = null;
        Producer producer ;
        
        conn = createConnection();
        String select = "SELECT products.id, products.name, onStock, TO_CHAR(onMarket,'YYYY-MM-DD'), producers.id, producers.name, sales " + 
                        " FROM products INNER JOIN producers ON products.id_pc = producers.id " + 
                        " WHERE products.id = ? ";
        PreparedStatement stmt = conn.prepareStatement(select);
        stmt.setInt(1, id);
        ResultSet rs = stmt.executeQuery();
        
        if (rs.next()) {
            producer = new Producer(rs.getInt(5), rs.getString(6), rs.getBigDecimal("sales"));
            product = new Product(rs.getInt(1), rs.getString(2), 
                                  rs.getInt(3), LocalDate.parse(rs.getString(4)));
            product.setProducer(producer);
        } else {
            throw new Exception("product with id '" + id + "' not found");
        }
        conn.close();
        return product;
    }
    public void addProduct(Product p) throws Exception {
        if (p.getProducer() == null)
            throw new Exception("error: no producer given");
        conn = createConnection();
        String select = "INSERT INTO products VALUES(seqProduct.NEXTVAL, ?, ?, ?, TO_DATE(?,'YYYY-MM-DD')";
        PreparedStatement stmt = conn.prepareStatement(select);
        stmt.setString(1, p.getName());
        stmt.setInt(2, p.getProducer().getId());
        stmt.setInt(3, p.getOnStock());
        stmt.setString(4, p.getOnMarket().format(DateTimeFormatter.ISO_DATE));
        stmt.executeUpdate();
        conn.close();
    }
    public void updateProduct(Product p) throws Exception {
        conn = createConnection();
        String select = "UPDATE products SET name = ?, "
                + " id_pc = ?, onStock = ? "
                + " WHERE id = ?";
        PreparedStatement stmt = conn.prepareStatement(select);
        stmt.setString(1, p.getName());
        stmt.setInt(2, p.getProducer().getId());
        stmt.setInt(3, p.getOnStock());
        stmt.setInt(4, p.getId());
        System.out.println("***update: " + stmt.executeUpdate());
        conn.commit();
        conn.close();
    }
    public Collection<Producer> getAllProducers() throws Exception {
        ArrayList<Producer> collProducers = new ArrayList<>();
        Producer producer = null;
        
        conn = createConnection();
        String select = "SELECT id, name, sales FROM producers ";
        PreparedStatement stmt = conn.prepareStatement(select);
        ResultSet rs = stmt.executeQuery();
        while (rs.next()) {
            producer = new Producer(rs.getInt("id"), rs.getString("name"), rs.getBigDecimal("sales"));
            collProducers.add(producer);
        } 
        conn.close();
        return collProducers;
    }
    public Collection<Product> getAllProducts() throws Exception {
        ArrayList<Product> collProducts = new ArrayList<>();
        Product product = null;
        
        conn = createConnection();
        String select = "SELECT products.id, products.name, onStock, TO_CHAR(onMarket,'YYYY-MM-DD') FROM products";
        PreparedStatement stmt = conn.prepareStatement(select);
        ResultSet rs = stmt.executeQuery();
        while (rs.next()) {
            product = new Product(rs.getInt(1), rs.getString(2), 
                                  rs.getInt(3), LocalDate.parse(rs.getString(4)));

            collProducts.add(product);
        } 
        conn.close();
        return collProducts;
    }

}
