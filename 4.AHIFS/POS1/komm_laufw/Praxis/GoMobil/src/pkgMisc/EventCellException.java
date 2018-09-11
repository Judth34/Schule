/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgMisc;

import java.util.EventObject;

/**
 *
 * @author schueler
 */
public class EventCellException extends EventObject{
    private final String message;
    public EventCellException(Object source){
        this(source, "not defined");
    }
    
    public EventCellException(Object source,String message){
        super(source);
        this.message = message;
    }
    
    public String getMessage(){
        return message;
    }
    
}
