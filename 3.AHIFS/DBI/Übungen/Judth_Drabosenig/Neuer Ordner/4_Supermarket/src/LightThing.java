import java.time.LocalDate;
import java.time.format.DateTimeFormatter;


public class LightThing extends Thing{
	LocalDate bestbefore;

	public LightThing() {
		this(null,0,0,"2000-01-05");
	}
	
	public LightThing(String name){
		this.name=name;
	}

	public LightThing(String name, int qty, int price, String bestbefore) {
		super(name, qty, price);
		this.bestbefore= LocalDate.parse(bestbefore);
	}

	@Override
	public String toString() {
		return super.toString() +"bestbefore " + bestbefore.format(DateTimeFormatter.ofPattern("EEEE, dd MMM y"));
	}
	
	@Override
	public boolean equals(Object o){
		return this.getClass().getName()==o.getClass().getName() && ((Thing)o).name==this.name;
	}
	
	public LocalDate getBestbefore() {
		return bestbefore;
	}
}
