/**
 * @author or
 */
public class TestAppl {
	static private Pupil p1 = null, p2 = null, p3 = null, p4 = null, p5 = null, p6 = null;
	static private Bus b1 = null, b2 = null;
	static private Ferry f1 = null, f2 = null;

	public static void main(String[] args) {
		generatePersons();
		fillCarrier();
		getPassengers(b1);
		getPassengers(f1);
		getPassengers(b2);
		getPassengers(f2);
	}

	static private void generatePersons() {
		System.out.println("------------ generating persons -----------------");
		p1 = generatePupil("Onestone O.", "1993-02-14");
		p2 = generatePupil("Twostone T.", "1992-04-05");
		p3 = generatePupil("Fourstone F.", "1999-12-31");
		p4 = generatePupil("Fivestone F.", "1991-01-31");
		p3 = generatePupil("Six", "1991-12-31");
		p5 = generatePupil("Threestone", "1933-12-31");
		p6 = generatePupil("Twostone T.", "1992-04-05");
	}

	static private void fillCarrier() {
		System.out.println("------------ fill carriers -----------------");
		b1 = new Bus("Ro 80", 3);
		b2 = new Bus("Isetta", 4);
		f1 = new Ferry("Queen Lizzy", 3);
		f2 = new Ferry("Queen Mary", 100);

		fillCarrierWithPerson(b1, p1);
		fillCarrierWithPerson(b1, p2);
		fillCarrierWithPerson(b1, p3);
		fillCarrierWithPerson(b1, p6);
		fillCarrierWithPerson(b1, p5);

		fillCarrierWithPerson(f1, p1);
		fillCarrierWithPerson(f1, p2);
		fillCarrierWithPerson(f1, p5);
		fillCarrierWithPerson(f1, p4);
	}

	static private Pupil generatePupil(String _name, String _bdate) {
		Pupil returnPupil = null;
		try {
			returnPupil = new Pupil(_name, _bdate);
		} catch (Exception _ipex) {
			System.out.println("Exception happened in generatePupil(): "
					+ _ipex.getMessage());
		}
		return returnPupil;
	}

	static private void fillCarrierWithPerson(Carrier _c, Person _p) {
		try {
			_c.add(_p);
		} catch (Exception _ibex) {
			System.out.println("Exception happened in fillBusWithPerson(): "
					+ _ibex);
		}
	}

	static private void getPassengers(Carrier _carrier) {
		System.out.println("--------list ---------" + _carrier);
		try {
			Person xy = _carrier.getFirst();
			while (xy != null) {
				System.out.println(xy);
				xy = _carrier.getNext();
			}
		} catch (Exception _ibex) {
			System.out.println("Exception happened in getPassengers(): "
					+ _ibex);
		}
		System.out.println("-----------------");
	}
}
