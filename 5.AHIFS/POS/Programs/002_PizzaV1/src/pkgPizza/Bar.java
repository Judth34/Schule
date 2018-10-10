/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgPizza;

import java.util.TreeSet;

/**
 *
 * @author Marcel Judth
 */
public class Bar {
    private final int pizzaCapacity = 2;
    private static TreeSet<Order> currentOrders;
    private static TreeSet<Order> finishedOrders;
    
    public Bar() {
        Bar.currentOrders = new TreeSet<>();
        Bar.finishedOrders = new TreeSet<>();
    }
    
    public void addOrder(Order o) throws Exception{
        Bar.currentOrders.add(o);
    }
    
    public Order getNextOrder() throws Exception{
        if(Bar.currentOrders.isEmpty())
            throw new Exception("No current orders!");
        return Bar.currentOrders.first();
    }
    
    public void addFinishedOrder(Order order) throws Exception {
        boolean found = false;
        for(int idx = 0; idx < Bar.currentOrders.size(); idx++){
            Order o = (Order)Bar.currentOrders.toArray()[idx];
            if(o.getId() == order.getId()){
                Bar.finishedOrders.add(order);
                Bar.currentOrders.remove(o);
                found = true;
            }
        }
        if(!found)
            throw new Exception("Order " + order.toString() + " is not in List!");
    }
    
    public Pizza getPizza(Order o) throws Exception{
        Pizza p = null;
        for(Order order : Bar.finishedOrders){
            if(order.getId() == o.getId()){
                p = order.getPizza();
                Bar.finishedOrders.remove(order);
            }
        }
        if(p == null)
            throw new Exception("Order " + o.toString() + " is not finished!!");
        return p;
    }

    public boolean hasOrder() {
        return !Bar.currentOrders.isEmpty();
    }

    public boolean orderIsFinished(Order order)  {
//        System.out.println(Bar.finishedOrders.toString());
        for(int idx = 0; idx < Bar.finishedOrders.size(); idx++){
            Order o = (Order)Bar.finishedOrders.toArray()[idx];
//            System.out.println((Order)Bar.finishedOrders.toArray()[idx]);
            if(o.getId() == order.getId())
                return true;
        }
        return false;
    }
}
