/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Data;

import java.io.Serializable;
import java.math.BigDecimal;
import java.math.RoundingMode;
import java.text.DateFormatSymbols;
import java.util.ArrayList;

/**
 *
 * @author schueler
 */
public class SalaryEntry implements Comparable<SalaryEntry>, Serializable {
    
    private final BigDecimal WAGE_PER_HOUR = new BigDecimal(9.80);
    private int Month;
    private BigDecimal totalSalary;
    private int totalHours;
    private int sal;

    public SalaryEntry(int Month, int totalHours) {
        this.Month = Month;
        this.totalSalary = new BigDecimal((long)totalHours * WAGE_PER_HOUR.longValue());
        this.totalHours = totalHours;
    }

    public SalaryEntry() {
    }
    
    

    public int getMonth() {
        return Month;
    }
    public String getMonthAsString(){
        if(this.Month == -1)
            return "undefiened";
        ArrayList<String> months = getAllMonths();
        return months.toArray()[this.getMonth()].toString();
        
    }

    @Override
    public String toString() {
        return "SalaryEntry{" + ", Month=" + this.getMonthAsString() + ", totalSalary=" + this.getTotalSalaryAsString() + ", totalHours=" + totalHours + '}';
    }

    public BigDecimal getTotalSalary() {
        return totalSalary;
    }

    public void setMonth(int Month) {
        this.Month = Month;
    }

    public void setTotalSalary(BigDecimal totalSalary) {
        this.totalSalary = totalSalary;
    }

    public String getTotalSalaryAsString(){
        return this.getTotalSalary().setScale(2, BigDecimal.ROUND_HALF_UP).toString();
    }   

    public int getTotalHours() {
        return totalHours;
    }

    public void setTotalHours(int totalHours) {
        this.totalHours = totalHours;
        this.totalSalary = (new BigDecimal(totalHours * this.WAGE_PER_HOUR.intValue()));
    }
    
    
    
    
    @Override
    public int compareTo(SalaryEntry o) {
         return this.getMonth() - o.getMonth();
    }

    public static ArrayList<String> getAllMonths(){
        ArrayList<String> result = new ArrayList<>();
        DateFormatSymbols dfs = new DateFormatSymbols();
        
        for(String d : dfs.getMonths())
            result.add(d);
        result.remove("");
        return result;
    }
        
}
