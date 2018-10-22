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
public class Customer extends Person  {

    public Customer(String name, Bar bar, Semaphore semBarFree, Semaphore semaPizzaOnBar, Semaphore semaOrderExists) {
        super(name, bar, semBarFree, semaPizzaOnBar, semaOrderExists);
    }

    @Override
    protected String call() throws Exception {
        try {
            while(!this.isEnd){
                System.out.println(this.getClass().getName() + " " + this.name + ": is hungry and creates order");
                Order order = new Order(this);
                this.bar.addOrder(order);
                this.semaOrderExists.release();
                System.out.println(this.getClass().getName() + " " + this.name + ": created Order " + order.toString());
                System.out.println(this.getClass().getName() + " " + this.name + ": starts waiting for pizza");
                boolean orderIsFinished = false;
                while(!orderIsFinished){
                    this.semBarFree.acquire();
                    orderIsFinished = this.bar.orderIsFinished(order);
                    if(!orderIsFinished)
                        this.semBarFree.release();
                }
                Pizza p = order.getPizza();
                System.out.println(this.getClass().getName() + " " + this.name + ": got pizza from order " + order.toString());
                this.semBarFree.release();
                this.semaPizzaOnBar.release();
                Thread.sleep((long)(Math.random() * 1000));
            }
            System.out.println(this.getClass().getName() + " " + this.name + " has finished ");
        } catch (Exception ex) {
            Logger.getLogger(Customer.class.getName()).log(Level.SEVERE, null, ex);
        }
        return "finished";
    }

    @Override
    public void start() {
        try {
            while(!this.isEnd){
                System.out.println(this.getClass().getName() + " " + this.name + ": is hungry and creates order");
                Order order = new Order(this);
                this.bar.addOrder(order);
                this.semaOrderExists.release();
                System.out.println(this.getClass().getName() + " " + this.name + ": created Order " + order.toString());
                System.out.println(this.getClass().getName() + " " + this.name + ": starts waiting for pizza");
                boolean orderIsFinished = false;
                while(!orderIsFinished){
                    this.semBarFree.acquire();
                    orderIsFinished = this.bar.orderIsFinished(order);
                    if(!orderIsFinished)
                        this.semBarFree.release();
                }
                Pizza p = order.getPizza();
                System.out.println(this.getClass().getName() + " " + this.name + ": got pizza from order " + order.toString());
                this.semBarFree.release();
                this.semaPizzaOnBar.release();
                Thread.sleep((long)(Math.random() * 1000));
            }
            System.out.println(this.getClass().getName() + " " + this.name + " has finished ");
        } catch (Exception ex) {
            Logger.getLogger(Customer.class.getName()).log(Level.SEVERE, null, ex);
        }    
    }
    
    @Override
    public String toString() {
        return "Customer{" + "name=" + name + '}';
    }
}
