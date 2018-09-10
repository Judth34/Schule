
public class HeavyThing extends Thing{
	int weight;

	public HeavyThing() {
		this(null,0,0,65);
	}

	public HeavyThing(String name, int qty, int price, int weight) {
		super(name, qty, price);
		this.weight = weight;
	}

	@Override
	public String toString() {
		return super.toString()+"weight "+weight;
	}	
	
	@Override
	public boolean equals(Object o){
		return this.getClass().getName()==o.getClass().getName() && ((Thing)o).name==this.name;
	}
}

