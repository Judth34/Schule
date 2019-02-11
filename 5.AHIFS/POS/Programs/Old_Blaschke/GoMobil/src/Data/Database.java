/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package Data;

import Misc.EventDriverChanged;
import Misc.EventLogBookChanged;
import Misc.EventSalaryChanged;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.Serializable;
import java.util.Observable;
import java.util.TreeSet;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.xml.bind.JAXBContext;
import javax.xml.bind.Marshaller;
import javax.xml.bind.Unmarshaller;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlTransient;

/**
 *
 * @author schueler
 */

@XmlRootElement
public class Database extends Observable implements Driver.OnLogBookChangedListener,Driver.OnSalChangedListener,Serializable {
    
    private static Database database;
    private TreeSet<Driver> colDriver;
    private TreeSet<Car> colCars;
    @XmlTransient
    private Driver selectedDriver; 
    @XmlTransient 
    private final Driver placeHolder = new Driver();
    
    @Override
    public void handleLogBookChanged (EventLogBookChanged event){
       this.setChanged();
       this.notifyObservers(event);
    }
    
    public void setColDriver(TreeSet<Driver> colDriver) {
        this.colDriver = colDriver;
    }

    public void setColCars(TreeSet<Car> colCars) {
        this.colCars = colCars;
    }

    public void setSelectedDriver(Driver selectedDriver) {
        this.selectedDriver = selectedDriver;
        this.selectedDriver.addONLogBookChangedListener(this);
        this.selectedDriver.addONSalChangedListener(this);
        this.setChanged();
        this.notifyObservers(new EventLogBookChanged("new driver was selected"));
        this.setChanged();
        this.notifyObservers(new EventSalaryChanged("new driver was selected"));
    }

    public static Database getDatabase() {
        return database;
    }

    public TreeSet<Driver> getColDriver() {
        return colDriver;
    }

    public Driver getSelectedDriver() {
        return selectedDriver;
    }
    
    //CONSTRUCTORS
    private Database() {
        colDriver = new TreeSet<>();
        colCars = new TreeSet<>();
    }
    
    
    //CUSTOM
    
    public static Database getNewInstance(){
        if (database == null)
            database = new Database();
        return database;
    }
    
    public void LoadDB(String filename) throws Exception{
        //Load Binary
        FileInputStream fis = new FileInputStream(filename);
        ObjectInputStream ois = new ObjectInputStream(fis);
        this.colDriver = ((Database)ois.readObject()).colDriver;
        this.setChanged();
        this.notifyObservers(new EventDriverChanged("Binary file loaded"));
        ois.close();
        fis.close();
    }
    
    public Driver getDriverWithRowNumber(int row){
        return (Driver)this.colDriver.toArray()[row];
    }
    
    public int getNumberOfDrivers(){
        return this.colDriver.size();
    }
    
    public void addDriver(Driver driver){
        this.colDriver.add(driver);
        this.setSelectedDriver(this.placeHolder);
        this.setChanged();
        this.notifyObservers(new EventDriverChanged("driver was added"));
    }
    
    public void DeleteDriver(Driver driver) throws Exception{
        try{
            this.colDriver.remove(driver);
            this.setChanged();
            this.notifyObservers(new EventDriverChanged("driver was deleted"));
            if(driver == this.selectedDriver){
                this.setSelectedDriver(this.placeHolder);
                this.notifyObservers(new EventLogBookChanged("selected Driver has been deleted")); 
            }
               
        }catch(Exception Ex){
            throw new Exception("Driver not existing");
        }
        
    }
    
    public void saveDB(String filename){
      
    FileOutputStream fos;
        try {
            fos = new FileOutputStream(filename);
            ObjectOutputStream oos;
        try {
            oos = new ObjectOutputStream(fos);
            oos.writeObject(database);
            oos.flush();
            oos.close();
            fos.close();
        } catch (IOException ex) {
            Logger.getLogger(Database.class.getName()).log(Level.SEVERE, null, ex);
        }
            
        } catch (FileNotFoundException ex) {
            Logger.getLogger(Database.class.getName()).log(Level.SEVERE, null, ex);
        }
    

    }
    
    /**
     *
     * @param filename
     * @throws Exception
     */
    public void saveDBXML(String filename) throws Exception{
        File file = new File(filename);
        JAXBContext jaxbContextVector = JAXBContext.newInstance(Database.class);
        Marshaller jaxbMarshallerVector;
        jaxbMarshallerVector = jaxbContextVector.createMarshaller();
        jaxbMarshallerVector.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, true);
        jaxbMarshallerVector.marshal(this, file);
    }
    
    public void loadDBXML(String filename) throws Exception{
        
        File fileXml = new File(filename);
        JAXBContext jaxbContextVector = JAXBContext.newInstance(Database.class);
        Unmarshaller jaxbUnmarshallerVector = jaxbContextVector.createUnmarshaller();
        Database dbcopy = (Database) jaxbUnmarshallerVector.unmarshal(fileXml);
        this.colDriver = dbcopy.colDriver;
        this.setChanged();
        this.notifyObservers(new EventDriverChanged("Xml file loaded"));
    }
    
    public void addCar(Car car){
        this.colCars.add(car);
    }
    
    public void DeleteCar(Car car) throws Exception{
        try{
            this.colCars.remove(car);
            this.notifyObservers();
        }catch(Exception Ex){
            throw new Exception("Driver not existing");
        }
    }

    public Car getCarAtName(String string) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    public TreeSet<Car> getColCars() {
        return colCars;
    }

    @Override
    public void handleSalChanged(EventSalaryChanged event) {
        this.setChanged();
        this.notifyObservers(event);
    }


    
}
