/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgDATA;

import java.io.Serializable;

/**
 *
 * @author schueler
 */
public class Car implements Comparable<Car>, Serializable{
    private String model;

    public Car(String model) {
        this.model = model;
    }

    public Car() {
    }
    
    public String getModel() {
        return model;
    }

    public void setModel(String model) {
        this.model = model;
    }

    @Override
    public int compareTo(Car o) {
        return model.compareTo(o.model);
    }

    @Override
    public String toString() {
        return model;
    }
    
    
}
