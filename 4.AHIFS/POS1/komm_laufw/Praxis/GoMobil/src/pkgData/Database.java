/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgData;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.util.ArrayList;
import java.util.Observable;
import java.util.TreeSet;
import javax.xml.bind.JAXBContext;
import javax.xml.bind.Marshaller;
import javax.xml.bind.Unmarshaller;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author schueler
 */
@XmlRootElement (name = "gomovile")
public class Database extends Observable
{
    @XmlElement(name = "driver")
    private TreeSet<Driver> collDriver;
    
    private static Database database;

    private Database() {
       super();
       collDriver= new TreeSet<>();
    }
	
    public static Database newInstance() {
		
	if(database ==null){
            database = new Database();
	}
            return database;
    }
        
    public void addDriver(Driver d) throws Exception{
        //exc unnötig weil wegn id. für remove gleich
        collDriver.add(d);
        this.setChanged();
        this.notifyObservers("add happened");//buugggg          
    }
    
    public void deleteDriver(Driver d) throws Exception{
        collDriver.remove(d);       
        this.setChanged();
        this.notifyObservers("remove happened");
    }
    
    public int getNumberOfDrivers(){
        return collDriver.size();
    }
    
    public Driver getDriverWithRowNumber(int row){
	Driver d = new ArrayList<>(collDriver).get(row);
        return d;
    }
    
    public void loadDB(String filename) throws Exception{
        FileInputStream fis = new FileInputStream(filename);
	ObjectInputStream ois = new ObjectInputStream(fis);
	collDriver = (TreeSet<Driver>) ois.readObject();		
	ois.close();
	fis.close();
		
	this.setChanged(); 
	this.notifyObservers("bin driver data loaded."); //cal update() of observers
    }
    
    public void saveDB(String filename) throws Exception{
        FileOutputStream fos = new FileOutputStream(filename);
	ObjectOutputStream oos = new ObjectOutputStream(fos);
	oos.writeObject(collDriver);
	oos.flush();
	oos.close();
	fos.close();
    }
    
    public void saveXML(String filename) throws Exception{
	File fileXML = new File(filename);
	JAXBContext jaxbContextVector = JAXBContext.newInstance(Database.class);
	Marshaller jaxbMarshallerVector = jaxbContextVector.createMarshaller();
	jaxbMarshallerVector.
		setProperty(Marshaller.JAXB_FORMATTED_OUTPUT,true);
	jaxbMarshallerVector.marshal(this, fileXML);
    }
    
    public void loadXML(String filename) throws Exception{
	File fileXML = new File(filename);
	JAXBContext jaxbContextVector = JAXBContext.newInstance(Database.class);
	Unmarshaller jaxbUnmarshallerVector = jaxbContextVector
			.createUnmarshaller();
	Database dbcopy = (Database) jaxbUnmarshallerVector.unmarshal(fileXML);
	collDriver = dbcopy.collDriver;
        
        this.setChanged(); 
	this.notifyObservers("xml driver data loaded."); //cal update() of observers
    
    }
    
    
    @Override
    public void notifyObservers(Object msg){
	setChanged();
	super.notifyObservers(msg.toString());
        System.out.println(collDriver);
    }
}
