package pkgCalc;

import java.util.Observable;

public class ModelCalc extends Observable {
	private int number1=0, number2=0, result=0;

	public int getNumber1() {
		return number1;
	}

	public void setNumber1(int number1) {
		this.number1 = number1;
	}

	public int getNumber2() {
		return number2;
	}

	public void setNumber2(int number2) {
		this.number2 = number2;
	}

	public int getResult() {
		return result;
	}
	/*******business logic**********/
	public void calcSum() {
		result = number1 + number2;
		this.setChanged();
		this.notifyObservers("sum was calculated");
	}
	public void calcMinus() {
		result = number1 - number2;
		this.setChanged();
		this.notifyObservers("minus was calculated");
	}
	
}
