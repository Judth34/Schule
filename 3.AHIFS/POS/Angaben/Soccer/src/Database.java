import java.util.Comparator;
import java.util.TreeSet;


public class Database {
	private TreeSet<Team> ts;
	
	public Database() {
		super();
		ts = new TreeSet<>();
	}
	public void addResult(String _textline){
		String[] splitted = _textline.split("(\\-)|(\\,)|(\\:)");
		updateTeam(splitted[0], Integer.parseInt(splitted[2]), Integer.parseInt(splitted[3]));
		updateTeam(splitted[2], Integer.parseInt(splitted[3]), Integer.parseInt(splitted[2]));
	}
	private void updateTeam(String name, int goalsShot, int goalsGot){
		Team newTeam = new Team(name, goalsShot, goalsGot);
		int points;
		if(goalsShot == goalsGot){
			points = 1;
		}
		else if(goalsShot<goalsGot){
			points = 0;
		}
		else{
			points = 3;
		}
		if(ts.contains(newTeam)){
			Team actualTeam = ts.ceiling(newTeam);
			actualTeam.setGoalsGot(actualTeam.getGoalsGot() + goalsGot);
			actualTeam.setGoalsShot(actualTeam.getGoalsShot() + goalsShot);
			actualTeam.setPoints(actualTeam.getPoints() + points);
		}
		else{
			newTeam.setPoints(points);
			ts.add(newTeam);
		}
	}
	public void alternateSort(Comparator<Team> _comparator){
		TreeSet<Team> newts = new TreeSet<>(_comparator);
		for(Team t : ts){
			newts.add(t);
		}
		ts = newts;
	}
	public void defaultSort(){
		TreeSet<Team> newts = new TreeSet<>();
		for(Team t : ts){
			newts.add(t);
		}
		ts = newts;
	}
	public TreeSet<Team> getTeams(){
		return ts;
	}

}
