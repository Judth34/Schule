/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgData;

import javafx.collections.ObservableList;

/**
 *
 * @author Marcel Judth
 */
public class PetrolPump {
    private static long serviceTime;
    private final int DEVIATION = 1;
    private String name;
    private boolean free;
    ObservableList<String> obsList;

    public PetrolPump(String name, ObservableList<String> obsList) {
        this.name = name;
        this.obsList = obsList;
    }
    
    private void doFuelUp(){
        
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public boolean isFree() {
        return free;
    }

    public void setFree(boolean free) {
        this.free = free;
    }

    public static long getServiceTime() {
        return serviceTime;
    }

    public static void setServiceTime(long serviceTime) {
        PetrolPump.serviceTime = serviceTime;
    }
    
    
}