package TextSources;

import java.io.IOException;
import java.util.ArrayList;

public interface SingleTextSourceInterface {
	public ArrayList<String> getText(String source) throws IOException;
}