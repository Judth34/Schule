/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package controller;

import data.Car;
import data.Owner;
import java.time.LocalDate;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Set;

/**
 *
 * @author schueler
 */
public class CarOwnerController {
    private static final HashMap<String, Owner> owners = new HashMap<String, Owner>();
    private static final HashMap<String, Car> cars = new HashMap<String, Car>();
    
    /**
     * insert new owner and new car
     * @param svNr
     * @param name
     * @param fgNr
     * @param date
     * @param type
     * @return svNr or null if failed to add new owner 
     */
    public static String newOwner(String svNr, String name, String fgNr, LocalDate date, String type) {
        String result = svNr;
        Owner owner = new Owner(svNr, name);
        if(owners.containsKey(owner.getSvNr()) || newCar(fgNr, date, type, owner) == null){
            result = null;
        }
        else{
            owners.put(owner.getSvNr(), owner);
        }
        return result;
    } 
    
    /**
     * 
     * @param fgNr
     * @param date
     * @param type
     * @param owner
     * @return fgNr or null if fail
     */
    public static String newCar(String fgNr, LocalDate date, String type, Owner owner) {
        String result;
        Car car = new Car(fgNr, date, type, owner.getSvNr());
        if(cars.containsKey(car.getFgNr())){
            result = null;
        }
        else{
            cars.put(car.getFgNr(), car);
            result = fgNr;
        }
        return result;
    }  
    
    public static boolean updateOwner(String oldSvNr, String newSvNr){
        Owner o = getOwner(oldSvNr);
        boolean res = o != null && !owners.containsKey(newSvNr);
        if(res){
            owners.remove(o);
            o.setSvNr(newSvNr);
            owners.put(newSvNr, o);
        }
        return res;
    }
    
    /**
     * deletes an owner and all of his cars
     * @param svNr
     * @return false if the owner could not be deleted
     */
    public static boolean deleteOwner(String svNr){
        Owner o = getOwner(svNr);
        for(Car c : o.getCars()){
            o.removeCar(c);
            cars.remove(c.getFgNr());
        }
        return owners.remove(svNr) != null;
    }
    
    /**
     * deletes a car
     * @param svNr
     * @return false if the car could not be deleted
     */
    public static boolean deleteCar(String fgNr){
        Car c = cars.get(fgNr);
        return c != null && c.getOwner().getCars().size() > 1 && cars.remove(fgNr) != null && c.getOwner().removeCar(c);
    }
    
    public static int countOwners(){
        return owners.size();
    }
    
    public static int countCars(){
        return cars.size();
    }
    
    /**
     * 
     * @param name
     * @return returns all owners with the specified name
     */
    public static Set<Owner> getOwnersByName(String name){
        Set<Owner> res = new HashSet<Owner>();
        for(Owner o : owners.values()){
            if(o.getName().equals(name))
                res.add(o);
        }
        return res;
    }

    public static Owner getOwner(String svNr) {
        return owners.get(svNr);
    }
}
