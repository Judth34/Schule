/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgPizza;

/**
 *
 * @author Marcel Judth
 */
public class Order {
    private static int OrderID = 1;
    private int id;
    private Customer customer;
    private Pizza pizza;

    public Order(Customer customer){
        this.setId();
        this.customer = customer;
    }
    
    private synchronized void setId() {
        this.id = OrderID;
        OrderID++;
    }

    public Customer getCustomer() throws InterruptedException {
        return customer;
    }

    public Pizza getPizza() {
        return pizza;
    }

    public int getId() {
        return id;
    }

    public void setPizza(Pizza pizza) {
        this.pizza = pizza;
    }
    
}
