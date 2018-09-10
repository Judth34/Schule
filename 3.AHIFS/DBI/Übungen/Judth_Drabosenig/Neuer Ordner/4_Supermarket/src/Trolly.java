import java.time.LocalDate;
import java.time.format.DateTimeFormatter;


public class Trolly {
	static final int MAX=10;
	Thing[] arrThings;
	EnumTrolly type;
	String errorMessage=null;
	int currentThing=0;
	int counter=0;
	
	public Trolly(EnumTrolly type) {
		super();
		generateArrThings();
		this.type = type;
	}
	
	public int getTotalQty()
	{
		int result=-1;
		
		if(counter < MAX){
			result=counter;
		}
		else{
			errorMessage="The current number of 'Things' is higher than MAX";
		}
		return result;
	}
	
	public int getTotalPrice(){
		int totalPrice=0;
		int idx=0;
		
		if(counter<MAX){
			for(idx=0;idx < counter&& arrThings[idx] != null;idx++){
				totalPrice=totalPrice +arrThings[idx].price;
			}
		}
		else{
			errorMessage="There are no things in this Trolly";
		}
		
		return totalPrice;
	}
	
	public void addThing(Thing newThing){
		if(counter<MAX ){
			if(newThing.getClass().getName() == "HeavyThing"||newThing.getClass().getName() == "LightThing"){
				arrThings[counter]=newThing;
				counter++;
			}
		}
		else{
			errorMessage="You can not initialize an object named 'Thing'";
		}
		
	}
	
	public String getErrorMessage() {
		return errorMessage;
	}
	
	public Thing getFirst(){
		currentThing=0;
		return arrThings[0];
	}
	
	public Thing getNext(){
		currentThing++;
		return arrThings[currentThing];
	}
	
	private void generateArrThings(){
		arrThings=new Thing[MAX];
	}
	
	private int getNumberOfThingsOfSpecifiedType(Thing thing){
		int idx=0;
		
		for(int i=0;i<counter;i++){
			if((thing.getClass().getName() == "HeavyThing")&&(arrThings[i].getClass().getName() =="HeavyThing")){
				idx++;
			}
			else if((thing.getClass().getName().equals("LightThing"))&&(arrThings[i].getClass().getName().equals("LightThing"))){
				idx++;
			}
			else{
				errorMessage="You can't count 'Things'";
			}
		}
		
		return idx;
	}	
	
	@Override
	public String toString() {
		return "Trolly is "+type+" with " + getNumberOfThingsOfSpecifiedType(new LightThing())
				+" different light things "+getNumberOfThingsOfSpecifiedType(new HeavyThing())
				+" different heavy things]";
		
	}
	
	public boolean isInTrolly(Thing t){
		boolean result=false;
		
		for(int i=0;i<counter;i++)
		{
			if(arrThings[i].equals(t)){
				result = true;
			}
		}
		return result;
	}
	
	void removeThing(Thing t){
		int idx=0;
		errorMessage=null;
		boolean found=false;
		
		if(isInTrolly(t)){
			for(int i=0;arrThings[i]!=null && found==false;i++)
			{
				if(arrThings[i].equals(t)){
					idx=i;
					while(idx<(counter-1)){
						arrThings[idx]=arrThings[idx+1];
						idx++;
						found=true;
					}
					counter=counter-1;
					arrThings[counter]=null;
				}
			}
		}
		else{
			errorMessage="Thing not found in Trolly";
		}
	}

	public String calculateGain(){
		String result="";
		int countHt= getNumberOfThingsOfSpecifiedType(new HeavyThing());
		String day=LocalDate.now().getDayOfWeek().toString();
		
		if(countHt<=1){
			for(int i=0; i < counter ;i++){
				if(arrThings[i].getClass().getName().equals("LightThing")){
					String dayBestbefore=((LightThing)arrThings[i]).getBestbefore().format(DateTimeFormatter.ofPattern("EEEE"));
					if(day .equals(dayBestbefore.toUpperCase())){
						result="YOU WON! today is "+day+", supermarket.LightThing: "+arrThings[i].toString()+ " and "+ countHt +" heavy things";
					}
				}
				else{
					result="today is "+day+", nothing appropriate in trolly ";
				}
			
			}
		}
		else{
			result="today is "+day+", nothing appropriate in trolly an "+countHt+" heavy things";
		}
		return result;
	}		
}
	


