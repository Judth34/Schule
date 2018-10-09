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
public class Cook extends Thread implements ISubject{

    private final String name;
    private final Semaphore semBarFree;
    private final Semaphore semaPizzaOnBar;
    private final Semaphore semaOrderExists;
    private boolean isEnd;
    private final Bar bar;

    public Cook(String name, Bar bar, Semaphore semBarFree, Semaphore semaPizzaOnBar, Semaphore semaOrderExists) {
        this.name = name;
        this.semBarFree = semBarFree;
        this.semaPizzaOnBar = semaPizzaOnBar;
        this.semaOrderExists = semaOrderExists;
        this.bar = bar;
        this.isEnd = false;
    }
    
    @Override
    public void run() {
        try {
            this.semBarFree.acquire();
            while(!isEnd){
                System.out.println(this.getClass().getName() + " " + this.getName() + ": is waiting for next order");
                this.semaOrderExists.acquire();
                Order o = this.bar.getNextOrder();
                Pizza p = new Pizza("Pizza");
                
                System.out.println(this.getClass().getName() + " " + this.getName() + ": starts creating "  + p.toString());
                Thread.sleep(1000);
                o.setPizza(p);
                
                System.out.println(this.getClass().getName() + " " + this.getName() + ": finished creating "  + p.toString());
                
                System.out.println(this.getClass().getName() + " " + this.getName() + ": starts waiting for free bar");
                
                this.semaPizzaOnBar.acquire();
                this.bar.addFinishedOrder(o);

                System.out.println(this.getClass().getName() + " " + this.getName() + ": laying on bar " + p.toString());
                this.semBarFree.release();
               }
        } catch (Exception ex) {
            Logger.getLogger(Cook.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
    @Override
    public void setEnd() {
        this.isEnd = true;
        this.semaPizzaOnBar.release();
        this.semaOrderExists.release();
    }
    
}
