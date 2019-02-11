/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkg_events;

import java.util.EventObject;

/**
 *
 * @author schueler
 */
public class EventProfileChanged extends EventObject {
    private final String message;
    
    public EventProfileChanged(Object source) {
        this("not defined",source);
    }

    public EventProfileChanged(String message, Object source) {
        super(source);
        this.message = message;
    }
    public String getMessage(){
        return this.message;
    }
}