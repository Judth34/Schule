/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Misc;

import Data.Car;
import Data.Database;
import Data.Driver;
import Data.Log;
import Data.SalaryEntry;
import java.math.BigDecimal;
import java.math.MathContext;
import java.util.ArrayList;
import java.util.EventListener;
import java.util.Observer;
import javax.swing.table.AbstractTableModel;

/**
 *
 * @author schueler
 */
public class SalaryTableModel extends AbstractTableModel implements Observer{
    private final String[] headers = new String[] {"month","hours","salary"};
    private Database db;
    private static final long serialVersionUID = 3L;
    
    /*******************************************************************/
    public interface OnExceptionTableModelListener extends EventListener {
        void handleTableModelException(EventCellException event);
    }
    
    private OnExceptionTableModelListener listener = null;
    public void addOnExceptionTableModelListener (OnExceptionTableModelListener listener){
        this.listener = listener;
    }
    
    
    public SalaryTableModel() {
        this.db = Database.getNewInstance();
    }

    
    @Override
    public boolean isCellEditable(int row, int column) {
        if(column == 2)
            return false;
        return true;
    }
    
    @Override
    public String getColumnName(int col) {
        return headers[col];
    }    
    
    @Override
    public int getRowCount() {
        if(this.db.getSelectedDriver() == null)
            return 0;
        return this.db.getSelectedDriver().getNumberOfSalaryEntrys();
    }

    @Override
    public int getColumnCount() {
        return headers.length;
    }
    
    @Override   
    public Object getValueAt(int rowIndex, int columnIndex) {
        try{
            return this.getSalaryEntryAttributes(this.db.getSelectedDriver(), rowIndex, columnIndex);
        }catch(Exception Ex){
            if(listener != null)
                listener.handleTableModelException(new EventCellException(this,"Error at getValue:  " + Ex.getMessage()));
        }
        return null;
    }
    
    @Override 
    public void setValueAt(Object value, int row, int col) {
	
        try{
            this.setSalaryEntryAttributes(value,this.db.getSelectedDriver(), row, col);
        }catch(Exception Ex){
            if(listener != null)
                listener.handleTableModelException(new EventCellException(this,"Error at getValue:  " + Ex.getMessage()));
        }
        
    }
    
    public Log getLogAtRow(int row) throws Exception{
        try {
            String date = (String)this.getValueAt(row,1);
            Car car = this.db.getCarAtName((String)this.getValueAt(row,2));
            int NrJourneys = (Integer)this.getValueAt(row,3);
            return new Log(date,NrJourneys,car);
        
        } catch (Exception e) {
            throw new Exception("no Log selected: " + e.getMessage());
        }
    }

    @Override
    public void update(java.util.Observable o, Object event) {
        if(event.getClass() == EventSalaryChanged.class)
            this.fireTableDataChanged();
    }
    
    
    
    
    //*******************Private methods
    
    private Object getSalaryEntryAttributes(Driver driver, int rowIndex, int columnIndex) throws Exception{
        if(driver == null)
            throw new Exception("No Driver selected");
        SalaryEntry sal = null;
        try {
            sal = driver.getSalWithRowNumber(rowIndex);
        } catch (Exception ex) {
            throw new Exception("error:" + ex.getMessage());
        }
        Object result = null;
            switch(columnIndex) {
                    case 0:
                            result = sal.getMonthAsString();
                    break;
                    case 1:
                            result = sal.getTotalHours();
                    break;
                    case 2:
                            result =  sal.getTotalSalaryAsString();
                    break;
            }
	return result;
    }
    
    private void setSalaryEntryAttributes(Object value,Driver driver,int row,int col) throws Exception{
        if(driver == null)
            throw new Exception("No Driver selected");
        SalaryEntry sal = null;
        try {
            sal = driver.getSalWithRowNumber(row);
            driver.deleteSal(sal);
        } catch (Exception ex) {
            throw new Exception("error:" + ex.getMessage());
        }
        try{
            switch(col) {
                case 0:
                    ArrayList<String> months = SalaryEntry.getAllMonths();
                    int res = months.indexOf(value);
                    sal.setMonth(res);
                break;
                case 1:
                    sal.setTotalHours((int) value);
                    this.fireTableDataChanged();
                break;

            }
            driver.addSalaryEntry(sal);
        }catch(Exception Ex){
            driver.addSalaryEntry(sal);
            throw new Exception("wrong input :" + Ex.getMessage());
        }
        
    }
    
    @Override
    public Class<?> getColumnClass(int c) {
        Class<?> retvalue = "x".getClass();
        if(this.getValueAt(0, c) != null && c>0){
            retvalue = this.getValueAt(0, c).getClass();
        }
        return retvalue;
    }    
    
    
    //*******************
    
    
}
