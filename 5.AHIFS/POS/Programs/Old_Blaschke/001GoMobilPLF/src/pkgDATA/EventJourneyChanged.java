/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgDATA;

import java.util.EventObject;

/**
 *
 * @author schueler
 */
public class EventJourneyChanged extends EventObject{
    private String message;
    
    public EventJourneyChanged(Object source) {
        this(source, "not defined");
    }
    
    public EventJourneyChanged(Object source, String message){
        super(source);
        this.message = message;
    }
    
    public String getMessage(){
        return this.message;
    }
}
