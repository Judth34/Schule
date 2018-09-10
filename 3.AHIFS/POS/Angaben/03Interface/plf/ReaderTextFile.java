
import java.io.BufferedReader;
import java.io.FileReader;
import java.util.ArrayList;

/**
 * very sophisticated and runtime efficient reader of text files
 *
 * @author Gerald
 *
 */
public class ReaderTextFile {

    private String filename = null;
    private FileReader fr = null;
    private BufferedReader br = null;
    private ArrayList<String> collWords = null;

    public ReaderTextFile(String filename) {
        this.filename = filename;
        collWords = new ArrayList();
    }

    /**
     * to avoid exceptions this should be your first call
     *
     * @throws Exception...eg. if file doesn't exist
     */
    public void open() throws Exception {
        fr = new FileReader(filename);
        br = new BufferedReader(fr);
    }

    /**
     * to be smart call this after last reading
     *
     * @throws Exception
     */
    public void close() throws Exception {
        br.close();
        fr.close();
    }

    /**
     * reads given textfile and stores words in collection
     *
     * @throws Exception
     */
    public void parseFile() throws Exception {
        String line;
        while ((line = readLine()) != null) {
            addWords(line);
        }
    }
    /**
     * 
     * @return ... number of words in textfile (after parseFile())
     */
    public int getNumberOfWords(){
        return collWords.size();
    }

    /**
     * 
     * @param position ... position in collection of words;
     *                     valid between 0 and getNumberOfWords - 1
     * @return ... word on that position
     * @throws Exception 
     */
    public String getWord(int position) throws Exception {
        return collWords.get(position);
    }
    /**
     * 
     * @return ... array of words (not sorted; duplicate words possible)
     */
    public String[] getArrayOfWords() {
        return collWords.toArray(new String[0]);
    }
    /**
     *
     * @return ...next line of text (or null)
     * @throws Exception...eg. reading from nirwana
     */
    private String readLine() throws Exception {
        return br.readLine();
    }

    /**
     * add words into string-array
     *
     * @param words ... line of words
     */
    private void addWords(String words) {
        String[] s = words.split("[ .,]");

        for (String item : s) {
            if (item.length() > 1) {
                collWords.add(item);
            }
        }

    }

    public String getFilename() {
        return filename;
    }

    public void setFilename(String filename) {
        this.filename = filename;
    }

    @Override
    public String toString() {
        return "ReaderTextFile [filename=" + filename + "]";
    }

}
