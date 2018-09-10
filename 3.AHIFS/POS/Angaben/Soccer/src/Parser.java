
public class Parser {
	
	public String getCommand(String userinput) throws Exception{
		String[] UIarray = userinput.split(" ");
		String command = UIarray[0];
		boolean isCommand = false;
		for(EnumCommand ec: EnumCommand.values()){
			if(ec.toString().compareToIgnoreCase(command) == 0){
				isCommand = true;
			}
			if(isCommand && command == "list"){
				if(UIarray[1].compareToIgnoreCase("-name") != 0 &&
					UIarray[1].compareToIgnoreCase("-points") != 0){
					throw new Exception(UIarray[1] + " != -name or -points");
				}
			}
		}
		if(!isCommand){
			throw new Exception(userinput + " Is not a valid command");
		}
		
		return command;
	}
	
	public String getParametersOfCommand(String userinput){
		return userinput;
		
	}

}
