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
public class IntegerConverter extends StringConverter<Integer> {

    public IntegerConverter() {
    }

    @Override
    public String toString(Integer object) {
        try{
            return object.toString();
        }catch(Exception error){
            return null;
        }
    }

    @Override
    public Integer fromString(String string) {
        try{
            return Integer.valueOf(string);   
        }catch(Exception error){
            return null;
        }
    }
    
}
