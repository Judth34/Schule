package pkgDATA;

import java.util.EventListener;
import java.util.Observable;
import java.util.Observer;
import javax.swing.table.AbstractTableModel;


public class LogbookTableModle extends AbstractTableModel implements Observer{
    private final String[] columnNames = {"date", "car", "# of journeys"};
    Database db;

    
    
    public interface OnExceptionInTableModelListener extends EventListener{
        void handleTableModelException(EventCellException event);
    }
    private OnExceptionInTableModelListener listener = null;
    public void addOnExceptionTableModelListener(OnExceptionInTableModelListener listener){
        this.listener = listener;
    }

    public LogbookTableModle(Database db) {
        this.db = db;
    }
    
    @Override
    public int getRowCount() {
        if(db.getSelectedDriver() == null)
            return 0;
        return db.getSelectedDriver().getNumberOfLogbooks();
    }

    @Override
    public int getColumnCount() {
        return columnNames.length;
    }

    @Override
    public Object getValueAt(int rowIndex, int columnIndex) {
        Object result = null;
        try{
        Logbook l = db.getSelectedDriver().getLogbookWithRowNumber(rowIndex);
        switch (columnIndex){
            case 0:
                result = l.getDate();
                break;
            case 1:
                result = l.getCar().toString();
                break;
            case 2: 
                result = l.getNumberOfJourneys();
                break;
            
        }
        }catch(Exception ex){
            if(listener!=null){
               listener.handleTableModelException(new EventCellException(this, "wrong val"));
            }        
        }
        return result;    
    }
    
    @Override
   public Class <?> getColumnClass(int c){
	Class<?> retValue = "x".getClass();
        
	//do not do it with date-type
	//because cell would be not editable
	if(getValueAt(0, c) != null && c > 0){
		retValue = getValueAt(0,c).getClass();
        }
        return retValue;
    }


    @Override
    public void setValueAt(Object aValue, int rowIndex, int columnIndex) {
        try {
            Logbook l = db.getSelectedDriver().getLogbookWithRowNumber(rowIndex);
            switch(columnIndex){
            case 0: 
                l.setDate(aValue.toString());
                break;
            case 1:
                l.setCar((Car)aValue);
                break;
            case 2:
                l.setNumberOfJourneys(Integer.parseInt(aValue.toString()));
            }
            db.getSelectedDriver().deleteLogbook(l);
            db.getSelectedDriver().addLogbook(l);
        } catch (Exception ex) {
            if(listener!=null){
               listener.handleTableModelException(new EventCellException(this, "wrong val"));
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
        if(arg != null && arg.getClass() == EventLogBookChanged.class)
            this.fireTableDataChanged();
    }
}
