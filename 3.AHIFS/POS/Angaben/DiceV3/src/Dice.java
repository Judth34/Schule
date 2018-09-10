

import java.awt.Color;
import java.awt.Component;
import java.awt.Graphics;

/**
 * zeichnet einen Wuerfel
*
 */
public class Dice extends Component {

    /**
     *
     */
    private static final long serialVersionUID = 1L;
    private static final int widthPoint = 8;
    int numberOfPoints = 0; //how many points should be shown


    public Dice() {

    }

    /**
     * set random number of points and immediately draw them
*
     */
    public void setPoints() {
        this.numberOfPoints = ((int) (Math.random() * 6) + 1);
        this.repaint();
    }
    

    public int getPoints() {
        return (this.numberOfPoints);
    }

    /**
     * redraw dice
*
     */
    public void paint(Graphics g) {
        super.paint(g);
        g.setColor(Color.gray);           //grey dice
        g.fill3DRect(5, 5, 40, 40, true);
        g.setColor(Color.blue);           //blue points
        switch (numberOfPoints) {
            case 1:
                g.fillArc(21, 21, widthPoint, widthPoint, 0, 360);
                break;
            case 2:
            	g.fillArc(12, 12, widthPoint, widthPoint, 0, 360);
            	g.fillArc(30, 30, widthPoint, widthPoint, 0, 360);
            	break;
            case 3:
            	g.fillArc(12, 12, widthPoint, widthPoint, 0, 360);
                g.fillArc(21, 21, widthPoint, widthPoint, 0, 360);
            	g.fillArc(30, 30, widthPoint, widthPoint, 0, 360);
            	break;
            case 4:
            	g.fillArc(12, 12, widthPoint, widthPoint, 0, 360);
            	g.fillArc(30, 12, widthPoint, widthPoint, 0, 360);
            	g.fillArc(12, 30, widthPoint, widthPoint, 0, 360);
            	g.fillArc(30, 30, widthPoint, widthPoint, 0, 360);
            	break;
            case 5:
            	g.fillArc(12, 12, widthPoint, widthPoint, 0, 360);
            	g.fillArc(30, 12, widthPoint, widthPoint, 0, 360);
                g.fillArc(21, 21, widthPoint, widthPoint, 0, 360);
            	g.fillArc(12, 30, widthPoint, widthPoint, 0, 360);
            	g.fillArc(30, 30, widthPoint, widthPoint, 0, 360);
            	break;
            case 6:
            	g.fillArc(12, 12, widthPoint, widthPoint, 0, 360);
            	g.fillArc(30, 12, widthPoint, widthPoint, 0, 360);
                g.fillArc(12, 21, widthPoint, widthPoint, 0, 360);
                g.fillArc(30, 21, widthPoint, widthPoint, 0, 360);
            	g.fillArc(12, 30, widthPoint, widthPoint, 0, 360);
            	g.fillArc(30, 30, widthPoint, widthPoint, 0, 360);
            	break;
        }
    }
}
