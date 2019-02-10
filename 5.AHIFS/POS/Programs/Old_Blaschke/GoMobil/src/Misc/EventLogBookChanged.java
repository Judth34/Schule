/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Misc;

import java.util.EventObject;

/**
 *
 * @author schueler
 */
public class EventLogBookChanged extends EventObject {
    private final String message;
    
    public EventLogBookChanged(Object source) {
        this("not defined",source);
    }

    public EventLogBookChanged(String message, Object source) {
        super(source);
        this.message = message;
    }
    public String getMessage(){
        return this.message;
    }
}
