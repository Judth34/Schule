/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package events;

import java.util.EventObject;

/**
 *
 * @author schueler
 */
public class EventChanged extends EventObject {
    private final String message;
    private final State state;
    
    public EventChanged(Object source) {
        this("not defined",source,State.DEFAULT);
    }

    public EventChanged(String message, Object source,State state) {
        super(source);
        this.message = message;
        this.state = state;
    }
    
    public EventChanged(String message, Object source) {
        super(source);
        this.message = message;
        this.state = State.DEFAULT;
    }
    
    public String getMessage(){
        return this.message;
    }
    
    public enum State {
        ERROR,
        SUCCESS,
        WARNING,
        DEFAULT
    }

    public State getState() {
        return state;
    }
    
}