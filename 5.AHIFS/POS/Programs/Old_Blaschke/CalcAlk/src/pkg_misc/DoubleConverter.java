/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkg_misc;

import javafx.util.StringConverter;

/**
 *
 * @author schueler
 */
public class DoubleConverter extends StringConverter<Double>{

    @Override
    public String toString(Double object) {
        return object.toString();
    }

    @Override
    public Double fromString(String string) {
        return Double.valueOf(string);
    }
    
        
}
