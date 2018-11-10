/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgData;

import java.util.concurrent.Semaphore;
import javafx.collections.ObservableList;
import javafx.concurrent.Task;

/**
 *
 * @author Marcel Judth
 */
public class CarGenerator extends Task<String>{
    private static final int DEVIATION = 100;
    private static final int MSEC = 1000;
    private boolean end;
    private long timeBetweenArrival;
    private Semaphore semaPertrolPumpFree;
    private PetrolStation petrolstation;
    private ObservableList<String> obsList;
    private long servicetime;

    public CarGenerator(long timeBetweenArrival,long servicetime, int numberOfPP, ObservableList<String> obsList) {
        this.timeBetweenArrival = timeBetweenArrival;
        this.obsList = obsList;
        this.end = false;
        this.semaPertrolPumpFree = new Semaphore(numberOfPP);
        this.petrolstation = new PetrolStation();
        PetrolPump.setServiceTime(servicetime);
        for(int i = 0; i < numberOfPP; i++)
            this.petrolstation.add(new PetrolPump("PP " + i, this.obsList));
    }

    @Override
    protected String call() throws Exception {
        int countDriver = 0;
        System.out.println("*******Starting car generator");
        while(!this.end){
            Thread.sleep(this.timeBetweenArrival);
            System.out.println("next cardirver is generated");
            new Thread(new CarDriver("driver " + countDriver++, this.petrolstation, this.semaPertrolPumpFree, this.obsList)).start();
        }
        return "finished!";
    }

    public void setEnd() {
        this.end = true;
    }
}
