/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkg_Data;

import java.io.File;
import java.time.LocalDate;
import java.util.ArrayList;
import javax.xml.bind.JAXBContext;
import javax.xml.bind.Marshaller;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author schueler
 */
@XmlRootElement
public class Calculation {
    @XmlElement
    private Profile profile;
    @XmlElement
    private Drink drink;
    private LocalDate date;
    @XmlElement
    ArrayList<AlcoholReduction> alcReduction;

    public Calculation(Profile profile, Drink drink,LocalDate date, ArrayList<AlcoholReduction> alcReduction) {
        this.profile = profile;
        this.drink = drink;
        this.date = date;
        this.alcReduction = alcReduction;
    }

    public Calculation() {
    }

    public Profile getProfile() {
        return profile;
    }

    public Drink getDrink() {
        return drink;
    }

    public String getDate() {
        return date.toString();
    }

    public void setDate(String date) {
        this.date = LocalDate.parse(date);
    }
    
    

    public ArrayList<AlcoholReduction> getAlcReduction() {
        return alcReduction;
    }

    @Override
    public String toString() {
        return "Calculation{" + "profile=" + profile + ", drink=" + drink + ", alcReduction=" + alcReduction + '}';
    }
    
    
    
    //MYFUNCTIONS
    
    public void save(String filename) throws Exception{
        try{
        File file = new File(filename);
        JAXBContext jaxbContextVector = JAXBContext.newInstance(Calculation.class);
        Marshaller jaxbMarshallerVector;
        jaxbMarshallerVector = jaxbContextVector.createMarshaller();
        jaxbMarshallerVector.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, true);
        jaxbMarshallerVector.marshal(this, file);
        }catch(Exception error){
            System.out.println(error.toString());
            throw new Exception("error at saving : " + error.toString());
        }
    }
    
    public void add(AlcoholReduction ar) throws Exception{
        try{
            this.alcReduction.add(ar);
        }catch(Exception error){
            throw new Exception("error at adding alcohol reduction : " + error.toString());
        }
    }
    
    
}
