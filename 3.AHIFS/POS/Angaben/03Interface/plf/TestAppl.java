/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/**
 *
 * @author Gerald
 */
public class TestAppl {
    private static final String TEXTFILENAME = "script.txt";
    private static AnalyserTextFile atf = null;

    public static void main(String[] args) {
        try {
            initATF();
            sortBy(EnumSortBy.BY_NAME);
            sortBy(EnumSortBy.BY_COUNT_NAME);
            sortBy(EnumSortBy.BY_NAME_REVERSE);
            sortBy(EnumSortBy.BY_COUNT_NAME_REVERSE);
        } catch (Exception exception) {
            System.out.println("error in main: " + exception.getMessage());
            exception.printStackTrace();
        }
    }

    private static void sortBy(EnumSortBy crit) {
        try {
            atf.sortBy(crit);
            CollectionEntry ce = atf.getFirst();
            System.out.println("************ sort " + crit + " ***********");
            while (ce != null) {
                System.out.println(ce);
                ce = atf.getNext();
            }
        } catch (Exception ex) {
            System.out.println("error in sortBy: " + ex.getMessage());
        }

    }
 
       private static void initATF() throws Exception {
            atf = new AnalyserTextFile(TEXTFILENAME);
            atf.fillCollection();
       }
}
