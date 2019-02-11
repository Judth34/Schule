/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Misc;

import Data.Database;
import Data.Driver;
import java.util.EventListener;
import java.util.Observer;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.table.AbstractTableModel;

/**
 *
 * @author schueler
 */
public class DriverTableModel extends AbstractTableModel implements Observer{
    private final String[] headers = new String[] {"ID","Name","Birthdate","Hire Begin","Hire End"};
    private Database db;
    private static final long serialVersionUID = 1L;
    
    /*******************************************************************/
    public interface OnExceptionTableModelListener extends EventListener {
        void handleTableModelException(EventCellException event);
    }
    
    private OnExceptionTableModelListener listener = null;
    public void addOnExceptionTableModelListener (OnExceptionTableModelListener listener){
        this.listener = listener;
    }
    
    /*******************************************************************/
    
    public DriverTableModel(Database db) {
        this.db = db;
    }

    
    @Override
    public boolean isCellEditable(int row, int column) {
            boolean res = false;
            if(column > 0)
                    res = true;
            return res;
    }
    
    @Override
    public String getColumnName(int col) {
        return headers[col];
    }    
    
    @Override
    public int getRowCount() {
        return db.getNumberOfDrivers();
    }

    @Override
    public int getColumnCount() {
        return headers.length;
    }
    
    @Override   
    public Object getValueAt(int rowIndex, int columnIndex) {
        Driver driver = db.getDriverWithRowNumber(rowIndex);
            Object result = null;
		switch(columnIndex) {
			case 0:
				result = driver.getId();
                        break;
			case 1:
				result = driver.getName();
                        break;
			case 2:
				result = driver.getBirthdate();
			break;
                        case 3:
				result = driver.getHireBegin();
			break;
                        case 4:
				result = driver.getHireEnd();
			break;
		}
	return result;
	}
    
    @Override 
    public void setValueAt(Object value, int row, int col) {
		
        Driver driver = this.db.getDriverWithRowNumber(row);
        try {
            this.db.DeleteDriver(driver);
        } catch (Exception ex) {
            Logger.getLogger(DriverTableModel.class.getName()).log(Level.SEVERE, null, ex);
        }
        try{
          
            switch(col) {
                case 0:
                        driver.setId(Integer.parseInt(value.toString()));
                break;
                case 1:
                        driver.setName(value.toString());
                break;
                case 2:
                        driver.setBirthdate((String)value);
                break;
                case 3:
                        driver.setHireBegin((String)value);
                break;
                case 4:
                        driver.setHireEnd((String)value);
                break;
            }
            this.db.addDriver(driver);
            this.fireTableDataChanged();
        }
        catch(Exception err){
            if(listener != null){
            this.db.addDriver(driver);
               listener.handleTableModelException(new EventCellException(this,"Wrong value! please enter a valid value"));
            }
        }
    }
    
    
    
    public Driver getDriverAtRow(int row) throws Exception{
        try {
            return this.db.getDriverWithRowNumber(row);
        
        } catch (Exception e) {
            throw new Exception("no driver selected: " + e.getMessage());
        }
    }

    @Override
    public void update(java.util.Observable o, Object event) {
        if(event.getClass() == EventDriverChanged.class)
            this.fireTableDataChanged();
    }   
}
