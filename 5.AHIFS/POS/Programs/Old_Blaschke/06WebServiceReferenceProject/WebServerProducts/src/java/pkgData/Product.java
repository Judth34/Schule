/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgData;

import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import javax.xml.bind.annotation.XmlRootElement;

/**
 *
 * @author Gerald
 */
@XmlRootElement
public class Product {
    private int id, onStock;
    private String name;
    private LocalDate onMarket;
    private Producer producer;

    public Product(int id,  String name, int onStock, LocalDate onMarket) {
        this.id = id;
        this.onStock = onStock;
        this.name = name;
        this.onMarket = onMarket;
    }
    public Product() {
    }
    public Product(String name) {
        this(-99, name, -99, null);
    }
    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    public int getOnStock() {
        return onStock;
    }

    public void setOnStock(int onStock) {
        this.onStock = onStock;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public LocalDate getOnMarket() {
        return onMarket;
    }
    public void setOnMarket(LocalDate onMarket) {
        this.onMarket = onMarket;
    }
    public void setOnMarket(String strOnMarket) {
        this.onMarket = LocalDate.parse(strOnMarket);
    }

    public Producer getProducer() {
        return producer;
    }

    public void setProducer(Producer producer) {
        this.producer = producer;
    }

    @Override
    public String toString() {
        return "Product{" + "id=" + id + ", onStock=" + onStock + ", name=" + name + ", onMarket=" + onMarket + '}';
    }
    
    
}
