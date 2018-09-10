import java.util.Comparator;


public class AlternateComparator implements Comparator<Team> {

	@Override
	public int compare(Team t1, Team t2) {
		int retValue = t1.getPoints()-t2.getPoints();
		if(retValue == 0){
			retValue = t1.getName().compareToIgnoreCase(t2.getName());
		}
		return retValue;
	}

}
