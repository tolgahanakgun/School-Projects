package LanguageIdentifier;

import java.util.ArrayList;

public class LanguageFactory {

	private ArrayList<AbstractLanguages> langs;

	public LanguageFactory(ArrayList<AbstractLanguages> langs) {
		this.langs = langs;
	}

	public ArrayList<AbstractLanguages> allLanguages() {
		ArrayList<AbstractLanguages> arrayList = new ArrayList<>();
		arrayList.add(new Turkish());
		arrayList.add(new English());
		arrayList.add(new German());
		return arrayList;
	}

	public boolean addLanguage(String languageName) {
		if (languageName.equals("Turkish")) {
			addIfNotExist(languageName);
			return true;
		}
		if (languageName.equals("English")) {
			addIfNotExist(languageName);
			return true;
		}
		if (languageName.equals("German")) {
			addIfNotExist(languageName);
			return true;
		}
		return false;
	}

	private void addIfNotExist(String language) {
		for (AbstractLanguages abstractLanguages : langs) {
			if (abstractLanguages.getClass().getSimpleName().equals(language)) {
				return;
			}
		}
		try {
			langs.add(
					(AbstractLanguages) Class.forName(language).newInstance());
		} catch (InstantiationException e) {
			e.printStackTrace();
		} catch (IllegalAccessException e) {
			e.printStackTrace();
		} catch (ClassNotFoundException e) {
			e.printStackTrace();
		}
	}

	public boolean removeLanguage(String language) {
		for (AbstractLanguages abstractLanguages : langs) {
			if (abstractLanguages.getClass().getSimpleName().equals(language)) {
				langs.remove(langs.indexOf(abstractLanguages));
				return true;
			}
		}
		return false;
	}

	public ArrayList<String> listAllAvailableLanguage() {
		ArrayList<String> availableLanguages = new ArrayList<>();
		for (AbstractLanguages abstractLanguages : langs) {
			availableLanguages
					.add(abstractLanguages.getClass().getSimpleName());
		}
		return availableLanguages;
	}
}