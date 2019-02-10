/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkg_data;

import java.time.LocalDate;

/**
 *
 * @author schueler
 */
public class Order implements Comparable<Order> {
    private int id;
    private int product_id;
    private int quantity;
    public static boolean first = true;
    Product product;
    
    public Order(int id, int product_id, int quantity, String name, int onStock, LocalDate onMarket, int price) {
        this.initialize(id, product_id, quantity,name,onStock,onMarket,price);
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public int getProduct_id() {
        return product_id;
    }

    public void setProduct_id(int product_id) {
        this.product_id = product_id;
    }

    public int getQuantity() {
        return quantity;
    }

    public void setQuantity(int quantity) {
        this.quantity = quantity;
    }

    @Override
    public String toString() {
        return "Order{" + "id=" + id + ", product_id=" + product_id + ", quantity=" + quantity + ", product=" + product + '}';
    }
    
    
    //MYFUCTIONS 
    
    private void initialize(int id, int product_id, int quantity,String name, int onStock, LocalDate OnMarket,int price){
        this.setId(id);
        this.setProduct_id(product_id);
        this.setQuantity(quantity);
        this.product = new Product(product_id,name,onStock,OnMarket,price);
        Order.first = false;
    }

    @Override
    public int compareTo(Order o) {
        return 1;
    }

    
    
}
