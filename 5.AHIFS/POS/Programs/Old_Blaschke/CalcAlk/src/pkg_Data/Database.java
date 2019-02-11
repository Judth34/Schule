/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkg_Data;


import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.Serializable;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.EventListener;
import java.util.EventObject;
import java.util.Observable;
import java.util.TreeSet;
import pkg_events.EventCalcAlkChanged;

/**
 *
 * @author schueler
 */
public class Database implements Serializable{
    
    private static final long serialVersionUID = 3L;
    private TreeSet<Profile> profiles = null;
    private TreeSet<Drink> drinks = null;
    private static Database database;
    private static OnExceptionControllerListener listener_err;
    private String connString;
    private static final String USER  = "d4a03";
    private static final String PASSWD = "d4a";
    private Connection conn;
    
    private Database() {
        this.profiles = new TreeSet<>();
        this.drinks = new TreeSet<>();
    }
    
    public static Database getNewInstance(){
        if (database == null)
            database = new Database();
        return database;
    }
    
    
    
    //inner classes
    
    public enum LoadType implements Serializable {
        OVERRIDE,
        CONCAT
    }
   


    //listners
     
    public interface OnExceptionControllerListener extends EventListener {
        void handleEvent(EventObject event);
    }
    
    public void addOnExceptionControllerListener (OnExceptionControllerListener listener){
        Database.listener_err = listener;
    }
    
    public static void notify(EventObject e){
        listener_err.handleEvent(e);
    }
    
    
    
    //Getters //Setters
    
    public TreeSet<Profile> getProfiles() {
        return profiles;
    }

    public TreeSet<Drink> getDrinks() {
        return drinks;
    }
    
    
    
    //MYFUNCTIONS
    
    public void add(Profile profile) throws Exception{
        if(this.profiles.contains(profile))
            throw new Exception("this object already exists!");
        this.profiles.add(profile);
    }
    
    public void add(Drink drink) throws Exception{
        if(this.drinks.contains(drink))
            throw new Exception("this object already exists!");
        this.drinks.add(drink);
    }
    
    public void remove(Drink drink) throws Exception{
        this.drinks.remove(drink);
    }
    
    public void remove(Profile profile) throws Exception{
        this.profiles.remove(profile);
    }
    
    public static ArrayList<AlcoholReduction> calculate(Profile profile, Drink drink, double quantity) throws Exception{
        ArrayList<AlcoholReduction> temp_list = new ArrayList<>();
        double coeffizient = profile.getType().equals(ProfileType.MALE) ? 0.7 : 0.57;
        double gramm = (quantity * 1000) * (drink.getAlcohol() / 100) * 0.8;
        double initial = gramm / (profile.getWeight() * coeffizient) -1;
        int hours = 1;
        while(initial > 0 ){
            if(hours > 2)
                temp_list.add(new AlcoholReduction(hours,initial));
            initial = initial -0.15;
            hours ++;
        }
        return (temp_list);
    }
    
    public void save (String filename){
       try (FileOutputStream fos = new FileOutputStream(filename)) {
            ObjectOutputStream oos;
            oos = new ObjectOutputStream(fos);
            oos.writeObject(database);
            oos.flush();
            oos.close();
            Database.notify(new EventCalcAlkChanged("sucessfully saved to --> " + filename,this));
       } catch(Exception error){
           Database.notify(new EventCalcAlkChanged(error.toString(),this));
       }
    }
    
    public void load (String filename,LoadType type) {
        try(FileInputStream fis = new FileInputStream(filename); ObjectInputStream ois = new ObjectInputStream(fis)) {
            Database temp = ((Database)ois.readObject());
                if(type == LoadType.OVERRIDE){
                    this.drinks = temp.drinks;
                    this.profiles = temp.profiles;
                }else if(type == LoadType.CONCAT){
                    this.drinks.addAll(temp.drinks);
                    this.profiles.addAll(temp.profiles);
                }
            Database.notify(new EventCalcAlkChanged("sucessfully loaded , load type --> " + type.toString(),this));
        }catch(Exception error){
            Database.notify(new EventCalcAlkChanged(error.toString(),this));
        }
    }
    
