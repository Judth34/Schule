/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package data;

import controller.CarOwnerController;
import java.time.LocalDate;
import java.util.Objects;

/**
 *
 * @author schueler
 */
public class Car {
    private String fgNr;
    private LocalDate date;
    private String type;
    private String ownerSvNr;

    public Car(String fgnr, LocalDate date, String type, String ownerSvNr) {
        this.fgNr = fgnr;
        this.date = date;
        this.type = type;
        this.ownerSvNr = ownerSvNr;
    }

    public String getFgNr() {
        return fgNr;
    }

    public void setFgNr(String fgnr) {
        this.fgNr = fgnr;
    }

    public LocalDate getDate() {
        return date;
    }

    public void setDate(LocalDate date) {
        this.date = date;
    }

    public String getType() {
        return type;
    }

    public void setType(String type) {
        this.type = type;
    }
    
    public Owner getOwner(){
        return CarOwnerController.getOwner(this.ownerSvNr);
    }
    

    @Override
    public String toString() {
        return "Car{" + "fgNr=" + fgNr + ", date=" + date + ", type=" + type + '}';
    }

    @Override
    public int hashCode() {
        int hash = 5;
        hash = 71 * hash + Objects.hashCode(this.fgNr);
        return hash;
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (obj == null) {
            return false;
        }
        if (getClass() != obj.getClass()) {
            return false;
        }
        final Car other = (Car) obj;
        if (!Objects.equals(this.fgNr, other.fgNr)) {
            return false;
        }
        return true;
    }
}
