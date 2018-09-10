/**
 * @author  or
 */
public abstract class Carrier {
	protected int MAX=0;

	protected String type = null;
	protected Person passengers[] = null;
	protected int  numberOfPersons=0;

	private int  currentPerson=-1;			//current Person (for getNext())

	public Carrier (String _type, int _MAX) {
		type = _type;
		MAX = _MAX;
		passengers = new Person[MAX];
	}
	public abstract boolean add(Person _p)  throws InvalidCarrierException;
	public abstract boolean delete(Person _p)  throws InvalidCarrierException;
	public String toString() {
		return getClass().getName() + ": " + type;
	}
	public Person getFirst()  throws InvalidCarrierException {
		Person returnPerson = null;
		if (numberOfPersons>0) {
			currentPerson=0;
			returnPerson=passengers[currentPerson];
		}
		else
			throw new InvalidCarrierException("carrier has no passengers");

		return returnPerson;
	}

	public Person getNext() {
		Person returnPerson = null;
		currentPerson++;
		if (numberOfPersons>0 && currentPerson<numberOfPersons) {
			returnPerson=passengers[currentPerson];
		}
		return returnPerson;
	}	
	protected boolean isPassenger(Person _p) {
		boolean isPassenger = false;
		
		for (int i=0; i<numberOfPersons && !isPassenger; i++) {
			if (passengers[i].compareTo(_p) == 0) 
				isPassenger = true;
		}
		
		return isPassenger;
	}

}
