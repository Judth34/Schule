
public class Team implements Comparable<Team>{
	private String name;
	private int points;
	private int goalsShot;
	private int goalsGot;
	public Team(String name, int goalsShot, int goalsGot) {
		super();
		this.name = name;
		this.goalsShot = goalsShot;
		this.goalsGot = goalsGot;
	}
	public Team(String name) {
		super();
		this.name = name;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public int getPoints() {
		return points;
	}
	public void setPoints(int points) {
		this.points = points;
	}
	public int getGoalsShot() {
		return goalsShot;
	}
	public void setGoalsShot(int goalsShot) {
		this.goalsShot = goalsShot;
	}
	public int getGoalsGot() {
		return goalsGot;
	}
	public void setGoalsGot(int goalsGot) {
		this.goalsGot = goalsGot;
	}
	@Override
	public String toString() {
		return "Team [name=" + name + ", points=" + points + ", goalsShot="
				+ goalsShot + ", goalsGot=" + goalsGot + "]";
	}
	@Override
	public int compareTo(Team t){
		return getName().compareTo(t.getName());
	}

}
