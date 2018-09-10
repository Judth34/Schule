/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */


import java.awt.Color;
import java.awt.GridLayout;
import java.awt.List;
import java.awt.Rectangle;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextField;

public class ApplPoker extends JFrame implements ActionListener, IApplPoker{

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
    private JTextField txtName = null;
    private JButton btnRound1 = null;
    private JButton btnRound2 = null;
    private JButton btnNextPlayer = null;
    //private JButton btnReset = null;
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
            jContentPane.add(getTxtName(), null);
            jContentPane.add(getBtnRound1(), null);
            jContentPane.add(getBtnRound2(), null);
            jContentPane.add(getBtnNextPlayer(), null);
            //jContentPane.add(getBtnReset(), null);
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
    private JTextField getTxtName() {
        if (txtName == null) {
        	txtName = new JTextField();
        	txtName.setBounds(new Rectangle(74, 76, 153, 20));
        	txtName.setText("name of player");
        }
        return txtName;
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
            btnRound2.setEnabled(false);
        }
        return btnRound2;
    }
    private JButton getBtnNextPlayer() {
        if (btnNextPlayer == null) {
        	btnNextPlayer = new JButton();
            btnNextPlayer.setBounds(new Rectangle(73, 180, 107, 29));
            btnNextPlayer.setText("next player");
            btnNextPlayer.addActionListener(this);
            btnNextPlayer.setEnabled(true);
        }
        return btnNextPlayer;
    }
    
//    private JButton getBtnReset() {
//        if (btnReset == null) {
//        	btnReset = new JButton();
//        	btnReset.setBounds(new Rectangle(135, 150, 107, 29));
//        	btnReset.setText("reset");
//        	btnReset.addActionListener(this);
//        }
//        return btnReset;
//    }

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
		for(Dice d : arrDice)
			d.setPoints();
		btnRound1.setEnabled(false);
		btnRound2.setEnabled(true);
		btnNextPlayer.setEnabled(false);
    }

    private void diceRound2() {
    	if(txtFix.getText().isEmpty()) {
    		diceRound1();
    	}
    	else {
    		for(int idx = 0; idx < arrDice.length; idx++) {
    			if(!isDiceFixed(idx))
    				arrDice[idx].setPoints();
    		}
    	}
    	arrLabel[currentRound].setText(Integer.valueOf(getSum()).toString());
    	currentRound++;
    	lblMessage.setText("dice round " + (currentRound + 1));
    	btnRound1.setEnabled(true);
    	btnRound2.setEnabled(false);
    	btnNextPlayer.setEnabled(true);
    	
    	if(currentRound >= 5) {
    		int sum = getTotalSum();    	
    		lblMessage.setText("Total sum is " + sum);
    		btnRound1.setEnabled(false);
    	}
    }

    private int getSum() {
		int sum = 0;
		for(Dice d : arrDice)
			sum += d.numberOfPoints;
        return sum;
    }

    private boolean isDiceFixed(int _dice) {
    	boolean result = false;
    	
    	String[] splittedStringArr = txtFix.getText().split(",");
    	int[] fixedDiceIndex = new int[splittedStringArr.length];
    	for(int idx = 0; idx < splittedStringArr.length; idx++)
    		fixedDiceIndex[idx] = Integer.parseInt(splittedStringArr[idx]);
    	for(int i : fixedDiceIndex) {
    		if(i - 1 == _dice)
    			result = true;
    	}

        return result;
    }
    
//    private void reset() {
//    	currentRound = 0;
//    	for(JLabel jl : arrLabel) 
//    		jl.setText(Integer.valueOf(0).toString());
//    	for(Dice d : arrDice) {
//    		d.numberOfPoints = 0;
//    		d.repaint();
//    	}
//    	lblMessage.setText("dice round 1");
//    	txtFix.setText("");
//    	btnRound2.setEnabled(false);
//    	btnRound1.setEnabled(true);
//    }

    @Override
    public void actionPerformed(ActionEvent e) {
        try {
            if (e.getSource() == this.btnRound1) {
                this.diceRound1();
            } else
            if (e.getSource() == this.btnRound2) {
                this.diceRound2();
            }
            else
                if (e.getSource() == this.btnNextPlayer) {
                    PokerController.newInstance().setNextPlayer();
                }
//            if(e.getSource() == this.btnReset) {
//            	this.reset();
//            }
        }
        catch(Exception ex) {
            lblMessage.setText("error: " + ex.getMessage());
        }
    }

	@Override
	public String getNameOfPlayer() {
		return txtName.getText();
	}

	@Override
	public int getTotalScoreOfPlayer() {
		return getTotalSum();
	}
	private int getTotalSum()
	{
		int result = 0;
		for(JLabel jl : arrLabel) 
			result += Integer.parseInt(jl.getText());
		return result;
	}
	@Override
	public void setEnablePlayer(boolean value) {
		if(currentRound < 5)
		{
			btnRound1.setEnabled(value);
			btnRound2.setEnabled(value);
			btnNextPlayer.setEnabled(value);
		}
	}
	

}  //  @jve:decl-index=0:visual-constraint="10,10"
