package supermarket;

public class TestAppl {

	private static Trolly t1_small = null, t3_medium = null, t5_big = null;

	public static void main(String[] args) {
		initStuff();
                printSortedByName();
                printSortedByNameReverse();
                printSortedByPriceName();
                printSortedByPriceNameReverse();
                printSortedByDayWeight();
                printSortedByDayWeightReverse();
	}

        public static void printSortedByName() {
            System.out.println("************** by name *****************");
            t1_small.sortTrolly(EnumThingSort.BY_NAME, false);
            printTrolly(t1_small);
            t3_medium.sortTrolly(EnumThingSort.BY_NAME, false);
            printTrolly(t3_medium);
            t5_big.sortTrolly(EnumThingSort.BY_NAME, false);
            printTrolly(t5_big);
        }
        public static void printSortedByNameReverse() {
            System.out.println("************** by name reverse *****************");
            t1_small.sortTrolly(EnumThingSort.BY_NAME, true);
            printTrolly(t1_small);
            t3_medium.sortTrolly(EnumThingSort.BY_NAME, true);
            printTrolly(t3_medium);
            t5_big.sortTrolly(EnumThingSort.BY_NAME, true);
            printTrolly(t5_big);
        }
        public static void printSortedByPriceName() {
            System.out.println("************** by price, name *****************");
            t1_small.sortTrolly(EnumThingSort.BY_PRICE_NAME, false);
            printTrolly(t1_small);
            t3_medium.sortTrolly(EnumThingSort.BY_PRICE_NAME, false);
            printTrolly(t3_medium);
            t5_big.sortTrolly(EnumThingSort.BY_PRICE_NAME, false);
            printTrolly(t5_big);
        }
        public static void printSortedByPriceNameReverse() {
            System.out.println("************** by price, name reverse *****************");
            t1_small.sortTrolly(EnumThingSort.BY_PRICE_NAME, true);
            printTrolly(t1_small);
            t3_medium.sortTrolly(EnumThingSort.BY_PRICE_NAME, true);
            printTrolly(t3_medium);
            t5_big.sortTrolly(EnumThingSort.BY_PRICE_NAME, true);
            printTrolly(t5_big);
        }
        public static void printSortedByDayWeight() {
            System.out.println("************** by day, weight *****************");
            t1_small.sortTrolly(EnumThingSort.BY_DAY_WEIGHT, false);
            printTrolly(t1_small);
            t3_medium.sortTrolly(EnumThingSort.BY_DAY_WEIGHT, false);
            printTrolly(t3_medium);
            t5_big.sortTrolly(EnumThingSort.BY_DAY_WEIGHT, false);
            printTrolly(t5_big);
        }
        public static void printSortedByDayWeightReverse() {
            System.out.println("************** by day, weight reverse *****************");
            t1_small.sortTrolly(EnumThingSort.BY_DAY_WEIGHT, true);
            printTrolly(t1_small);
            t3_medium.sortTrolly(EnumThingSort.BY_DAY_WEIGHT, true);
            printTrolly(t3_medium);
            t5_big.sortTrolly(EnumThingSort.BY_DAY_WEIGHT, true);
            printTrolly(t5_big);
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
		t1_small.addThing(new LightThing("Salamiwurst", 2, 13, "2012-12-24"));
	}

	private static void fillTrollyMedium() {
		t3_medium.addThing(new LightThing("Leberwurst", 13, 10, "2012-12-11"));
		t3_medium.addThing(new HeavyThing("Bierkiste", 2, 20, 12));
		t3_medium.addThing(new LightThing("Semmel", 13, 10, "2012-11-30"));
	}


	private static void fillTrollyBig() {
		t5_big.addThing(new LightThing("Leberwurst", 13, 10, "2016-10-15"));
		t5_big.addThing(new HeavyThing("Bierkiste", 2, 20, 22));
		t5_big.addThing(new LightThing("Semmel", 13, 10, "2016-06-27"));
		t5_big.addThing(new HeavyThing("Erdaepfelkiste", 2, 20, 12));
	}


	private static void printTrolly(Trolly tr) {
		System.out.println(tr);
		for (Thing th = tr.getFirst(); th != null; th = tr.getNext()) {
			System.out.println("   - " + th);
		}
	}

}
