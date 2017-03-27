package TextSources;

import java.io.IOException;
import java.net.URL;
/**
 * This interface can be used in strategy patterns later for different internet
 * sites. A dependent class to this interface, can decide and assign different
 * internet site adapter which implements this interface according to the URL's
 * site. In the program it is assumed that all the links come from Wikipedia and
 * no need for creating a class which can create different strategy for
 * different URL sources.
 */
public interface InternetSiteAdapterStrategyInterface {
	public String getContent(URL url) throws IOException;
}
