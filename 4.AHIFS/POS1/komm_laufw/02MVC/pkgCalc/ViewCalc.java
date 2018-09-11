package pkgCalc;

import java.awt.Color;
import java.awt.Dimension;
import java.awt.GridLayout;
import java.awt.Rectangle;
import java.util.Observable;
import java.util.Observer;

import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextField;

public class ViewCalc extends JPanel implements Observer {

    /**
     * This method initializes
     *
     */
    public ViewCalc() {
        super();
        initialize();
    }
    @Override
    public void update(Observable o, Object arg) {
        ModelCalc _model = (ModelCalc) o;
        txtResult.setText(Integer.toString(_model.getResult()));
        lblMessage.setText(arg.toString());
    }
    public int getNumber1() {
        return Integer.parseInt(txtNumber1.getText());
    }

    public int getNumber2() {
        return Integer.parseInt(txtNumber2.getText());
    }

    /**
     * unimportant methods
     */
    /**
     * This method initializes this
     *
     */
    private void initialize() {
        setLayout(null);
        setSize(new Dimension(248, 226));
        setBackground(new java.awt.Color(204, 255, 0));
        lblMessage = new JLabel();
        lblMessage.setBounds(new Rectangle(20, 210, 234, 15));
        lblMessage.setBackground(Color.orange);
        lblMessage.setText("...");
        lblMessage.setOpaque(true);
        add(getPaneText(), null);
        add(lblMessage, null);
    }


    /**
     * This method initializes paneText
     *
     * @return javax.swing.JPanel
     */
    private JPanel getPaneText() {
        if (paneText == null) {
            lblResult = new JLabel();
            lblResult.setText("result");
            lblNumber2 = new JLabel();
            lblNumber2.setText("number-2");
            lblNumber1 = new JLabel();
            lblNumber1.setText("number-1");
            GridLayout gridLayout1 = new GridLayout();
            gridLayout1.setRows(3);
            paneText = new JPanel();
            paneText.setLayout(gridLayout1);
            paneText.setBounds(new Rectangle(20, 20, 235, 186));
            paneText.add(lblNumber1, null);
            paneText.add(getTxtNumber1(), null);
            paneText.add(lblNumber2, null);
            paneText.add(getTxtNumber2(), null);
            paneText.add(lblResult, null);
            paneText.add(getTxtResult(), null);
        }
        return paneText;
    }

    /**
     * This method initializes txtNumber1
     *
     * @return javax.swing.JTextField
     */
    private JTextField getTxtNumber1() {
        if (txtNumber1 == null) {
            txtNumber1 = new JTextField();
            txtNumber1.setText("0");
            txtNumber1.setHorizontalAlignment(JTextField.RIGHT);
        }
        return txtNumber1;
    }

    /**
     * This method initializes txtNumber2
     *
     * @return javax.swing.JTextField
     */
    private JTextField getTxtNumber2() {
        if (txtNumber2 == null) {
            txtNumber2 = new JTextField();
            txtNumber2.setText("0");
            txtNumber2.setHorizontalAlignment(JTextField.RIGHT);
        }
        return txtNumber2;
    }

    /**
     * This method initializes txtResult
     *
     * @return javax.swing.JTextField
     */
    private JTextField getTxtResult() {
        if (txtResult == null) {
            txtResult = new JTextField();
            txtResult.setText("--");
            txtResult.setHorizontalAlignment(JTextField.RIGHT);
        }
        return txtResult;
    }

    /**
     * GUI attributes
     */
    private final static long serialVersionUID = 0;
    private JPanel paneText = null;
    private JLabel lblNumber1 = null;
    private JTextField txtNumber1 = null;
    private JLabel lblNumber2 = null;
    private JTextField txtNumber2 = null;
    private JLabel lblResult = null;
    private JTextField txtResult = null;
    private JLabel lblMessage = null;

}  //  @jve:decl-index=0:visual-constraint="22,6"
