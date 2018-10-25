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
public class CarDriver extends Task<String>{
    private String name;
    PetrolStation petrolStation;
    private Semaphore semaPetrolPumpFree;
    private long timeStart;
    private long timeEnd;
    private ObservableList<String> obsList;

    public CarDriver(String name, PetrolStation petrolStation, Semaphore semaPetrolPumpFree, ObservableList<String> obsList) {
        this.name = name;
        this.petrolStation = petrolStation;
        this.semaPetrolPumpFree = semaPetrolPumpFree;
        this.obsList = obsList;
    }

    public String getName() {
        return name;
    }
    
    @Override
    protected String call() throws Exception {
        return "";
    }
    
    public long getRespondTime(){
        return this.timeEnd - this.timeStart;
    }
}
