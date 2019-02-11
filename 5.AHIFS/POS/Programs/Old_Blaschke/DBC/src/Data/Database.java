/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Data;


import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;

/**
 *
 * @author schueler
 */
public class Database {
    private final  String connString; 
    private static final String USER  = "d4a03";
    private static final String PASSWD = "d4a";
    Connection conn;
    
    public Database(String connStringv) throws Exception {
        this.connString = connStringv;
        this.createConnection();
    }
    
    private void createConnection() throws Exception{
        if(conn == null){
            DriverManager.registerDriver(new oracle.jdbc.OracleDriver());
            this.conn = DriverManager.getConnection(connString,USER,PASSWD);
            conn.setAutoCommit(false);
            conn.setTransactionIsolation(Connection.TRANSACTION_READ_COMMITTED);
        }
    }

    public ArrayList<Employee> selectEmps() throws SQLException, Exception {
        if(this.conn == null || conn.isClosed())
            throw new Exception("not connected !");
        ArrayList<Employee> collEmps = new ArrayList<>();
        String select = "SELECT empno, ename, sal FROM empV2 ORDER BY ename";
        Statement stmnt = conn.createStatement(ResultSet.TYPE_FORWARD_ONLY,ResultSet.CONCUR_READ_ONLY);
        ResultSet rs = stmnt.executeQuery(select);
        while(rs.next()){
            collEmps.add(new Employee(rs.getInt("empno"),rs.getString("ename"),rs.getFloat("sal")));
        }
        return collEmps;
    }
    
    public void commit() throws Exception{
        this.conn.commit();
    }
    
    public void rollback() throws Exception {
        this.conn.rollback();
    }
    
    public void updateEmps(Employee emp) throws Exception{
        String update = 
                "UPDATE empV2 " 
                + " SET ename = ?,"
                + "       sal = ? "
                + "WHERE empno = ?";
        PreparedStatement stmt = conn.prepareStatement(update,
                ResultSet.TYPE_FORWARD_ONLY,ResultSet.CONCUR_READ_ONLY);
        stmt.setString(1,emp.getName());
        stmt.setFloat(2,emp.getSal());
        stmt.setInt(3,emp.getId());
        stmt.executeUpdate();
    }
    
}
