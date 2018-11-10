/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgData;

import java.util.concurrent.Semaphore;
import java.util.logging.Level;
import javafx.application.Platform;
import javafx.collections.ObservableList;
import javafx.concurrent.Task;
import pkg004_petrolstation.FXMLMainController;

/**
 *
 * @author Marcel Judth
 */
public class CarDriver extends Task<String> implements AnimCoordinates{
    private static FXMLMainController controller;
    private static int nextID = 0;
    private int id;
    private String name;
    PetrolStation petrolStation;
    private Semaphore semaPetrolPumpFree;
    private long timeStart;
    private long timeEnd;
    private ObservableList<String> obsList;
    private int currentCooX = XCOO_START;
    private int olfCooX = XCOO_START;

    public CarDriver(String name, PetrolStation petrolStation, Semaphore semaPetrolPumpFree, ObservableList<String> obsList) throws Exception {
        if(controller == null)
            throw new Exception("cardriver has no controller defined!");
        this.name = name;
        this.petrolStation = petrolStation;
        this.semaPetrolPumpFree = semaPetrolPumpFree;
        this.obsList = obsList;
        this.id = nextID++;
    }

    public static void setController(FXMLMainController controller) {
        CarDriver.controller = controller;
    }

    public String getName() {
        return name;
    }   
    
    @Override
    protected String call() throws Exception {
        long startTime = System.currentTimeMillis();
        this.moveCar();
        this.fillObsList("driver " + name + ": driving in petrol station");
        System.out.println("driver " + name + ": driving in petrol station");
        this.fillObsList("driver " + name + ": waiting for free pump");
        System.out.println("driver " + name + ": waiting for free pump");
        this.semaPetrolPumpFree.acquire();
        PetrolPump pump = this.petrolStation.getFreePump();
        this.fillObsList("driver " + name + ": got free pump with name: " + pump.getName());
        System.out.println("driver " + name + ": got free pump with name: " + pump.getName());
        this.fillObsList("driver " + name + ": starts pumping");
        System.out.println("driver " + name + ": starts pumping");
        pump.doFuelUp();
        this.fillObsList("driver " + name + ": ends pumping");
        System.out.println("driver " + name + ": ends pumping");
        this.fillObsList("driver " + name + ": leaving petrol station with responsetime: " + (System.currentTimeMillis() - startTime));
        System.out.println("driver " + name + ": leaving petrol station with responsetime: " + (System.currentTimeMillis() - startTime));
        this.semaPetrolPumpFree.release();
        return this.name + " has finished";
    }
    
    public long getRespondTime(){
        return this.timeEnd - this.timeStart;
    }

    public int getId() {
        return id;
    }

    public int getCurrentCooX() {
        return currentCooX;
    }
    
    private void fillObsList(String value){
        Platform.runLater(new Runnable() {
            public void run() {
                obsList.add(value);
            }
        });
    }
    
    private void moveCar(){
        Platform.runLater(() -> {
            try {
                controller.doAnimationMoving(CarDriver.this);
            } catch (Exception ex) {
                java.util.logging.Logger.getLogger(CarDriver.class.getName()).log(Level.SEVERE, null, ex);
            }
        });
    }
}
