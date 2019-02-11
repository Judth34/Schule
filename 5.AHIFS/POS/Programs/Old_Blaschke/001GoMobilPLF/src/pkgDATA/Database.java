/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgDATA;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.Serializable;
import java.util.Observable;
import java.util.TreeSet;
import javax.xml.bind.JAXBContext;
import javax.xml.bind.Marshaller;
import javax.xml.bind.Unmarshaller;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlTransient;

/**
 *
 * @author schueler
 */
@XmlRootElement
public class Database extends Observable implements Driver.OnLogBookChangedListener, Serializable{
    //to do an update an fire table data changed
    @XmlElement(name = "Driver")
    private TreeSet<Driver> collDriver;
    @XmlElement(name = "Cars")
    private TreeSet<Car> collCars;
    private static Database database;
    private FileOutputStream fos;
    @XmlTransient 
    private Driver selectedDriver;
    private Logbook selectedLogbook;
    
    //ToDo: Listener
    
    private Database() {
        collDriver = new TreeSet<>();
        collCars = new TreeSet<>();
    }
    
    public static Database newInstance(){
        if(database == null)
            database = new Database();
        return database;
    }
    
    public Driver getDriverWithRowNumber(int row) throws Exception{
        try{
            return (Driver)this.collDriver.toArray()[row];
        }catch(Exception ex){
            return null;
        }
    }
    
    
    
    protected int getNumberOfDrivers(){
        return collDriver.size();
    }
    
    public void addDriver(Driver driver) throws Exception{
        if(collDriver.contains(driver)){
            throw new Exception("Driver already added!!");
        }
        collDriver.add(driver);
        this.notifyDriverTable();
    }
    
    public void addCar(Car newCar) throws Exception{
        if(collCars.contains(newCar)){
            throw new Exception("Car is already added!!");
        }
        this.collCars.add(newCar);
    }
    
    public void deleteDriver(Driver driver) throws Exception{
        if(!collDriver.contains(driver))
            throw new Exception("Driver is not in TreeSet!!");
        this.collDriver.remove(driver);
        this.notifyDriverTable();
    }
    
    @XmlTransient
    public Driver getSelectedDriver(){
        return this.selectedDriver;
    }
    
    public Logbook getSelectedLogbook(){
        return this.selectedLogbook;
    }
    
    public TreeSet<Car> getCars(){
        return (TreeSet<Car>) collCars.clone();
    }
    
    public void setSelectedDriver(Driver d) throws Exception{
        //notify observer if(current is not the same or current is null)
        if(!this.collDriver.contains(d))
            throw new Exception("This driver is not in List!");
        this.selectedDriver = d;
        this.selectedDriver.addOnLogBookChangedListener(this);
        this.setChanged();
        this.notifyObservers(new EventLogBookChanged("something has changed"));
    }
    
    public void setSelectedLogbook(Logbook l) throws Exception{
        
        this.selectedLogbook = l;
        this.setChanged();
        this.notifyObservers(new EventJourneyChanged("something has changed"));
    }
    
    public void saveDB(String filename) throws Exception{
        fos = new FileOutputStream(filename);
        ObjectOutputStream oos;
        oos = new ObjectOutputStream(fos);
        oos.writeObject(this.collDriver);
        oos.flush();
        oos.close();
        fos.close();
    }
    
    public void loadDB(String filename) throws Exception{
        FileInputStream fis = new FileInputStream(filename);
        ObjectInputStream ois = new ObjectInputStream(fis);
        collDriver = (TreeSet<Driver>) ois.readObject();
        ois.close();
        fis.close();   
        this.notifyDriverTable();
    }
    
    public void saveDBXML(String filename) throws Exception{
        File fileXml = new File(filename);
        JAXBContext jaxbContextVector = JAXBContext.newInstance(Database.class);
        Marshaller jaxbMarshallerVector = jaxbContextVector.createMarshaller();
        jaxbMarshallerVector.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, true);
        jaxbMarshallerVector.marshal(this ,fileXml);
    }
    
    public void loadDBXML(String filename) throws Exception{
        File fileXml = new File(filename);
        JAXBContext jaxbContextVector = JAXBContext.newInstance(Database.class);
        Unmarshaller jaxbUnmarshallerVector = jaxbContextVector.createUnmarshaller();
        Database dbcopy = (Database) jaxbUnmarshallerVector.unmarshal(fileXml);
        collDriver = dbcopy.collDriver;
        this.notifyDriverTable();
    }

    @Override
    public void handlelogBookChanged(EventLogBookChanged event) {
        this.setChanged();
        this.notifyObservers(event);   
    }
    
    private void notifyDriverTable(){
        this.setChanged();
        this.notifyObservers(new EventDriverChanged("Something has changed!"));
    }
}