    public void load (String filename) {
        try(FileInputStream fis = new FileInputStream(filename); ObjectInputStream ois = new ObjectInputStream(fis)) {
            Database temp = ((Database)ois.readObject());
            this.profiles = temp.profiles;
            this.drinks = temp.drinks;
            Database.notify(new EventCalcAlkChanged("sucessfully loaded from --> " + filename,this));
        }catch(Exception error){
            Database.notify(new EventCalcAlkChanged(error.toString(),this));
        }
    }
    
    //SQL
    
    public void connect(String connString){
        try{
            this.connString = connString;
            DriverManager.registerDriver(new oracle.jdbc.OracleDriver());
            this.conn = DriverManager.getConnection(this.connString,USER,PASSWD);
        }catch(Exception error){
            Database.notify(new EventCalcAlkChanged(error.toString(),this));
        }
    }
    
    public void disconnect(){
        try{
            if(this.conn == null)
                throw new Exception("cant disconnect, db is not connected");
            if(this.conn.isClosed())
                throw new Exception("Connection is already disconnected");
            this.conn.close();
        }catch(Exception error){
            Database.notify(new EventCalcAlkChanged(error.toString(),this));
        }
    }
    
    public void loadSql(LoadType type){
        try{
            if(type == LoadType.OVERRIDE){
                this.drinks = this.selectDrinks();
                this.profiles = this.selectProfiles();
            }else if(type == LoadType.CONCAT){
                this.drinks.addAll(this.selectDrinks());
                this.profiles.addAll(this.selectProfiles());
            }
            Database.notify(new EventCalcAlkChanged("--> Successfully loaded from user " + USER + ", load type --> " + type.toString(),this));
        }catch(Exception error){
            Database.notify(new EventCalcAlkChanged(error.toString(),this));
        }
    }
    
    public void saveSql(){
        try{
            this.saveDrinksSql();
            this.saveProfileSql();
        }catch(Exception error){
            Database.notify(new EventCalcAlkChanged("error at saving into sql-db: " + error.toString(),this));
        }
        
    }
    
    private TreeSet<Drink> selectDrinks() throws Exception{
        TreeSet<Drink> tempdrinks =  new TreeSet<>();
        String select;
        try{
            if(this.conn == null || this.conn.isClosed())
                throw new Exception("not Connected to sql Database");
                select = "SELECT name,alcohol FROM drink ORDER BY name";
                Statement stmnt = conn.createStatement(ResultSet.TYPE_FORWARD_ONLY,ResultSet.CONCUR_READ_ONLY);
                ResultSet rs = stmnt.executeQuery(select);
                while(rs.next()){
                    tempdrinks.add(new Drink(rs.getString("name"),Double.parseDouble(rs.getString("alcohol").replace(',','.'))));
                }
        }catch(Exception error){
            throw new Exception("error in Database.selectProfiles:" + error.toString());
        }
        return tempdrinks;
    }
    
    private TreeSet<Profile> selectProfiles() throws Exception{
        TreeSet<Profile> tempprofiles =  new TreeSet<>();
        String select;
        try{
            if(this.conn == null || this.conn.isClosed())
                throw new Exception("not Connected to sql Database");
            select = "SELECT name,weight,type FROM profile ORDER BY name";
            Statement stmnt = conn.createStatement(ResultSet.TYPE_FORWARD_ONLY,ResultSet.CONCUR_READ_ONLY);
            ResultSet rs = stmnt.executeQuery(select);
            while(rs.next()){
                tempprofiles.add(new Profile(rs.getString("name"),ProfileType.valueOf(rs.getString("type").toUpperCase()),rs.getInt("weight")));
            }
        }catch(Exception error){
            throw new Exception("error in Database.selectProfiles:" + error.toString());
        }
        return tempprofiles;
    }
    
    private void saveDrinksSql() throws Exception{
        try{
            
        }catch(Exception error){
            throw new Exception("error at Database.saveDrinksSql " + error.toString());
        }
    }
    
    private void saveProfileSql() throws Exception{
        try{
            
        }catch(Exception error){
            throw new Exception("error at Database.saveProfilesSql " + error.toString());
        }
    }
    
}
