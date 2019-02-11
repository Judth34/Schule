/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Data;
import Misc.EventLogBookChanged;
import Misc.EventSalaryChanged;
import java.io.Serializable;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.EventListener;
import java.util.TreeSet;
import javax.xml.bind.annotation.XmlElement;

/**
 *
 * @author schueler
 */

public class Driver implements Comparable<Driver>,Serializable{
    
    static int nextID = 0;
    int id;
    String name;
    LocalDate birthdate;
    LocalDate HireBegin;
    LocalDate HireEnd;
    TreeSet<Log> Logbook;
    @XmlElement
    TreeSet<SalaryEntry> Salary;
    
    //CONSTRUCTORS
    public Driver(String name, LocalDate birthdate, LocalDate HireBegin, LocalDate HireEnd) {
        this.id = nextID++;
        this.name = name;
        this.birthdate = birthdate;
        this.HireBegin = HireBegin;
        this.HireEnd = HireEnd;
        this.Logbook = new TreeSet<>();
        this.Salary = new TreeSet<>();
    }

    public Driver( String name, String birthdate, String HireBegin, String HireEnd) {
       try{
        this.id = nextID;
        this.name = name;
        this.birthdate = LocalDate.parse(birthdate);
        this.HireBegin = LocalDate.parse(HireBegin);
        this.HireEnd = LocalDate.parse(HireEnd);   
        this.Logbook = new TreeSet<>();
        this.Salary = new TreeSet<>();
        nextID++;
        
       }catch(Exception ex){
          // throw new Exception ("A Date was wrong");
       }   
    }
   
    public Driver() {
        this.id = ++nextID;
        this.Logbook = new TreeSet<>();
        this.Salary = new TreeSet<>();
    }

    public Driver(int id, String name, String birthdate, String HireBegin, String HireEnd) {
       try{
        this.id = id;
        this.name = name;
        this.birthdate = LocalDate.parse(birthdate);
        this.HireBegin = LocalDate.parse(HireBegin);
        this.HireEnd = LocalDate.parse(HireEnd);  
        this.Logbook = new TreeSet<>(); 
        this.Salary = new TreeSet<>();
       }catch(Exception ex){
           //throw new Exception ("A Date was wrong");
       }      
    }

    public SalaryEntry getSalWithRowNumber(int row) throws Exception {
    try{
            return (SalaryEntry)this.Salary.toArray()[row];
        }catch(Exception Ex){
            throw new Exception("No such Log exists " + Ex.getMessage());
        }
    }

    public void deleteSal(SalaryEntry sal) throws Exception {
        this.Salary.remove(sal);
        if(this.listenersal != null)
            listenersal.handleSalChanged(new EventSalaryChanged("sal deleted",this));
    }

    public int getTotalNumberOfJourneys() {
        int res = 0;
            for(Log log: this.Logbook)
                res += log.getNrJourneys();
        return res;
    }
    
    public interface OnLogBookChangedListener extends EventListener{
        void handleLogBookChanged(EventLogBookChanged event);
    }
    private OnLogBookChangedListener listener = null;
    
    public void addONLogBookChangedListener(OnLogBookChangedListener listener){
        this.listener = listener;
    }
    
    public interface OnSalChangedListener extends EventListener{
        void handleSalChanged(EventSalaryChanged event);
    }
    private OnSalChangedListener listenersal = null;
    
    public void addONSalChangedListener(OnSalChangedListener listener){
        this.listenersal = listener;
    }
    
    public int getNumberOfLogBooks() {
        return this.Logbook.size();
    }
    
    
    //GETTER
    public int getId() {
        return id;
    }

    public String getName() {
        return name;
    }

    public String getBirthdate() {
        return birthdate.toString();
    }

    public String getHireBegin() {
        return HireBegin.toString();
    }

    public String getHireEnd() {
        return HireEnd.toString();
    }
    
    
    //SETTER
    public void setId(int id) {
        this.id = id;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setBirthdate(String birthdate) {
        this.birthdate = LocalDate.parse(birthdate);
    }

    public void setHireBegin(String HireBegin) {
        this.HireBegin = LocalDate.parse(HireBegin);
    }

    public TreeSet<Log> getLogbook() {
        return Logbook;
    }

    public void setLogbook(TreeSet<Log> Logbook) {
        this.Logbook = Logbook;
    }

    public void setHireEnd(String HireEnd) {
        this.HireEnd = LocalDate.parse(HireEnd);
    }
    
    
    //OVERRIDE
    @Override
    public int compareTo(Driver o) {
        int result = this.getName().compareTo(o.getName());
        if (result == 0)
            return this.getId()-o.getId();
        return result;
    }

    @Override
    public String toString() {
        return "Driver{" + "id=" + id + ", name=" + name + ", birthdate=" + birthdate + ", HireBegin=" + HireBegin + ", HireEnd=" + HireEnd + '}';
    }
    
    public void addLog (Log log){
        this.Logbook.add(log);
        Logbook.add(log);
        if(listener != null)
            listener.handleLogBookChanged(new EventLogBookChanged("Something was added to collection",this));
        
    }
    
    public void DeleteLog(Log log){
        this.Logbook.remove(log);
        if(listener != null)
            listener.handleLogBookChanged(new EventLogBookChanged("Something changed",this));
    }
    
    public Log getLogWithRowNumber(int row) throws Exception{
        //
        try{
            return (Log)this.Logbook.toArray()[row];
        }catch(Exception Ex){
            throw new Exception("No such Log exists " + Ex.getMessage());
        }
    }

    public int getNumberOfLogs(){
        if (this.Logbook == null || this.Logbook.isEmpty())
            return 0;
        return this.Logbook.size();
    }
    
    public int getNumberOfSalaryEntrys(){
        if(this.Salary == null || this.Salary.isEmpty())
            return 0;
        return this.Salary.size();
    }
    
    public void addSalaryEntry(SalaryEntry sal){
        this.Salary.add(sal);
        if (listenersal != null)
            listenersal.handleSalChanged(new EventSalaryChanged("added",this));
    }
    
}
