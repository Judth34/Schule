/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package basti;

/**
 *
 * @author schueler
 */
public class Person {
    String name;
    int id;
    
    static int  nextid = 0;
    
    public Person (){
        id = nextid ++;
    }
    
    public void setName (String nameübergeben){
        name = nameübergeben;
    }
    public String getName(){
        return name;
    }
    
}
