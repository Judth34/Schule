/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkgDATA;

import java.util.EventListener;
import java.util.Observable;
import java.util.Observer;
import javax.swing.table.AbstractTableModel;

/**
 *
 * @author schueler
 */
public class JourneyTableModle extends AbstractTableModel implements Observer{
    private final String[] columnNames = {"starttime", "endtime", "startposition", "endposition", "# passengers"};
    Database db;
    
    //*************
    
    public interface OnEventCellExceptionListener{
        public void handleEventCellException(EventCellException ex);
    }
    
    private OnEventCellExceptionListener listener = null;
    
    public void addOnEventCellExceptionListener (OnEventCellExceptionListener listener){
        this.listener = listener;
    }
    
    //*************
    
    public JourneyTableModle(Database db) {
        this.db = db;
    }
    
    @Override
    public int getRowCount() {
        if(db.getSelectedLogbook() == null)
            return 0;
        return db.getSelectedLogbook().getSizeOfCollJourneys();
    }

    @Override
    public int getColumnCount() {
        return columnNames.length;
    }

    @Override
    public Object getValueAt(int rowIndex, int columnIndex) {
        Object result = null;
        try{
        Journey j = db.getSelectedLogbook().getJourneyWithRowNumber(rowIndex);
        switch (columnIndex){
            case 0:
                result = j.getSartTime();
                break;
            case 1:
                result = j.getEndTime();
                break;
            case 2: 
                result = j.getStartposition();
                break;
            case 3:
                result = j.getEndposition();
                break;
            case 4:
                result = j.getNumberOfPassenger();
                break;
        }
        }catch(Exception ex){
                  ex.printStackTrace();
        }
        return result;    
    }

    @Override
    public void setValueAt(Object aValue, int rowIndex, int columnIndex) {
        try {
            Journey j = db.getSelectedLogbook().getJourneyWithRowNumber(rowIndex);
            switch(columnIndex){
            case 0:
                j.setSartTime(aValue.toString());
                break;
            case 1:
                j.setEndTime(aValue.toString());
                break;
            case 2: 
                j.setStartposition(aValue.toString());
                break;
            case 3:
                j.setEndposition(aValue.toString());
                break;
            case 4:
                j.setNumberOfPassenger((int)aValue);
                break;
            }
            db.getSelectedLogbook().deleteJourney(j);
            db.getSelectedLogbook().addJourney(j);
            this.fireTableDataChanged();
        } catch (Exception ex) {
            if(listener != null){
                listener.handleEventCellException(new EventCellException(this, "Wrong value!"));
            }
        }
    }

    @Override
    public String getColumnName(int column) {
        return columnNames[column];
    }

    @Override
    public boolean isCellEditable(int rowIndex, int columnIndex) {
        boolean res = false;
            if(columnIndex >=0)
                    res = true;
            return res;
    }

    @Override
    public void update(Observable o, Object arg) {
        if(arg != null && arg.getClass() == EventJourneyChanged.class){
            this.fireTableDataChanged();
        }
    }
}
