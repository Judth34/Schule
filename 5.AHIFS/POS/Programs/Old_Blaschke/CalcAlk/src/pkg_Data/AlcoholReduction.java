/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkg_Data;

import javax.xml.bind.annotation.XmlElement;

/**
 *
 * @author schueler
 */
public class AlcoholReduction {
    @XmlElement
    private int hour;
    @XmlElement
    private double alcohol;

    public AlcoholReduction(int hour, double alcohol) {
        this.hour = hour;
        this.alcohol = alcohol;
    }

    public AlcoholReduction() {
    }

    public int getHour() {
        return hour;
    }

    public double getAlcohol() {
        return alcohol;
    }
    
    @Override
    public String toString() {
        return this.hour + ".hour ... " + alcohol;
    }
    
    
}
