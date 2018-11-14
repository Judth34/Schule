/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgData;

import java.util.concurrent.Semaphore;
import javafx.application.Platform;
import javafx.collections.ObservableList;
import javafx.concurrent.Task;

/**
 *
 * @author Marcel Judth
 */
public class CarGenerator extends Task<String>{
    private static final int DEVIATION = 20;
    private static final int MSEC = 1000;
    private boolean end;
    private final long timeBetweenArrival;
    private final Semaphore semaPertrolPumpFree;
    private final PetrolStation petrolstation;
    private final ObservableList<String> obsList;

    public CarGenerator(long timeBetweenArrival,long servicetime, int numberOfPP, ObservableList<String> obsList) {
        this.timeBetweenArrival = timeBetweenArrival * MSEC;
        this.obsList = obsList;
        this.end = false;
        this.semaPertrolPumpFree = new Semaphore(numberOfPP);
        this.petrolstation = new PetrolStation();
        PetrolPump.setServiceTime(servicetime * MSEC);
        for(int i = 0; i < numberOfPP; i++)
            this.petrolstation.add(new PetrolPump("PP " + i, this.obsList));
    }

    @Override
    protected String call() throws Exception {
        int countDriver = 0;
        System.out.println("*******Starting car generator");
        
        while(!this.end){
            long rndTime = TimeGenerator.getRandomTime(this.timeBetweenArrival, DEVIATION);
            this.informUser("next car is generated in: " + rndTime + "...[" + (double)rndTime/1000 + "min.]");
            Thread.sleep(rndTime);
            new Thread(new CarDriver("driver " + countDriver++, this.petrolstation, this.semaPertrolPumpFree, this.obsList)).start();
            this.informUser("car generated");
        }
        
        double usageRate = this.petrolstation.calculateUsageRate();
        this.informUser("=================== avg usage rate of petrol pumps: " + usageRate + "%");
        return "finished!";
    }

    public void setEnd() {
        this.end = true;
    }
    
    private void informUser(String value){
        System.out.println(value);
        Platform.runLater(new Runnable() {
            public void run() {
                obsList.add(value);
            }
        });
    }
}
