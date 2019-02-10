/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgDATA;

import java.io.Serializable;
import java.time.LocalDate;
import java.util.TreeSet;

/**
 *
 * @author schueler
 */
public class Logbook implements Comparable<Logbook>, Serializable{
    private LocalDate date;
    private int numberOfJourneys;
    private Car selectedCar;
    private TreeSet<Journey> collJourneys;

    public Logbook(String date, int numberOfJourneys, Car selectedCar) {
        this.date = LocalDate.parse(date);
        this.numberOfJourneys = numberOfJourneys;
        this.selectedCar = selectedCar;
        this.collJourneys = new TreeSet<>();
    }

    public Logbook() {
        date = LocalDate.parse("2000-01-01");
        numberOfJourneys = 0;
        this.collJourneys = new TreeSet<>();
    }
    
    public String getDate() {
        return date.toString();
    }

    public int getNumberOfJourneys() {
        return numberOfJourneys;
    }

    public Car getCar() {
        return selectedCar;
    }
    
    public int getSizeOfCollJourneys(){
        return this.collJourneys.size();
    }

    public Journey getJourneyWithRowNumber(int row){
        return (Journey)this.collJourneys.toArray()[row];
    }
    
    public void setCar(Car car) {
        this.selectedCar = car;
    }
    
    public void setDate(String date) {
        this.date = LocalDate.parse(date);
    }

    public void setNumberOfJourneys(int numberOfJourneys) {
        this.numberOfJourneys = numberOfJourneys;
    }
    
    public void addJourney(Journey newJourney) throws Exception{
        if(this.collJourneys.contains(newJourney))
            throw new Exception("Journey already added!");
        this.collJourneys.add(newJourney);
    }
    
    @Override
    public int compareTo(Logbook o) {
        int result = date.compareTo(o.date);
        if(result == 0)
            return this.numberOfJourneys - o.numberOfJourneys;
        return result;
    }

    void deleteJourney(Journey j) throws Exception {
        if(!this.collJourneys.contains(j))
            throw new Exception("This journey is not in List!");
        this.collJourneys.remove(j);
    }
    
}
