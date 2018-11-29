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
import java.util.HashSet;
import java.util.Set;

/**
 *
 * @author samuel
 */
public class OwnerManager {

    private static final HashMap<String, Owner> owners = new HashMap<String, Owner>();

    public static String newOwner(String svNr, String name, String fgNr, LocalDate date, String type) {
        String result = svNr;
        
        if (owners.containsKey(svNr) || CarManager.newCar(fgNr, date, type, svNr) == null) {
            result = null;
        } else {
            Owner owner = new Owner(svNr, name);
            owners.put(owner.getSvNr(), owner);
        }
        return result;
    }

    public static boolean updateOwner(String oldSvNr, String newSvNr) {
        Owner o = getOwner(oldSvNr);
        boolean res = (o != null && !owners.containsKey(newSvNr));
        if (res) {
            owners.remove(o.getSvNr());
            o.setSvNr(newSvNr);
            owners.put(newSvNr, o);
        }
        return res;
    }

    public static boolean deleteOwner(String svNr) {
        Owner o = getOwner(svNr);
        for (Car c : o.getCars()) {
            o.removeCar(c);
            CarManager.deleteCar(c.getFgNr());
        }
        return owners.remove(svNr) != null;
    }

    public static int countOwners() {
        return owners.size();
    }

    public static Set<Owner> getOwnersByName(String name) {
        Set<Owner> res = new HashSet<Owner>();
        for (Owner o : owners.values()) {
            if (o.getName().equals(name)) {
                res.add(o);
            }
        }
        return res;
    }

    public static Owner getOwner(String svNr) {
        return owners.get(svNr);
    }
}
