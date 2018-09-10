
public class TestAppl {

	private static Trolly t1_small = null, t3_medium = null, t5_big = null;

	public static void main(String[] args) {
		initStuff();
		testIsInTrolly();
		testRemove();
		testGain();
	}

	private static void testIsInTrolly() {
		System.out.println("\n--------test is in trolly---------------");
		System.out.println("true=>"
				+ t1_small.isInTrolly(new LightThing("Leberwurst", 3, 10,
						"2099-12-01")));
		System.out.println("true=>"
				+ t1_small.isInTrolly(new LightThing("Metwurst", 4, 22,
						"2012-12-02")));
		System.out.println("true=>"
				+ t1_small.isInTrolly(new LightThing("Salamiwurst", 44, 13,
						"2012-12-06")));
		System.out.println("false=>"
				+ t1_small.isInTrolly(new LightThing("Kaeswurs", 5, 12,
						"2012-12-03")));
		System.out.println("false=>"
				+ t1_small.isInTrolly(new HeavyThing("Kaeswurst", 5, 12, 44)));
		System.out.println("\n--------end test is in trolly---------------");
	}

	private static void testRemove() {
		System.out.println("\n--------test remove from trolly---------------");
		System.out.println("-------------------- remove Leberwurst");
		t1_small.removeThing(new LightThing("Leberwurst"));
		if (t1_small.getErrorMessage() != null)
			System.out.println("***** error with remove: "
					+ t1_small.getErrorMessage());
		printTrolly(t1_small);
		System.out.println("-------------------- remove not existing Kaeswurs");
		t1_small.removeThing(new LightThing("Kaeswurs"));
		if (t1_small.getErrorMessage() != null)
			System.out.println("***** error with remove: "
					+ t1_small.getErrorMessage());
		printTrolly(t1_small);
		System.out.println("-------------------- remove Kaeswurst");
		t1_small.removeThing(new LightThing("Kaeswurst"));
		if (t1_small.getErrorMessage() != null)
			System.out.println("***** error with remove: "
					+ t1_small.getErrorMessage());
		printTrolly(t1_small);
		System.out.println("-------------------- remove Salamiwurst");
		t1_small.removeThing(new LightThing("Salamiwurst"));
		if (t1_small.getErrorMessage() != null)
			System.out.println("***** error with remove: "
					+ t1_small.getErrorMessage());
		printTrolly(t1_small);
		System.out.println("-------------------- remove Metwurst");
		t1_small.removeThing(new LightThing("Metwurst"));
		if (t1_small.getErrorMessage() != null)
			System.out.println("***** error with remove: "
					+ t1_small.getErrorMessage());
		printTrolly(t1_small);
		System.out.println("-------------------- remove again Metwurst");
		t1_small.removeThing(new LightThing("Metwurst"));
		if (t1_small.getErrorMessage() != null)
			System.out.println("***** error with remove: "
					+ t1_small.getErrorMessage());
		printTrolly(t1_small);
		System.out
				.println("--------end test remove from trolly---------------");

	}
	private static void testGain() {
		fillTrollySmall();
		System.out.println("\n--------test gain---------------");
		printTrolly(t1_small);
		System.out.println(t1_small.calculateGain());
		printTrolly(t3_medium);
		System.out.println(t3_medium.calculateGain());
		printTrolly(t5_big);
		System.out.println(t5_big.calculateGain());
		System.out.println("--------end test gain---------------");
	}

	/**
	 * methods already known
	 */
	private static void initStuff() {
		generateTrollies();
		fillTrollySmall();
		fillTrollyMedium();
		fillTrollyBig();
	}

	private static void generateTrollies() {
		t1_small = new Trolly(EnumTrolly.SMALL);
		t3_medium = new Trolly(EnumTrolly.MEDIUM);
		t5_big = new Trolly(EnumTrolly.BIG);
	}

	private static void fillTrollySmall() {
		t1_small.addThing(new LightThing("Leberwurst", 3, 10, "2012-12-01"));
		t1_small.addThing(new LightThing("Metwurst", 4, 11, "2012-12-02"));
		t1_small.addThing(new LightThing("Kaeswurst", 5, 12, "2016-10-25"));
		t1_small.addThing(new LightThing("Salamiwurst", 2, 13, "2012-12-06"));
	}

	private static void fillTrollyMedium() {
		t3_medium.addThing(new LightThing("Leberwurst", 13, 10, "2012-12-01"));
		t3_medium.addThing(new HeavyThing("Bierkiste", 2, 20, 12));
		t3_medium.addThing(new LightThing("Semmel", 13, 10, "2012-11-30"));
	}


	private static void fillTrollyBig() {
		t5_big.addThing(new LightThing("Leberwurst", 13, 10, "2016-10-25"));
		t5_big.addThing(new HeavyThing("Bierkiste", 2, 20, 12));
		t5_big.addThing(new LightThing("Semmel", 13, 10, "2016-10-27"));
		t5_big.addThing(new HeavyThing("Erdaepfelkiste", 2, 20, 12));
	}


	private static void printTrolly(Trolly tr) {
		System.out.println(tr);
		for (Thing th = tr.getFirst(); th != null; th = tr.getNext()) {
			System.out.println("   - " + th);
		}
	}

}
