/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgPizza;

import java.util.Set;
import java.util.TreeSet;


/**
 *
 * @author Marcel Judth
 */
public class Bar {
    private final int pizzaCapacity = 2;
    private TreeSet<Order> currentOrders;
    private TreeSet<Order> finishedOrders;
    
    public Bar() {
        this.currentOrders = new TreeSet<>();
        this.finishedOrders = new TreeSet<>();
    }
    
    public void addOrder(Order o) throws Exception{
        this.currentOrders.add(o);
    }
    
    public void addFinishedOrder(Order o) {
        
    }
    
    public Pizza getPizza(Order o) throws Exception{
        Pizza p = null;
        for(Order order : this.finishedOrders){
            if(order.getId() == o.getId()){
                p = order.getPizza();
                this.finishedOrders.remove(order);
            }
        }
        if(p == null)
            throw new Exception("Order " + o.toString() + " is not finished!!");
        return p;
    }
}
