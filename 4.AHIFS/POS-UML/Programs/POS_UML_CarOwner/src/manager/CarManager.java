/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package manager;

import data.Car;
import data.Owner;
import java.time.LocalDate;
import java.util.HashMap;
import static manager.OwnerManager.getOwner;

/**
 *
 * @author samuel
 */
public class CarManager {

    private static final HashMap<String, Car> cars = new HashMap<String, Car>();

    public static String newCar(String fgNr, LocalDate date, String type, String ownerSv) {
        String result;
        if (cars.containsKey(fgNr) || OwnerManager.getOwner(ownerSv) == null) {
            result = null;
        } else {
            Car car = new Car(fgNr, date, type, ownerSv);
            cars.put(car.getFgNr(), car);
            OwnerManager.getOwner(ownerSv).addCar(car);
            result = fgNr;
        }
        return result;
    }

    public static boolean deleteCar(String fgNr) {
        Car c = cars.get(fgNr);
        Owner o = OwnerManager.getOwner(c.getOwnerSvNr());
        return c != null && o.getCars().size() > 1 && cars.remove(fgNr) != null && o.removeCar(c);
    }
    
    public static boolean updateCar(String oldFgNr, String newFgNr) {
        Car c = getCar(oldFgNr);
        boolean res = (c != null && !cars.containsKey(newFgNr));
        if (res) {
            cars.remove(c.getFgNr());
            c.setFgNr(newFgNr);
            cars.put(newFgNr, c);
        }
        return res;
    }
    
    public static Car getCar(String fgNr){
        return cars.get(fgNr);
    }

    public static int countCars() {
        return cars.size();
    }
}
