import java.util.Comparator;


public class SoccerAppl {
	final private static Database db = new Database();;
	public static void main(String[] args) {
		String userInput = " ";
		String com = " ";
		Parser p = new Parser();
		
		do{
			try {
				Gui.printMenue();
				userInput = Gui.getInput();
				com = p.getCommand(userInput);
				switch(com){
				case "load":
					break;
				case "add":
					break;
				case "list":
					break;
				
				}
				
				
			} catch (Exception e) {
				System.out.println("error: " + e.getMessage());
			}
		}
		while(com != "quit");
		
		
		
	}
	private static void printTeamsAlternate(){
		db.alternateSort(new AlternateComparator());
		for(Team t : db.getTeams()){
			System.out.println(t);
		}
	}
	private static void printTeams(){
		db.defaultSort();
		for(Team t : db.getTeams()){
			System.out.println(t);
		}
	}
	private static void readingTextFile(String _filename){
		ReaderTextFile fileReader = null;
		try {
			fileReader = new ReaderTextFile(_filename);
			fileReader.open();
			String line = fileReader.readLine();
			 while(line != null){
				//System.out.println("adding " + line);
				db.addResult(line);
				line = fileReader.readLine();
			}
			fileReader.close();
		}
		catch(Exception x){
			x.printStackTrace();
		}
	}
}
