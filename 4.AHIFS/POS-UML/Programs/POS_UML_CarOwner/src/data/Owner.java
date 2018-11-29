/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package data;

import java.util.HashSet;
import java.util.Objects;

/**
 *
 * @author samuel
 */
public class Owner {
    private String svNr;
    private String name;
    private HashSet<Car> cars;

    public Owner(String svNr, String name) {
        this.svNr = svNr;
        this.name = name;
        this.cars = new HashSet<Car>();
    }

    public String getSvNr() {
        return svNr;
    }

    public void setSvNr(String svNr) {
        this.svNr = svNr;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public HashSet<Car> getCars() {
        return cars;
    }
    
    public boolean addCar(Car c){
        return cars.add(c);
    }
    
    public boolean removeCar(Car c){
        return cars.remove(c);
    }   
    
    @Override
    public String toString() {
        return "Owner{" + "svNr=" + svNr + ", name=" + name + '}';
    }

    @Override
    public int hashCode() {
        int hash = 7;
        hash = 43 * hash + Objects.hashCode(this.svNr);
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
        final Owner other = (Owner) obj;
        if (!Objects.equals(this.svNr, other.svNr)) {
            return false;
        }
        return true;
    }

}
