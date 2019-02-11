/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgDATA;

import java.io.Serializable;
import java.time.LocalDate;
import java.util.EventListener;
import java.util.TreeSet;
import javax.xml.bind.annotation.XmlElement;
/**
 *
 * @author schueler
 */
public class Driver implements Comparable<Driver>, Serializable{
    static int nextId = 1;
    int id;
    String name;
    LocalDate birth;
    LocalDate hireBegin;
    LocalDate hireEnd;
    @XmlElement(name = "Logbooks")
    private TreeSet<Logbook> collLogbook = new TreeSet<>();
    
    public interface OnLogBookChangedListener extends EventListener {
        void handlelogBookChanged(EventLogBookChanged event);
    }
    
    private OnLogBookChangedListener listener = null;
    
    public void addOnLogBookChangedListener (OnLogBookChangedListener listener){
        this.listener = listener;
    }
    
    public Driver(){
        this.id = nextId;
        nextId++;
    }
    
    public Driver(String name, LocalDate birth, LocalDate hireBegin, LocalDate hireEnd){
        this.id = nextId;
        this.name = name;
        this.birth = birth;
        this.hireBegin = hireBegin;
        this.hireEnd = hireEnd;
        nextId++;
    }
    
    public Driver(String name, String strBirth, String strHireBegin, String strHireEnd){
        this.id = nextId;
        this.name = name;
        this.birth = LocalDate.parse(strBirth);
        this.hireBegin = LocalDate.parse(strHireBegin);
        this.hireEnd = LocalDate.parse(strHireEnd);
        nextId++;
    }

    public Logbook getLogbookWithRowNumber(int row){
        try{
                    return (Logbook)this.collLogbook.toArray()[row];
        }catch(Exception ex){
            return null;
        }
    }
    
     protected int getNumberOfLogbooks(){
        return collLogbook.size();
    }
     
     public void addLogbook(Logbook logbook) throws Exception{
        if(collLogbook.contains(logbook)){
            throw new Exception("Logbook already added!!");
        }
        this.collLogbook.add(logbook);
        if(listener != null){
            listener.handlelogBookChanged(new EventLogBookChanged(this, "Something has changed" ));
        }
    }
    
    public void deleteLogbook(Logbook lb) throws Exception{
        if(!collLogbook.contains(lb))
            throw new Exception("Logbook is not in TreeSet!!");
        this.collLogbook.remove(lb);
        if(listener != null){
            listener.handlelogBookChanged(new EventLogBookChanged(this, "Something has changed"));
        }
    }
    
    public boolean containsLogbook(Logbook l){
        return this.collLogbook.contains(l);
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

    public String getBirth() {
        if(birth == null)
            return "";
        return birth.toString();
    }

    public void setBirth(String birth){
        this.birth = LocalDate.parse(birth);
    }

    public String getHireBegin() {
        if(hireBegin == null)
            return "";
        return hireBegin.toString();
    }

    public void setHireBegin(String hireBegin) {
        this.hireBegin = LocalDate.parse(hireBegin);
    }

    public String getHireEnd() {
        if(hireEnd == null)
            return "";
        return hireEnd.toString();
    }

    public void setHireEnd(String hireEnd) {
        this.hireEnd = LocalDate.parse(hireEnd);
    }

    @Override
    public String toString() {
        return "Driver{" + "id=" + id + ", name=" + name + ", birth=" + birth + ", hireBegin=" + hireBegin + ", hireEnd=" + hireEnd + '}';
    }

    @Override
    public int compareTo(Driver o) {
        int result = this.getName().compareTo(o.getName()); 
        if(result == 0)
             result = this.getId() - o.getId();
        if(result == 0)
            result = this.getHireBegin().compareTo(o.getHireBegin());
        if(result == 0)
            result = this.getHireEnd().compareTo(o.getHireEnd());
        if(result == 0)
            result = this.getBirth().compareTo(o.getBirth());
        return result;
    }
    
}
