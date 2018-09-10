import java.io.BufferedReader;
import java.io.InputStreamReader;


public class Gui {
	static public void printMenue(){
		System.out.println("************************************************");
		System.out.println("* load <filename> ... load teams and results   *");
		System.out.println("* add <team1-team2,goal1:goal2> ... add result *");
		System.out.println("* list {-name | -points} ... list order by	   *");
		System.out.println("* quit ... end of app						   *");
		System.out.println("************************************************");
		System.out.print("===>");
	}
	
	static public String getInput() throws Exception{
		String retString;
		InputStreamReader isr = new InputStreamReader(System.in);
		BufferedReader keyboard = new BufferedReader(isr);
		retString = keyboard.readLine();
		return retString;
	}
}
