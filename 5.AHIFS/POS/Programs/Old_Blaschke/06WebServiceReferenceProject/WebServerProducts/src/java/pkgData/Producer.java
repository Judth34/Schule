/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgData;

import java.math.BigDecimal;
import java.util.ArrayList;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author org
 */
@XmlRootElement
public class Producer {
    private int id;
    private String name;
    private BigDecimal sales;
    private ArrayList<Product> collProducts;

    public Producer() {
    }
    public Producer(String name) {
        this(-99,name,null);
    }
    public Producer(int id, String name, BigDecimal sales) {
        this.id = id;
        this.name = name;
        this.sales = sales;
    }

    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public BigDecimal getSales() {
        return sales;
    }

    public void setSales(BigDecimal sales) {
        this.sales = sales;
    }

    public ArrayList<Product> getCollProducts() {
        return collProducts;
    }

    @Override
    public String toString() {
        return "Producer{" + "id=" + id + ", name=" + name + ", sales=" + sales + '}';
    }

   
}
