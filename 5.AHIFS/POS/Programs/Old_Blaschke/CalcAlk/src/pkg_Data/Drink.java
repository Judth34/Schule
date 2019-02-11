/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkg_Data;

import java.io.Serializable;

/**
 *
 * @author schueler
 */
public class Drink implements Comparable<Drink>,Serializable{
    
    private static final long serialVersionUID = 1L;
    String name;
    double alcohol;

    public Drink(String name, double alcohol) {
        this.name = name;
        this.alcohol = alcohol;
    }

    public Drink() {
    }
    

    public String getName() {
        return name;
    }

    public double getAlcohol() {
        return alcohol;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setAlcohol(double alcohol) {
        this.alcohol = alcohol;
    }

    @Override
    public int compareTo(Drink drink) {
        if(this.name.compareToIgnoreCase(drink.getName()) == 0)
            return (int)(this.alcohol - drink.getAlcohol());
        return this.name.compareToIgnoreCase(drink.getName());
    }

    @Override
    public String toString() {
        return this.name + ", " + this.alcohol + "%";
    }

    

    
    
    
    
    
}
