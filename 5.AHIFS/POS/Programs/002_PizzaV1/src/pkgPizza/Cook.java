/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgPizza;

import java.util.concurrent.Semaphore;
import java.util.logging.Level;
import java.util.logging.Logger;
import javafx.application.Platform;

/**
 *
 * @author Marcel Judth
 */
public class Cook extends Person{  

    public Cook(String name, Bar bar, Semaphore semBarFree, Semaphore semaPizzaOnBar, Semaphore semaOrderExists) {
        super(name, bar, semBarFree, semaPizzaOnBar, semaOrderExists);
    }
    
    
    
    @Override
    public void setEnd() {
        this.isEnd = true;
        this.semaPizzaOnBar.release();
        this.semaOrderExists.release();
    }

    @Override
    protected String call() throws Exception {
        try {
            this.semBarFree.acquire();
            int tmp_i = 100;
            while(!isEnd){
                System.out.println(this.getClass().getName() + " " + this.name + ": is waiting for next order");
                this.semaOrderExists.acquire();
                if(!isEnd){
                    Order o = this.bar.getNextOrder();
                    System.out.println(this.getClass().getName() + " " + this.name + ": got order " + o.toString());
                    Pizza p = new Pizza("Pizza");
                    System.out.println(this.getClass().getName() + " " + this.name + ": starts creating "  + p.toString());
                    Thread.sleep(1000);
                    Platform.runLater(()-> this.setDoubleProperty(tmp_i));

                    o.setPizza(p);
                    System.out.println(this.getClass().getName() + " " + this.name + ": finished creating "  + p.toString());

                    System.out.println(this.getClass().getName() + " " + this.name + ": starts waiting for free bar");

                    this.semaPizzaOnBar.acquire();
                    this.bar.addFinishedOrder(o);

                    System.out.println(this.getClass().getName() + " " + this.name + ": laying on bar " + p.toString());
                    this.semBarFree.release();
                }
               }
            System.out.println(this.getClass().getName() + " " + this.name + ": has finished");
        } catch (Exception ex) {
            Logger.getLogger(Cook.class.getName()).log(Level.SEVERE, null, ex);
        }    
        return "finished";
    }

    @Override
    public void start() {
        try {
            this.semBarFree.acquire();
            while(!isEnd){
                System.out.println(this.getClass().getName() + " " + this.name + ": is waiting for next order");
                this.semaOrderExists.acquire();
                if(!isEnd){
                    Order o = this.bar.getNextOrder();
                    System.out.println(this.getClass().getName() + " " + this.name + ": got order " + o.toString());
                    Pizza p = new Pizza("Pizza");
                    System.out.println(this.getClass().getName() + " " + this.name + ": starts creating "  + p.toString());
                    Thread.sleep(1000);
                    o.setPizza(p);
                    System.out.println(this.getClass().getName() + " " + this.name + ": finished creating "  + p.toString());

                    System.out.println(this.getClass().getName() + " " + this.name + ": starts waiting for free bar");

                    this.semaPizzaOnBar.acquire();
                    this.bar.addFinishedOrder(o);

                    System.out.println(this.getClass().getName() + " " + this.name + ": laying on bar " + p.toString());
                    this.semBarFree.release();
                }
               }
            System.out.println(this.getClass().getName() + " " + this.name + ": has finished");
        } catch (Exception ex) {
            Logger.getLogger(Cook.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
}
