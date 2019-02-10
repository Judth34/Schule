/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgDATA;

import java.time.LocalDate;
import java.time.LocalTime;

/**
 *
 * @author schueler
 */
public class Journey implements Comparable<Journey>{
    private LocalTime sartTime;
    private LocalTime endTime;
    private String startposition;
    private String endposition;
    private int numberOfPassenger;

    public Journey(String sartTime, String endTime, String startposition, String endposition, int numberOfPassenger) {
        this.sartTime = LocalTime.parse(sartTime);
        this.endTime = LocalTime.parse(endTime);
        this.startposition = startposition;
        this.endposition = endposition;
        this.numberOfPassenger = numberOfPassenger;
    }

    public Journey() {
        this.sartTime = LocalTime.now();
        this.endTime = LocalTime.now();
        this.startposition = "unknown";
        this.endposition = "unknown";
        this.numberOfPassenger = 0;
    }

    public String getSartTime() {
        return sartTime.toString();
    }

    public String getEndTime() {
        return endTime.toString();
    }

    public String getStartposition() {
        return startposition;
    }

    public String getEndposition() {
        return endposition;
    }

    public int getNumberOfPassenger() {
        return numberOfPassenger;
    }

    public void setSartTime(String sartTime) {
        this.sartTime = LocalTime.parse(sartTime);
    }

    public void setEndTime(String endTime) {
        this.endTime = LocalTime.parse(endTime);
    }

    public void setStartposition(String startposition) {
        this.startposition = startposition;
    }

    public void setEndposition(String endposition) {
        this.endposition = endposition;
    }

    public void setNumberOfPassenger(int numberOfPassenger) {
        this.numberOfPassenger = numberOfPassenger;
    }

    @Override
    public int compareTo(Journey o) {
        return this.getSartTime().compareTo(o.getSartTime());
    }
    
    
    
}
