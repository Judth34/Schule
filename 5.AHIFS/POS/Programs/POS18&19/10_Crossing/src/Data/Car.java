/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Data;

import Controller.SimulationController;
import helpers.AnimCoordinates;
import helpers.TimeGenerator;
import java.util.HashMap;
import java.util.concurrent.Semaphore;
import java.util.logging.Level;
import javafx.application.Platform;
import javafx.concurrent.Task;

/**
 *
 * @author schueler
 */
public class Car extends Task<String> implements AnimCoordinates {

    private static final int DEVIATION = 20;
    private static SimulationController controller;
    private static int nextID = 0;
    private int id;
    private String name;
    private Place startPoint;
    private Place destination;
    private long waitingTime;
    private int currentXCoo;
    private int currentYCoo;
    private int oldXCoo;
    private int oldYCoo;
    private HashMap<String, Integer> allCoo;
    private Semaphore semaStreetSpittal;
    private Semaphore semaStreetKlgft;

    public Car(String name, Place startPoint, Place destination, long waitingTime, Semaphore semaStreetSpittal, Semaphore semaStreetKlgft) throws Exception {
        if (controller == null) {
            throw new Exception("Car Controller is null!");
        }
        this.id = getNextID();
        this.name = name;
        this.destination = destination;
        this.startPoint = startPoint;
        this.waitingTime = waitingTime;
        this.allCoo = AnimCoordinates.getCoo();
        this.currentXCoo = allCoo.get("START_X_" + this.startPoint.toString());
        this.currentYCoo = allCoo.get("START_Y_" + this.startPoint.toString());
        this.semaStreetSpittal = semaStreetSpittal;
        this.semaStreetKlgft = semaStreetKlgft;
    }

    @Override
    protected String call() throws Exception {
        controller.addNewCarImage(this);
        this.oldXCoo = this.currentXCoo;
        this.oldYCoo = this.currentYCoo;
        this.currentXCoo = allCoo.get("CROSSING_X_" + this.startPoint.toString());
        this.currentYCoo = allCoo.get("CROSSING_Y_" + this.startPoint.toString());
        this.moveCar();
        long rndTime = TimeGenerator.getRandomTime(this.waitingTime, DEVIATION);
        Thread.sleep(rndTime);
        if (this.startPoint == Place.KLAGENFURT) {
            this.semaStreetSpittal.acquire();
            if (this.destination == Place.UDINE) {
                while(this.semaStreetKlgft.tryAcquire()){
                    System.out.println("Waiting..." + this.toString());
                }
                this.semaStreetKlgft.acquire();
                System.out.println("lets go");
            }
        } else if (this.startPoint == Place.SPITTAL) {
            this.semaStreetKlgft.acquire();
            if (this.destination == Place.AFRITZ) {
                while(this.semaStreetSpittal.tryAcquire()){
                    System.out.println("Waiting..." + this.toString());
                }
                System.out.println("lets go");
                this.semaStreetSpittal.acquire();
            }
        }

        this.oldXCoo = this.currentXCoo;
        this.oldYCoo = this.currentYCoo;
        this.currentXCoo = allCoo.get("MIDDEL_CROSSING_X");
        this.currentYCoo = allCoo.get("MIDDEL_CROSSING_Y");
        this.moveCar();
        Thread.sleep(1000);
        this.oldXCoo = this.currentXCoo;
        this.oldYCoo = this.currentYCoo;
        this.currentXCoo = allCoo.get("START_X_" + this.destination.toString());
        this.currentYCoo = allCoo.get("START_Y_" + this.destination.toString());
        this.moveCar();
        Thread.sleep(1000);
        this.removeCar();
        return "finished!";
    }

    private void moveCar() {
        Platform.runLater(() -> {
            try {
                controller.doAnimationMoving(Car.this);
            } catch (Exception ex) {
                java.util.logging.Logger.getLogger(Car.class.getName()).log(Level.SEVERE, null, ex);
            }
        });
    }

    private void removeCar() {
        Platform.runLater(() -> {
            try {
                controller.removeImage(Car.this);
            } catch (Exception ex) {
                java.util.logging.Logger.getLogger(Car.class.getName()).log(Level.SEVERE, null, ex);
            }
        });
    }

    private static int getNextID() {
        nextID++;
        return nextID;
    }

    public static void setNextID(int nextID) {
        Car.nextID = nextID;
    }

    public int getCurrentYCoo() {
        return currentYCoo;
    }

    public void setCurrentYCoo(int currentYCoo) {
        this.currentYCoo = currentYCoo;
    }

    public Place getStartPoint() {
        return startPoint;
    }

    public void setStartPoint(Place startPoint) {
        this.startPoint = startPoint;
    }

    public int getOldYCoo() {
        return oldYCoo;
    }

    public void setOldYCoo(int oldYCoo) {
        this.oldYCoo = oldYCoo;
    }

    public int getCurrentXCoo() {
        return currentXCoo;
    }

    public int getOldXCoo() {
        return oldXCoo;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Place getDestination() {
        return destination;
    }

    public void setDestination(Place destination) {
        this.destination = destination;
    }

    public long getWaitingTime() {
        return waitingTime;
    }

    public void setWaitingTime(long waitingTime) {
        this.waitingTime = waitingTime;
    }

    public static void setController(SimulationController controller) {
        Car.controller = controller;
    }

    @Override
    public String toString() {
        return "Car{" + "id=" + id + ", name=" + name + ", startPoint=" + startPoint + ", destination=" + destination + ", waitingTime=" + waitingTime + ", currentXCoo=" + currentXCoo + ", currentYCoo=" + currentYCoo + ", oldXCoo=" + oldXCoo + ", oldYCoo=" + oldYCoo + '}';
    }

}
