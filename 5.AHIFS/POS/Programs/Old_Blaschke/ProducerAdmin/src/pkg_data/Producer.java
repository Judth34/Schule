/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkg_data;

import java.sql.Date;
import java.time.LocalDate;
import java.util.TreeSet;

/**
 *
 * @author schueler
 */
public class Producer {
    
    private int id;
    private String name;
    private int sal;
    private TreeSet<Product> products;
    private int count;
    private LocalDate first;
    private LocalDate last;

    public Producer(int id, String name, int sal) {
        this.initialize(id, name, sal, new TreeSet<>(),LocalDate.MIN,LocalDate.MAX,Integer.MAX_VALUE);
    }

    public Producer() {
        this.initialize(Integer.MAX_VALUE, "", Integer.MAX_VALUE, new TreeSet<>(),LocalDate.MIN,LocalDate.MAX,Integer.MAX_VALUE);
    }

    public Producer(int id, String name, int sal, TreeSet<Product> temp) {
        this.initialize(id, name, sal, temp,LocalDate.MIN,LocalDate.MAX,Integer.MAX_VALUE);
    }

    public Producer(int id, String name, int sal, TreeSet<Product> products, int count, LocalDate first, LocalDate last) {
        this.initialize(id, name, sal, products, first, last, count);
    }

    public Producer(int id, String name, int sal, int count, LocalDate first, LocalDate last) {
        this.initialize(id, name, sal, new TreeSet<>(), first, last, count);
    }
        
    public Producer(int id, String name, int sal, int count, Date first,Date last) {
        if(first != null && last != null)
            this.initialize(id, name, sal, new TreeSet<>(), first.toLocalDate(), last.toLocalDate(), count);
        else 
            this.initialize(id, name, sal, new TreeSet<>(), null, null, count);
    }
    
    
    public int getId() {
        return id;
    }

    private void setId(int id) {
        this.id = id;
    }
    
    public String getName() {
        return name;
    }

    public int getSal() {
        return sal;
    }

    private void setSal(int sal) {
        this.sal = sal;
    }

    public int getCount() {
        return count;
    }

    public void setCount(int count) {
        this.count = count;
    }

    public LocalDate getFirst() {
        return first;
    }

    public void setFirst(LocalDate first) {
        this.first = first;
    }

    public LocalDate getLast() {
        return last;
    }

    public void setLast(LocalDate last) {
        this.last = last;
    }
    
    public TreeSet<Product> getProducts() {
        return products;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setProducts(TreeSet<Product> products) {
        this.products = products;
    }

    @Override
    public String toString() {
        return "Producer{" + "name=" + name + ", count=" + count + ", first=" + first + ", last=" + last + '}';
    }
    
    
    
    //MUFUNTIONS
    
    public void add(Product product)throws Exception{
        if(this.products.contains(product))
            throw new Exception("this product already exists.");
        this.products.add(product);
        this.count++;
    }
    
    private void initialize(int id, String name, int sal, TreeSet<Product> temp, LocalDate first, LocalDate last, int count) {
       this.setId(id);
       this.setName(name);
       this.setSal(sal);
       this.setProducts(temp);
       this.setCount(count);
       this.setFirst(first);
       this.setLast(last);
       
    }
    
    
}
