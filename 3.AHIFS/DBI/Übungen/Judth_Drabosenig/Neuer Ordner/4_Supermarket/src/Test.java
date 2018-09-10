public class Test {
static int field[];
public static void main(String args[]) {
for (int i=-1;i<4;i++) {
try {
System.out.println(1/i);	//Arithmetic Exception division by 0
if (i==2)
field[0]=1;
System.out.println("i="+i+"...in try");
}//end try
catch (java.lang.ArithmeticException e) {
System.out.println("attention:"+e);
System.out.println("i="+i+"...in catch");
}//end catch
catch (Exception e) {
System.out.println("general exception:"+e);
}//end catch
finally {
System.out.println("i="+i+"...in finally");
}
System.out.println("i="+i+"...extern try");
}//end for
}//end main
}//end class
