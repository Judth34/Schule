

public class Thing {
	String name;
	int qty;
	int price;
	
	public Thing(String name, int qty, int price) {
		super();
		this.name = name;
		this.qty = qty;
		this.price = price;
	}

	public Thing() {
		super();
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public int getQty() {
		return qty;
	}

	public void setQty(int qty) {
		this.qty = qty;
	}

	public int getPrice() {
		return price;
	}

	public void setPrice(int price) {
		this.price = price;
	}
	
	@Override
	public boolean equals(Object o){
		
		return this.getClass().getName().equals(o.getClass().getName())
				&& ((Thing)o).name.equals(this.name);
	}

	@Override
	public String toString() {
		return "Thing [name=" + name + ", qty=" + qty + ", price=" + price
				+ "]";
	}
	
	
}
