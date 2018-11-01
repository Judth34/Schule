/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgData;

import java.util.Random;
import javafx.collections.ObservableList;

/**
 *
 * @author Marcel Judth
 */
public class PetrolPump {
    private static long serviceTime;
    private final int DEVIATION = 20;
    private String name;
    private boolean free;
    ObservableList<String> obsList;

    public PetrolPump(String name, ObservableList<String> obsList) {
        this.name = name;
        this.obsList = obsList;
        this.free = true;
    }
    
    public void doFuelUp() throws Exception{
        this.setFree(false);
        Random rand = new Random();
        double percentage = rand.nextInt(DEVIATION) / 100;
        System.out.println(serviceTime * percentage);
        long fuelUpTime = serviceTime + serviceTime * (rand.nextInt(DEVIATION) / 100);
        System.out.println(this.getClass().getName() + " " + this.getName() + ": starts filling: " + fuelUpTime);
        this.obsList.add(this.getClass().getName() + " " + this.getName() + ": starts filling: " + fuelUpTime);
        Thread.sleep(fuelUpTime);
        System.out.println(this.getClass().getName() + " " + this.getName() + ": ends filling");
        this.obsList.add(this.getClass().getName() + " " + this.getName() + ": ends filling");
        this.setFree(true);
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
