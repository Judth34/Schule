/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgPizza;

import java.util.concurrent.Semaphore;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author Marcel Judth
 */
public class Customer extends Thread implements ISubject {
    private final String name;
    private final Semaphore semBarFree;
    private final Semaphore semaPizzaOnBar;
    private final Semaphore semaCustIsHungry;
    private boolean isEnd;
    private final Bar bar;

    public Customer(String name, Bar bar, Semaphore semBarFree, Semaphore semaPizzaOnBar, Semaphore semaCustIsHungry) {
        this.name = name;
        this.semBarFree = semBarFree;
        this.semaPizzaOnBar = semaPizzaOnBar;
        this.semaCustIsHungry = semaCustIsHungry;
        this.bar = bar;
        isEnd = false;
    }
    
    @Override
    public void run() {
        try {
            while(!this.isEnd){
                Thread.sleep(1000);
                System.out.println(this.getClass().getName() + " " + this.name + ": is hungry and creates order");
                Order order = new Order(this);
                this.bar.addOrder(order);
                this.semaCustIsHungry.release();
                this.semaCustIsHungry.release();
                System.out.println(this.getClass().getName() + " " + this.name + ": starts waiting for pizza");
                this.semBarFree.acquire();
                
                
                
//                this.semBarFree.acquire();
//                if(!this.semaPizzaOnBar.tryAcquire()){
//                    System.out.println(this.getClass().getName() + " " + this.name + ": starts eating pizza");
//                    Pizza p = this.bar.getPizza(order);
//                    this.semaPizzaOnBar.release();
//                    System.out.println(this.getClass().getName() + " " + this.name + ": finished eating pizza");
//                }
            }
        } catch (Exception ex) {
            Logger.getLogger(Customer.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
    @Override
    public void setEnd(){
        this.isEnd = true;
    }        
}
