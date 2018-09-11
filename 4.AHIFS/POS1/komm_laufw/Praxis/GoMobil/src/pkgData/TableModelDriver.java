/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgData;

import java.time.LocalDate;
import java.util.EventListener;
import java.util.Observable;
import java.util.Observer;
import javax.swing.table.AbstractTableModel;
import pkgMisc.EventCellException;

/**
 *
 * @author savan_000
 */
public class TableModelDriver extends AbstractTableModel implements Observer {

    private static final long serialVersionUID = 1L;
    private final String[] columnNames;
    private Database db;
    OnExceptionInTableModelListener listener=null;

    public TableModelDriver(){
        super();
        this.columnNames = new String[]{"id", "name", "birth", "hireBegin", "hireeEnd"};
        this.db = Database.newInstance();   
        
        db.addObserver(this);
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
    public Object getValueAt(int row, int col) {
        Driver d = getDriverAtRow(row);
	Object returnvalue = null;
	switch(col){
            case 0: 
    		returnvalue = d.getId();
    		break;
            case 1: 
		returnvalue = d.getName();
		break;
            case 2: 
		returnvalue = d.getBirth();
		break;	
            case 3: 
		returnvalue = d.getHireBegin();
		break;
            case 4: 
		returnvalue = d.getHireEnd();
		break;	
	}		
	
        return returnvalue;
    }
    
    
    @Override
    public String getColumnName(int col){
	return columnNames[col];
    }
	
    @Override
    public Class<?> getColumnClass(int col){
	return getValueAt(0,col).getClass();
    }
    

    @Override
    public boolean isCellEditable(int row,int col){
	boolean retValue = false;
	if(col >=1){
		retValue=true;
	}
	return retValue;
    }
	
    @Override
    public void setValueAt(Object value, int row, int col){
        LocalDate ld;
        Driver d;
        try{
            d = getDriverAtRow(row);
            if(d!=null){
            
                switch(col){
                    case 1: 
                        d.setName(value.toString());
                        break;
                    case 2: 
                        ld = LocalDate.parse(value.toString());
                        d.setBirth(ld);
                        break;	
                    case 3: 
                        d.setHireBegin(value.toString());
                        break;
                    case 4: 
                        d.setHireEnd(value.toString());
                        break;	
                }
              //  fireTableCellUpdated(row,col);
              this.fireTableDataChanged();
                if(listener!=null){
                   // this.fireTableDataChanged();
                        listener.handleTableModelException(new EventCellException(this,"update of cell is doc"));
                }
            }
        
        }	
        
        catch(Exception ex){
            if(listener !=null){
                listener.handleTableModelException(new EventCellException(this,"error" +ex.getMessage()));
            }
        }
    }
    
    
    public void addDriver(Driver d) throws Exception{
        db.addDriver(d); 
    }
    public Driver getDriverAtRow(int row){
	return db.getDriverWithRowNumber(row);
    }

    @Override
    public void update(Observable o, Object o1) {
        this.fireTableDataChanged();    
        if(listener !=null){
            listener.handleTableModelException(new EventCellException(this,"data changed:"));
        }
    }
    
    public interface OnExceptionInTableModelListener extends EventListener{
        void handleTableModelException(EventCellException event);
    }
    
    public void addOnExceptionInTableModelListener(OnExceptionInTableModelListener listener){
        this.listener = listener;
    }
}
