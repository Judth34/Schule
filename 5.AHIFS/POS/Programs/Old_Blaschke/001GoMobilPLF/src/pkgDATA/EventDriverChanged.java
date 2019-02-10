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
public class EventDriverChanged extends EventObject{
    
    private final String message;
    
    public EventDriverChanged(Object source){
        this(source, "not defined");
    }
    public EventDriverChanged(Object source, String message) {
        super(source);
        this.message = message;
    }
}
