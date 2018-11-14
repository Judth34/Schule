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
    private int oldCooX = 0;

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
        controller.addNewCarImage(this.getId());
        this.oldCooX = XCOO_START;
        this.currentCooX = XCOO_WAITING_PUMP;
        this.moveCar();
        this.informUser("driver " + name + ": driving in petrol station");
        this.informUser("driver " + name + ": waiting for free pump");
        this.semaPetrolPumpFree.acquire();
        this.oldCooX = XCOO_WAITING_PUMP;
        this.currentCooX = XCOO_PUMPING;
        this.moveCar();
        PetrolPump pump = this.petrolStation.getFreePump();
        this.informUser("driver " + name + ": got free pump with name: " + pump.getName());
        this.informUser("driver " + name + ": starts pumping");
        System.out.println("driver " + name + ": starts pumping");
        pump.doFuelUp();
        this.informUser("driver " + name + ": ends pumping");
        this.informUser("driver " + name + ": leaving petrol station with responsetime: " + (System.currentTimeMillis() - startTime));
        this.currentCooX = XCOO_EXIT;
        this.oldCooX = XCOO_PUMPING;
        this.moveCar();
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

    public int getOldCooX() {
        return oldCooX;
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

    @Override
    public String toString() {
        return "CarDriver{" + "id=" + id + ", name=" + name + ", currentCooX=" + currentCooX + ", oldCooX=" + oldCooX + '}';
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
