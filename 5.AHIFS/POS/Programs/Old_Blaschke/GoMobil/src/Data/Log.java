/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Data;

import java.io.Serializable;
import java.time.LocalDate;

/**
 *
 * @author schueler
 */

public class Log implements Comparable<Log>,Serializable{
    LocalDate date;
    int NrJourneys;
    Car selectedCar;    
    private int id;
    private static int nextID;

    public Log(LocalDate date, int NrJourneys, Car selectedCar) {
        this.date = date;
        this.NrJourneys = NrJourneys;
        this.selectedCar = selectedCar;
        this.id = nextID++;
    }
    
    public Log(String date, int NrJourneys, Car selectedCar) {
        this.date = LocalDate.parse(date);
        this.NrJourneys = NrJourneys;
        this.selectedCar = selectedCar;
        this.id = nextID++;
    }

    public Log() {
        
    }

    public String getDate() {
        return date.toString();
    }

    public int getNrJourneys() {
        return NrJourneys;
    }

    public Car getSelectedCar() {
        return selectedCar;
    }

    public void setDate(String date) {
        this.date = LocalDate.parse(date);
    }

    public void setNrJourneys(int NrJourneys) {
        this.NrJourneys = NrJourneys;
    }

    public void setSelectedCar(Car selectedCar) {
        this.selectedCar = selectedCar;
    }

    public int getId() {
        return id;
    }

    
    
    @Override
    public int compareTo(Log o) {
        int result = this.getDate().compareTo(o.getDate());
        if(result == 0)
            return this.getSelectedCar().compareTo(o.getSelectedCar());
        return result;
       
    }

    @Override
    public String toString() {
        return "Log{" + "date=" + date + ", NrJourneys=" + NrJourneys + ", selectedCar=" + selectedCar + '}';
    }
    
    
    
    
}
