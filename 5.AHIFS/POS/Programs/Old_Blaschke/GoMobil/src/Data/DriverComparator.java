/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Data;

import Data.Driver;
import java.io.Serializable;
import java.util.Comparator;

/**
 *
 * @author schueler
 */
public class DriverComparator implements Comparator<Driver>,Serializable {

    @Override
    public int compare(Driver o1, Driver o2) {
        int result = 0;

        result = o1.getName().compareTo(o2.getName());

        return result;
    }
    
}
