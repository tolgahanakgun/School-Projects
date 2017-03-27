package TextSources;

import java.io.IOException;
import java.util.ArrayList;

public interface MultipleTextSourceInterface {
	public ArrayList<ArrayList<String>> getContent(ArrayList<String> sources) throws IOException;
}
