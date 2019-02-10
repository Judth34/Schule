package pkgCalc;

import java.awt.Dimension;
import java.awt.GridLayout;
import java.util.Observable;
import java.util.Observer;

import javax.swing.JButton;
import javax.swing.JPanel;

public class ControllerCalc extends JPanel implements Observer {

    public ControllerCalc(ViewCalc view, ModelCalc model) {
        super();
        initialize();
        this.view = view;
        this.model = model;
    }

    @Override
    public void update(Observable o, Object arg) {

    }

    /**
     * This method initializes btnPlus
     *
     * @return javax.swing.JButton
     */
    private JButton getBtnPlus() {
        if (btnPlus == null) {
            btnPlus = new JButton();
            btnPlus.setText("+");
            btnPlus.addActionListener((java.awt.event.ActionEvent e) -> {
                model.setNumber1(view.getNumber1());
                model.setNumber2(view.getNumber2());
                model.calcSum();
            });
        }
        return btnPlus;
    }

    /**
     * This method initializes btnMinus
     *
     * @return javax.swing.JButton
     */
    private JButton getBtnMinus() {
        if (btnMinus == null) {
            btnMinus = new JButton();
            btnMinus.setText("-");
            btnMinus.addActionListener((java.awt.event.ActionEvent e) -> {
                model.setNumber1(view.getNumber1());
                model.setNumber2(view.getNumber2());
                model.calcMinus();
            });
        }
        return btnMinus;
    }
    /**
     * This method initializes this
     */
    private void initialize() {
        setSize(new Dimension(100, 240));
        GridLayout gridLayout = new GridLayout();
        gridLayout.setRows(4);
        gridLayout.setVgap(20);
        gridLayout.setHgap(20);
        setLayout(gridLayout);
        setBackground(new java.awt.Color(255, 204, 204));
        add(getBtnMinus(), null);
        add(getBtnPlus(), null);
    }

 /**
 * GUI attributes
 */
    private JButton btnPlus = null;
    private JButton btnMinus = null;

    /**
     * non GUI components
     */
    private final static long serialVersionUID = 0;

    private ViewCalc view = null;
    private ModelCalc model = null;

}  //  @jve:decl-index=0:visual-constraint="10,10"
