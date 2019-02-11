/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Misc;

import java.awt.Color;
import java.awt.Component;
import javax.swing.JTable;
import javax.swing.table.DefaultTableCellRenderer;
import javax.swing.table.TableCellRenderer;

/**
 *
 * @author schueler
 */
public class CellRendererJourneys extends DefaultTableCellRenderer {

    @Override
    public Component getTableCellRendererComponent(JTable table, Object value, boolean isSelected, boolean hasFocus, int row, int column) {
        Component c = super.getTableCellRendererComponent(table, value, isSelected, hasFocus, row, column);
        int journeys = (int) value;
        if(journeys == 0)
            c.setBackground(Color.red);
        else if(journeys > 0 && journeys <=100)
            c.setBackground(Color.orange);
        else if(journeys >100)
            c.setBackground(Color.green);
        return c;
    }

    
    
    
}
