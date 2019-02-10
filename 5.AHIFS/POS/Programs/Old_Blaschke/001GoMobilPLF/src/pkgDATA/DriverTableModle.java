/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgDATA;

import java.time.LocalDate;
import java.util.EventListener;
import java.util.Observable;
import java.util.Observer;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.swing.table.AbstractTableModel;

/**
 *
 * @author schueler
 */



public class DriverTableModle extends AbstractTableModel implements Observer{
    private final String[] columnNames = {"id", "Name", "Birth", "Hire Begin", "Hire End"};
    Database db;
/***********************************/
public interface OnExceptionInTableModelListener extends EventListener{
    void handleTableModelException(EventCellException event);
}
private OnExceptionInTableModelListener listener = null;
public void addOnExceptionTableModelListener(OnExceptionInTableModelListener listener){
    this.listener = listener;
}
 /***********************************/
   
    public DriverTableModle(Database db) {
        this.db = db;
    }
    
    @Override
    public int getRowCount() {
        return db.getNumberOfDrivers();
    }
    
    @Override
    public int getColumnCount() {
        return columnNames.length;
    }

    @Override
    public Object getValueAt(int rowIndex, int columnIndex) {
        Object result = null;
        try {
            Driver d = db.getDriverWithRowNumber(rowIndex);
            switch (columnIndex){
                case 0:
                    result = d.getId();
                    break;
                case 1:
                    result = d.getName();
                    break;
                case 2:
                    result = d.getBirth();
                    break;
                case 3:
                    result = d.getHireBegin();
                    break;
                case 4:
                    result = d.getHireEnd();
                    break;
            }
            
        } catch (Exception ex) {
            Logger.getLogger(DriverTableModle.class.getName()).log(Level.SEVERE, null, ex);
        }
        return result;
    }
    
    @Override
    public String getColumnName(int col){
        return this.columnNames[col];
    }
    
    @Override
    public boolean isCellEditable(int row, int column) {
            boolean res = false;
            if(column >= 1)
                    res = true;
            return res;
    }
        
    @Override
    public void setValueAt(Object value, int row, int col){
        try {
            Driver d = db.getDriverWithRowNumber(row);
            switch(col){
            case 0: 
                d.setId(Integer.parseInt(value.toString()));
                break;
            case 1:
                d.setName(value.toString());
                break;
            case 2:
                d.setBirth(value.toString());
            case 3:
                d.setHireBegin(value.toString());
                break;
            case 4:
                d.setHireEnd(value.toString());
                break;
            }
            db.deleteDriver(d);
            db.addDriver(d);
        } catch (Exception ex) {
            if(listener != null){
                listener.handleTableModelException(new EventCellException(this, "wrong val"));
            }
        }
    }

    @Override
    public void update(Observable o, Object arg) {
        if(arg != null && arg.getClass() == EventDriverChanged.class){
            this.fireTableDataChanged();
        }
    }
}
