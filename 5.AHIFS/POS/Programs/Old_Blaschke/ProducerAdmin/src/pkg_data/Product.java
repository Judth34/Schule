package pkg_data;

import java.time.LocalDate;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author schueler
 */
public class Product implements Comparable<Product> {
    private int id;
    private String name;
    private int decOnStock;
    private int onStock;
    private LocalDate onMarket;
    private State state;
    private int price;
    
    public enum State{
        MODIFIED,
        CREATED,
        UNMODIFIED
    }
    
    public Product(int id, String name, int onStock, LocalDate onMarket, int price) {
        this.initialize(id, name, onStock, onMarket,price);
    }

    public Product() {
        this.initialize(Integer.MAX_VALUE, "", Integer.MAX_VALUE, LocalDate.MAX,Integer.MAX_VALUE);
    }

    public int getPrice() {
        return price;
    }

    public void setPrice(int price) {
        this.price = price;
    }
    
    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getDecOnStock() {
        return decOnStock;
    }

    public void setDecOnStock(int decOnStock) {
        this.decOnStock = decOnStock;
    }
    
    public int getOnStock() {
        return onStock;
    }

    public void setOnStock(int onStock) {
        this.onStock = onStock;
    }

    public LocalDate getOnMarket() {
        return this.onMarket;
    }

    public State getState() {
        return state;
    }

    public void setState(State state) {
        this.state = state;
    }

    public void setOnMarket(LocalDate onMarket) {
        this.onMarket = onMarket;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    @Override
    public String toString() {
        return "Product{" + "id=" + id + ", name=" + name + ", decOnStock=" + decOnStock + ", onStock=" + onStock + ", onMarket=" + onMarket + ", state=" + state + ", price=" + price + '}';
    }
    
    
    
    
    //MYFUNCTIONS

    @Override
    public int compareTo(Product o) {
        return o.getId() - this.getId();
    }
    
    private void initialize(int id,String name,int onStock,LocalDate OnMarket, int price){
       this.setId(id);
       this.setName(name);
       this.setDecOnStock(0);
       this.setOnStock(onStock);
       this.setPrice(price);
       this.setOnMarket(OnMarket);
       this.setState(State.UNMODIFIED);
    }
    
    
}
