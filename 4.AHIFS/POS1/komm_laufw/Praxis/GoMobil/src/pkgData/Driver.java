/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgData;

import java.io.Serializable;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import javax.xml.bind.annotation.XmlRootElement;
/**
 *
 * @author schueler
 */

@XmlRootElement
public class Driver implements Comparable<Driver>, Serializable{
    
    private static final long serialVersionUID = 1L; //1L = type convercion
    private static int nextId=0;
    private int id;
    private String name;
    private LocalDate birth;
    private LocalDate hireBegin;
    private LocalDate hireEnd;

    public Driver(){
        super();
    }
    public Driver(String name, LocalDate birth, LocalDate hireBegin, LocalDate hireEnd) {
        this.name = name;
        this.birth = birth;
        this.hireBegin = hireBegin;
        this.hireEnd = hireEnd;
        this.id = nextId;
        nextId++;
    }
    
     public Driver(String name, String birth,String hireBegin, String hireEnd) {
        this.name = name; 
        DateTimeFormatter formatter =DateTimeFormatter.ofPattern("yyyy-MM-dd"); 
        this.birth = LocalDate.parse(birth,formatter);
        this.hireBegin = LocalDate.parse(hireBegin,formatter);
        this.hireEnd = LocalDate.parse(hireEnd,formatter);
        this.id = nextId;
        nextId++;
    }

    public int getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public String getBirth() {
        return birth.toString();
    }

    public void setId(int id) {
        this.id = id;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setBirth(LocalDate birth) {
        this.birth = birth;
    }
    
     public void setBirth(String birth) {
        this.birth = LocalDate.parse(birth, DateTimeFormatter.ofPattern("yyyy-MM-dd"));
    }
     
    public void setHireBegin(LocalDate hireBegin) {
        this.hireBegin = hireBegin;
    }

    public void setHireBegin(String hireBegin) {
        this.hireBegin = LocalDate.parse(hireBegin, DateTimeFormatter.ofPattern("yyyy-MM-dd"));
    }
        
    public void setHireEnd(LocalDate hireEnd) {
        this.hireEnd = hireEnd;
    }

    public void setHireEnd(String hireEnd) {
        this.hireEnd = LocalDate.parse(hireEnd, DateTimeFormatter.ofPattern("yyyy-MM-dd"));;
    }
        
    public String getHireBegin() {
        return hireBegin.toString();
    }

    public String getHireEnd() {
        return hireEnd.toString();
    }

    @Override
    public String toString() {
        return "Driver{" + "id=" + id + ", name=" + name + ", birth=" + birth + ", hireBegin=" + hireBegin + ", hireEnd=" + hireEnd + '}';
    }

    @Override
    public int compareTo(Driver o) {
        int result=0;
      //  result=this.name.compareTo(o.getName());
        //if(result==0)
            result = this.id-o.getId();
        
        return result;
    }
    
}
 