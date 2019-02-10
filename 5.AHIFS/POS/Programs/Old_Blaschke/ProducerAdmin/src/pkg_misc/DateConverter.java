/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkg_misc;

import java.text.DateFormat;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.Locale;
import javafx.util.StringConverter;

/**
 *
 * @author schueler
 */
public class DateConverter extends StringConverter<LocalDate> {

    private final String pattern = "EEE, dd. MM. uuuu";
    private final DateTimeFormatter formatter = DateTimeFormatter.ofPattern(pattern,Locale.US);
    
    public DateConverter() {
    }

    @Override
    public String toString(LocalDate object) {
        try{        
            return formatter.format(object);
        }catch(Exception e){
            return null;
        }
    }

    @Override
    public LocalDate fromString(String string) {
        try{
            return LocalDate.parse(string,formatter);            
        }catch(Exception e){ 
            return null;
        }
    }
    
}
