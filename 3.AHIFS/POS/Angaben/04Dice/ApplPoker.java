/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package dice01;

import java.awt.Color;
import java.awt.GridLayout;
import java.awt.Rectangle;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextField;

public class ApplPoker extends JFrame implements ActionListener{

    private static final long serialVersionUID = 1L;
    private JPanel jContentPane = null;
    private JPanel panelDice = null;

    /* other properties */
    private static final int MAXDICE = 5;
    private static final int MAXLABEL = 5;
    private int currentRound = 0;
    private final Dice arrDice[] = new Dice[MAXDICE];
    private final JLabel arrLabel[] = new JLabel[MAXLABEL];
    private JLabel lblMessage = null;
    private JLabel lblFix = null;
    private JTextField txtFix = null;
    private JButton btnRound1 = null;
    private JButton btnRound2 = null;
    private JPanel panelResult = null;

    /**
     * This is the default constructor
     */
    public ApplPoker() {
        super();
        initNonGUI();
        initialize();
    }

    private void initNonGUI() {
        for (int i = 0; i < MAXDICE; i++) {
            arrDice[i] = new Dice();
        }
        for (int i = 0; i < MAXLABEL; i++) {
            arrLabel[i] = new JLabel("0");
            arrLabel[i].setBackground(Color.yellow);
            arrLabel[i].setOpaque(true);
        }

    }

    /**
     * This method initializes this
     *
     * @return void
     */
    private void initialize() {
        this.setSize(372, 340);
        this.setContentPane(getJContentPane());
        this.setTitle("Poker V1");
        this.setDefaultCloseOperation(DISPOSE_ON_CLOSE);
    }

    /**
     * This method initializes jContentPane
     *
     * @return javax.swing.JPanel
     */
    private JPanel getJContentPane() {
        if (jContentPane == null) {
            lblFix = new JLabel();
            lblFix.setBounds(new Rectangle(73, 13, 152, 22));
            lblFix.setText("fix (#,#, ...):");
            lblMessage = new JLabel();
            lblMessage.setBounds(new Rectangle(5, 274, 327, 25));
            lblMessage.setBackground(Color.orange);
            lblMessage.setText("dice round 1 ");
            lblMessage.setOpaque(true);
            jContentPane = new JPanel();
            jContentPane.setLayout(null);
            jContentPane.setBackground(Color.lightGray);
            jContentPane.add(lblMessage, null);
            jContentPane.add(getPanelDice(), null);
            jContentPane.add(lblFix, null);
            jContentPane.add(getTxtFixieren(), null);
            jContentPane.add(getBtnRound1(), null);
            jContentPane.add(getBtnRound2(), null);
            jContentPane.add(getPanelResult(), null);
        }
        return jContentPane;
    }

    /**
     * This method initializes panelDice
     *
     * @return javax.swing.JPanel
     */
    private JPanel getPanelDice() {
        if (panelDice == null) {
            GridLayout gridLayout = new GridLayout();
            gridLayout.setRows(5);
            gridLayout.setColumns(1);
            panelDice = new JPanel();
            panelDice.setLayout(gridLayout);
            panelDice.setBounds(new Rectangle(10, 14, 51, 239));
            for (int i = 0; i < MAXDICE; i++) {
                panelDice.add(arrDice[i]);
            }
        }
        return panelDice;
    }

    /**
     * This method initializes txtFix
     *
     * @return javax.swing.JTextField
     */
    private JTextField getTxtFixieren() {
        if (txtFix == null) {
            txtFix = new JTextField();
            txtFix.setBounds(new Rectangle(74, 46, 153, 20));
        }
        return txtFix;
    }

    /**
     * This method initializes btnRound1
     *
     * @return javax.swing.JButton
     */
    private JButton getBtnRound1() {
        if (btnRound1 == null) {
            btnRound1 = new JButton();
            btnRound1.setBounds(new Rectangle(73, 222, 107, 29));
            btnRound1.setText("round 1");
            btnRound1.addActionListener(this);
        }
        return btnRound1;
    }

    /**
     * This method initializes btnRound2
     *
     * @return javax.swing.JButton
     */
    private JButton getBtnRound2() {
        if (btnRound2 == null) {
            btnRound2 = new JButton();
            btnRound2.setBounds(new Rectangle(189, 220, 99, 32));
            btnRound2.setText("round 2");
            btnRound2.addActionListener(this);
        }
        return btnRound2;
    }

    /**
     * This method initializes panelResult
     *
     * @return javax.swing.JPanel
     */
    private JPanel getPanelResult() {
        if (panelResult == null) {
            GridLayout gridLayout1 = new GridLayout();
            gridLayout1.setRows(5);
            gridLayout1.setColumns(1);
            panelResult = new JPanel();
            panelResult.setLayout(gridLayout1);
            panelResult.setBounds(new Rectangle(295, 16, 57, 235));
            for (int i = 0; i < MAXDICE; i++) {
                panelResult.add(arrLabel[i]);
            }
        }
        return panelResult;
    }

    private void diceRound1() {
		//	...do it yourself
    }

    private void diceRound2() {
		//	...do it yourself
    }

    private int getSum() {
		//	...do it yourself
        return -99;
    }

    private boolean isDiceFixed(int _dice) {
		//	...do it yourself

        return false;
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        try {
            if (e.getSource() == this.btnRound1) {
                this.diceRound1();
            } else
            if (e.getSource() == this.btnRound2) {
                this.diceRound2();
            }
        }
        catch(Exception ex) {
            lblMessage.setText("error: " + ex.getMessage());
        }
    }

}  //  @jve:decl-index=0:visual-constraint="10,10"
